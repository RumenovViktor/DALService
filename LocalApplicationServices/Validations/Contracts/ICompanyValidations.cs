namespace LocalApplicationServices.Validations
{
    using Models;

    public interface ICompanyValidations
    {
        CompanyLogin ValidateCompanyLogin(CompanyLogin companyLoginModel);
    }
}
