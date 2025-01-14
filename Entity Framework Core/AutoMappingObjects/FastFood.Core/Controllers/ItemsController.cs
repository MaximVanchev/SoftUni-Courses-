﻿namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var items = this.context.Items
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(items);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var item = this.mapper.Map<FastFood.Models.Item>(model);

            this.context.Items.Add(item);

            this.context.SaveChanges();
            return this.RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            var items = this.context.Items
              .ProjectTo<ItemsAllViewModels>(mapper.ConfigurationProvider)
              .ToList();

            return this.View(items);
        }
    }
}
