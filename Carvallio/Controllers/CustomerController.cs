using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Carvallio.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CarvallioDBEntities db = new CarvallioDBEntities();

        // GET: api/Customer
        public IQueryable<CustomerTB> GetCustomerTBs()
        {
            return db.CustomerTBs;
        }

        // GET: api/Customer/5
        [ResponseType(typeof(CustomerTB))]
        public IHttpActionResult GetCustomerTB(string id)
        {
            var customerTB = db.CustomerTBs.Find(id);
            if (customerTB == null)
                return NotFound();

            return Ok(customerTB);
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerTB(string id, CustomerTB customerTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != customerTB.Plate_Number)
                return BadRequest();

            db.Entry(customerTB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTBExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customer
        [ResponseType(typeof(CustomerTB))]
        public IHttpActionResult PostCustomerTB(CustomerTB customerTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.CustomerTBs.Add(customerTB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerTBExists(customerTB.Plate_Number))
                    return Conflict();
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = customerTB.Plate_Number}, customerTB);
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(CustomerTB))]
        public IHttpActionResult DeleteCustomerTB(string id)
        {
            var customerTB = db.CustomerTBs.Find(id);
            if (customerTB == null)
                return NotFound();

            db.CustomerTBs.Remove(customerTB);
            db.SaveChanges();

            return Ok(customerTB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool CustomerTBExists(string id)
        {
            return db.CustomerTBs.Count(e => e.Plate_Number == id) > 0;
        }
    }
}