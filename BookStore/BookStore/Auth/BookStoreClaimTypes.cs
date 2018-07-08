using System.Collections.Generic;

namespace BookStore.Auth
{
    public static class BookStoreClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = 
            new List<string> { "Delete Book", "Add Book", "Age for ordering" };
    }
}
