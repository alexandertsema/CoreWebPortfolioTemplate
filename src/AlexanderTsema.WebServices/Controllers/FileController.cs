//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using AlexanderTsema.Storage.Abstractions.Repositories;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//
//namespace AlexanderTsema.WebServices.Controllers
//{
//    [Route("api/[controller]")]
//    public class FileController : Controller
//    {
//        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
//        private readonly IMapper _mapper;
//        private readonly ILogger<FileController> _log;
//        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";
//        //https://github.com/stewartm83/angular-fileupload-sample/tree/master/src/AspNetWebApi
//        public FileController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
//            IMapper mapper, ILogger<FileController> log)
//        {
//            this._storage = storage;
//            this._mapper = mapper;
//            this._log = log;
//        }
//
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                var portfolioItemCategories = await this._storage.GetRepository<IPortfolioItemCategoryRepository>().AllAsync();
//                return
//                    Ok(_mapper
//                        .Map
//                        <IEnumerable<Storage.Entities.Entities.PortfolioItemCategory>,
//                            IEnumerable<ViewModels.ViewModels.PortfolioItemCategory>>
//                            (portfolioItemCategories));
//            }
//            catch (Exception e)
//            {
//                _log.LogError(e.ToString());
//                return StatusCode((int)HttpStatusCode.InternalServerError);
//            }
//            //var photos = new List<PhotoViewModel>();
//
//            //var photoFolder = new DirectoryInfo(workingFolder);
//
//            //await Task.Factory.StartNew(() =>
//            //{
//            //    photos = photoFolder.EnumerateFiles()
//            //        .Where(fi => new[] { ".jpeg", ".jpg", ".bmp", ".png", ".gif", ".tiff" }
//            //            .Contains(fi.Extension.ToLower()))
//            //        .Select(fi => new PhotoViewModel
//            //        {
//            //            Name = fi.Name,
//            //            Created = fi.CreationTime,
//            //            Modified = fi.LastWriteTime,
//            //            Size = fi.Length / 1024
//            //        })
//            //        .ToList();
//            //});
//
//            //return Ok(new { Photos = photos });
//        }
//        
//        [HttpGet("{id}")]
//        public Task<IActionResult> Get(int id)
//        {
//            try
//            {
//                var portfolioItemCategory = await this._storage.GetRepository<IPortfolioItemCategoryRepository>().SingleAsync(id);
//                return Ok(_mapper
//                    .Map
//                    <Storage.Entities.Entities.PortfolioItemCategory,
//                        ViewModels.ViewModels.PortfolioItemCategory>(portfolioItemCategory));
//            }
//            catch (Exception e)
//            {
//                _log.LogError(e.ToString());
//                return StatusCode((int)HttpStatusCode.InternalServerError);
//            }
//        }
//        
//        [HttpPost]
//        public Task<IActionResult> Post([FromBody]string value)
//        {
//            if (!ModelState.IsValid) return StatusCode((int)HttpStatusCode.BadRequest, ModelState);
//            try
//            {
//                var entity =
//                    _mapper
//                        .Map
//                        <ViewModels.ViewModels.PortfolioItemCategory,
//                            Storage.Entities.Entities.PortfolioItemCategory>(portfolioItemCategory);
//                await this._storage.GetRepository<IPortfolioItemCategoryRepository>().CreateAsync(entity);
//                return StatusCode((int)HttpStatusCode.Created, entity);
//            }
//            catch (Exception e)
//            {
//                _log.LogError(e.ToString());
//                return StatusCode((int)HttpStatusCode.InternalServerError);
//            }
//
//
//            //// Check if the request contains multipart/form-data.
//            //if (!Request.Content.IsMimeMultipartContent("form-data"))
//            //{
//            //    return BadRequest("Unsupported media type");
//            //}
//            //try
//            //{
//            //    var provider = new CustomMultipartFormDataStreamProvider(workingFolder);
//            //    //await Request.Content.ReadAsMultipartAsync(provider);
//            //    await Task.Run(async () => await Request.Content.ReadAsMultipartAsync(provider));
//
//            //    var photos = new List<PhotoViewModel>();
//
//            //    foreach (var file in provider.FileData)
//            //    {
//            //        var fileInfo = new FileInfo(file.LocalFileName);
//
//            //        photos.Add(new PhotoViewModel
//            //        {
//            //            Name = fileInfo.Name,
//            //            Created = fileInfo.CreationTime,
//            //            Modified = fileInfo.LastWriteTime,
//            //            Size = fileInfo.Length / 1024
//            //        });
//            //    }
//            //    return Ok(new { Message = "Photos uploaded ok", Photos = photos });
//            //}
//            //catch (Exception ex)
//            //{
//            //    return BadRequest(ex.GetBaseException().Message);
//            //}
//        }
//        
//        [HttpPut]
//        public Task<IActionResult> Put([FromBody]string value)
//        {
//            if (!ModelState.IsValid) return StatusCode((int)HttpStatusCode.BadRequest, ModelState);
//            try
//            {
//                var entity =
//                    _mapper
//                        .Map
//                        <ViewModels.ViewModels.PortfolioItemCategory,
//                            Storage.Entities.Entities.PortfolioItemCategory>(portfolioItemCategory);
//                if (await this._storage.GetRepository<IPortfolioItemCategoryRepository>().UpdateAsync(entity))
//                    return StatusCode((int)HttpStatusCode.OK);
//                return StatusCode((int)HttpStatusCode.NotModified);
//            }
//            catch (Exception e)
//            {
//                _log.LogError(e.ToString());
//                return StatusCode((int)HttpStatusCode.InternalServerError);
//            }
//        }
//        
//        [HttpDelete("{id}")]
//        public Task<IActionResult> Delete(int id)
//        {
//            try
//            {
//                if (await this._storage.GetRepository<IPortfolioItemCategoryRepository>().DeleteAsync(id))
//                    return StatusCode((int)HttpStatusCode.OK);
//                return StatusCode((int)HttpStatusCode.NotFound);
//            }
//            catch (Exception e)
//            {
//                _log.LogError(e.ToString());
//                return StatusCode((int)HttpStatusCode.InternalServerError);
//            }
//            //if (!FileExists(fileName))
//            //{
//            //    return NotFound();
//            //}
//
//            //try
//            //{
//            //    var filePath = Directory.GetFiles(workingFolder, fileName)
//            //        .FirstOrDefault();
//
//            //    await Task.Factory.StartNew(() =>
//            //    {
//            //        if (filePath != null)
//            //            File.Delete(filePath);
//            //    });
//
//            //    var result = new PhotoActionResult
//            //    {
//            //        Successful = true,
//            //        Message = fileName + "deleted successfully"
//            //    };
//            //    return Ok(new { message = result.Message });
//            //}
//            //catch (Exception ex)
//            //{
//            //    var result = new PhotoActionResult
//            //    {
//            //        Successful = false,
//            //        Message = "error deleting fileName " + ex.GetBaseException().Message
//            //    };
//            //    return BadRequest(result.Message);
//            //}
//        }
//
//        public bool FileExists(string fileName)
//        {
//            var file = Directory.GetFiles(workingFolder, fileName).FirstOrDefault();
//
//            return file != null;
//        }
//    }
//}
