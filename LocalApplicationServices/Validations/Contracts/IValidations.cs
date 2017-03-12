namespace LocalApplicationServices.Validations
{
    using Models;

    public interface IValidations<T>
    {
        T ValidateLogin(T loginModel);
    }
}
