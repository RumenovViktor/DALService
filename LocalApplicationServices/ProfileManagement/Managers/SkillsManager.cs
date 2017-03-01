namespace LocalApplicationServices
{
    using System.Linq;
    using System.Collections.Generic;

    using ApplicationServices;
    using Models;
    using Data.Unit_Of_Work;

    public class SkillsManager : Base, ISkillsManager
    {
        public SkillsManager(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public IList<SkillsDto> GetMatchedSkills(string name)
        {
                var matchedSkills = dalServiceData.Skills.All()
                                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                    .ToList()
                                    .Select(x => new SkillsDto(x.SkillId, x.Name));

            return matchedSkills.ToList();
        }
    }
}
