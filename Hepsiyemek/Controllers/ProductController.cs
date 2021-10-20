using Hepsiyemek.BindingModels;
using Hepsiyemek.BindingModels.RequestModel;
using Hepsiyemek.infrastructure.Entites;
using Hepsiyemek.infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hepsiyemek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;
        public ProductController(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            _productRepository = productRepository;
            _distributedCache = distributedCache;
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var productCache = await _distributedCache.GetStringAsync("product_" + id);

            if (productCache == null)
            {
                var dbProduct= _productRepository.GetById(id);
                if (dbProduct==null)
                {
                    return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
                }
                var option = new DistributedCacheEntryOptions();
                option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5); 
                await _distributedCache.SetStringAsync("product_" + id, JsonSerializer.Serialize(dbProduct), option);

                return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Product sorgu", dbProduct));
            }
          
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Product sorgu", JsonSerializer.Deserialize<Product>(productCache)));
        }


        [HttpPost("Create")]
        public ActionResult Post([FromBody] ProductCreateRequestModel model)
        {
            var result = _productRepository.Add(new Product
            {
                categoryId = new Category
                {
                    description = model.categoryId.description,
                    name = model.categoryId.name
                },
                currency = model.currency,
                description = model.description,
                name = model.name,
                price = model.price
            });
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Kayı başarılı", new { result.ID }));

        }


        [HttpPut("Edit")]
        public IActionResult Put([FromBody] ProductEditRequestModel model)

        {
            var product = _productRepository.GetById(model.id);

            if (product == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
            }

            product.categoryId.description = model.categoryId.description;
            product.categoryId.name = model.categoryId.name;
            product.currency = model.currency;
            product.description = model.description;
            product.name = model.name;
            product.price = model.price;

            _productRepository.Update(product);
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Güncelleme başarılı", new { product.ID }));
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound(new BaseResponseModel(StatusCodes.Status404NotFound, "Kayıt bulunamadı"));
            }
            _productRepository.Remove(product);
            return Ok(new BaseResponseModel(StatusCodes.Status200OK, "Kayır silindi"));


        }
    }
}
