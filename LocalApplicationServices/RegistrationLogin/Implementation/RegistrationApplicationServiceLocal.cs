namespace LocalApplicationServices
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Data.Unit_Of_Work;
    using DTOs.Models;

    public class RegistrationApplicationServiceLocal : IRegistrationApplicationServiceLocal
    {
        private readonly IDALServiceData dalServiceData;

        public RegistrationApplicationServiceLocal(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public CompanyRegistration Execute(CompanyRegistration command)
        {
            var company = dalServiceData.Companies
                .FindEntity(x => (x.CountryId == command.CountryId && x.Name == command.CompanyName) || x.Email == command.Email);

            if (company != null)
            {
                return new CompanyRegistration()
                {
                    CompanyExists = true
                };
            }

            var sector = dalServiceData.Sectors.FindEntity(x => x.Id == command.SectorId.Value);
            var newCompany = new Company(command, sector);

            dalServiceData.Companies.AddEntity(newCompany);
            dalServiceData.Companies.SaveChanges();

            var existingCompany = dalServiceData.Companies
                .FindEntity(x => (x.CountryId == command.CountryId && x.Name == command.CompanyName) || x.Email == command.Email);

            return new CompanyRegistration()
            {
                CompanyId = existingCompany.Id,
                CompanyExists = false
            };
        }

        public UserRegistration Execute(UserRegistration command)
        {
            var registeredUser = ExecuteSaveCommand(command);
            return (UserRegistration)registeredUser;
        }

        private ICommand ExecuteSaveCommand(UserRegistration command)
        {
            var existingUser = dalServiceData.Users.FindEntity(x => x.Email == command.Email);

            if (existingUser != null)
            {
                return new UserRegistration()
                {
                    UserExists = true
                };
            }

            var newUser = new User()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Skills = default(IList<Skill>),
                IsDeleted = default(bool),
                DateOfCreation = DateTime.UtcNow,
                CountryId = command.CountryId
            };

            dalServiceData.Users.AddEntity(newUser);
            dalServiceData.Users.SaveChanges();

            existingUser = dalServiceData.Users.FindEntity(x => x.Email == command.Email);
            command.UserId = existingUser.UserId;

            return command;
        }
    }
}
