using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackerPhotography.Models;

namespace HackerPhotography.Controllers
{   
    public class AlbumsController : Controller
    {
		private readonly IAlbumRepository albumRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public AlbumsController() : this(new AlbumRepository())
        {
        }

        public AlbumsController(IAlbumRepository albumRepository)
        {
			this.albumRepository = albumRepository;
        }

        //
        // GET: /Albums/

        public ViewResult Index()
        {
            return View(albumRepository.AllIncluding(album => album.Photos));
        }

        //
        // GET: /Albums/Details/5

        public ViewResult Details(int id)
        {
            return View(albumRepository.Find(id));
        }

        //
        // GET: /Albums/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Albums/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid) {
                albumRepository.InsertOrUpdate(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Albums/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(albumRepository.Find(id));
        }

        //
        // POST: /Albums/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid) {
                albumRepository.InsertOrUpdate(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Albums/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(albumRepository.Find(id));
        }

        //
        // POST: /Albums/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            albumRepository.Delete(id);
            albumRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

