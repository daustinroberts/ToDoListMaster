using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoListApp.Models;
using System;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {

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
            Item.ClearAll();
            return View();
        }
    }
}
