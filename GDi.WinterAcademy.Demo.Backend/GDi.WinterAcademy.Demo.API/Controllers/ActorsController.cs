using GDi.WinterAcademy.Demo.API.Models;
using GDi.WinterAcademy.Demo.Core.Entities;
using GDi.WinterAcademy.Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDi.WinterAcademy.Demo.API.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly WinterAcademyDemoDbContext _dbContext;

        public ActorsController(
            WinterAcademyDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorModel>>> GetActors()
        {
            var actors = await _dbContext.Actors.Select(x => new ActorModel(x.Id, x.Name, x.DateOfBirth, x.Nationality)).ToListAsync();

            return Ok(actors);
        }

        [HttpGet("dropdown")]
        public async Task<ActionResult<List<DropdownModel>>> GetActorsDropdown()
        {
            var actorsDropdown = await _dbContext.Actors.Select(x => new DropdownModel(x.Id, x.Name)).ToListAsync();

            return Ok(actorsDropdown);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorModel>> GetActor(long id)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor is null)
                return BadRequest("Actor doesn't exist");

            return Ok(new ActorModel(actor.Id, actor.Name, actor.DateOfBirth, actor.Nationality));
        }

        [HttpPut]
        public async Task<ActionResult<ActorModel>> UpdateActor([FromBody] ActorModel actorModel)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == actorModel.Id);
            if (actor is null)
                return BadRequest("Actor doesn't exist");

            actor.Name = actorModel.Name;
            actor.DateOfBirth = actorModel.DateOfBirth;
            actor.Nationality = actorModel.Nationality;

            _dbContext.Entry(actor).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok(actorModel);
        }

        [HttpPost]
        public async Task<ActionResult<ActorModel>> AddActor([FromBody] ActorModel actorModel)
        {
            var actor = new Actor
            {
                Name = actorModel.Name,
                DateOfBirth = actorModel.DateOfBirth,
                Nationality = actorModel.Nationality
            };

            _dbContext.Actors.Add(actor);

            await _dbContext.SaveChangesAsync();

            return Ok(new ActorModel(actor.Id, actor.Name, actor.DateOfBirth, actor.Nationality));
        }
    }
}
