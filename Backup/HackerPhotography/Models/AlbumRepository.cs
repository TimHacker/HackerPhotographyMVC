using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HackerPhotography.Models
{ 
    public class AlbumRepository : IAlbumRepository
    {
        HackerPhotographyContext context = new HackerPhotographyContext();

        public IQueryable<Album> All
        {
            get { return context.Albums; }
        }

        public IQueryable<Album> AllIncluding(params Expression<Func<Album, object>>[] includeProperties)
        {
            IQueryable<Album> query = context.Albums;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Album Find(int id)
        {
            return context.Albums.Find(id);
        }

        public void InsertOrUpdate(Album album)
        {
            if (album.AlbumId == default(int)) {
                // New entity
                context.Albums.Add(album);
            } else {
                // Existing entity
                context.Entry(album).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var album = context.Albums.Find(id);
            context.Albums.Remove(album);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IAlbumRepository
    {
        IQueryable<Album> All { get; }
        IQueryable<Album> AllIncluding(params Expression<Func<Album, object>>[] includeProperties);
        Album Find(int id);
        void InsertOrUpdate(Album album);
        void Delete(int id);
        void Save();
    }
}