using GDi.WinterAcademy.Demo.API.Models;
using GDi.WinterAcademy.Demo.Core.Entities;
using GDi.WinterAcademy.Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GDi.WinterAcademy.Demo.API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly WinterAcademyDemoDbContext _dbContext;

        public MoviesController(
            WinterAcademyDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<MovieModel>> GetMovies([FromQuery] bool delay = false)
        {
            var movies = _dbContext.Movies
                            .Include(x => x.MainCharacter)
                            .Select(y => new MovieModel(
                                            y.Id,
                                            y.ReleaseDate,
                                            y.Title,
                                            y.Duration,
                                            y.MainCharacter.Id,
                                            y.MainCharacter.Name))
                            .ToList();

            if (delay)
                Thread.Sleep(3000);

            return Ok(movies);
        }

        [HttpGet("check-movie/{id}")]
        public async Task<ActionResult<bool>> CheckIfExists(long id)
        {
            var actor = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (actor is null)
                return this.Ok(false);

            return this.Ok(true);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieModel> GetMovie(int id)
        {
            var movie = _dbContext.Movies.Include(x => x.MainCharacter).FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return BadRequest("Movie doesn't exist");
            }

            return Ok(new MovieModel(movie.Id, movie.ReleaseDate, movie.Title, movie.Duration, movie.MainCharacter.Id, movie.MainCharacter.Name));
        }

        [HttpPut]
        public async Task<ActionResult<MovieModel>> UpdateMovie([FromBody] MovieModel movieModel)
        {
            var movie = _dbContext.Movies.Include(x => x.MainCharacter).FirstOrDefault(x => x.Id == movieModel.Id);
            if (movie is null)
                return BadRequest("Movie doesn't exist");

            movie.Title = movieModel.Title;
            movie.Duration = movieModel.Duration;
            movie.ReleaseDate = movieModel.ReleaseDate;
            if (movieModel.ActorId != movie.MainCharacter.Id)
            {
                movie.MainCharacterId = movieModel.ActorId;
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok(movieModel);
        }

        [HttpPost]
        public async Task<ActionResult<MovieModel>> AddMovie([FromBody] MovieModel movieModel)
        {
            var movie = new Movie
            {
                Title = movieModel.Title,
                Duration = movieModel.Duration,
                ReleaseDate = movieModel.ReleaseDate,
                MainCharacterId = movieModel.ActorId
            };

            _dbContext.Movies.Add(movie);

            await _dbContext.SaveChangesAsync();

            return Ok(new MovieModel(movie.Id, movieModel.ReleaseDate, movieModel.Title, movieModel.Duration, movieModel.ActorId, movieModel.ActorName));
        }
    }
}
