using CoffeShop.Models;
using CoffeShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productRepository.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
            TempData["Success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Products");
        }

        public IActionResult Orders()
        {
            var orders = orderRepository.GetAllOrders();
            return View(orders);
        }

        public async Task<IActionResult> Users()
        {
            var users = userManager.Users.ToList();
            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await userManager.GetRolesAsync(user);
            }
            ViewBag.UserRoles = userRoles;
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                TempData["Success"] = "Xóa user thành công!";
            }
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> ManageRole()
        {
            var users = userManager.Users.ToList();
            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await userManager.GetRolesAsync(user);
            }
            ViewBag.UserRoles = userRoles;
            ViewBag.Roles = roleManager.Roles.ToList();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var currentRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, currentRoles);
                await userManager.AddToRoleAsync(user, role);
                TempData["Success"] = $"Đã gán role {role} cho {user.UserName}";
            }
            return RedirectToAction("ManageRole");
        }
    }
}