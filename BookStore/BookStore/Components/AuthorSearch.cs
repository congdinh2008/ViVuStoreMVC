using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Components
{
    public class AuthorSearch: ViewComponent
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorSearch(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IViewComponentResult Invoke()
        {
            var authors = _authorRepository
                .GetAuthors().OrderBy(a => a.Name);
            return View(authors);
        }
    }
}
