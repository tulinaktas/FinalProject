using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // attribute (javada annotation)
    public class ProductsController : ControllerBase
    {
        // bagımlılık cozuyoruz 
        //loosely coupled (gevsek baglılık-soyuta baglılık)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //productmanagera bagımlıyız su anda
            //dependency chain
            //IProductService productServices = new ProductManager(new EFProductDal());
            var result = _productServices.GetAll();

            return result.Data;
        }
    }
}
