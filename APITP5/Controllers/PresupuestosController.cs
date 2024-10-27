using Microsoft.AspNetCore.Mvc;

namespace APITP5.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private PresupuestoRepository presRep;

    public PresupuestosController()
    {
        presRep = new PresupuestoRepository();
    } 

    [HttpPost("crearPres")]
    public ActionResult crearPresupuesto([FromBody] Presupuesto presupuesto)
    {
        presRep.create(presupuesto);
        return Ok();
    }

    [HttpPost("agregarDetalle")]
    public ActionResult agregarDetalle([FromBody]Producto producto, int cantidad, int idPresupuesto)
    {
        var detalle = new PresupuestoDetalle();
        detalle.asignarProd(producto);
        detalle.Cantidad = cantidad;

        presRep.agregarDetalle(detalle, idPresupuesto);
        return Ok();
    }

    [HttpPost("agregarDetalle2")]
    public ActionResult agregarDetalle(PresupuestoDetalle detalle, int idPresupuesto)
    {
        presRep.agregarDetalle(detalle, idPresupuesto);
        return Ok();
    }

    [HttpGet("listarPres")]
    public ActionResult<List<Presupuesto>> listarPresupuestos()
    {
        var listaPres = presRep.listarPresupuestos();
        return Ok(listaPres);
    }

}