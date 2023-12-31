﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Common.DTOs.Common;
using Product.Services.Contracts.Common;
using NSwag.Annotations;

namespace ProductManagment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private IProductBiz _productBiz;
        public ProductController(IProductBiz productBiz)
        {
            _productBiz = productBiz;
        }

      //  [HttpPost]
        [HttpPost(Name = "Create")]
        [OpenApiOperation("Create", "Create Product ", "")]
        public IActionResult Create(ProductsDTO data)
        {
            var succeed = _productBiz.Insert(data, out var errorMessage);

             return Okk(succeed, errorMessage);
            //return Okk();
        }

        [HttpPost(Name = "Update")]
        [OpenApiOperation("Update", "Update Product ", "")]
        public IActionResult Update(ProductsDTO data)
        {
            var succeed = _productBiz.Update(data, out var errorMessage);

            return Okk(succeed, errorMessage);
            //return Ok(succeed);
        }

        [HttpPost(Name = "Delete")]
        [OpenApiOperation("Delete", "Delete Product ", "")]
        public IActionResult Delete(ProductsDTO data)
        {
            _productBiz.Delete(data);
             return Okk();
            //return Ok(true);
        }



        
        [HttpGet(Name = "GetProductList")]
        [AllowAnonymous]
        [OpenApiOperation("GetProductList", "Get Product List","")]
        public IActionResult GetProductList()
        {
            return Okk(true, " ", _productBiz.GetList());
            //return Ok(new BaseResponse(true));

        }
    }
}
