using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDi.WinterAcademy.Demo.API.Models
{
    public record GetMoviesResponse(
        List<MovieModel> Movies);

    public record MovieModel(
        long Id,
        DateTime ReleaseDate,
        string Title,
        int Duration,
        long ActorId,
        string ActorName);
}
