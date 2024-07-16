using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class  NewPostsViewComponent: ViewComponent
    {
        private IPostRepository _postRepository;
        public NewPostsViewComponent(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postRepository
                                .Posts
                                .OrderByDescending(p => p.PublishedOn)
                                .Take(0)
                                .ToListAsync()
            );
        }
    }
}