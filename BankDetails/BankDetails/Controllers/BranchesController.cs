using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly BankDetailsDbContext _context;

        public BranchesController(BankDetailsDbContext context)
        {
            _context = context;
        }

        /*methos to get all branches in db. by default it gives 50 entries as response. limit can be changed using limit & offset*/
        // GET: api/branches
        [HttpGet]
        public IActionResult GetBranches(int? offset, int?limit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branch = _context.Branches.
                Skip(offset == null ? 0 : offset.Value).Take(limit == null ? 50 : limit.Value);

            if (branch.First() == null)
            {
                return NotFound("Given IFSC not found.");                   //if bank with ifsc code not found.
            }

            return Ok(branch);                                          //return 200OK if branch found.
        }

        /*methos to get a bank by ifsc code*/
        // GET: api/branches/ifsc
        [HttpGet("byIFSC")]
        public IActionResult GetBranchByIFSC(string ifsc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branch = _context.Branches.Where(b => b.ifsc.Equals(ifsc)).DefaultIfEmpty();

            if (branch.First() == null)
            {
                return NotFound("Given IFSC not found.");                   //if bank with ifsc code not found.
            }

            return Ok(branch);                                          //return 200OK if branch found.
        }

        // GET: api/branches/byName&City?name=&city=
        [HttpGet("byName&City")]
        public IActionResult GetBranchByIFSC(string name, string city, int? offset, int? limit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank = _context.Banks.Where(b => b.name.Equals(name)).DefaultIfEmpty();

            if (bank.First() == null)
            {
                return NotFound("Given bank name not found.");                  //if bank with name not found.
            }

            var branch = _context.Branches.
                Where(b => (b.bank_id.Equals(bank.First().id) && b.city.Equals(city))).
                Skip(offset == null ? 0 : offset.Value).
                Take(limit == null ? 20 : limit.Value).DefaultIfEmpty();

            if (branch.First() == null)
            {
                return NotFound("Branch with given name & city not found.");              //if bank with city not found.
            }

            return Ok(branch);                        //return 200OK if branch with given name & city found.
        }
    }
}
