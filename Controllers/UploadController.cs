using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using WebApi.Entities;
using FileResult = DataAccess.Model.FileResult;
using WebApi.Authorization;
using KaynakKod.Entities;
using WebApi.Helpers;

namespace AspNetCoreFileUploadFileTable.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IFileRepository _fileRepository;
        private readonly IOptions<ApplicationConfiguration> _optionsApplicationConfiguration;

        private readonly AppSettings _appSettings;




        public FileUploadController(IFileRepository fileRepository, IOptions<ApplicationConfiguration> o, IOptions<AppSettings> appSettings)
        {
            _fileRepository = fileRepository;
            _optionsApplicationConfiguration = o;
            _appSettings = appSettings.Value;


        }

        [Authorize(Role.Admin)]
        [HttpPost("UploadFiles")]
        [DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadFiles([FromForm] FileDescriptionShort fileDescriptionShort)
        {



            var names = new List<string>();
            var contentTypes = new List<string>();
            Guid obj = Guid.NewGuid();
            if (ModelState.IsValid)
            {

                foreach (var file in fileDescriptionShort.File)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                        contentTypes.Add(file.ContentType);

                        names.Add(fileName);

                        await file.SaveAsAsync(Path.Combine(_appSettings.ServerUploadFolder, obj.ToString()));

                    }
                }
            }

            var files = new FileResult
            {
                FileNames = names,
                ContentTypes = contentTypes,
                FileGuid = obj.ToString(),
                Revize_Id = fileDescriptionShort.Revize_Id,
                Description = fileDescriptionShort.Description,
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
            };

            var x = _fileRepository.AddFileDescriptions(files);

            return Ok(x);
        }
        [Authorize(Role.Admin)]
        [Route("Download/{id}")]
        [HttpGet]
        public FileStreamResult Download(int id)
        {
            var fileDescription = _fileRepository.GetFileDescription(id);

            var path = _appSettings.ServerUploadFolder + "\\" + fileDescription.FileGuid;
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, fileDescription.ContentType, fileDescription.FileName);
        }
        [Authorize(Role.Admin)]
        [Route("Get_Files_With_Revize_Id")]
        [HttpPost]
        public IActionResult Get_Files_With_Revize_Id(Revize id)
        {

            var temp = _fileRepository.Get_Files_With_Revize_Id(id);
            return Ok(temp);
        }
        [Authorize(Role.Admin)]
        [Route("Delete_File_By_Id")]
        [HttpPost]
        public IActionResult Delete_File_By_Id(Revize id)
        {

            _fileRepository.Delete_File_By_Id(id);
            return Ok();
        }
    }
}

