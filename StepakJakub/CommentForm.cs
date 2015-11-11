using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepakJakub.Migrations
{
    public partial class CommentForm : Form
    {
        public CommentForm()
        {
            InitializeComponent();
        }

        BlogContext bContext;

        IEnumerable<Blog> blogs;
        IEnumerable<Post> posts;

        private void refresh ()
        {
            bContext = new BlogContext();
            bContext.BlogsList.Load();
            bContext.PostsList.Load();
            bContext.CommentsList.Load();

            this.blogsList.DataSource = (from blog in bContext.BlogsList.Local
                                         select blog.Name).ToList();

            blogs = from blog in bContext.BlogsList.Local
                    select blog;
            posts = from post in bContext.PostsList.Local
                    select post;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void blogsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blogsList.SelectedItem != null)
            {
                string curr_blog_name = blogsList.SelectedItem.ToString();

                if (blogs != null && curr_blog_name != null && curr_blog_name != "")
                {
                    var blog = blogs.Where(b => b.Name == curr_blog_name).ToList()[0];
                    if (blog.Posts != null)
                        this.postsList.DataSource = blog.Posts.Select(p => p.Title).ToList();
                    else
                    {
                        this.postsList.DataSource = null;
                        this.commentsList.DataSource = null;
                    }
                }
            }
        }

        private void postsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (postsList.SelectedItem != null)
            {
                string curr_post_name = postsList.SelectedItem.ToString();

                if (posts != null && curr_post_name != null && curr_post_name != "")
                {
                    var post = posts.Where(p => p.Title == curr_post_name).ToList()[0];
                    if (post.Comments != null)
                    {
                        Console.WriteLine("no elo");
                        this.commentsList.DataSource = post.Comments.Select(c => c.Content).ToList();
                    }
                    else
                    {
                        Console.WriteLine("null :(");
                        this.commentsList.DataSource = null;
                    }
                }
            }
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            if (postsList.SelectedItem != null)
            {
                string curr_post_name = postsList.SelectedItem.ToString();

                if (posts != null && curr_post_name != null && curr_post_name != "")
                {
                    var post = posts.Where(b => b.Title == curr_post_name).ToList()[0];
                    AddComment cm = new AddComment(post);
                    cm.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
