namespace EbookReaderTest
{
    partial class launchForm
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
            JUMP = new Button();
            pictureBox1 = new PictureBox();
            comboRecents = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // JUMP
            // 
            JUMP.Anchor = AnchorStyles.None;
            JUMP.Location = new Point(338, 408);
            JUMP.Name = "JUMP";
            JUMP.Size = new Size(125, 35);
            JUMP.TabIndex = 0;
            JUMP.Text = "Jump";
            JUMP.UseVisualStyleBackColor = true;
            JUMP.Click += JUMP_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.rabbitHoleTest3;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 374);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // comboRecents
            // 
            comboRecents.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRecents.FormattingEnabled = true;
            comboRecents.Location = new Point(338, 456);
            comboRecents.Name = "comboRecents";
            comboRecents.Size = new Size(125, 33);
            comboRecents.TabIndex = 2;
            comboRecents.SelectedIndexChanged += comboRecents_SelectedIndexChanged;
            // 
            // launchForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(comboRecents);
            Controls.Add(pictureBox1);
            Controls.Add(JUMP);
            Name = "launchForm";
            Text = "Launch Form";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button JUMP;
        private PictureBox pictureBox1;
        private ComboBox comboRecents;
    }
}