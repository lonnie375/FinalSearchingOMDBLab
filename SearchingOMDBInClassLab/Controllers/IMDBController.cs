using Microsoft.AspNetCore.Mvc;
using SearchingOMDBInClassLab.Models;
using SearchingOMDBInClassLab.Models.DataAccessLayer;
using System.Diagnostics;

namespace SearchingOMDBInClassLab.Controllers
{
    public class IMDBController : Controller
    {
        private readonly IIMDBRepository _iMDBRepository;

        public IMDBController(IIMDBRepository iMDBRepository)
        {
            _iMDBRepository = iMDBRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
            return View();
        }

        public IActionResult MultiMovieSearch()
        {
            return View();
        }
  

        //This action occurs when they hit the submit button 
        //The controller has to go through the interface to the class. This is done for security purposes. 
        [HttpPost]
        public async Task<ActionResult> MovieSearch(SearchMovie test)
        {
            //This is needed in order to search for your movie 
            MovieInfo movieResponse = await _iMDBRepository.SearchMovie(test.SearchTerm);
            return RedirectToAction("MovieResult", movieResponse);

        }

        public IActionResult MovieResult(MovieInfo movie)
        {
            return View(movie);
        }

     
       [HttpPost]
       public async Task<IActionResult> MultiMovieResult (MultiMovieSearch movieNight)
       {
           //create a list with nothing in it. 
           List<MovieInfo> movieList = new List<MovieInfo>();

           //add items to the list 
           movieList.Add(await _iMDBRepository.SearchMovie(movieNight.Movie1));
           movieList.Add(await _iMDBRepository.SearchMovie(movieNight.Movie2));
           movieList.Add(await _iMDBRepository.SearchMovie(movieNight.Movie3));

           //return the list of movies to the view 
           return View(movieList);
       }
       
       public async Task<IActionResult> MultiMovieResult(List<MovieInfo> movies)
       {
           return View(movies);
       }
      
    }
}
