using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Carvallio.Controllers
{
    public class InsuranceController : ApiController
    {
        private readonly CarvallioDBEntities db = new CarvallioDBEntities();

        // GET: api/Insurance
        public IQueryable<InsuranceTB> GetInsuranceTBs()
        {
            return db.InsuranceTBs;
        }

        // GET: api/Insurance/5
        [ResponseType(typeof(InsuranceTB))]
        public async Task<IHttpActionResult> GetInsuranceTB(int id)
        {
            var insuranceTB = await db.InsuranceTBs.FindAsync(id);
            if (insuranceTB == null)
                return NotFound();

            return Ok(insuranceTB);
        }

        // PUT: api/Insurance/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInsuranceTB(int id, InsuranceTB insuranceTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != insuranceTB.ID)
                return BadRequest();

            db.Entry(insuranceTB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceTBExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Insurance
        [ResponseType(typeof(InsuranceTB))]
        public async Task<IHttpActionResult> PostInsuranceTB(InsuranceTB insuranceTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.InsuranceTBs.Add(insuranceTB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = insuranceTB.ID}, insuranceTB);
        }

        // DELETE: api/Insurance/5
        [ResponseType(typeof(InsuranceTB))]
        public async Task<IHttpActionResult> DeleteInsuranceTB(int id)
        {
            var insuranceTB = await db.InsuranceTBs.FindAsync(id);
            if (insuranceTB == null)
                return NotFound();

            db.InsuranceTBs.Remove(insuranceTB);
            await db.SaveChangesAsync();

            return Ok(insuranceTB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool InsuranceTBExists(int id)
        {
            return db.InsuranceTBs.Count(e => e.ID == id) > 0;
        }
    }
}