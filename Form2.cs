using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;

namespace asm._1618
{
    public partial class Form2 : Form
    {
        DataTable table = new DataTable("table");
        List<Student> students = new List<Student>();
        BindingSource bindingSource = new BindingSource();

        public Form2()
        {
            InitializeComponent();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("GPA", typeof(double));

            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;

            this.cb_Search.Items.Add("Name");
            this.cb_Search.Items.Add("ID");
            cb_Search.SelectedIndex = 0;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text;
            string email = txt_Email.Text;
            if (int.TryParse(txt_ID.Text, out int id) && double.TryParse(txt_GPA.Text, out double gpa))
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Name and Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Student newStudent = new Student(name, id)
                {
                    Email = email,
                    GPA = gpa
                };
                students.Add(newStudent);

                DataRow newRow = table.NewRow();
                newRow["ID"] = id;
                newRow["Name"] = name;
                newRow["Email"] = email;
                newRow["GPA"] = gpa;

                table.Rows.Add(newRow);
                MessageBox.Show("Added Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("ID or GPA is incorrect!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text.ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter the name of student!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedsearch = cb_Search.SelectedItem.ToString().ToLower();
            DataTable searchResult = table.Clone();

            foreach (Student student in students)
            {
                bool match = false;
                switch (selectedsearch)
                {
                    case "name":
                        match = student.Name.ToLower().Contains(keyword);
                        break;
                    case "id":
                        match = student.ID.ToString().ToLower().Contains(keyword);
                        break;
                }

                if (match)
                {
                    DataRow newRow = searchResult.NewRow();
                    newRow["ID"] = student.ID;
                    newRow["Name"] = student.Name;
                    newRow["Email"] = student.Email;
                    newRow["GPA"] = student.GPA;

                    searchResult.Rows.Add(newRow);
                }
            }

            dataGridView1.DataSource = searchResult;

            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = table;
            }
            /*string keyword = txt_Search.Text.ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter the name of the student you want to find!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable searchResult = table.Clone();

            foreach (Student student in students)
            {
                if (student.Name.ToLower().Contains(keyword))
                {
                    DataRow newRow = searchResult.NewRow();
                    newRow["ID"] = student.ID;
                    newRow["Name"] = student.Name;
                    newRow["Email"] = student.Email;
                    newRow["GPA"] = student.GPA;

                   *//* txt_Name.Text = student.Name;
                    txt_Email.Text = student.Email;
                    txt_ID.Text = student.ID.ToString();
                    txt_GPA.Text = student.GPA.ToString();*//*

                    searchResult.Rows.Add(newRow);
                }
            }
            dataGridView1.DataSource = searchResult;

            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = table;
            }*/
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text.ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter the name of the student you want to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool item = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name.ToLower().Contains(keyword))
                {
                    students.RemoveAt(i);
                    table.Rows.RemoveAt(i);

                    item = true;
                    MessageBox.Show("Delete Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            if (!item)
            {
                MessageBox.Show("Student not found! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = table;
            bindingSource.ResetBindings(false);
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            /*string name = txt_Name.Text;
            string email = txt_Email.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the name of the student you want to find!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(txt_ID.Text, out int id) && double.TryParse(txt_GPA.Text, out double gpa))
            {
                
                bool updated = false;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        students[i].Name = name;
                        students[i].Email = email;
                        students[i].ID = id;
                        students[i].GPA = gpa;

                        DataRow row = table.Rows[i];
                        row["ID"] = id;
                        row["Name"] = name;
                        row["Email"] = email;
                        row["GPA"] = gpa;

                        updated = true;
                        MessageBox.Show("Update Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bindingSource.ResetBindings(false);
                        break;
                    }
                }

                if (!updated)
                {
                    MessageBox.Show("Student not found! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ID or GPA is incorrect!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }*/
            string keyword = txt_Search.Text.ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter the name of the student you want to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool item = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name.ToLower().Contains(keyword))
                {
                    string name = txt_Name.Text;
                    string email = txt_Email.Text;
                    if (int.TryParse(txt_ID.Text, out int id) && double.TryParse(txt_GPA.Text, out double gpa))
                    {
                        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
                        {
                            MessageBox.Show("Name and Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        students[i].Name = name;
                        students[i].Email = email;
                        students[i].ID = id;
                        students[i].GPA = gpa;

                        DataRow row = table.Rows[i];
                        row["ID"] = id;
                        row["Name"] = name;
                        row["Email"] = email;
                        row["GPA"] = gpa;

                        item = true;
                        MessageBox.Show("Update Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            if (!item)
            {
                MessageBox.Show("Student not found! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bindingSource.ResetBindings(false);
        }
        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            students.Clear();
            table.Rows.Clear();
            richTextBox1.Clear();
            using (StreamReader readtext = new StreamReader("students.txt"))
            {
                string line;
                while ((line = readtext.ReadLine()) != null)
                {
                    richTextBox1.Text += line + "\n";
                    string[] info = line.Split(new string[] { " | " }, StringSplitOptions.None);

                    if (info.Length == 4)
                    {
                        string name = info[0];
                        int id = Convert.ToInt32(info[1]);
                        string email = info[2];
                        double gpa = Convert.ToDouble(info[3]);

                        Student newStudent = new Student(name, id)
                        {
                            Email = email,
                            GPA = gpa
                        };
                        students.Add(newStudent);

                        DataRow newRow = table.NewRow();
                        newRow["ID"] = id;
                        newRow["Name"] = name;
                        newRow["Email"] = email;
                        newRow["GPA"] = gpa;

                        table.Rows.Add(newRow);
                    }
                }
            }
            bindingSource.ResetBindings(false);
        }
        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            using (StreamWriter writetext = new StreamWriter("students.txt"))
            {
                foreach (Student student in students)
                {
                    string stu_info = $"{student.Name} | {student.ID} | {student.Email} | {student.GPA}";
                    writetext.WriteLine(stu_info);
                }
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            students.Clear();
            richTextBox1.Clear(); // xóa nội dung trong richtextbox
            bindingSource.ResetBindings(false);
            File.WriteAllText("students.txt", string.Empty);//xóa nội dung đã lưu
        }
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void cb_Search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
