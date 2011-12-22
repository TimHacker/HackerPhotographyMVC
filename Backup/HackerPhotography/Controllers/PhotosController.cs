using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackerPhotography.Models;

namespace HackerPhotography.Controllers
{   
    public class PhotosController : Controller
    {
		private readonly IAlbumRepository albumRepository;
		private readonly IPhotoRepository photoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PhotosController() : this(new AlbumRepository(), new PhotoRepository())
        {
        }

        public PhotosController(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
			this.albumRepository = albumRepository;
			this.photoRepository = photoRepository;
        }

        //
        // GET: /Photos/

        public ViewResult Index()
        {
            return View(photoRepository.AllIncluding(photo => photo.Album));
        }

        //
        // GET: /Photos/Details/5

        public ViewResult Details(int id)
        {
            return View(photoRepository.Find(id));
        }

        //
        // GET: /Photos/Create

        public ActionResult Create()
        {
			ViewBag.PossibleAlbums = albumRepository.All;
            return View();
        } 

        //
        // POST: /Photos/Create

        [HttpPost]
        public ActionResult Create(Photo photo)
        {
            if (ModelState.IsValid) {
                photoRepository.InsertOrUpdate(photo);
                photoRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAlbums = albumRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Photos/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleAlbums = albumRepository.All;
             return View(photoRepository.Find(id));
        }

        //
        // POST: /Photos/Edit/5

        [HttpPost]
        public ActionResult Edit(Photo photo)
        {
            if (ModelState.IsValid) {
                photoRepository.InsertOrUpdate(photo);
                photoRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAlbums = albumRepository.All;
				return View();
			}
        }

        //
        // GET: /Photos/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(photoRepository.Find(id));
        }

        //
        // POST: /Photos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            photoRepository.Delete(id);
            photoRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

