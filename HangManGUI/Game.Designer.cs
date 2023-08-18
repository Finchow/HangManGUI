namespace HangManGUI
{
    partial class Game
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
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            livesCounter = new Label();
            incorrectLetters = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(155, 158);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 111);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "Guess";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Lives: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(145, 77);
            label3.Name = "label3";
            label3.Size = new Size(0, 18);
            label3.TabIndex = 4;
            label3.UseWaitCursor = true;
            label3.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "C:\\Users\\OscarWhite\\source\\repos\\HangManGUI\\HangManGUI\\Images\\HangMan11.png";
            pictureBox1.Location = new Point(12, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 141);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // livesCounter
            // 
            livesCounter.AutoSize = true;
            livesCounter.Location = new Point(47, 9);
            livesCounter.Name = "livesCounter";
            livesCounter.Size = new Size(13, 15);
            livesCounter.TabIndex = 6;
            livesCounter.Text = "0";
            // 
            // incorrectLetters
            // 
            incorrectLetters.AutoSize = true;
            incorrectLetters.Location = new Point(139, 9);
            incorrectLetters.Name = "incorrectLetters";
            incorrectLetters.Size = new Size(0, 15);
            incorrectLetters.TabIndex = 7;
            incorrectLetters.Click += label4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 9);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 8;
            label4.Text = "Incorrect:";
            label4.Click += label4_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(145, 50);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 9;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 199);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(incorrectLetters);
            Controls.Add(livesCounter);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Game";
            Text = "Hang Man";
            Load += Game_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

   

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label livesCounter;
        private Label incorrectLetters;
        public PictureBox pictureBox1;
        private Label label4;
        private Label label5;
    }
}