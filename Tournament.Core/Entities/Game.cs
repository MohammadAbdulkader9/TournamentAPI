using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        public string? Title { get; set; }
        public DateTime Time { get; set; }

        // Forigen Key
        public int TournamentDetailsId { get; set; }

        // Navigational property
        public TournamentDetails TournamentDetails { get; set; } = new TournamentDetails();
    }
}
