namespace HomePropertySystem.ServiceInterfaces
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task<string> GenerateFile(IFormFile avatarFile, string folderName, string specialFolderName);
    }
}
