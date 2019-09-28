using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Clients.Models;

namespace Clients.Controllers
{
    public class clientsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/clients
        public IQueryable<clients> Getclients()
        {
            return db.clients;
        }

        // GET: api/clients/5
        [ResponseType(typeof(clients))]
        public IHttpActionResult Getclients(int id)
        {
            clients clients = db.clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclients(int id, clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clients.FriendID)
            {
                return BadRequest();
            }

            db.Entry(clients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/clients
        [ResponseType(typeof(clients))]
        public IHttpActionResult Postclients(clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clients.Add(clients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clients.FriendID }, clients);
        }

        // DELETE: api/clients/5
        [ResponseType(typeof(clients))]
        public IHttpActionResult Deleteclients(int id)
        {
            clients clients = db.clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.clients.Remove(clients);
            db.SaveChanges();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientsExists(int id)
        {
            return db.clients.Count(e => e.FriendID == id) > 0;
        }
    }
}