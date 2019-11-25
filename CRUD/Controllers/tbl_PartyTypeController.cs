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
    builder.EntitySet<tbl_PartyType>("tbl_PartyType");
    builder.EntitySet<tbl_Party>("tbl_Party"); 
    builder.EntitySet<tbl_PartyCateg>("tbl_PartyCateg"); 
    builder.EntitySet<tbl_Ledger>("tbl_Ledger");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tbl_PartyTypeController : ODataController
    {
        private Db1 db = new Db1();

        // GET: odata/tbl_PartyType
        [EnableQuery]
        public IQueryable<tbl_PartyType> Gettbl_PartyType()
        {
            return db.tbl_PartyType;
        }

        // GET: odata/tbl_PartyType(5)
        [EnableQuery]
        public SingleResult<tbl_PartyType> Gettbl_PartyType([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_PartyType.Where(tbl_PartyType => tbl_PartyType.PartyTypeID == key));
        }

        // PUT: odata/tbl_PartyType(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<tbl_PartyType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_PartyType tbl_PartyType = db.tbl_PartyType.Find(key);
            if (tbl_PartyType == null)
            {
                return NotFound();
            }

            patch.Put(tbl_PartyType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_PartyType);
        }

        // POST: odata/tbl_PartyType
        public IHttpActionResult Post(tbl_PartyType tbl_PartyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_PartyType.Add(tbl_PartyType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_PartyTypeExists(tbl_PartyType.PartyTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tbl_PartyType);
        }

        // PATCH: odata/tbl_PartyType(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<tbl_PartyType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_PartyType tbl_PartyType = db.tbl_PartyType.Find(key);
            if (tbl_PartyType == null)
            {
                return NotFound();
            }

            patch.Patch(tbl_PartyType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PartyTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tbl_PartyType);
        }

        // DELETE: odata/tbl_PartyType(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            tbl_PartyType tbl_PartyType = db.tbl_PartyType.Find(key);
            if (tbl_PartyType == null)
            {
                return NotFound();
            }

            db.tbl_PartyType.Remove(tbl_PartyType);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tbl_PartyType(5)/tbl_Party
        [EnableQuery]
        public IQueryable<tbl_Party> Gettbl_Party([FromODataUri] int key)
        {
            return db.tbl_PartyType.Where(m => m.PartyTypeID == key).SelectMany(m => m.tbl_Party);
        }

        // GET: odata/tbl_PartyType(5)/tbl_PartyCateg
        [EnableQuery]
        public SingleResult<tbl_PartyCateg> Gettbl_PartyCateg([FromODataUri] int key)
        {
            return SingleResult.Create(db.tbl_PartyType.Where(m => m.PartyTypeID == key).Select(m => m.tbl_PartyCateg));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PartyTypeExists(int key)
        {
            return db.tbl_PartyType.Count(e => e.PartyTypeID == key) > 0;
        }
    }
}
