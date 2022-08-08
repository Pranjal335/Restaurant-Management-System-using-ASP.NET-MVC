﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Web.Data;
using Hotel.Web.Models;

namespace Hotel.Web.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant/OrderDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDetails.Include(o => o.Menus).Include(o => o.Orders);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Restaurant/OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Menus)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: Restaurant/OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["DishID"] = new SelectList(_context.Menus, "DishID", "DishName");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: Restaurant/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailId,OrderId,DishID,Quantity")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishID"] = new SelectList(_context.Menus, "DishID", "DishName", orderDetails.DishID);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetails.OrderId);
            return View(orderDetails);
        }

        // GET: Restaurant/OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            ViewData["DishID"] = new SelectList(_context.Menus, "DishID", "DishName", orderDetails.DishID);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetails.OrderId);
            return View(orderDetails);
        }

        // POST: Restaurant/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailId,OrderId,DishID,Quantity")] OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.OrderDetailId))
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
            ViewData["DishID"] = new SelectList(_context.Menus, "DishID", "DishName", orderDetails.DishID);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetails.OrderId);
            return View(orderDetails);
        }

        // GET: Restaurant/OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Menus)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: Restaurant/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailId == id);
        }
    }
}
