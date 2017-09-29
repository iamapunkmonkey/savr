using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using savr.Contexts;
using savr.Lib;
using savr.Models;

namespace savr.Controllers
{
    [Route("api/[controller]")]
    public class BookmarksController : Controller
    {
        public BookmarksController(DataContext _context)
        {
            Context = _context;
        }

        private DataContext Context { get; }

        [HttpGet]
        public IEnumerable<Bookmark> Get()
        {
            return Context.Bookmarks.Where(b => !b.IsDeleted);
        }

        [HttpGet("{id}")]
        public Bookmark Get(Guid id)
        {
            return Context.Bookmarks.FirstOrDefault(b => b.Id == id);
        }

        [HttpPost]
        public Guid Post([FromBody] Bookmark bookmark)
        {
            return ProcessBookmark.NewBookmark(bookmark.Url);
        }

        [HttpPut]
        public void Update([FromBody] Bookmark bookmark)
        {
            var bookmarkItem = Context.Bookmarks.FirstOrDefault(b => b.Id == bookmark.Id);

            if (bookmarkItem == null) return;

            bookmarkItem.Title = bookmark.Title;

            if (bookmark.Url != bookmarkItem.Url)
                bookmarkItem.Title = ProcessBookmark.ProcessTitle(bookmark.Url);

            Context.Bookmarks.Update(bookmarkItem);
            Context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var bookmark = Context.Bookmarks.FirstOrDefault(b => b.Id == id);

            if (bookmark == null) return;

            bookmark.IsDeleted = true;
            Context.Bookmarks.Update(bookmark);
            Context.SaveChanges();
        }
    }
}