namespace Homies.Controllers
{
    using Homies.Data;
    using Homies.Data.Entities;
    using Homies.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Security.Claims;
    using Type = Data.Entities.Type;

    public class EventController : Controller
    {

        private readonly HomiesDbContext dbContext;
        public EventController(HomiesDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Join(int Id)
        {

            try
            {
                string userId = GetUserId();

                EventParticipant eventParticipant = new EventParticipant()
                {
                    EventId = Id,
                    HelperId = userId
                };

                dbContext.EventParticipants.Add(eventParticipant);

                await dbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Invalid Event Id");
            }
            return RedirectToAction(nameof(Joined));

        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var events = await dbContext
                .EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new EventViewModel
            {
                Name = ep.Event.Name,
                Start = ep.Event.Start.ToString("dd/MM/yyyy H:mm"),
                Type = ep.Event.Type.Name,
                Id = ep.Event.Id
            }).ToListAsync();


            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int Id)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var eventToLeave = await dbContext
                .EventParticipants
                .FirstOrDefaultAsync(ep => ep.EventId == Id && ep.HelperId == userId);

            if (eventToLeave != null)
            {
                dbContext.EventParticipants.Remove(eventToLeave);

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {

            var model = await dbContext.Events.Where(x => x.Id.Equals(Id)).Select(e => new EditEventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                End = e.End.ToString("dd/MM/yyyy H:mm"),
                TypeId = e.Type.Id,

            }).SingleOrDefaultAsync();


            if (model == null)
            {
                throw new ArgumentException("Invalid Event Id");
            }

            model.Types = await GetTypesAsync();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEventViewModel editEventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editEventViewModel);
            }

            try
            {

                var @event = await dbContext
                .Events
                .FindAsync(editEventViewModel.Id);

                if (@event != null)
                {
                    @event.Name = editEventViewModel.Name;
                    @event.Description = editEventViewModel.Description;
                    @event.Start = DateTime.Parse(editEventViewModel.Start);
                    @event.End = DateTime.Parse(editEventViewModel.End);
                    @event.TypeId = editEventViewModel.TypeId;

                }

                await dbContext.SaveChangesAsync();


                return RedirectToAction(nameof(All));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Invalid Event Id");

                return View(editEventViewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {

            var model = await dbContext.Events.Where(x => x.Id.Equals(Id)).Select(e => new DetailsViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                Organiser = e.Organiser.UserName,
                Start = e.Start,
                End = e.End,
                Type = e.Type.Name

            }).SingleOrDefaultAsync();


            if (model == null)
            {
                throw new ArgumentException("Invalid Event Id");
            }

            return View(model);

        }

        public async Task<IActionResult> All()
        {

            var allEvents = await dbContext.Events.Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString("dd/MM/yyyy HH:mm"),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName,
            }).ToListAsync();

            return View(allEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddEventViewModel()
            {
                Types = await GetTypesAsync()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypesAsync();

                return View(model);
            }

            try
            {
                var @event = new Event()
                {
                    Name = model.Name,
                    Start = model.Start,
                    End = model.End,
                    Description = model.Description,
                    OrganiserId = GetUserId(),
                    TypeId = model.TypeId,
                };

                dbContext.Add(@event);

                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Invalid Event");


                model.Types = await GetTypesAsync();

                return View(model);
            }

        }

        private async Task<IEnumerable<Type>> GetTypesAsync()
            => await dbContext.Types.ToListAsync();


        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
