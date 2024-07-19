using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository; // Post repository arayüzü

        private ICommentRepository _commentRepository; // Comment repository arayüzü

        // Dependency injection ile repository nesnelerini alır
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        // Blog yazılarının listesini gösterir
        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts; // Tüm postları alır

            // Eğer bir tag varsa, ilgili tag'e sahip postları filtreler
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }

            // View'e PostsViewModel nesnesi ile birlikte postları gönderir
            return View(new PostsViewModel { Posts = await posts.ToListAsync() });
        }

        // Belirli bir postun detaylarını gösterir
        public async Task<IActionResult> Details(string url)
        {
            // İlgili postu ve onunla ilişkili tag ve yorumları alır
            return View(await _postRepository
                        .Posts
                        .Include(x => x.Tags)
                        .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(p => p.Url == url));
        }

        // Yorum ekleme işlemini gerçekleştirir
        [HttpPost]
        public JsonResult AddComment(int PostId, string UserName, string Text)
        {
            // Yeni yorum nesnesi oluşturur
            var entity = new Comment {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                User = new User { UserName = UserName, Image = "avatar.jpg" }
            };

            // Yorum repository'si aracılığıyla yorumu kaydeder
            _commentRepository.CreateComment(entity);

            // Yeni yorumun detaylarını JSON olarak döner
            return Json(new { 
                UserName,
                Text,
                entity.PublishedOn,
                entity.User.Image
            });
        }
    }
}
