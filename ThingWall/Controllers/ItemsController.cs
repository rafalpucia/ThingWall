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
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create(string id)
        {
            using (var ctx = new DataContext())
            {
                if (ctx.Users.Find(id) == null)
                {
                    id = User.Identity.GetUserId();
                }
                var user = ctx.Users.Find(id);
                var model = new CreateViewModel();
                model.Username = user.UserName;

                return View(model);
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(string id, ItemViewModels newItem)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new DataContext())
                {
                    if (id == null)
                    {
                        id = User.Identity.GetUserId();
                    }
                    if (ctx.Users.Find(id) == null)
                    {
                        return HttpNotFound();
                    }

                    Item itemToDatabase = new Item();
                    itemToDatabase.Name = newItem.Name;
                    itemToDatabase.Description = newItem.Description;
                    itemToDatabase.CreateDate = DateTime.Now.Date;
                    itemToDatabase.OwnerId = id;

                    ctx.Items.Add(itemToDatabase);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Show", "Items", new { id = id });
        }
        [Authorize]
        public ActionResult CurrentUserItems()
        {
            using (var ctx = new DataContext())
            {
                string UserID = User.Identity.GetUserId();
                var ItemsList = ctx.Items.Where(x => x.OwnerId == UserID).ToList();

                return View(ItemsList);
            }
        }

        // GET: Show
        public ActionResult Show(string id)
        {
            using (var ctx = new DataContext())
            {
                var model = new ShowViewModel();
                var items = new List<Item>();
                if (id == null)
                {
                    id = User.Identity.GetUserId();
                }
                var user = ctx.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                items = ctx.Items.Where(x => x.OwnerId == id).ToList();
                model.Username = user.UserName;
                model.UserID = id;
                model.Items = items;

                return View(model);
            }

        }

    }
}