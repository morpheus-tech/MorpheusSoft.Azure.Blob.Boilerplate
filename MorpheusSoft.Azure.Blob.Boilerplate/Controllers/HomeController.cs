using Microsoft.AspNetCore.Mvc;
using MorpheusSoft.Azure.Blob.Boilerplate.Models;
using MorpheusSoft.Azure.Blob.Service.Services;
using System.Diagnostics;

namespace MorpheusSoft.Azure.Blob.Boilerplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UploadFile(IFormFile file,[FromServices] IAzureBlobService azureBlobService)
        {
            string fileUrl;
            //await azureBlobService.CreateContainerAsync("main");
            await azureBlobService.SavePublicFileAsync(file.OpenReadStream(), file.FileName,"main",out fileUrl);
            var getFileResult = await azureBlobService.GetFileAsync(file.FileName, "main");
            await azureBlobService.DeleteFileAsync(file.FileName, "main");
            return View("File uploaded successfully");
        }
        public IActionResult SeeFiles()
        {
            return View();
        }
        public IActionResult DeleteFile()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}