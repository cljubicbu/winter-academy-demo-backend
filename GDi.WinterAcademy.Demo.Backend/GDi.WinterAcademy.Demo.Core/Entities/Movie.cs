using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace GDi.WinterAcademy.Demo.Core.Entities
{
    public class Movie
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }

        public Actor MainCharacter { get; set; }

        public long MainCharacterId { get; set; }
    }
}
