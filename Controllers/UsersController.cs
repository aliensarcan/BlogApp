using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {
        // Boş constructor (Dependency injection gerekmez)
        public UsersController()
        {
        
        }

        // Login sayfasını gösterir
        public IActionResult Login()
        {
            return View();
        }
    }
}
