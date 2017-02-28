namespace LocalApplicationServices.Validations
{
    using System;
    using Models;
    using Data.Unit_Of_Work;

    public class CompanyValidations : Base, ICompanyValidations
    {
        public CompanyValidations(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public CompanyLogin ValidateCompanyLogin(CompanyLogin companyLoginModel)
        {
            var company = dalServiceData.Companies.FindEntity(x => x.Name == companyLoginModel.CompanyName && x.Password == companyLoginModel.Password);
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
