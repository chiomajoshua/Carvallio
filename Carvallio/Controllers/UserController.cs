using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Carvallio.Controllers
{
    public class UserController : ApiController
    {
        private readonly CarvallioDBEntities db = new CarvallioDBEntities();

        // GET: api/User
        public IQueryable<UserTB> GetUserTBs()
        {
            return db.UserTBs;
        }

        // GET: api/User/5
        [ResponseType(typeof(UserTB))]
        public async Task<IHttpActionResult> GetUserTB(int id)
        {
            var userTB = await db.UserTBs.FindAsync(id);
            if (userTB == null)
                return NotFound();

            return Ok(userTB);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserTB(int id, UserTB userTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != userTB.ID)
                return BadRequest();

            db.Entry(userTB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTBExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(UserTB))]
        public async Task<IHttpActionResult> PostUserTB(UserTB userTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.UserTBs.Add(userTB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = userTB.ID}, userTB);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(UserTB))]
        public async Task<IHttpActionResult> DeleteUserTB(int id)
        {
            var userTB = await db.UserTBs.FindAsync(id);
            if (userTB == null)
                return NotFound();

            db.UserTBs.Remove(userTB);
            await db.SaveChangesAsync();

            return Ok(userTB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool UserTBExists(int id)
        {
            return db.UserTBs.Count(e => e.ID == id) > 0;
        }
    }
}