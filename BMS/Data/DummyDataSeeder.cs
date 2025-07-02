namespace BMS.Data
{
    public static class DummyDataSeeder
    {
        public static List<Theater> InitializeTheaters()
        {
            var movies = Movies();

            List<Theater> theaters = new List<Theater>();

            for (int t = 1; t <= 2; t++) // 2 Theaters
            {
                var theater = new Theater
                {
                    Id = t,
                    Name = $"Theater {t}",
                    Location = $"City {t}",
                    Screens = new List<Screen>()
                };
                for (int s = 1; s <= 3; s++) // 3 Screens
                {
                    var screen = new Screen
                    {
                        Id = s,
                        Shows = new List<Show>()
                    };
                    theater.Screens.Add(screen);
                    for (int sh = 0; sh < 2; sh++) // 2 Shows per screen
                    {
                        var movie = movies[sh % movies.Count];
                        var showTime = DateTime.Now.AddHours(sh * 3);
                        var show = new Show
                        {
                            Id = 10 + sh,
                            Movie = movie,
                            StartTime = showTime,
                            EndTime = showTime.AddMinutes((double)movie.DurationInMinutes),
                            ShowSeats = GenerateShowSeats()
                        };
                        screen.Shows.Add(show);
                    }
                }

                theaters.Add(theater);
            }
            return theaters;
        }

        public static List<Movie> Movies()
        {
            return new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", DurationInMinutes = 148, ReleaseDate = DateTime.Now.AddYears(-10) },
            new Movie { Id = 2, Title = "Interstellar", Genre = "Sci-Fi", DurationInMinutes = 169, ReleaseDate = DateTime.Now.AddYears(-9) },
            new Movie { Id = 3, Title = "Dunkirk", Genre = "War", DurationInMinutes = 106, ReleaseDate = DateTime.Now.AddYears(-7) },
            new Movie { Id = 4, Title = "Tenet", Genre = "Sci-Fi", DurationInMinutes = 150, ReleaseDate = DateTime.Now.AddYears(-3) }
        };
        }

        private static List<ShowSeat> GenerateShowSeats()
        {
            var showSeats = new List<ShowSeat>();
            var random = new Random();

            for (int i = 1; i <= 60; i++) // 60 Seats per show
            {
                var seatType = (SeatType)(i % 3); // Cycle through Default, Recliner, Comfortable
                var seat = new Seat
                {
                    Id = i,
                    SeatType = seatType
                };

                showSeats.Add(new ShowSeat
                {
                    Seat = seat,
                    IsAvailable = true
                });
            }

            return showSeats;
        }
    }

}
