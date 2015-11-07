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

        private void BlogForm_Load(object sender, EventArgs e)
        {
            bContext = new BlogContext();
            bContext.BlogsList.Load();
            this.blogsBindingSource.DataSource = bContext.BlogsList.Local.ToBindingList();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
