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
    public class ReviewController : ApiController
    {
        Context db = new Context();

        
        public IQueryable<Review> Get()
        {
            DbSet<Review> results = db.Reviews;
            return results;
        }

        public IHttpActionResult Get(int id)
        {
            Review result = db.Reviews.Find(id);
            return Ok(result);
        }

        public IHttpActionResult Post(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return Created("Get", Review);
        }

        public IHttpActionResult Put(int id, Review Review)
        {
            Review.Id = id;
            db.Entry(Review).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Review Review = db.Reviews.Find(id);
            db.Reviews.Remove(Review);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
