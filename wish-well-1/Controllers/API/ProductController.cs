﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace wish_well_1.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private ProductsCsvController _ProductsCsvController = new ProductsCsvController();

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Product product)
        {
            int productID = string.IsNullOrEmpty(product.ID.ToString()) ? -1 : product.ID;
            string name = string.IsNullOrEmpty(product.Name) ? "" : product.Name;
            string url = string.IsNullOrEmpty(product.Url) ? "" : product.Url;
            string price = string.IsNullOrEmpty(product.Price) ? "" : product.Price;
            int userId = string.IsNullOrEmpty(product.UserId.ToString()) ? -1 : product.UserId;

            return Ok(_ProductsCsvController.addProductToList(productID, name, url, price, userId));
        }

        [HttpGet("ByUserId")]
        
        public ActionResult<Product[]> ByUserId([FromQuery(Name = "userId")]  int userId) {
            var result = _ProductsCsvController.getProductsByUserId(userId);
            return Ok(result);
        }
    }
}
