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
                    Title = "Elite Championship",
                    StartDate = new DateTime(2025, 4, 1),
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Elite Qualifier 1",
                            Time = new DateTime(2025, 4, 2, 10, 0, 0)
                        },
                        new Game
                        {
                            Title = "Elite Qualifier 2",
                            Time = new DateTime(2025, 4, 2, 14, 0, 0)
                        },
                        new Game
                        {
                            Title = "Elite Finals",
                            Time = new DateTime(2025, 4, 3, 18, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Global Invitational",
                    StartDate = new DateTime(2025, 8, 20),
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Opening Match",
                            Time = new DateTime(2025, 8, 20, 16, 0, 0)
                        },
                        new Game
                        {
                            Title = "Knockout Stage",
                            Time = new DateTime(2025, 8, 22, 12, 0, 0)
                        },
                        new Game
                        {
                            Title = "Championship Match",
                            Time = new DateTime(2025, 8, 25, 20, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Legends Cup",
                    StartDate = new DateTime(2025, 11, 5),
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Legends Qualifier",
                            Time = new DateTime(2025, 11, 6, 14, 0, 0)
                        },
                        new Game
                        {
                            Title = "Legends Semi Final",
                            Time = new DateTime(2025, 11, 7, 17, 0, 0)
                        },
                        new Game
                        {
                            Title = "Legends Final",
                            Time = new DateTime(2025, 11, 8, 19, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "Championship Series",
                    StartDate = new DateTime(2026, 2, 15),
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Series Opener",
                            Time = new DateTime(2026, 2, 15, 10, 0, 0)
                        },
                        new Game
                        {
                            Title = "Series Match 1",
                            Time = new DateTime(2026, 2, 17, 14, 0, 0)
                        },
                        new Game
                        {
                            Title = "Series Finale",
                            Time = new DateTime(2026, 2, 20, 18, 0, 0)
                        }
                    }
                },
                new TournamentDetails
                {
                    Title = "World Series",
                    StartDate = new DateTime(2026, 5, 1),
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Opening Ceremony",
                            Time = new DateTime(2026, 5, 1, 16, 0, 0)
                        },
                        new Game
                        {
                            Title = "Semi Finals",
                            Time = new DateTime(2026, 5, 5, 12, 0, 0)
                        },
                        new Game
                        {
                            Title = "World Championship",
                            Time = new DateTime(2026, 5, 8, 20, 0, 0)
                        }
                    }
                }
            };
        }
    }
}
