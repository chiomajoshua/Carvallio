using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Carvallio.Controllers
{
    public class UserRoleController : ApiController
    {
        private readonly CarvallioDBEntities db = new CarvallioDBEntities();

        // GET: api/UserRole
        public IQueryable<User_RoleTB> GetUser_RoleTB()
        {
            return db.User_RoleTB;
        }

        // GET: api/UserRole/5
        [ResponseType(typeof(User_RoleTB))]
        public async Task<IHttpActionResult> GetUser_RoleTB(int id)
        {
            var user_RoleTB = await db.User_RoleTB.FindAsync(id);
            if (user_RoleTB == null)
                return NotFound();

            return Ok(user_RoleTB);
        }

        // PUT: api/UserRole/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser_RoleTB(int id, User_RoleTB user_RoleTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != user_RoleTB.ID)
                return BadRequest();

            db.Entry(user_RoleTB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_RoleTBExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserRole
        [ResponseType(typeof(User_RoleTB))]
        public async Task<IHttpActionResult> PostUser_RoleTB(User_RoleTB user_RoleTB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.User_RoleTB.Add(user_RoleTB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = user_RoleTB.ID}, user_RoleTB);
        }

        // DELETE: api/UserRole/5
        [ResponseType(typeof(User_RoleTB))]
        public async Task<IHttpActionResult> DeleteUser_RoleTB(int id)
        {
            var user_RoleTB = await db.User_RoleTB.FindAsync(id);
            if (user_RoleTB == null)
                return NotFound();

            db.User_RoleTB.Remove(user_RoleTB);
            await db.SaveChangesAsync();

            return Ok(user_RoleTB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool User_RoleTBExists(int id)
        {
            return db.User_RoleTB.Count(e => e.ID == id) > 0;
        }
    }
}