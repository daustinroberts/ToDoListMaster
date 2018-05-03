using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoListApp.Models;
using System;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        // [HttpGet("/categories/{categoryId}/items/new")]
        // public ActionResult CreateForm(int categoryId)
        // {
        //   Dictionary<string, object> model = new Dictionary<string, object>();
        //   Category category = Category.Find(categoryId);
        //   return View(category);
        // }
        // [HttpGet("/categories/{categoryId}/items/{itemId}")]
        // public ActionResult Details(int categoryId, int itemId)
        // {
        //   Item item = Item.Find(itemId);
        //   Dictionary<string, object> model = new Dictionary<string, object>();
        //   Category category = Category.Find(categoryId);
        //   model.Add("item", item);
        //   model.Add("category", category);
        //   return View(item);
        // }
        [HttpGet("/items")]
        public ActionResult Index()
        {
          // return new EmptyResult();
          List<Item> allItems = Item.GetAll();
          // return View();
          // return new EmptyResult();
          return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/items")]
        public ActionResult Create()
        {
          Item newItem = new Item (Request.Form["new-item"]);
          newItem.Save();
          List<Item> allItems = Item.GetAll();
          return View("Index", allItems);
        }
        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            // Item.ClearAll();
            return View();
        }
    }
}
