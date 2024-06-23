using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur (IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                    
                    new Entity.Tag {Text ="Web Programlama"},
                    
                    new Entity.Tag {Text ="Backend"},
                    
                    new Entity.Tag {Text ="Frontend"},
                    
                    new Entity.Tag {Text ="fulstack"},
                    
                    new Entity.Tag {Text ="Php"}
                    );
                     context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName="AliEnsarCan"},
                        new User {UserName="Berre Yılmaz"}
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{
                            Title="Asp.net Core",
                            Content= "Asp.net Core Dersleri",
                            Isacticve =true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId= 1
                        },
                        
                        new Post{
                            Title="Php ",
                            Content= "Php Core Dersleri",
                            Isacticve =true,
                            PublishedOn=DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId= 1
                        },
                        
                        new Post{
                            Title="Django",
                            Content= "Django Dersleri",
                            Isacticve =true,
                            PublishedOn=DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId= 2
                        }
                        
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}