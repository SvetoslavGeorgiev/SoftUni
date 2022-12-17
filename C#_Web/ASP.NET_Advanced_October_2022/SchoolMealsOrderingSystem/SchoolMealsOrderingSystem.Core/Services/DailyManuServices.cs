﻿namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data;
    using static Data.Constants.GeneralConstants;
    using static Data.Constants.ChildConstants;
    using SchoolMealsOrderingSystem.Data.Entities.Menu;
    using System.Collections.Generic;
    using SchoolMealsOrderingSystem.Core.Models.DailyMenu;
    using SchoolMealsOrderingSystem.Data.Entities;

    public class DailyManuServices : IDailyMenuServices
    {

        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public DailyManuServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }

        public async Task AddDailyMenuAsync(MealsForParentToChooseViewModel model)
        {
            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id == model.ChildId && !c.IsDeleted)
                .Include(c => c.Menus)
                .FirstOrDefaultAsync();

            if (child == null)
            {
                throw new ArithmeticException(InvalidChildUserId);
            }

            if (child.Menus.Any(m => m.Name.ToString() == model.DayOfTheWeek.ToString()))
            {

                throw new ArithmeticException("Меню за този ден вече съществива");
            }

            var dailyMenu = new DailyMenu()
            {
                Name = model.DayOfTheWeek,
                SoupId = model.SoupId,
                DessertId = model.DessertsId,
                MainDishId = model.MainDishId,
                CreatedOn = DateTime.Now,
                ChildId = model.ChildId,
            };

            await schoolMealsOrderingSystemDbContext.DailyMenus.AddAsync(dailyMenu);

            child.Menus.Add(dailyMenu);

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task DeleteDailyMenuAsync(Guid dailyMenuId)
        {
            var dailyMenu = await schoolMealsOrderingSystemDbContext
            .DailyMenus
                .Where(dm => dm.Id == dailyMenuId && !dm.IsDeleted)
                .FirstOrDefaultAsync();

            if (dailyMenu != null)
            {
                //dailyMenu.IsDeleted = true;

                schoolMealsOrderingSystemDbContext.DailyMenus.Remove(dailyMenu);

                await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DailyMenuViewModel>> GetAllDailyMenusAsync(Guid childId)
        {
            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id == childId && !c.IsDeleted)
                .Include(c => c.Menus.Where(m => !m.IsDeleted))
                .ThenInclude(m => m.Soup)
                .Include(c => c.Menus.Where(m => !m.IsDeleted))
                .ThenInclude(m => m.MainDish)
                .Include(c => c.Menus.Where(m => !m.IsDeleted))
                .ThenInclude(m => m.Dessert)
                .FirstOrDefaultAsync();

            if (child == null)
            {
                throw new ArithmeticException(InvalidChildUserId);
            }

            var result = child
                .Menus
                .OrderBy(x => ((int)x.Name + 6) % 7)
                .Select(m => new DailyMenuViewModel()
                {
                    Id = m.Id,
                    Name = m.Name.ToString() == "Monday" ? "Понеделник" :
                           m.Name.ToString() == "Tuesday" ? "Вторник" :
                           m.Name.ToString() == "Wednesday" ? "Сряда" :
                           m.Name.ToString() == "Thursday" ? "Четвъртък" :
                           "Петък",
                    Dessert = m.Dessert,
                    Soup = m.Soup,
                    MainDish = m.MainDish,
                });

            return result;
        }

        public async Task<MealsForParentToChooseViewModel> GetMealsForParentsToChoose(Guid id)
        {
            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id == id && !c.IsDeleted)
                .Include(c => c.SchoolUser.Soups.Where(s => s.IsSelected && !s.IsDeleted))
                .Include(c => c.SchoolUser.MainDishes.Where(s => s.IsSelected && !s.IsDeleted))
                .Include(c => c.SchoolUser.Desserts.Where(s => s.IsSelected && !s.IsDeleted))
                .FirstOrDefaultAsync();

            if (child.SchoolUser.Soups == null ||
                child.SchoolUser.MainDishes == null ||
                child.SchoolUser.Desserts == null)
            {
                throw new ArgumentException(InvalidMenu);
            }

            var model = new MealsForParentToChooseViewModel()
            {
                ChildId = child.Id,
                Soups = child.SchoolUser.Soups,
                MainDishes = child.SchoolUser.MainDishes,
                Desserts = child.SchoolUser.Desserts,
                SchoolId = child.SchoolUserId
            };

            return model;
        }

    }
}
