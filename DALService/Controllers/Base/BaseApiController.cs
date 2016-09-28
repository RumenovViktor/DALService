namespace DALService.Controllers
{
    using System.Web.Http;

    using Data.Unit_Of_Work;

    public class BaseApiController : ApiController
    {
        #region Private Members

        protected readonly IDALServiceData m_Data;

        #endregion

        #region Ctor(s)

        protected BaseApiController(IDALServiceData data)
        {
            m_Data = data;
        }

        #endregion

        #region Protected Methods

        #endregion
    }
}
