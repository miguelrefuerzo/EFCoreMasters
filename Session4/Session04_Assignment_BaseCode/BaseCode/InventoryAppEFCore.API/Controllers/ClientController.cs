using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly InventoryAppEfCoreContext _context;

        public ClientController(IMapper mapper, InventoryAppEfCoreContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var prodEntity = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if (prodEntity == null)
            {
                return NotFound();
            }

            var prodDTO = _mapper.Map<ProductDTO>(prodEntity);

            return Ok(prodDTO);
        }
    }
}