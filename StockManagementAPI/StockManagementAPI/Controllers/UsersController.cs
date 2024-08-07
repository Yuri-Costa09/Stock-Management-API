using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockManagementAPI.Data;
using StockManagementAPI.Models;
using StockManagementAPI.Repositories;

namespace StockManagementAPI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _userRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(id.Value);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,CreatedDate")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.InsertAsync(user);
                    await _userRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log exception
                    return StatusCode(500, "Internal server error");
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(id.Value);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,CreatedDate")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateAsync(id, user);
                    await _userRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    // Log exception
                    return StatusCode(500, "Internal server error");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(id.Value);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user != null)
                {
                    await _userRepository.DeleteAsync(id);
                    await _userRepository.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        private async Task<bool> UserExists(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return user != null;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }
    }
}
