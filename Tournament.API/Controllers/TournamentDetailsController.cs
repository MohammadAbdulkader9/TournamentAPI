using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.API.Controllers
{
    [Route("api/TournamentDetails")]
    [ApiController]
    public class TournamentDetailsController : ControllerBase
    {
        //private readonly TournamentContext _context;
        private readonly IUnitOfWork _uow;

        public TournamentDetailsController(TournamentContext context, IUnitOfWork uow)
        {
            //_context = context;
            _uow = uow;
        }

        // GET: api/TournamentDetails
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<TournamentDetails>>> GetTournamentDetails()
        //{
        //    return await _context.TournamentDetails.ToListAsync();
        //}
        public async Task<ActionResult<IEnumerable<TournamentDetails>>> GetTournamentDetails()
        {
            var tournaments = await _uow.TournamentRepository.GetAllAsync();
            return Ok(tournaments);
        }

        // GET: api/TournamentDetails/5
        [HttpGet("{id:int}")]
        //public async Task<ActionResult<TournamentDetails>> GetTournamentDetails(int id)
        //{
        //    var tournamentDetails = await _context.TournamentDetails.FindAsync(id);

        //    if (tournamentDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return tournamentDetails;
        //}
        public async Task<ActionResult<TournamentDetails>> GetTournamentDetails(int id)
        {
            var tournament = await _uow.TournamentRepository.GetAsync(id);
            if (tournament == null) return NotFound("No Available Tournaments");

            return Ok(tournament);
        }

        // PUT: api/TournamentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        //public async Task<IActionResult> PutTournamentDetails(int id, TournamentDetails tournamentDetails)
        //{
        //    if (id != tournamentDetails.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tournamentDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TournamentDetailsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public async Task<IActionResult> PutTournamentDetails(int id, TournamentDetails tournamentDetails)
        {
            if (id != tournamentDetails.Id) return BadRequest("Tournament ID mismatch");

            var existingTournaments = await _uow.TournamentRepository.AnyAsync(id);
            if (!existingTournaments) return NotFound("No Tournaments Found");

            try
            {
                await _uow.CompleteAsync();
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the tournament.");
            }

            return NoContent();
        }

        // POST: api/TournamentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<TournamentDetails>> PostTournamentDetails(TournamentDetails tournamentDetails)
        //{
        //    _context.TournamentDetails.Add(tournamentDetails);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTournamentDetails", new { id = tournamentDetails.Id }, tournamentDetails);
        //}
        public async Task<ActionResult<TournamentDetails>> PostTournamentDetails(TournamentDetails tournamentDetails)
        {
            _uow.TournamentRepository.Add(tournamentDetails);
            await _uow.CompleteAsync();

            return CreatedAtAction("GetTournamentDetails", new { id = tournamentDetails.Id }, tournamentDetails);
        }

        // DELETE: api/TournamentDetails/5
        [HttpDelete("{id:int}")]
        //public async Task<IActionResult> DeleteTournamentDetails(int id)
        //{
        //    var tournamentDetails = await _context.TournamentDetails.FindAsync(id);
        //    if (tournamentDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TournamentDetails.Remove(tournamentDetails);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        public async Task<IActionResult> DeleteTournamentDetails(int id)
        {
            var tournament = await _uow.TournamentRepository.GetAsync(id);
            if (tournament == null) return NotFound("No Tournament Found");

            _uow.TournamentRepository.Remove(tournament);
            await _uow.CompleteAsync();

            return NoContent();
        }

        //private bool TournamentDetailsExists(int id)
        //{
        //    return _context.TournamentDetails.Any(e => e.Id == id);
        //}
    }
}
