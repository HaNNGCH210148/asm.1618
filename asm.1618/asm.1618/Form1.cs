namespace asm._1618
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            this.txt_Password.PasswordChar = '*';
            this.cb_Category.Items.Add("Admin");
            this.cb_Category.Items.Add("Student");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string selectedCategory = cb_Category.SelectedItem.ToString();
            if (this.txt_UserName.Text == "Admin")
            {
                if (this.txt_Password.Text == "123" && selectedCategory == "Admin")
                {
                    this.form2.Show();
                    MessageBox.Show("Welcome Admin!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password. Please enter again to login!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }
    }
}
