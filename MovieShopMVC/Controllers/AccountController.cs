using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        // [HttpGet]
        // public ActionResult Login()
        // {
        //     return View();
        // }
        //
        // public ActionResult Register()
        // {
        //     return View();
        // }
        // public ActionResult Hello()
        // {
        //     return View();
        // }
    
        private readonly MovieShopDbContext _context;

        public AccountController(MovieShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View(new LoginViewModel());
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            
            // Check if passwords match
            if (registerVM.Password != registerVM.ConfirmPassword)
            {
                TempData["Error"] = "Password and Confirm Password do not match.";
                return View(registerVM);
            }
            
            // Check if email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerVM.EmailAddress);
            if (existingUser != null)
            {
                TempData["Error"] = "Email already exists";
                return View(registerVM);
            }

            var salt = GenerateSalt();
            var hashedPassword = HashPassword(registerVM.Password, salt);

            var newUser = new User
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.EmailAddress,
                HashedPassword = hashedPassword,
                salt = salt,
                DateOfBirth = registerVM.DateOfBirth,
                IsLocked = false,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) 
                return View(loginVM);

            // Fetch only the necessary columns for login
            var user = await _context.Users
                .Where(u => u.Email == loginVM.EmailAddress)
                .Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.HashedPassword,
                    u.salt
                })
                .FirstOrDefaultAsync();

            if (user != null && VerifyPassword(loginVM.Password, user.HashedPassword, user.salt))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Email == "admin@example.com" ? "Admin" : "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Invalid credentials";
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private string GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var combined = password + salt;
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            var hashOfInput = HashPassword(password, salt);
            return hashOfInput == hashedPassword;
        }

        public IActionResult AccessDenied() => View();
    }
}
 