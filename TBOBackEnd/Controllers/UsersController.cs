﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models;

namespace TBOBackEnd.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    private static string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    [HttpGet("[action]")]
    public IEnumerable<User> AllUsers()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new User
      {
        Id = $"{index}",
        FirstName = $"FName{index}",
        LastName = $"LName{index}",
      });
    }
    /*
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
      return View(await _context.Users.ToListAsync());
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.Users
          .FirstOrDefaultAsync(m => m.Id == id);
      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }

    // GET: Users/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] User user)
    {
      if (ModelState.IsValid)
      {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(user);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return View(user);
    }

    // POST: Users/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName")] User user)
    {
      if (id != user.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(user);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserExists(user.Id))
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
      return View(user);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.Users
          .FirstOrDefaultAsync(m => m.Id == id);
      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
      var user = await _context.Users.FindAsync(id);
      _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserExists(string id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
    */
  }
}
