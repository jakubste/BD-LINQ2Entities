using StepakJakub.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepakJakub
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogContext blogContext = new BlogContext();

            /*
            var coms = from com in blogContext.CommentsList
                       select com;

            foreach (var com in coms)
            {
                Console.WriteLine(com.PostId);
                Console.WriteLine(com.Content);
            }

            var posts = blogContext.PostsList.Select(p => p);

            foreach (var post in posts)
            {
                Console.WriteLine(post.Comments);
            }
            */


            /*
            Console.WriteLine("Podaj nazwe bloga");
            string input;
            input = Console.ReadLine();
            Blog newblog = new Blog();
            newblog.Name = input;
            blogContext.BlogsList.Add(newblog);
            blogContext.SaveChanges();

            Console.WriteLine("zaraz pojdzie zapytanie");

            IQueryable<string> blogs = from blog in blogContext.BlogsList
                                       select blog.Name;

            Console.WriteLine("po zapytaniu");

            foreach (var blogname in blogs)
            {
                Console.WriteLine(blogname);
            }

            Console.WriteLine("po petli");
            */

            int blogid = (from b in blogContext.BlogsList
                          where b.Name == "blogasek"
                          select b.BlogId).First();

            /*
            Post post = new Post();
            post.BlogId = blogid;
            post.Content = "bla bla bla";
            post.Title = "BlaTitle";
            blogContext.PostsList.Add(post);
            blogContext.SaveChanges();
            */

            BlogForm blogform = new BlogForm();
            blogform.ShowDialog();

            CommentForm commentForm = new CommentForm();
            commentForm.ShowDialog();



            //Console.Read();
        }
    }
}
