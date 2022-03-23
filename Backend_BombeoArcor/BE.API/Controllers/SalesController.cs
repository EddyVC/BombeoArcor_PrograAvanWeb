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
    public class SalesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public SalesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Sales>>> GetSales()
        {
            var res = new BE.BS.Sales(_context).GetAll();
            List<models.Sales> mapaAux = _mapper.Map<IEnumerable<data.Sales>, IEnumerable<models.Sales>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Sales>> GetSales(int id)
        {
            var sales = new BE.BS.Sales(_context).GetOneById(id);

            if (sales == null)
            {
                return NotFound();
            }
            models.Sales mapaAux = _mapper.Map<data.Sales, models.Sales>(sales);
            return mapaAux;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(int id, models.Sales sales)
        {
            if (id != sales.Id)
            {
                return BadRequest();
            }

            try
            {
                data.Sales mapaAux = _mapper.Map<models.Sales, data.Sales>(sales);
                new BE.BS.Sales(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Sales>> PostSales(models.Sales sales)
        {
            try
            {
                var mapAux = _mapper.Map<models.Sales, data.Sales>(sales);
                new BE.BS.Sales(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetProducts", new { id = sales.Id }, sales);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Sales>> DeleteSales(int id)
        {
            var sales = new BE.BS.Sales(_context).GetOneById(id);
            if (sales == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Sales(_context).Delete(sales);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Sales, models.Sales>(sales);
            return mapAux;
        }

        private bool SalesExists(int id)
        {
            return (new BE.BS.Sales(_context).GetOneById(id) != null);
        }
    }

}