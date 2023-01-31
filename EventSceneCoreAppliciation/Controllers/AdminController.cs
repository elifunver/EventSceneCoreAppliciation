using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace EventSceneCoreAppliciation.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IToastNotification _toastNotification;

        public AdminController(ILogger<AdminController> logger, IToastNotification toastNotification)
        {
            _logger = logger;
            _toastNotification = toastNotification;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        public IActionResult profile()
        {
            return View();
        }
		[AllowAnonymous]
		[HttpPost]
        public async Task<IActionResult> Giris(Admin admin)
        {
            Context c = new Context();
            var result = c.adminler.Where(adminn => adminn.adminMail == admin.adminMail && adminn.adminSifre == admin.adminSifre).SingleOrDefault();

            if (result != null)
            {
                var claims = new List<Claim>() ;
                var claimAd = new Claim(ClaimTypes.Name, result.adminAd);
                var claimMail = new Claim(ClaimTypes.Email, result.adminMail);
                var claimRole = new Claim(ClaimTypes.Role, result.adminTur);

                claims.Add(claimAd);
				claims.Add(claimMail);
				claims.Add(claimRole);

				var userIdentify = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);

                //  await HttpContext.SignInAsync(principal);
                await HttpContext
                .SignInAsync(principal, new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(1) });
                return RedirectToAction("Index", "Home");
            }

            _toastNotification.AddErrorToastMessage("Kullanıcı adı veya password hatalı");
            TempData["init"] = 1;
            return RedirectToAction("login");
        }

        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }

        public string sifreleme(string value)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(value);
            dizi = provider.ComputeHash(dizi);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte bayt in dizi)
            {
                stringBuilder.Append(bayt.ToString().ToLower());
            }
            return stringBuilder.ToString();
        }
    }
}