using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepakJakub
{
    public partial class AddComment : Form
    {
        public Post post; 
        public AddComment(Post p)
        {
            post = p;
            InitializeComponent();
        }

        private void AddComment_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BlogContext bContext = new BlogContext();
            Comment comment = new Comment();
            comment.Content = commentText.Text.ToString();
            comment.PostId = post.PostId;

            Console.WriteLine(comment.Content);
            Console.WriteLine(comment.PostId);

            bContext.CommentsList.Add(comment);
            bContext.SaveChanges();
            this.Close();
        }
    }
}
