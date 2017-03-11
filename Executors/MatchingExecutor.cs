namespace Executors
{
    using Data.Unit_Of_Work;
    using System.Collections.Generic;

    public abstract class MatchingExecutor<TLoggedEntity, TMatched>
    {
        protected const byte Avarage = 1;
        protected const decimal TotalPercentage = 100;

        protected IDALServiceData dalServiceData;

        public MatchingExecutor(IDALServiceData dalServiceData)
        {
            this.dalServiceData = dalServiceData;
        }

        public abstract IList<TMatched> Match(TLoggedEntity currentUser, int? sectorId, int? countryId);
    }
}
