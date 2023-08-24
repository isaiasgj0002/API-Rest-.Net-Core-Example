using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miprimerwebapi.Data;
using miprimerwebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace miprimerwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        public readonly DataContext _context;
        public ProductoController(DataContext context)
        {
            _context = context;
        }
        //httpPOST
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducto(Product product){
            var producto = new Product{
                Nombre = product.Nombre,
                Descripcion = product.Descripcion,
                Precio = product.Precio,
                FechaAlta = DateTime.Now,
                Activo = true
            };
            _context.Products.Add(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //httpGET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
            var products = await _context.Products.ToListAsync();
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await _context.Products.FindAsync(id);
            if(product == null){
                return NotFound();
            }
            return product;
        }
        //httpPUT
        [HttpPut]
        public async Task<IActionResult> PutProduct(int id, Product product){
            if(id != product.Id){
                return BadRequest();
            }
            var productoEdit = await _context.Products.FindAsync(id);
            if(productoEdit == null){
                return NotFound();
            }
            productoEdit.Nombre = product.Nombre;
            productoEdit.Descripcion = product.Descripcion;
            productoEdit.Precio = product.Precio;
            productoEdit.Activo = product.Activo;
            await _context.SaveChangesAsync();
            return Ok();
        }
        //httpDELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id){
            var productoDelete = await _context.Products.FindAsync(id);
            if(productoDelete == null){
                return NotFound();
            }
            _context.Products.Remove(productoDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}