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
    builder.EntitySet<tbl_MHead>("tbl_MHead");
    builder.EntitySet<tbl_Head>("tbl_Head"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_MHeadController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_MHead
        [EnableQuery]
        public IQueryable<tbl_MHead> Gettbl_MHead()
        {
            return db.tbl_MHead;
        }

        // GET: odata/tbl_MHead(5)
        [EnableQuery]
        public SingleResult<tbl_MHead> Gettbl_MHead([FromODataUri] byte key)
        {
            return SingleResult.Create(db.tbl_MHead.Where(tbl_MHead => tbl_MHead.MHeadID == key));
        }

        // PUT: odata/tbl_MHead(5)
        public IHttpActionResult Put([FromODataUri] byte key, Delta<tbl_MHead> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_MHead tbl_MHead = db.tbl_MHead.Find(key);
            if (tbl_MHead == null)
            {
                return NotFound();
            }

            patch.Put(tbl_MHead);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_MHeadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_MHead);
        }

        // POST: odata/tbl_MHead
        public IHttpActionResult Post(tbl_MHead tbl_MHead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_MHead.Add(tbl_MHead);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_MHeadExists(tbl_MHead.MHeadID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tbl_MHead);
        }

        // PATCH: odata/tbl_MHead(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] byte key, Delta<tbl_MHead> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_MHead tbl_MHead = db.tbl_MHead.Find(key);
            if (tbl_MHead == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_MHead);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_MHeadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_MHead);
        }

        // DELETE: odata/tbl_MHead(5)
        public IHttpActionResult Delete([FromODataUri] byte key)
        {
            tbl_MHead tbl_MHead = db.tbl_MHead.Find(key);
            if (tbl_MHead == null)
            {
                return NotFound();
            }

            db.tbl_MHead.Remove(tbl_MHead);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_MHead(5)/tbl_Head
        [EnableQuery]
        public IQueryable<tbl_Head> Gettbl_Head([FromODataUri] byte key)
        {
            return db.tbl_MHead.Where(m => m.MHeadID == key).SelectMany(m => m.tbl_Head);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MHeadExists(byte key)
        {
            return db.tbl_MHead.Count(e => e.MHeadID == key) > 0;
        }
    }
}
