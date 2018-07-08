using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
    }
}