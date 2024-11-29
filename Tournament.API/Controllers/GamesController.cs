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
using AutoMapper;
using Tournament.Core.Dto;

namespace Tournament.API.Controllers
{
    [Route("api/TournamentDetails/{tournamentDetailsId}/Games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //private readonly TournamentContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        //public GamesController(TournamentContext context)
        //{
        //    _context = context;
        //}
        public GamesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        //{
        //    return await _context.Game.ToListAsync();
        //}
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            //var games = await _uow.GameRepository.GetAllAsync();
            var games = _mapper.Map<IEnumerable<GameDto>>(await _uow.GameRepository.GetAllAsync());
            return Ok(games);
        }

        // GET: api/Games/5
        [HttpGet("{id:int}")]
        //public async Task<ActionResult<Game>> GetGame(int id)
        //{
        //    var game = await _context.Game.FindAsync(id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return game;
        //}
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            Game? game = await _uow.GameRepository.GetAsync(id);
            if (game == null) return NotFound("No Available Games");

            var dto = _mapper.Map<GameDto>(game);
            return Ok(dto);

        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        //public async Task<IActionResult> PutGame(int id, Game game)
        //{
        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
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
        public async Task<IActionResult> PutGame(int id, GameUpdateDto gameUpdateDto)
        {
            if (id != gameUpdateDto.Id) return BadRequest("Game ID mismatch");

            var existingGames = await _uow.GameRepository.AnyAsync(id);
            if (!existingGames) return NotFound("No Games Found");

            _mapper.Map(gameUpdateDto, existingGames);
            await _uow.CompleteAsync();
            return Ok(_mapper.Map<GameDto>(existingGames));
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Game>> PostGame(Game game)
        //{
        //    _context.Game.Add(game);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = game.Id }, game);
        //}
        public async Task<ActionResult<Game>> PostGame(GameCreateDto gameCreateDto)
        {
            var game = _mapper.Map<Game>(gameCreateDto);
            _uow.GameRepository.Add(game);
            await _uow.CompleteAsync();

            var createdGame = _mapper.Map<GameDto>(game);

            return CreatedAtAction(nameof(GetGame), new { id = createdGame.Id }, createdGame);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id:int}")]
        //public async Task<IActionResult> DeleteGame(int id)
        //{
        //    var game = await _context.Game.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Game.Remove(game);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _uow.GameRepository.GetAsync(id);
            if (game == null) return NotFound("No Game Found");

            _uow.GameRepository.Remove(game);
            await _uow.CompleteAsync();

            return NoContent();
        }

        //private bool GameExists(int id)
        //{
        //    return _context.Game.Any(e => e.Id == id);
        //}
    }
}
