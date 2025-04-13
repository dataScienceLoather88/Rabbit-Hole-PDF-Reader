namespace EbookReaderTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnShowBookmarks = new Button();
            btnAddBookmark = new Button();
            btnForward = new Button();
            btnBack = new Button();
            btnToggleTheme = new Button();
            pgeInfo = new TextBox();
            btnNext = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            pictureBoxInverted = new PictureBox();
            blackBg = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInverted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blackBg).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnShowBookmarks);
            panel1.Controls.Add(btnAddBookmark);
            panel1.Controls.Add(btnForward);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(btnToggleTheme);
            panel1.Controls.Add(pgeInfo);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(668, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(120, 406);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnShowBookmarks
            // 
            btnShowBookmarks.BackColor = SystemColors.ButtonHighlight;
            btnShowBookmarks.Location = new Point(3, 256);
            btnShowBookmarks.Name = "btnShowBookmarks";
            btnShowBookmarks.Size = new Size(112, 34);
            btnShowBookmarks.TabIndex = 8;
            btnShowBookmarks.Text = "Show JMPs";
            btnShowBookmarks.UseVisualStyleBackColor = false;
            btnShowBookmarks.Click += btnShowBookmarks_Click;
            // 
            // btnAddBookmark
            // 
            btnAddBookmark.BackColor = SystemColors.ButtonHighlight;
            btnAddBookmark.Location = new Point(3, 216);
            btnAddBookmark.Name = "btnAddBookmark";
            btnAddBookmark.Size = new Size(112, 34);
            btnAddBookmark.TabIndex = 7;
            btnAddBookmark.Text = "'Mark This";
            btnAddBookmark.UseVisualStyleBackColor = false;
            btnAddBookmark.Click += btnAddBookmark_Click;
            // 
            // btnForward
            // 
            btnForward.BackColor = SystemColors.ButtonHighlight;
            btnForward.Location = new Point(59, 367);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(56, 34);
            btnForward.TabIndex = 6;
            btnForward.Text = "-->";
            btnForward.UseVisualStyleBackColor = false;
            btnForward.Click += btnForward_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ButtonHighlight;
            btnBack.Location = new Point(3, 367);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(56, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "<--";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.BackColor = SystemColors.ButtonHighlight;
            btnToggleTheme.Location = new Point(3, 176);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(112, 34);
            btnToggleTheme.TabIndex = 4;
            btnToggleTheme.Text = "Switch";
            btnToggleTheme.UseVisualStyleBackColor = false;
            btnToggleTheme.Click += btnToggleTheme_Click;
            // 
            // pgeInfo
            // 
            pgeInfo.BackColor = SystemColors.ButtonHighlight;
            pgeInfo.Location = new Point(3, 139);
            pgeInfo.Name = "pgeInfo";
            pgeInfo.ReadOnly = true;
            pgeInfo.Size = new Size(112, 31);
            pgeInfo.TabIndex = 3;
            pgeInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            btnNext.BackColor = SystemColors.ButtonHighlight;
            btnNext.Location = new Point(3, 99);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 2;
            btnNext.Text = "Find Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += button2_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonHighlight;
            btnSearch.Location = new Point(3, 59);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(3, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(112, 31);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // pictureBoxInverted
            // 
            pictureBoxInverted.BackColor = SystemColors.ControlLightLight;
            pictureBoxInverted.Location = new Point(16, 32);
            pictureBoxInverted.Name = "pictureBoxInverted";
            pictureBoxInverted.Size = new Size(650, 406);
            pictureBoxInverted.TabIndex = 1;
            pictureBoxInverted.TabStop = false;
            pictureBoxInverted.Visible = false;
            // 
            // blackBg
            // 
            blackBg.BackColor = SystemColors.ControlText;
            blackBg.Dock = DockStyle.Fill;
            blackBg.Location = new Point(0, 0);
            blackBg.Name = "blackBg";
            blackBg.Size = new Size(800, 450);
            blackBg.TabIndex = 2;
            blackBg.TabStop = false;
            blackBg.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(pictureBoxInverted);
            Controls.Add(blackBg);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInverted).EndInit();
            ((System.ComponentModel.ISupportInitialize)blackBg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnNext;
        private Button btnSearch;
        private TextBox txtSearch;
        private TextBox pgeInfo;
        private Button btnToggleTheme;
        private PictureBox pictureBoxInverted;
        private PictureBox blackBg;
        private Button btnForward;
        private Button btnBack;
        private Button btnAddBookmark;
        private Button btnShowBookmarks;
    }
}
