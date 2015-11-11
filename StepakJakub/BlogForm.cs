using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace StepakJakub
{
    public partial class BlogForm : Form
    {
        public BlogForm()
        {
            InitializeComponent();
        }

        BlogContext bContext;

        private void blogsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bContext.SaveChanges();
        }

        public void refresh() {
            bContext.BlogsList.Load();
            bContext.PostsList.Load();

            var blogs = from blog in bContext.BlogsList.Local
                        select new
                        {
                            BlogId = blog.BlogId,
                            Name = blog.Name,
                            Url = blog.Url,
                            PostCount = (from post in bContext.PostsList.Local
                                     where post.BlogId == blog.BlogId
                                     select post).Count()
                        };

            this.blogsBindingSource.DataSource = blogs.ToList();


            var posts = bContext.PostsList.Local.Join(
                bContext.BlogsList,
                blog => blog.BlogId,
                post => post.BlogId,
                (post, blog) => new
                {
                    PostId = post.PostId,
                    BlogName = blog.Name,
                    Title = post.Title,
                    Content = post.Content
                }).OrderBy(pb => pb.BlogName);

            this.postsBindingSource.DataSource = posts;
        }

        private void BlogForm_Load(object sender, EventArgs e)
        {
            bContext = new BlogContext();
            refresh();

        }

        private void addPostButton_click(object sender, EventArgs e)
        {
            AddPost addPost = new AddPost();
            addPost.ShowDialog();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void savePosts_Click(object sender, EventArgs e)
        {
            bContext.SaveChanges();
        }

        private void postsBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
