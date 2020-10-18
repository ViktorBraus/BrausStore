using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUA1.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Books);
        }
        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        }
        public ViewResult Create()
        {
            return View();
        }
 
        public ActionResult Delete(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            repository.DeleteBook(book);
            TempData["message"] = string.Format("Видалення Книги \"{0}\" здійснилось успішно", book.Name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Книга \"{0}\" додана до списку", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] =string.Format("Зміна інформації про книгу \"{0}\" збережена",book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
    }
}