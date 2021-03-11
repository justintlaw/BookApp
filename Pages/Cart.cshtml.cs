using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Infrastructure;
using BookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace BookApp.Pages
{
    public class CartModel : PageModel
    {
        private IBookAppRepository repository;

        public CartModel (IBookAppRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(elem => elem.BookId == bookId);

            Cart.AddItem(book, 1);

            Cart = HttpContext.Session.GetJson<SessionCart>("Cart") ?? new SessionCart();

            HttpContext.Session.SetJson("Cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostDelete(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(elem => elem.BookId == bookId);

            Cart.RemoveLine(book);

            Cart = HttpContext.Session.GetJson<SessionCart>("Cart") ?? new SessionCart();

            HttpContext.Session.SetJson("Cart", Cart);

            return RedirectToPage(new { returnUrl = "/" });
        }
    }
}
