using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] // (1) framework will route our requet to this controller
    public class ProductsController : ControllerBase // (2) create new instance of product controller
    {
        private readonly StoreContext _context; // commmon developer tool to use _ for private fields. Gives us access to db context
        public ProductsController(StoreContext context) // (3) see that you need a service, which is the store context. 
        //The seervice is in the Program.cs file, it's gonna use that service and create new instance that dbcontext (context) can use 
        {
            _context = context; // methods etc. are now also available to the controller - cause they're linked to the dbcontext
            
        }
        
        //methods below
        //ActionResult is used to return something using HTTP responce (status code)
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() // ActionResult to return a list of products
        
        {
            // products wasn't determined as a lit/array, so the .ToList method is used to convert it to a list
            var products = await _context.Products.ToListAsync(); 
            
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) //returning a single product
        {
            return await _context.Products.FindAsync(id); //finds product by id
        }
    }
}