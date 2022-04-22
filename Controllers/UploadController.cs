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


namespace AspNetCoreFileUploadFileTable.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IFileRepository _fileRepository;
        private readonly IOptions<ApplicationConfiguration> _optionsApplicationConfiguration;

        public FileUploadController(IFileRepository fileRepository, IOptions<ApplicationConfiguration> o)
        {
            _fileRepository = fileRepository;
            _optionsApplicationConfiguration = o;
        }

        [Authorize(Role.Admin)]
        [HttpPost("UploadFiles")]
        [ServiceFilter(typeof(ValidateMimeMultipartContentFilter))]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UploadFiles([FromForm] FileDescriptionShort fileDescriptionShort)
        {
            var names = new List<string>();
            var contentTypes = new List<string>();
            if (ModelState.IsValid)
            {
                // http://www.mikesdotnetting.com/article/288/asp-net-5-uploading-files-with-asp-net-mvc-6
                // http://dotnetthoughts.net/file-upload-in-asp-net-5-and-mvc-6/
                foreach (var file in fileDescriptionShort.File)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                        contentTypes.Add(file.ContentType);

                        names.Add(fileName);

                        // Extension method update RC2 has removed this 
                        await file.SaveAsAsync(Path.Combine(@"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebApiUploads_Dir_", fileName));
                    }
                }
            }

            var files = new FileResult
            {
                FileNames = names,
                ContentTypes = contentTypes,
                Description = fileDescriptionShort.Description,
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
            };

            var x = _fileRepository.AddFileDescriptions(files);

            return Ok(x);
        }

        [Route("Download")]
        [HttpGet]
        public FileStreamResult Download([FromForm] int id)
        {
            var fileDescription = _fileRepository.GetFileDescription(id);

            var path = @"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebApiUploads_Dir_" + "\\" + fileDescription.FileName;
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, fileDescription.ContentType);
        }
    }
}

