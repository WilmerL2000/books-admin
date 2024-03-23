using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {

                return View(context.Books.ToList());
            }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
			using (DbModels context = new DbModels())
			{

				return View(context.Books.Where(x=> x.id == id).FirstOrDefault());
			}
		}

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Books book)
        {
            try
            {
				using (DbModels context = new DbModels())
				{
                    context.Books.Add(book);
                    context.SaveChanges();
				}

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
				return View(context.Books.Where(x => x.id == id).FirstOrDefault());
			}
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Books book)
        {
            try
            {
				using (DbModels context = new DbModels())
				{
					context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges();
				}

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
			using (DbModels context = new DbModels())
			{
				return View(context.Books.Where(x => x.id == id).FirstOrDefault());
			}
		}

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                { 
                    Books book = context.Books.Where(x=> x.id == id).FirstOrDefault();
                    context.Books.Remove(book);
                    context.SaveChanges();
                }

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
