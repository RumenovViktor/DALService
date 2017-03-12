namespace LocalApplicationServices.Validations
{
    using Models;
    using Data.Unit_Of_Work;

    public class UserValidations : Base, IValidations<UserLogin>
    {
        public UserValidations(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public UserLogin ValidateLogin(UserLogin loginModel)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            if (user != null)
            {
                return new UserLogin()
                {
                    UserId = user.UserId,
                    DoesUserExists = true
                };
            }

            return new UserLogin()
            {
                DoesUserExists = false
            };
        }
    }
}
