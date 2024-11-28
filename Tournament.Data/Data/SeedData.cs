using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public static class SeedData
    {
        public static async Task InitAsync(TournamentContext context)
        {
            if (await context.TournamentDetails.AnyAsync()) return;

            // Generate TournamentDetails with Games
            var tournamentDetails = GenerateTournaments();
            await context.AddRangeAsync(tournamentDetails);

            await context.SaveChangesAsync();
        }

        private static List<TournamentDetails> GenerateTournaments()
        {
            return new List<TournamentDetails>
            {
                new TournamentDetails
                {
                    Title = "Spring Championship",
                    StartDate = new DateTime(2025, 3, 15),
                    games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Quarter Final 1",
                            Time = new DateTime(2025, 3, 16, 10, 0, 0)
                        },
                        new Game
                        {
                            Title = "Quarter Final 2",
                            Time = new DateTime(2025, 3, 16, 14, 0, 0)
                        },
                        new Game
                        {
                            Title = "Semi Final",
                            Time = new DateTime(2025, 3, 17, 12, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Summer League",
                    StartDate = new DateTime(2025, 6, 1),
                    games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Opening Match",
                            Time = new DateTime(2025, 6, 1, 18, 0, 0)
                        },
                        new Game
                        {
                            Title = "Group Stage Match",
                            Time = new DateTime(2025, 6, 5, 15, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Autumn Invitational",
                    StartDate = new DateTime(2025, 10, 10),
                    games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Preliminary Round",
                            Time = new DateTime(2025, 10, 11, 9, 0, 0)
                        },
                        new Game
                        {
                            Title = "Elimination Round",
                            Time = new DateTime(2025, 10, 12, 14, 0, 0)
                        },
                        new Game
                        {
                            Title = "Finals",
                            Time = new DateTime(2025, 10, 15, 20, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Winter Clash",
                    StartDate = new DateTime(2025, 12, 20),
                    games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Snowball Showdown",
                            Time = new DateTime(2025, 12, 21, 10, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Champions Cup",
                    StartDate = new DateTime(2026, 1, 5),
                    games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Opening Ceremony",
                            Time = new DateTime(2026, 1, 5, 18, 0, 0)
                        },
                        new Game
                        {
                            Title = "Grand Final",
                            Time = new DateTime(2026, 1, 10, 20, 0, 0)
                        }
                    }
                }
            };
        }
    }
}
