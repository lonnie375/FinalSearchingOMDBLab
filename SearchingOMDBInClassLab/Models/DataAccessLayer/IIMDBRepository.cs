namespace SearchingOMDBInClassLab.Models.DataAccessLayer
{
    public interface IIMDBRepository
    {
        //This is interface because we know that the information below exists. The interface requires that the class uses this information 
        //and they can't change it unless they can't change it in the interface. 
        Task<MovieInfo> SearchMovie(string searchTerm);
    }
}
