using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    [Route("/eventcategory")]
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);

        }
        [HttpGet("create")]
        public IActionResult Create()
        {

            AddEventCategoryViewModel addEventCategoryViewModel = new();
            if (ModelState.IsValid)
            {
                EventCategory newEventCategoty = new EventCategory
                {
                    Name = addEventViewModel.Name,
                };

                context.EventCategory.Add(newEventCategoty);
                context.SaveChanges();
            }

            return View(addEventViewModel);
        }

        public IActionResult ProcessCreateEventCategoryForm()
        {
            return View();
        }
    }
}

