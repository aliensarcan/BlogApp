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
     public UsersController()
     {
        
     }
     public IActionResult Login()
     {
        return View();
     }
     
           
}
}