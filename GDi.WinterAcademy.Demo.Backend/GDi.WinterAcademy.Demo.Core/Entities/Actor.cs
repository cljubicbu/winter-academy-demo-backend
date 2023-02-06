using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace GDi.WinterAcademy.Demo.Core.Entities
{
    public class Actor
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
