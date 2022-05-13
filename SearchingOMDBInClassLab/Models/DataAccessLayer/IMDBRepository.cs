using Microsoft.AspNetCore.Mvc;

namespace SearchingOMDBInClassLab.Models.DataAccessLayer
{
    public class IMDBRepository : IIMDBRepository
    {

        //2b. This is going to grab the title from the input on the page. Call the API, conver the JSOn, return the movie Model to the view for MovieSearch
        //Have to put await before this to confirm that the process is done. 
        //Make this method provide so that the public can't visit this in their URL. 
        //We are going to remove this from the controller to the DataAccess Layer
        //This prevent "Code Smells" => preventing you from not being efficient by repeating your code 
        //This is why we put this in a model so that it can be grabbed by any controller!!!

      
        public async Task<MovieInfo> SearchMovie(string searchTerm)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://www.omdbapi.com");

            var response = await client.GetFromJsonAsync<MovieInfo>("?t=" + searchTerm + "&apiKey=5785a2a5");

            return response;
        }
    }
}
