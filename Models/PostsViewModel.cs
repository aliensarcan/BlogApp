using BlogApp.Entity; // Entity sınıflarını içe aktarır

namespace BlogApp.Models
{
    public class PostsViewModel
    {
        // Postların listesi
        public List<Post> Posts { get; set; } = new();

        // Taglerin listesi
        public List<Tag> Tags { get; set; } = new();
    }
}
