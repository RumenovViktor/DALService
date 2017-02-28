namespace LocalApplicationServices
{
    using Models;
    using ApplicationServices;
    using Data.Unit_Of_Work;
    using DTOs.Models;
    using System;

    public class SkillsApplicationServiceLocal : Base, ISkillsApplicationService
    {
        public SkillsApplicationServiceLocal(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public PositionRequiredSkill Execute(PositionRequiredSkill command)
        {
            foreach (var skill in command.SkillsNames)
            {
                var dbSkill = dalServiceData.Skills.FindEntity(x => x.Name.Equals(skill));

                if (dbSkill != null)
                {
                    dalServiceData.Positions.FindEntity(x => x.Id == command.PositionId).RequiredSkills.Add(dbSkill);
                }
                else
                {
                    var newSkill = new Skill(skill);
                    dalServiceData.Skills.AddEntity(newSkill);
                    dalServiceData.Positions.FindEntity(x => x.Id == command.PositionId).RequiredSkills.Add(newSkill);

                    dalServiceData.Skills.SaveChanges();
                }
            }

            dalServiceData.Positions.SaveChanges();

            return command;
        }

        public SkillDtoWriteModel Execute(SkillDtoWriteModel command)
        {
            var skill = dalServiceData.Skills.FindEntity(x => x.Name == command.Name);

            if (skill != null)
            {
                dalServiceData.Users.FindEntity(x => x.Email == command.UserEmail).Skills.Add(skill);
            }
            else
            {
                var newSkill = new Skill(command.Name);
                dalServiceData.Skills.AddEntity(newSkill);
                dalServiceData.Users.FindEntity(x => x.Email == command.UserEmail).Skills.Add(newSkill);

                dalServiceData.Skills.SaveChanges();
            }

            dalServiceData.Users.SaveChanges();
            return command;
        }
    }
}
