using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto
{
    public record TournamentForManipulationDto
    {
        [Required(ErrorMessage = "Tournament Title is a required field.")]
        public string Title { get; init; }
        public DateTime StartDate { get; init; }
    }
}
