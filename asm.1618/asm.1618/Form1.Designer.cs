namespace asm._1618
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
            btn_Login = new Button();
            btn_Quit = new Button();
            cb_Category = new ComboBox();
            txt_Password = new TextBox();
            txt_UserName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Honeydew;
            btn_Login.Location = new Point(326, 277);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(94, 29);
            btn_Login.TabIndex = 15;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Quit
            // 
            btn_Quit.BackColor = Color.Red;
            btn_Quit.ForeColor = SystemColors.ButtonHighlight;
            btn_Quit.Location = new Point(60, 277);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(94, 29);
            btn_Quit.TabIndex = 14;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = false;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // cb_Category
            // 
            cb_Category.BackColor = SystemColors.Info;
            cb_Category.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Category.FormattingEnabled = true;
            cb_Category.Location = new Point(194, 208);
            cb_Category.Name = "cb_Category";
            cb_Category.Size = new Size(151, 28);
            cb_Category.TabIndex = 13;
            // 
            // txt_Password
            // 
            txt_Password.BackColor = SystemColors.Info;
            txt_Password.Location = new Point(194, 119);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(151, 27);
            txt_Password.TabIndex = 12;
            // 
            // txt_UserName
            // 
            txt_UserName.BackColor = SystemColors.Info;
            txt_UserName.Location = new Point(194, 33);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(151, 27);
            txt_UserName.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 216);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 10;
            label3.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 126);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 40);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 8;
            label1.Text = "UserName";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(480, 338);
            Controls.Add(btn_Login);
            Controls.Add(btn_Quit);
            Controls.Add(cb_Category);
            Controls.Add(txt_Password);
            Controls.Add(txt_UserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Button btn_Quit;
        private ComboBox cb_Category;
        private TextBox txt_Password;
        private TextBox txt_UserName;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
