using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_MAG_Ingenenieria.Models;

namespace API_MAG_Ingenenieria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly DBAPI_PROYECTContext _dbContext;

        public ClienteController (DBAPI_PROYECTContext _context)
        {
            _dbContext = _context;
        }

        //Listar Clientes
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                lista =_dbContext.Clientes.Include(c => c.Areas).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }


        }

    }
}
