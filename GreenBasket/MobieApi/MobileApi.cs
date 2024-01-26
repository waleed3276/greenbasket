﻿using GreenBasket.DBContexts;
using GreenBasket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenBasket.MobieApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MobileApi : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MobileApi(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            if (categoryId <= 0)
                return BadRequest("category Id must be greater then zero");
            //var products =await _context.Products.Where(a=>a.SubCategories.CategoryId == categoryId && a.Status).ToListAsync();

            var result = await _context.Products.Where(a => a.SubCategories.CategoryId == categoryId && a.Status).Select(a => new
            {
                a.Id,
                a.Name,
                a.Discount,
                DiscountType = a.DiscountType.ToString(),
                a.SalePrice,
                a.MaxLimit,
                a.Image,
                a.SubCategoryId,
                SubCategoryName =a.SubCategories.Name,
                CategoryId = categoryId,
                CategoryName = a.SubCategories.Categories.Name,
                Unit = a.Units.Name,
                a.UnitId,
                a.Description
                
            }).ToListAsync();
            return Ok(result);

        }
        #region Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var data = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetProducts()
        {
            var data = await _context.Products.ToListAsync();
            return Ok(data);
        }
        #endregion
        #region Category
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetCategoryDetailById(int id)
        {
            var data = await _context.Categories.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetCategories()
        {
            var data = await _context.Categories.ToListAsync();
            return Ok(data);
        }
        #endregion
        #region SubCategory
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategory input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory(SubCategory input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetSubCategoryDetailById(int id)
        {
            var data = await _context.SubCategories.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetSubCategories()
        {
            var data = await _context.SubCategories.ToListAsync();
            return Ok(data);
        }
        #endregion
        #region Phase
        [HttpPost]
        public async Task<IActionResult> CreatePhase(Phase input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdatePhase(Phase input)
        {
            
            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetPhaseDetailById(int id)
        {
            var data = await _context.Phases.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetPhases()
        {
            var data = await _context.Phases.ToListAsync();
            return Ok(data);
        }
        #endregion
        #region Unit
        [HttpPost]
        public async Task<IActionResult> CreateUnit(Unit input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateUnit(Unit input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetUnitDetailById(int id)
        {
            var data = await _context.Units.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetUnits()
        {
            var data = await _context.Units.ToListAsync();
            return Ok(data);
        }
        #endregion

        #region Customer
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Response = "Create Success!!",
                CustomerId = input.Id,
            });

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetCustomerDetailById(long id)
        {
            var data = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetCustomers()
        {
            var data = await _context.Customers.ToListAsync();
            return Ok(data);
        }
        #endregion

        #region Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Response = "Create Success!!",
                OrderId = input.Id,
                //OrderItems = input.OrderItems.Select(a=>a.Id).ToList()
            });

        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetOrcerDetailById(long id)
        {
            var data = await _context.Orders.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetOrders()
        {
            var data = await _context.Orders.ToListAsync();
            return Ok(data);
        }
        #endregion

        #region Order
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItem input)
        {
            input.Status = true;
            input.Date = DateTime.Now;
            _context.Add(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrderItem(OrderItem input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetOrcerItemDetailById(long id)
        {
            var data = await _context.OrderItems.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetOrderItems()
        {
            var data = await _context.OrderItems.ToListAsync();
            return Ok(data);
        }
        #endregion
    }
}
