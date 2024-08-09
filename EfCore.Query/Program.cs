using EfCore.Query.Data.Context;
using EfCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCore.Query
{
    public class Program
    {
        static void Main(string[] args)
        {
            BlogContext blogContext = new BlogContext();

            //blogContext.Add(new Blog
            //{
            //   Title = "Blog-1",
            //   Url = "ysk.com/blog-1"
              
            //});
            //blogContext.Add(new Blog
            //{
            //    Title = "Blog-2",
            //    Url = "ysk.com/blog-2"

            //});
            //blogContext.Add(new Blog
            //{
            //    Title = "Blog-3",
            //    Url = "ysk.com/blog-3"

            //});
            //blogContext.Add(new Blog
            //{
            //    Title = "Blog-4",
            //    Url = "ysk.com/blog-4"

            //});
            //blogContext.SaveChanges();

            //load-eager
            //var blogs = blogContext.Blogs.Include(x=>x.Comments).ToList();
            var blogs = blogContext.Blogs.Include(x=>x.Comments.Where(x=>x.Content.Contains("Yorum-1"))).ToList();
            foreach(var blog in blogs )
            {
                Console.WriteLine($"{blog.Title } blogun yorumları");
                foreach (var comment in blog.Comments)
                {
                    Console.WriteLine($"    {comment.Content}");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
