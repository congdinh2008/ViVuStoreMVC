﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ViVuStoreDbContext _context;

        public BookRepository(ViVuStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books
        {
            get
            {
                return _context.Books.Include(c => c.Category);
            }
        }

        public Book GetBookById(Guid bookId)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookId);
        }
    }
}
