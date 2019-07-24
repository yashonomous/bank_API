using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankDetails.Models;
using System.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace BankDetails.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankDetailsDbContext _context;

        public BanksController(BankDetailsDbContext context)
        {
            _context = context;
        }

        /*methos to get all banks in db. by default it gives 50 entries as response. limit can be changed using limit & offset*/
        // GET: api/Banks
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IEnumerable<Bank> GetBanks(int? offset, int? limit)
        {
            return _context.Banks.
                Skip(offset == null ? 0 : offset.Value).Take(limit == null ? 50 : limit.Value);
        }

        /*methos to get a bank in db by ID*/
        // GET: api/Banks/5
        [HttpGet("byId")]
        public IActionResult GetBank(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var bank = _context.Banks.Where(b => b.id.Equals(id)).DefaultIfEmpty();
            
            if (bank.First() == null)
            {
                return NotFound("Given bank not found.");               //if bank with id not found.
            }

            return Ok(bank);                                            //return 200OK if bank found.
        }
    }
}
 