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
        IEnumerable<Comment> comments;

        private void refresh ()
        {
            bContext = new BlogContext();
            bContext.BlogsList.Load();
            bContext.PostsList.Load();
            bContext.CommentsList.Load();


            this.blogsList.DataSource = (from blog in bContext.BlogsList
                                         select blog.Name).ToList();

            blogs = bContext.BlogsList.Include(b => b.Posts);
            posts = bContext.PostsList;
            comments = bContext.CommentsList;
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
                    var post = posts.Where(p => p.Title == curr_post_name).Select(p=>p.PostId).First();
                    List<string> commentsList = new List<string>();

                    foreach (var comment in comments)
                    {
                        if (comment.PostId == post)
                        {
                            commentsList.Add(comment.Content);
                        }
                    }
                    this.commentsList.DataSource = commentsList;
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
                    var post = posts.Where(b => b.Title == curr_post_name).First();
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
