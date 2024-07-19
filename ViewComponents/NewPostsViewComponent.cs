using BlogApp.Data.Abstract; // Abstract repository arayüzlerini içe aktarır
using Microsoft.AspNetCore.Mvc; // ASP.NET Core MVC bileşenlerini içe aktarır
using Microsoft.EntityFrameworkCore; // Entity Framework Core bileşenlerini içe aktarır

namespace BlogApp.ViewComponents
{
    public class NewPostsViewComponent : ViewComponent
    {
        private IPostRepository _postRepository; // Post repository arayüzü

        // Dependency injection ile repository nesnesini alır
        public NewPostsViewComponent(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // ViewComponent'in asenkron olarak çalıştırılmasını sağlar
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Yeni postları tarihe göre sıralayıp ilk 5'ini alır ve View'e gönderir
            return View(await _postRepository
                                .Posts
                                .OrderByDescending(p => p.PublishedOn)
                                .Take(5)
                                .ToListAsync());
        }
    }
}
