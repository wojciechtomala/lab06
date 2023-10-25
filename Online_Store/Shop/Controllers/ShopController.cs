﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        public static IList<ShopItem> shopItems = new List<ShopItem> {
            new ShopItem() { Id=1, Name="Avocado From Mexico", Description="The fruit of domestic varieties have smooth, buttery, golden-green flesh when ripe. Depending on the cultivar, avocados have green, brown, purplish, or black skin, and may be pear-shaped, egg-shaped, or spherical. For commercial purposes the fruits are picked while unripe and ripened after harvesting.", Price=2, imgURL = "data:image/jpeg;base64,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"},
            new ShopItem() { Id=2, Name="Peach", Description="A peach is a soft, round, slightly furry fruit with sweet yellow flesh and pinky-orange skin. Peaches grow in warm countries. Something that is peach is pale pinky-orange in colour.", imgURL="data:image/jpeg;base64,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", Price=4},
            new ShopItem() { Id=3, Name="Banana", Description="Bananas are long, curved fruits with smooth, yellow, and sometimes slightly green skin. The average length of a banana is about 7 to 9 inches, and it is about 2 to 3 inches in diameter. The skin of the banana is usually yellow when it is ripe, but it can also be green, red, or purple depending on the variety.", Price=3, imgURL="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/4QBzRXhpZgAASUkqAAgAAAABAA4BAgBRAAAAGgAAAAAAAABUd28gcmlwZSBiYW5hbmFzLCBhbmQgY3V0IGEgcGllY2Ugb2YgcGVlbGVkIGJhbmFuYSBvbiB3aGl0ZSBiYWNrZ3JvdW5kLCBpc29sYXRlZC7/7QCiUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAIYcAlAADklubmEgVGFyYXNlbmtvHAJ4AFFUd28gcmlwZSBiYW5hbmFzLCBhbmQgY3V0IGEgcGllY2Ugb2YgcGVlbGVkIGJhbmFuYSBvbiB3aGl0ZSBiYWNrZ3JvdW5kLCBpc29sYXRlZC4cAm4AGEdldHR5IEltYWdlcy9pU3RvY2twaG90b//hAzhodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvAAk8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPgoJCTxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1sbnM6SXB0YzR4bXBDb3JlPSJodHRwOi8vaXB0Yy5vcmcvc3RkL0lwdGM0eG1wQ29yZS8xLjAveG1sbnMvIiB4bWxuczpHZXR0eUltYWdlc0dJRlQ9Imh0dHA6Ly94bXAuZ2V0dHlpbWFnZXMuY29tL2dpZnQvMS4wLyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwbHVzPSJodHRwOi8vbnMudXNlcGx1cy5vcmcvbGRmL3htcC8xLjAvIiB4bWxuczppcHRjRXh0PSJodHRwOi8vaXB0Yy5vcmcvc3RkL0lwdGM0eG1wRXh0LzIwMDgtMDItMjkvIiBwaG90b3Nob3A6Q3JlZGl0PSJHZXR0eSBJbWFnZXMvaVN0b2NrcGhvdG8iIEdldHR5SW1hZ2VzR0lGVDpBc3NldElEPSIxMTI2Njk1NjkzIiA+CjxkYzpjcmVhdG9yPjxyZGY6U2VxPjxyZGY6bGk+SW5uYSBUYXJhc2Vua288L3JkZjpsaT48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"}
        };
        public IActionResult ShopList()
        {
            return View(shopItems);
        }
        // GET: ShopController
        public ActionResult Index()
        {
            return View(shopItems);
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            ShopItem item = shopItems.FirstOrDefault(x => x.Id == id);
            ViewBag.ItemName = item.Name;
            return View(shopItems.FirstOrDefault(x => x.Id == id));
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopItem shopItem)
        {
            shopItem.Id = shopItems.Count + 1;
            shopItems.Add(shopItem);
            return RedirectToAction("Index");
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(shopItems.FirstOrDefault(x => x.Id == id));
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(shopItems.FirstOrDefault(x => x.Id == id));
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ShopItem shopItem)
        {
            ShopItem shopItemToDelete = shopItems.FirstOrDefault(x => x.Id == id);
            shopItems.Remove(shopItemToDelete);
            return RedirectToAction("Index");
        }
    }
}