using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using NoteTakingApp.Domain;
using NoteTakingApp.WebApp.Models;

namespace NoteTakingApp.WebApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly IRepository _repo;

        public NoteController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetNotes());
        }

        public IActionResult Details(int id)
        {
            // bad: should have a repo implementation to just get one note
            return View(_repo.GetNotes().First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // form submission (by default)
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedNote viewModel)
        {
            // ASP.NET "model binding"
            // - fill in action method parameters with data from the request
            //   (URL path, URL query string, form data, etc.)
            //   based on compatible data type and name.

            // validate all action method parameters as user input
            if (!ModelState.IsValid)
            {
                // if ModelState has errors, that can influence view rendering
                // (the validation tag helpers look at it)
                return View(viewModel);
                //return View("ErrorMessage", model: "invalid");
            }

            var note = new Note { Text = viewModel.Text };

            try
            {
                _repo.AddNote(note);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(key: "Text", errorMessage: e.Message);
                ModelState.AddModelError(key: "", errorMessage: "general errors could go up here");
                return View(viewModel);
            }

            //return View("Details", note);
            return RedirectToAction("Details", new { id = note.Id });
        }
    }
}
