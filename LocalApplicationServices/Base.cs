using Data.Unit_Of_Work;

namespace LocalApplicationServices
{
    public class Base
    {
        protected readonly IDALServiceData dalServiceData;

        protected Base(IDALServiceData dalServiceData)
        {
            this.dalServiceData = dalServiceData;
        }
    }
}
