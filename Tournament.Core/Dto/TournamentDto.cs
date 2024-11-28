using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto
{
    public record TournamentDto
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }

        public TournamentDto(int id, string? title, DateTime? startDate)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            EndDate = startDate?.AddMonths(3);
        }
    }
}
