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
    builder.EntitySet<tbl_PartyCateg>("tbl_PartyCateg");
    builder.EntitySet<tbl_Head>("tbl_Head"); 
    builder.EntitySet<tbl_PartyType>("tbl_PartyType"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_PartyCategController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_PartyCateg
        [EnableQuery]
        public IQueryable<tbl_PartyCateg> Gettbl_PartyCateg()
        {
            return db.tbl_PartyCateg;
        }

        // GET: odata/tbl_PartyCateg(5)
        [EnableQuery]
        public SingleResult<tbl_PartyCateg> Gettbl_PartyCateg([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_PartyCateg.Where(tbl_PartyCateg => tbl_PartyCateg.PartyCategID == key));
        }

        // PUT: odata/tbl_PartyCateg(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<tbl_PartyCateg> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_PartyCateg tbl_PartyCateg = db.tbl_PartyCateg.Find(key);
            if (tbl_PartyCateg == null)
            {
                return NotFound();
            }

            patch.Put(tbl_PartyCateg);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyCategExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_PartyCateg);
        }

        // POST: odata/tbl_PartyCateg
        public IHttpActionResult Post(tbl_PartyCateg tbl_PartyCateg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_PartyCateg.Add(tbl_PartyCateg);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_PartyCategExists(tbl_PartyCateg.PartyCategID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tbl_PartyCateg);
        }

        // PATCH: odata/tbl_PartyCateg(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_PartyCateg> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_PartyCateg tbl_PartyCateg = db.tbl_PartyCateg.Find(key);
            if (tbl_PartyCateg == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_PartyCateg);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyCategExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_PartyCateg);
        }

        // DELETE: odata/tbl_PartyCateg(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_PartyCateg tbl_PartyCateg = db.tbl_PartyCateg.Find(key);
            if (tbl_PartyCateg == null)
            {
                return NotFound();
            }

            db.tbl_PartyCateg.Remove(tbl_PartyCateg);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_PartyCateg(5)/tbl_Head
        [EnableQuery]
        public SingleResult<tbl_Head> Gettbl_Head([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_PartyCateg.Where(m => m.PartyCategID == key).Select(m => m.tbl_Head));
        }

        // GET: odata/tbl_PartyCateg(5)/tbl_PartyType
        [EnableQuery]
        public IQueryable<tbl_PartyType> Gettbl_PartyType([FromODataUri] int key)
        {
            return db.tbl_PartyCateg.Where(m => m.PartyCategID == key).SelectMany(m => m.tbl_PartyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PartyCategExists(int key)
        {
            return db.tbl_PartyCateg.Count(e => e.PartyCategID == key) > 0;
        }
    }
}
