using Basic_Web_Project_Phonebook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Web_Project_Phonebook.Controllers
{
    public class PhonebookController : Controller
    {
        public IActionResult Index()
        {
            return View(DataContext.Contacts);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                DataContext.Contacts.Add(contact);
            }
            else
            {
                TempData["Error"] = "Въведените данни не са валидни!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
