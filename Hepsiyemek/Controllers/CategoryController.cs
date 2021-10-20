using Hepsiyemek.BindingModels;
using Hepsiyemek.BindingModels.RequestModel;
using Hepsiyemek.infrastructure.Entites;
using Hepsiyemek.infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CategoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: CategoryController
        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {


            var dbProduct = _productRepository.Where(x=>x.categoryId.ID==id).FirstOrDefault();
            if (dbProduct == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
            }


            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Category sorgu", dbProduct.categoryId));

        }


        [HttpPost("Create")]
        public ActionResult Post([FromBody] CategoryCreateRequestModel model)
        {
            var product = _productRepository.GetById(model.productId);
            if (product == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayı bulunamadı"));
            }

            product.categoryId = new Category
            {
                description = model.description,
                name = model.name
            };

            _productRepository.Update(product);
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Kayı başarılı", new { product.categoryId.ID }));

        }


        [HttpPut("Edit")]
        public IActionResult Put([FromBody] CategoryEditRequestModel model)
        {
            var product = _productRepository.Where(x => x.categoryId.ID == model.id).FirstOrDefault();

            if (product == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
            }
            product.categoryId.description = model.description;
            product.categoryId.name = model.name;

            _productRepository.Update(product);
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Güncelleme başarılı", new { product.ID }));
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var product = _productRepository.Where(x => x.categoryId.ID == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
            }
            product.categoryId = null;
            _productRepository.Update(product);
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Kayır silindi"));


        }
    }
}
