using AutoMapper;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstaladorController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public InstaladorController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Instalador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Instalador>>> GetInstalador()
        {
            //return null;
            //return new BE.BS.Instalador(_context).GetAll().ToList();
            var res = new BE.BS.Instalador(_context).GetAll();
            List<models.Instalador> mapaAux = _mapper.Map<IEnumerable<data.Instalador>, IEnumerable<models.Instalador>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Instalador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Instalador>> GetInstalador(int id)
        {
            var instalador = new BE.BS.Instalador(_context).GetOneById(id);

            if (instalador == null)
            {
                return NotFound();
            }
            models.Instalador mapaAux = _mapper.Map<data.Instalador, models.Instalador>(instalador);
            return mapaAux;
        }

        // PUT: api/Instalador/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalador(int id, models.Instalador instalador)
        {
            if (id != instalador.IdRol)
            {
                return BadRequest();
            }

            try
            {
                data.Instalador mapaAux = _mapper.Map<models.Instalador, data.Instalador>(instalador);
                new BE.BS.Instalador(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!InstaladorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instalador
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Instalador>> PostInstalador(models.Instalador instalador)
        {
            try
            {
                var mapAux = _mapper.Map<models.Instalador, data.Instalador>(instalador);
                new BE.BS.Instalador(_context).Insert(mapAux);
            }
            catch (Exception )
            {
                BadRequest();
            }

            return CreatedAtAction("GetInstalador", new { id = instalador.IdRol }, instalador);
        }

        // DELETE: api/Instalador/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Instalador>> DeleteInstalador(int id)
        {
            var instalador = new BE.BS.Instalador(_context).GetOneById(id);
            if (instalador == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Instalador(_context).Delete(instalador);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Instalador, models.Instalador>(instalador);
            return mapAux;
        }

        private bool InstaladorExists(int id)
        {
            return (new BE.BS.Instalador(_context).GetOneById(id) != null);
        }
    }
}
