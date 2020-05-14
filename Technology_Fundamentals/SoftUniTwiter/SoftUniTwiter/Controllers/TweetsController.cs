using Microsoft.AspNetCore.Mvc;
using SoftUniTwiter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SoftUniTwiter.Models;
using Microsoft.AspNetCore.Authorization;

namespace SoftUniTwiter.Controllers
{
    [Authorize]
    public class TweetsController : Controller
    {


        ApplicationDbContext db;
        public TweetsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveToDatabase(string tweettext)
        {

            var tweet = new Tweet();
            tweet.Text = tweettext;
            tweet.CreatedOn = DateTime.Now;
            tweet.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            db.Tweets.Add(tweet);
            db.SaveChanges();
            return Redirect("/");

        }
    }
}

