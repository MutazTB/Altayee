using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Al_Tayee.Areas.Admin.Controllers
{
    [Authorize]
    public class BrandsController : Controller
    {
        private IWebHostEnvironment _environment;
        private IBrandsSvc<Brands> _brandsSvc;
        public BrandsController(IWebHostEnvironment environment , IBrandsSvc<Brands> brandsSvc)
        {
            _environment = environment;
            _brandsSvc = brandsSvc;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Brands/AddBrand")]
        public async Task<ReturnResponse> Create([FromBody] Brands brands)
        {            
            return await _brandsSvc.Add(brands);
        }

        [HttpPost]
        [Route("Brands/AddImages")]
        public string AddImages(List<IFormFile> Images)
        {
            var count = 0;
            var fileName = string.Empty;
            foreach (var image in Images)
            {
                fileName = Path.GetFileName("Img_" + count.ToString() + image.FileName + Guid.NewGuid());
                var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(fileStream);
                }
                count++;
            }
            return fileName;
        }

        [HttpPost]
        [Route("Brands/DeleteBrand/{Id}")]
        public async Task<ReturnResponse> Delete(Guid Id)
        {
            return await _brandsSvc.Delete(Id);
        }
        [HttpPost]
        [Route("Brands/GetAllBrands")]
        public async Task<IList<Brands>> GetAll()
        {
            return await _brandsSvc.GetDataList();
        }
    }
}
