using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApp3.Data;
using WebApp3.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

using Microsoft.AspNetCore.Identity;

namespace WebApp3.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
      

        public CommunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: Communities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Community.ToListAsync());
        }
      
        // GET: Communities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .FirstOrDefaultAsync(m => m.id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // GET: Communities/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        

        // POST: Communities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserName,Description,Pic, Name")] Community community, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //string stringFileName = UploadFile(community);
                //community.Pic = stringFileName;
                //if (community.Pic != null)
                //{
                //    var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
                //    pic.CopyTo(new FileStream(fileName, FileMode.Create));
                //}
                
                community.UserName = User.Identity.Name;
                UploadFile(file, community);
                _context.Add(community);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(community);
        }

        public void UploadFile(IFormFile file, Community community)
        {
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
           
            if(community != null)
                {
                community.Pic = fileName;
                _context.Update(community);
            }
           
        }

        //public string UploadFile(Community community)
        //{
        //    string file = null;
        //}

        // GET: Communities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            return View(community);
        }

        // POST: Communities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UserName,Description,Pic, Name")] Community community)
        {
            if (id != community.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    community.UserName = User.Identity.Name;
                    _context.Update(community);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityExists(community.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(community);
        }

        // GET: Communities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .FirstOrDefaultAsync(m => m.id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }
        //public async FileContentResult GetImage(int? id)
        //{
        //    Community community = await _context.Community
        //        .FirstOrDefaultAsync(m => m.id == id);

           
        //    if (community != null)
        //    {
        //        return File(community.bytePic, community.Pic);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        // POST: Communities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var community = await _context.Community.FindAsync(id);
            _context.Community.Remove(community);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(int id)
        {
            return _context.Community.Any(e => e.id == id);
        }
    }
}
