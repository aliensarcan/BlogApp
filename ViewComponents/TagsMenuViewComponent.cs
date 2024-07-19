using BlogApp.Data.Abstract; // Abstract repository arayüzlerini içe aktarır
using Microsoft.AspNetCore.Mvc; // ASP.NET Core MVC bileşenlerini içe aktarır
using Microsoft.EntityFrameworkCore; // Entity Framework Core bileşenlerini içe aktarır

namespace BlogApp.ViewComponents
{
    public class TagsMenuViewComponent : ViewComponent
    {
        private ITagRepository _tagRepository; // Tag repository arayüzü

        // Dependency injection ile repository nesnesini alır
        public TagsMenuViewComponent(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // ViewComponent'in asenkron olarak çalıştırılmasını sağlar
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tag listesini alır ve View'e gönderir
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}
