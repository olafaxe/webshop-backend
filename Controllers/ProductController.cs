using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopApi.Contexts;
using shopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace shopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (Context context = new Context())
            {
                return context.Products.ToList();
                // return context.Users.Include(u => u.Posts).ThenInclude(p => p.Comments).ToList();

            }

        }
    }
}
