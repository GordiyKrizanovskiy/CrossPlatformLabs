using System.Security.Claims;
using Lab5.Models;
using Lab5.Services;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

// Контролер для авторизації та реєстрації
public class AuthController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;

    // Інжекція IConfiguration і AuthService
    public AuthController(IConfiguration configuration, AuthService authService)
    {
        _configuration = configuration;
        _authService = authService;
    }

    // Профіль користувача
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        // Отримання ідентифікатора користувача з токена
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("User ID is missing from claims.");
            return RedirectToAction("Login");
        }

        Console.WriteLine($"User ID from claims: {id}");

        // Отримання користувача через AuthService
        var user = await _authService.GetUserAsync(id);

        if (user == null)
        {
            Console.WriteLine($"User not found for ID: {id}");
            return RedirectToAction("Register");
        }

        Console.WriteLine($"User found: {user.UserName}");
        return View(user);
    }

    // Сторінка реєстрації
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // Обробка реєстрації користувача
    [HttpPost]
    public async Task<IActionResult> Register(SignUpViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Створення користувача через AuthService
        var result = await _authService.CreateUserAsync(model);

        if (!result)
        {
            ModelState.AddModelError(string.Empty, "Failed to create user");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    // Сторінка входу
    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // Обробка логіна
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "/")
    {
        if (!ModelState.IsValid)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        try
        {
            var authClient = new AuthenticationApiClient(new Uri($"https://{_configuration["Auth0:Domain"]}"));

            var loginRequest = new ResourceOwnerTokenRequest
            {
                ClientId = _configuration["Auth0:ClientId"],
                ClientSecret = _configuration["Auth0:ClientSecret"],
                Scope = "openid profile email",
                Realm = "Username-Password-Authentication",
                Username = model.Email,
                Password = model.Password
            };

            var loginResponse = await authClient.GetTokenAsync(loginRequest);

            // Отримання інформації про користувача
            var userInfo = await authClient.GetUserInfoAsync(loginResponse.AccessToken);

            // Створення токена для локальної автентифікації
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId), // Використовується user_id
                new Claim(ClaimTypes.Name, userInfo.Email ?? model.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            return Redirect(returnUrl);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login error: {ex.Message}");
            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your credentials.");
            return View(model);
        }
    }

    // Вихід користувача
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
