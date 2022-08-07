using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;

namespace DataAccess
{
    using System.IO;
    using System.Threading;
    using KaynakKod.Entities;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using WebApi.Authorization;
    using WebApi.Helpers;

    public interface IFileRepository
    {
        IEnumerable<FileDescriptionShort> AddFileDescriptions(FileResult fileResult);

        IEnumerable<FileDescriptionShort> GetAllFiles();

        FileDescription GetFileDescription(int id);

        List<FileDescription> Get_Files_With_Revize_Id(Revize id);

        void Delete_File_By_Id(Revize x);


    }


    public class FileService : IFileRepository
    {



        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public FileService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<FileDescriptionShort> AddFileDescriptions(FileResult fileResult)
        {
            List<string> filenames = new List<string>();
            for (int i = 0; i < fileResult.FileNames.Count(); i++)
            {


                int index = fileResult.FileNames[i].LastIndexOf("\\");
                var shortName = fileResult.FileNames[i].Substring(index + 1);

                var fileDescription = new FileDescription
                {
                    ContentType = fileResult.ContentTypes[i],
                    FileName = shortName,
                    FileGuid = fileResult.FileGuid,
                    Revize_Id = fileResult.Revize_Id,
                    CreatedTimestamp = fileResult.CreatedTimestamp,
                    UpdatedTimestamp = fileResult.UpdatedTimestamp,
                    Description = fileResult.Description
                };

                filenames.Add(fileResult.FileNames[i]);
                _context.FileDescriptions.Add(fileDescription);
            }

            _context.SaveChanges();
            return GetNewFiles(filenames);
        }

        private IEnumerable<FileDescriptionShort> GetNewFiles(List<string> filenames)
        {
            IEnumerable<FileDescription> x = _context.FileDescriptions.Where(r => filenames.Contains(r.FileName));
            return x.Select(t => new FileDescriptionShort { Id = t.Id, Description = t.Description });
        }

        public IEnumerable<FileDescriptionShort> GetAllFiles()
        {
            return _context.FileDescriptions.Select(
                    t => new FileDescriptionShort { Name = t.FileName, Id = t.Id, Description = t.Description });
        }

        public FileDescription GetFileDescription(int id)
        {
            return _context.FileDescriptions.Single(t => t.Id == id);
        }

        public List<FileDescription> Get_Files_With_Revize_Id(Revize y)
        {
            var temp = (from x in _context.FileDescriptions
                        where x.Revize_Id == y.Id
                        select x
            );

            return temp.ToList();
        }

        public void Delete_File_By_Id(Revize y)
        {
            var temp = (from x in _context.FileDescriptions
                        where x.Id == y.Id
                        select x
            ).FirstOrDefault();


            string path = _appSettings.ServerUploadFolder + "\\" + temp.FileGuid;



            bool isDeleted = false;
            while (!isDeleted)
            {

                File.Delete(path);
                isDeleted = true;

                Thread.Sleep(50);
            }

            var temp_ = _context.FileDescriptions;
            var Değer = temp_.FirstOrDefault(o => o.Id == y.Id);
            _context.FileDescriptions.Remove(Değer);
            _context.SaveChanges();

        }
    }
}

