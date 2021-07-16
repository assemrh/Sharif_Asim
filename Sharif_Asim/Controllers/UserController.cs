using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sharif_Asim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sharif_Asim.Models.Dto;

namespace Sharif_Asim.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_userManager.Users.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            if (ModelState.IsValid) {
                var user = new User();
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                    return StatusCode(201, "User created Succefully");
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError("", e.Description));
            }
            return View(userDto);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(User NewUser)
        {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByIdAsync(NewUser.Id);
                user.Email = NewUser.Email;
                user.UserName = NewUser.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("List");
                }
                else {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));
                }
            }
            return View(NewUser);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByIdAsync(Id);

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("List");
                }
                else {
                    result.Errors.ToList().ForEach(a => ModelState.AddModelError("", a.Description));
                }
            }
            return View();
        }
    }
}
