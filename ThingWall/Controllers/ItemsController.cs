using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;
using ThingWall.Data.Model;
using ThingWall.Models;
using Microsoft.AspNet.Identity;

namespace ThingWall.Controllers
{
    public class ItemsController : Controller
    {
        private DataContext _dbContext;
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(ItemViewModels NewItem)
        {
            _dbContext = new DataContext();
            Item ItemToDatabase = new Item();
            ItemToDatabase.Name = NewItem.Name;
            ItemToDatabase.Description = NewItem.Description;
            ItemToDatabase.CreateDate = DateTime.Now.Date;
            ItemToDatabase.OwnerId = User.Identity.GetUserId();


            _dbContext.Items.Add(ItemToDatabase);
            _dbContext.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult CurrentUserItems()
        {
            _dbContext = new DataContext();
            string UserID = User.Identity.GetUserId();
            var ItemsList = _dbContext.Items.Where(x => x.OwnerId == UserID).ToList();

            return View(ItemsList);
        }
    }
}