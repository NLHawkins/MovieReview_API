using MovieReview_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieReview_API.Controllers
{
    
    public class UserController : ApiController
    {
        Context db = new Context();

        [ResponseType(typeof(User))]
        public IHttpActionResult Get()
        {
            DbSet<User> results = db.Users;
            return Ok(results);
        }

        public IHttpActionResult Get(int id)
        {
            User result = db.Users.Find(id);
            return Ok(result);
        }

        public IHttpActionResult Post(User User)
        {
            db.Users.Add(User);
            db.SaveChanges();
            return Created("Get", User);
        }

        public IHttpActionResult Put(int id, User User)
        {
            User.Id = id;
            db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            User User = db.Users.Find(id);
            db.Users.Remove(User);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

