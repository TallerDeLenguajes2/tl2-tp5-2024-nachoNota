using Microsoft.AspNetCore.Mvc;

namespace APITP5.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
    private ProductosRepository prodRep;

    public ProductosController()
    {
        prodRep = new ProductosRepository();
    }

    [HttpGet("GetProductos")]
    public ActionResult<List<Producto>> getProductos()
    {
        var productos = prodRep.listarProductos();
        return Ok(productos);
    }

    [HttpPost("Crear")]
    public ActionResult crearProducto([FromBody] Producto nuevoProducto)
    {
        prodRep.Create(nuevoProducto);
        return Ok();
    }

    [HttpPut("Modificar")]
    public ActionResult<Producto> modificarProducto(int id, string desc)
    {
        var producto = prodRep.GetProducto(id);
        producto.Descripcion = desc;
        prodRep.Update(producto);
        
        return Ok(producto);
    }
}
