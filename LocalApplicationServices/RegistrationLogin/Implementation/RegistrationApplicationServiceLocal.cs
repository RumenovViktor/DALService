namespace LocalApplicationServices
{
    using Models;
    using Data.Unit_Of_Work;
    using DTOs.Models;
    using System;

    public class RegistrationApplicationServiceLocal : IRegistrationApplicationServiceLocal
    {
        private readonly IDALServiceData dalServiceData;

        public RegistrationApplicationServiceLocal(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public UserRegistration Execute(UserRegistration command)
        {
            var registeredUser = ExecuteSaveCommand(command);
            return (UserRegistration)registeredUser;
        }

        private ICommand ExecuteSaveCommand(UserRegistration command)
        {
            var newUser = new User()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Skills = null,
                IsDeleted = false,
                DateOfCreation = DateTime.UtcNow
            };

            dalServiceData.Users.AddEntity(newUser);
            dalServiceData.Users.SaveChanges();

            return command;
        }
    }
}
