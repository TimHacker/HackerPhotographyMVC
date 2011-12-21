using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackerPhotography.Models
{ 
    public class PhotoRepository : IPhotoRepository
    {
        HackerPhotographyContext context = new HackerPhotographyContext();

        public IQueryable<Photo> All
        {
            get { return context.Photos; }
        }

        public IQueryable<Photo> AllIncluding(params Expression<Func<Photo, object>>[] includeProperties)
        {
            IQueryable<Photo> query = context.Photos;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Photo Find(int id)
        {
            return context.Photos.Find(id);
        }

        public void InsertOrUpdate(Photo photo)
        {
            if (photo.PhotoId == default(int)) {
                // New entity
                context.Photos.Add(photo);
            } else {
                // Existing entity
                context.Entry(photo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IPhotoRepository
    {
        IQueryable<Photo> All { get; }
        IQueryable<Photo> AllIncluding(params Expression<Func<Photo, object>>[] includeProperties);
        Photo Find(int id);
        void InsertOrUpdate(Photo photo);
        void Delete(int id);
        void Save();
    }
}