namespace LocalApplicationServices.Validations
{
    using System;
    using Models;
    using Data.Unit_Of_Work;

    public class CompanyValidations : Base, IValidations<CompanyLogin>
    {
        public CompanyValidations(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public CompanyLogin ValidateLogin(CompanyLogin loginModel)
        {
            var company = dalServiceData.Companies.FindEntity(x => x.Name == loginModel.CompanyName && x.Password == loginModel.Password);
            var doesCompanyExist = company != null;

            if (doesCompanyExist)
            {
                var existingCompany = new CompanyLogin(doesCompanyExist);
                existingCompany.CompanyId = company.Id;

                return existingCompany;
            }

            return new CompanyLogin(doesCompanyExist);
        }
    }
}
