using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCine.BAL.DTO;

namespace ManagerDataHttpTest
{
    [TestClass]
    public class UnitTest1
    {
    
        [TestMethod]
        public async Task FIlmpost()
        {

            //var connectionService = new ConectionService {Uri = "api/film"};
            var filmsTest = new FilmsDto()
            {
                HasInScreening = false,
                Title = "filmtest7",
                About = "",
                Actor = new List<ActorDto>() { new ActorDto() { Name = "actor" } },
                Affiche = new byte[0],
                AgePG = 1,
                Country = new List<CountryDto>() { new CountryDto() { Country1 = "country" } },
                DirectorProduction = "director",
                Duration = TimeSpan.Parse("2:00:00"),
                Premiere =
                    new List<PremiereDto>()
                    {
                        new PremiereDto() {PremiereDate = DateTime.Parse("17.02.2017"), CountryPremieres = "here"}

                    },
                Genre = new List<GenreDto> { new GenreDto() { GenreName = "affaf" } },
                Seance = new List<SeanceDto>()
            }; 
            //var result = await connectionService.Create(filmsTest);
            //Assert.IsTrue(result!=null);
        }

        [TestMethod]
        public void PostSeances()
        {
            //    var filmHttpProxy = new FilmDataHttpProxy();
            //    var film = new FilmsDto()
            //    {
            //        Title = "gafjhafbakjjbvjnlv",
            //        HasInScreening = false
            //    };
            //    var filmadded= filmHttpProxy.AddFilm(film);

            //    var cinemaHttp = new CinemaDataHttpProxy();
            //    var cinema = new CinemaDto()
            //    {
            //        CinemaName = "testCInema"
            //    };
            //    var cinemaAdded = cinemaHttp.AddCinema(cinema);

            //    var SeancesHttp = new SeancesDataHttpProxy();
            //    var seance = new SeancesDto
            //    {
            //        Cinema = cinemaAdded,
            //        Films = filmadded,
            //        PlayingDate = DateTime.Today.Date
            //    };
            //    var addedSeances = SeancesHttp.AddSeances(seance);
            //    Assert.IsTrue(addedSeances.Cinema != null);
        }

    }
}
