using GreenBasket.DBContexts;
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
            try
            {
                if (!IsExistcustomerbyNumber(input.Phone))
                {
                    input.Status = true;
                    input.Date = DateTime.Now;
                    _context.Add(input);
                    await _context.SaveChangesAsync();
                    return Ok(new { Customer = input, isCustomerCreated = true, msg = "Success!!", isExist = false });

                }
                return Ok(new { Customer = input, isCustomerCreated = false, msg = "Phone No already exists", isExist = true });

            }catch(Exception ex)
            {
                return Ok(new { Customer = input, isCustomerCreated = false, msg = ex.Message, isExist = false });
            }

        }
        [HttpGet]
        public async Task<IActionResult> IsCustomerExist(string phone)
        {
            if (IsExistcustomerbyNumber(phone))
            {
                if(IsExistCustomer(phone))
                    return Ok(new { Customer = _context.Customers.FirstOrDefault(a => a.Phone == phone), msg = "Success!!", isExist = true });
                return Ok(new { msg="Phone No exist but Admin No Permition Contact Admin", isExist = true });
            }
            return Ok(new { msg="No Exist" ,isExist = false });
        }
        private  bool IsExistcustomerbyNumber(string phone)
        {
            return _context.Customers.Any(a=>a.Phone == phone);
        }
        private bool IsExistCustomer(string phone)
        {
            return _context.Customers.Any(a => a.Phone == phone && a.Status);
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
            try
            {
                input.Status = true;
                input.Date = DateTime.Now;
                _context.Add(input);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    msg = "Order Created Success!!",
                    IsCreated = true,
                    OrderId = input.Id,
                    //OrderItems = input.OrderItems.Select(a=>a.Id).ToList()
                });

            }
            catch (Exception ex)
            {
                return Ok(new { msg = ex.Message, IsCreated = false });
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order input)
        {

            _context.Update(input);
            await _context.SaveChangesAsync();
            return Ok(input);

        }
        public async Task<IActionResult> GetOrderById(long id)
        {
            var data = await _context.Orders.Where(a => a.Id == id).Include(a=>a.OrderItems).FirstOrDefaultAsync();
            return Ok(data);
        }
       
        public async Task<IActionResult> GetCustomerOrder(long id)
        {
            var data = await _context.Orders.Where(a => a.CustomerId == id).Include(a=>a.OrderItems).ToListAsync();
            return Ok(data);
        }
        public async Task<IActionResult> GetCustomerOrderStatusWise(long id)
        {
            var data = await _context.Orders.Where(a => a.CustomerId == id).Include(a=>a.OrderItems).ToListAsync();
            var newList = new
            {
                CurrentOrders = data.Where(a => a.OrderStatus == OrderStatusEnum.Pending).ToList(),
                PastOrders = data.Where(a => a.OrderStatus == OrderStatusEnum.Delivered || a.OrderStatus == OrderStatusEnum.Cancelled).ToList()
            };
            return Ok(newList);
        }
        public async Task<IActionResult> GetOrders()
        {
            var data = await _context.Orders.ToListAsync();
            return Ok(data);
        }
        public async Task<IActionResult> ChangeOrderStatus(long id,string status)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(a => a.Id == id);

            if (data == null)
                return BadRequest("Invalid Order Id");
            var orderStatus = Enum.Parse<OrderStatusEnum>(status);
            data.OrderStatus = orderStatus;
            _context.Update(data);
            _context.SaveChanges();
            return Ok("Status Change");
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
