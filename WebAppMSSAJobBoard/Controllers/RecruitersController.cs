using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMSSAJobBoard;

namespace WebAppMSSAJobBoard.Controllers
{
    public class RecruitersController : Controller
    {
        private jobboardtaketwoEntities db = new jobboardtaketwoEntities();

        // GET: Recruiters
        public async Task<ActionResult> Index()
        {
            return View(await db.Recruiters.ToListAsync());
        }

        // GET: Recruiters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruiter recruiter = await db.Recruiters.FindAsync(id);
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            return View(recruiter);
        }

        // GET: Recruiters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recruiters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,FName,LName,eMailAddress,PhoneNumber,LinkedIn,CompanyName")] Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                db.Recruiters.Add(recruiter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recruiter);
        }

        // GET: Recruiters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruiter recruiter = await db.Recruiters.FindAsync(id);
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            return View(recruiter);
        }

        // POST: Recruiters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,FName,LName,eMailAddress,PhoneNumber,LinkedIn,CompanyName")] Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruiter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recruiter);
        }

        // GET: Recruiters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruiter recruiter = await db.Recruiters.FindAsync(id);
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            return View(recruiter);
        }

        // POST: Recruiters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recruiter recruiter = await db.Recruiters.FindAsync(id);
            db.Recruiters.Remove(recruiter);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
