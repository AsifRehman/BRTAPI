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
    builder.EntitySet<tbl_Ledger>("tbl_Ledger");
    builder.EntitySet<tbl_Party>("tbl_Party"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_LedgerController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_Ledger
        [EnableQuery]
        public IQueryable<tbl_Ledger> Gettbl_Ledger()
        {
            return db.tbl_Ledger;
        }

        // GET: odata/tbl_Ledger(5)
        [EnableQuery]
        public SingleResult<tbl_Ledger> Gettbl_Ledger([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Ledger.Where(tbl_Ledger => tbl_Ledger.ID == key));
        }

        // PUT: odata/tbl_Ledger(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<tbl_Ledger> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Ledger tbl_Ledger = db.tbl_Ledger.Find(key);
            if (tbl_Ledger == null)
            {
                return NotFound();
            }

            patch.Put(tbl_Ledger);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_LedgerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Ledger);
        }

        // POST: odata/tbl_Ledger
        public IHttpActionResult Post(tbl_Ledger tbl_Ledger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Ledger.Add(tbl_Ledger);
            db.SaveChanges();

            return Created(tbl_Ledger);
        }

        // PATCH: odata/tbl_Ledger(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_Ledger> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Ledger tbl_Ledger = db.tbl_Ledger.Find(key);
            if (tbl_Ledger == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_Ledger);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_LedgerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_Ledger);
        }

        // DELETE: odata/tbl_Ledger(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_Ledger tbl_Ledger = db.tbl_Ledger.Find(key);
            if (tbl_Ledger == null)
            {
                return NotFound();
            }

            db.tbl_Ledger.Remove(tbl_Ledger);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_Ledger(5)/tbl_Party
        [EnableQuery]
        public SingleResult<tbl_Party> Gettbl_Party([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_Ledger.Where(m => m.ID == key).Select(m => m.tbl_Party));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_LedgerExists(int key)
        {
            return db.tbl_Ledger.Count(e => e.ID == key) > 0;
        }
    }
}
