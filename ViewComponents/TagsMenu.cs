using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.ViewComponents
{
    public class TagsMenu : ViewComponent
    {
        private readonly ITagRepository _tagRepository;

        public TagsMenu(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IViewComponentResult Invoke()
        {
            var tags = _tagRepository.Tags.ToList();
            return View(tags);
        }
    }
}
