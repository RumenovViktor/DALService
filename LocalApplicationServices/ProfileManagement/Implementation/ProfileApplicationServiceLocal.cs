namespace LocalApplicationServices.ProfileManagement
{
    using System;
    using System.Linq;
    using Data.Unit_Of_Work;
    using DTOs.Models;
    using LocalApplicationServices.ProfileManagement.Contracts;
    using Models;

    public class ProfileApplicationServiceLocal : Base, IProfileApplicationService
    {
        public ProfileApplicationServiceLocal(IDALServiceData dalServiceData)  : base(dalServiceData) { }

        public ExperienceViewModel Execute(ExperienceViewModel command)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == command.UserEmail);

            user.Experience.Add(new Experience(command));
            dalServiceData.Users.UpdateEntity(user);
            dalServiceData.Users.SaveChanges();

            return command;
        }
    }
}
