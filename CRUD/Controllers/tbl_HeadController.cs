using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CRUD.Models;

namespace CRUD.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CRUD.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<tbl_Head>("tbl_Head");
    builder.EntitySet<tbl_MHead>("tbl_MHead"); 
    builder.EntitySet<tbl_PartyCateg>("tbl_PartyCateg"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_HeadController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_Head
        [EnableQuery]
        public IQueryable<tbl_Head> Gettbl_Head()
        {
            return db.tbl_Head;
        }

        // GET: odata/tbl_Head(5)
        [EnableQuery]
        public SingleResult<tbl_Head> Gettbl_Head([FromODataUri] short key)
        {
            return SingleResult.Create(db.tbl_Head.Where(tbl_Head => tbl_Head.HeadID == key));
        }

        // PUT: odata/tbl_Head(5)
        public IHttpActionResult Put([FromODataUri] short key, Delta<tbl_Head> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Head tbl_Head = db.tbl_Head.Find(key);
            if (tbl_Head == null)
            {
                return NotFound();
            }

            patch.Put(tbl_Head);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_HeadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Head);
        }

        // POST: odata/tbl_Head
        public IHttpActionResult Post(tbl_Head tbl_Head)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Head.Add(tbl_Head);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_HeadExists(tbl_Head.HeadID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tbl_Head);
        }

        // PATCH: odata/tbl_Head(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] short key, Delta<tbl_Head> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Head tbl_Head = db.tbl_Head.Find(key);
            if (tbl_Head == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_Head);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_HeadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Head);
        }

        // DELETE: odata/tbl_Head(5)
        public IHttpActionResult Delete([FromODataUri] short key)
        {
            tbl_Head tbl_Head = db.tbl_Head.Find(key);
            if (tbl_Head == null)
            {
                return NotFound();
            }

            db.tbl_Head.Remove(tbl_Head);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_Head(5)/tbl_MHead
        [EnableQuery]
        public SingleResult<tbl_MHead> Gettbl_MHead([FromODataUri] short key)
        {
            return SingleResult.Create(db.tbl_Head.Where(m => m.HeadID == key).Select(m => m.tbl_MHead));
        }

        // GET: odata/tbl_Head(5)/tbl_PartyCateg
        [EnableQuery]
        public IQueryable<tbl_PartyCateg> Gettbl_PartyCateg([FromODataUri] short key)
        {
            return db.tbl_Head.Where(m => m.HeadID == key).SelectMany(m => m.tbl_PartyCateg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_HeadExists(short key)
        {
            return db.tbl_Head.Count(e => e.HeadID == key) > 0;
        }
    }
}
