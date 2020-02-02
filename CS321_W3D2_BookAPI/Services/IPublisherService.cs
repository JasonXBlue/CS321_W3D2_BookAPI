using System;
using System.Collections.Generic;
using CS321_W3D2_BookAPI.Models;

namespace CS321_W3D2_BookAPI.Services
{
    public interface IPublisherService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        Publisher Add(Publisher publisher);
        // read
        Publisher Get(int id);
        // update
        Publisher Update(Publisher publisher);
        // delete
        void Remove(Publisher publisher);
        // list
        IEnumerable<Publisher> GetAll();
    }
}
