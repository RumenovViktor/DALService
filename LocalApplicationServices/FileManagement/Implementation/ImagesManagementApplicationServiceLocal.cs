using System;
using ApplicationServices;
using Models;
using DB = DTOs.Models;
using Data.Unit_Of_Work;

namespace LocalApplicationServices
{
    public class ImagesManagementApplicationServiceLocal : IFileManagementApplicationService
    {
        private readonly IDALServiceData dalServiceData;

        public ImagesManagementApplicationServiceLocal(IDALServiceData dalServiceData)
        {
            this.dalServiceData = dalServiceData;
        }

        public File Execute(File command)
        {
            ExecuteSaveCommand(command);
            return command;
        }

        private void ExecuteSaveCommand(File command)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == command.UserId);

            var newFile = new DB.File()
            {
                Name = command.Name,
                UserId = user.UserId,
                FileInputStream = command.FileInputStream
            };

            user.Files.Add(newFile);
            dalServiceData.Users.UpdateEntity(user);
            dalServiceData.Users.SaveChanges();
        }
    }
}
