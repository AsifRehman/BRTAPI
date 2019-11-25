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
    builder.EntitySet<tbl_Party>("tbl_Party");
    builder.EntitySet<tbl_Ledger>("tbl_Ledger"); 
    builder.EntitySet<tbl_PartyType>("tbl_PartyType"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_PartyController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_Party
        [EnableQuery]
        public IQueryable<tbl_Party> Gettbl_Party()
        {
            return db.tbl_Party;
        }

        // GET: odata/tbl_Party(5)
        [EnableQuery]
        public SingleResult<tbl_Party> Gettbl_Party([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Party.Where(tbl_Party => tbl_Party.PartyNameID == key));
        }

        // PUT: odata/tbl_Party(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<tbl_Party> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Party tbl_Party = db.tbl_Party.Find(key);
            if (tbl_Party == null)
            {
                return NotFound();
            }

            patch.Put(tbl_Party);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Party);
        }

        // POST: odata/tbl_Party
        public IHttpActionResult Post(tbl_Party tbl_Party)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Party.Add(tbl_Party);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_PartyExists(tbl_Party.PartyNameID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tbl_Party);
        }

        // PATCH: odata/tbl_Party(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_Party> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Party tbl_Party = db.tbl_Party.Find(key);
            if (tbl_Party == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_Party);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Party);
        }

        // DELETE: odata/tbl_Party(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_Party tbl_Party = db.tbl_Party.Find(key);
            if (tbl_Party == null)
            {
                return NotFound();
            }

            db.tbl_Party.Remove(tbl_Party);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_Party(5)/tbl_Ledger
        [EnableQuery]
        public IQueryable<tbl_Ledger> Gettbl_Ledger([FromODataUri] int key)
        {
            return db.tbl_Party.Where(m => m.PartyNameID == key).SelectMany(m => m.tbl_Ledger);
        }

        // GET: odata/tbl_Party(5)/tbl_PartyType
        [EnableQuery]
        public SingleResult<tbl_PartyType> Gettbl_PartyType([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Party.Where(m => m.PartyNameID == key).Select(m => m.tbl_PartyType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PartyExists(int key)
        {
            return db.tbl_Party.Count(e => e.PartyNameID == key) > 0;
        }
    }
}
