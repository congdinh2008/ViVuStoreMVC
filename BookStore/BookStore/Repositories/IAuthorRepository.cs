using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
    }
}