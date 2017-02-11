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

        public SkillDtoWriteModel Execute(SkillDtoWriteModel command)
        {
            var skill = dalServiceData.Skills.FindEntity(x => x.Name == command.Name);

            if (skill != null)
            {
                dalServiceData.Users.FindEntity(x => x.Email == command.UserEmail).Skills.Add(skill);
            }
            else
            {
                var newSkill = new Skill(command);
                dalServiceData.Skills.AddEntity(newSkill);
                dalServiceData.Users.FindEntity(x => x.Email == command.UserEmail).Skills.Add(newSkill);

                dalServiceData.Skills.SaveChanges();
            }

            dalServiceData.Users.SaveChanges();
            return null;
        }

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
