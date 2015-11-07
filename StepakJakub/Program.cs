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

            BlogForm blogform = new BlogForm();
            blogform.ShowDialog();

            Console.ReadLine();
        }
    }
}
