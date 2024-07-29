namespace WinFormsApp1
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
            loginButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(37, 62);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(160, 23);
            loginButton.TabIndex = 0;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(37, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите ваше имя для игры";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 111);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(loginButton);
            Name = "Form1";
            Text = "Вход";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox textBox1;
        private Label label1;
    }
}
