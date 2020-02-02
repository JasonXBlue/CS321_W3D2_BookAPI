using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D2_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            // TODO: keep a reference to the BookContext in _bookContext
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher publisher)
        {
            // TODO: implement add
            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();
            return publisher;
        }

        public Publisher Get(int id)
        {
            // TODO: return the specified Publisher using Find()
            return _bookContext.Publishers
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            // TODO: return all Publishers using ToList()
            return _bookContext.Publishers
                .Include(a => a.Books)
                .ToList();
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            // get the ToDo object in the current list with this id 
            var currentPublisher = _bookContext.Publishers.Find(updatedPublisher.Id);

            // return null if todo to update isn't found
            if (currentPublisher == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatedPublisher);

            // update the todo and save
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }

        public void Remove(Publisher publisher)
        {
            // TODO: remove the publisher
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }
    }
}
