namespace StepakJakub.Migrations
{
    partial class CommentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blogsList = new System.Windows.Forms.ListBox();
            this.postsList = new System.Windows.Forms.ListBox();
            this.commentsList = new System.Windows.Forms.ListBox();
            this.commentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // blogsList
            // 
            this.blogsList.FormattingEnabled = true;
            this.blogsList.ItemHeight = 16;
            this.blogsList.Location = new System.Drawing.Point(37, 69);
            this.blogsList.Name = "blogsList";
            this.blogsList.Size = new System.Drawing.Size(277, 436);
            this.blogsList.TabIndex = 0;
            this.blogsList.SelectedIndexChanged += new System.EventHandler(this.blogsList_SelectedIndexChanged);
            // 
            // postsList
            // 
            this.postsList.FormattingEnabled = true;
            this.postsList.ItemHeight = 16;
            this.postsList.Location = new System.Drawing.Point(320, 71);
            this.postsList.Name = "postsList";
            this.postsList.Size = new System.Drawing.Size(347, 436);
            this.postsList.TabIndex = 1;
            this.postsList.SelectedIndexChanged += new System.EventHandler(this.postsList_SelectedIndexChanged);
            // 
            // commentsList
            // 
            this.commentsList.FormattingEnabled = true;
            this.commentsList.ItemHeight = 16;
            this.commentsList.Location = new System.Drawing.Point(673, 68);
            this.commentsList.Name = "commentsList";
            this.commentsList.Size = new System.Drawing.Size(419, 436);
            this.commentsList.TabIndex = 2;
            // 
            // commentButton
            // 
            this.commentButton.Location = new System.Drawing.Point(842, 510);
            this.commentButton.Name = "commentButton";
            this.commentButton.Size = new System.Drawing.Size(95, 33);
            this.commentButton.TabIndex = 3;
            this.commentButton.Text = "Skomentuj";
            this.commentButton.UseVisualStyleBackColor = true;
            this.commentButton.Click += new System.EventHandler(this.commentButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Odśwież";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commentButton);
            this.Controls.Add(this.commentsList);
            this.Controls.Add(this.postsList);
            this.Controls.Add(this.blogsList);
            this.Name = "CommentForm";
            this.Text = "Lista komentarzy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox blogsList;
        private System.Windows.Forms.ListBox postsList;
        private System.Windows.Forms.ListBox commentsList;
        private System.Windows.Forms.Button commentButton;
        private System.Windows.Forms.Button button1;
    }
}