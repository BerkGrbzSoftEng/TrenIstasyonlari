using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlari.Business.Services;
using TrenIstasyonlari.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrenIstasyonlari.Controllers
{
    public class UserController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public UserController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _kullaniciService.GetUser(x => x.KullaniciId == id).Result;
            var delete = _kullaniciService.Delete(user);
            if (delete.Result)
            {
                return Ok(delete.Result);
            }

            return BadRequest(delete.Result);
        }
        public IActionResult List()
        {
            var data = _kullaniciService.GetList();
            var dtoList = new List<KullaniciDto>();
            foreach (var item in data.Result)
            {
                dtoList.Add(new KullaniciDto()
                {
                    KullaniciAdi = item.KullaniciAdi,
                    Sifre = item.Sifre,
                    KullaniciId = item.KullaniciId
                });
            }
            return View(dtoList);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(KullaniciDto kullanici)
        {
            if (ModelState.IsValid)
            {
                var user = _kullaniciService.Login(new Kullanici()
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Sifre = kullanici.Sifre
                });
                if (user != null)
                {
                    List<Claim> userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.KullaniciId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, user.KullaniciAdi));
                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register(KullaniciDto kullanici)
        {
            if (ModelState.IsValid)
            {
                var user = _kullaniciService.Register(new Kullanici()
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Sifre = kullanici.Sifre
                });
                if (user != null)
                {
                    return RedirectToAction("Login");
                }
            }


            return View();
        }


        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> update(KullaniciDto kullanici)
        {
            var user =User.Identity.Name;
            var autheticatedUser = _kullaniciService.GetUser(x => x.KullaniciAdi == user).Result.KullaniciId;
            var update = _kullaniciService.Update(new Kullanici()
            {
	            KullaniciAdi = kullanici.KullaniciAdi,
	            Sifre = kullanici.Sifre,
	            KullaniciId = autheticatedUser
            });
            if (user!=null)
            {
                return Ok(kullanici);


            }

            return BadRequest();
        }

    }
}
