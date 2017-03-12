namespace Executors
{
    using System.Linq;
    using System.Collections.Generic;

    using DTOs.Models;
    using Data.Unit_Of_Work;
    using Models.Profile;
    using Models;

    public class UserMatchingExecutor : MatchingExecutor<User, UserSuitiblePosition>
    {
        public UserMatchingExecutor(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public override IList<UserSuitiblePosition> Match(User currentUser, int? sectorId, int? countryId)
        {
            var matchedPositions = new List<UserSuitiblePosition>();

            var allPositions = FilterPositions(sectorId, countryId);

            foreach (var position in allPositions)
            {
                var positionRequiredSkills = position.RequiredSkills.Count;
                var userSkills = currentUser.Skills.Count;

                var skillMatchInPercentage = positionRequiredSkills != 0 ? (userSkills / positionRequiredSkills) * TotalPercentage : TotalPercentage;
                var fixedPercentage = skillMatchInPercentage > TotalPercentage ? TotalPercentage : skillMatchInPercentage;

                var matchedPercentage = fixedPercentage / Avarage;

                matchedPositions.Add(
                    new UserSuitiblePosition(position.CompanyId, position.Id, position.Company.Name, position.PositionName, matchedPercentage));
            }

            return matchedPositions.OrderByDescending(x => x.MatchPersentage).Take(12).ToList();
        }

        private IList<Position> FilterPositions(int? sectorId, int? countryId)
        {
            if (sectorId.HasValue && countryId.HasValue)
            {
                return dalServiceData.Positions.All()
                    .Where(x => x.Company.Sectors.Select(t => t.Id).ToList().Contains(sectorId.Value) && x.Company.CountryId == countryId.Value)
                    .ToList();
            }

            if (sectorId.HasValue)
            {
                return dalServiceData.Positions.All().Where(x => x.Company.Sectors.Select(t => t.Id).ToList().Contains(sectorId.Value)).ToList();
            }

            if (countryId.HasValue)
            {
                return dalServiceData.Positions.All().Where(x => x.Company.CountryId == countryId.Value).ToList();
            }

            return dalServiceData.Positions.All().ToList();
        }
    }
}
