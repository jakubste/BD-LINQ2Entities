using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepakJakub
{
    class BlogContext : DbContext
    {
        public DbSet<Blog> BlogsList { get; set; }
        public DbSet<Post> PostsList { get; set; }
        public DbSet<Comment> CommentsList { get; set; }
    }
}
