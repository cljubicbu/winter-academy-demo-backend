using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDi.WinterAcademy.Demo.API.Models
{
    public record ActorModel(
        long Id,
        string Name,
        DateTime DateOfBirth,
        string Nationality);

    public record DropdownModel(
        long Value,
        string Label);
}
