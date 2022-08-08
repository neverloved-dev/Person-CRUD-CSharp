using PersonWindows.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Data;

namespace PersonWindows
{
    public partial class Form1 : Form
    {
        PersonContext db;
        public Form1()
        {
            InitializeComponent();
            db = new PersonContext();
            dataGridView1.DataSource = db.People.ToList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                short id = 0;
                bool converted = short.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Person person = db.People.Find(id);
                db.People.Remove(person);
                DeleteForm delForm = new DeleteForm(this);
                delForm.label9.Text = person.Id.ToString();
                delForm.label10.Text = person.Oid;
                delForm.label11.Text = person.NameAndSurname;
                delForm.label12.Text = person.Place;
                delForm.label13.Text = person.Address;
                delForm.label14.Text = person.Phone;
                delForm.label15.Text = person.Mail;
                DialogResult result = delForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
            }
        }


            private void AddButton_Click(object sender, EventArgs e)
            {
                AddForm addForm = new AddForm(this);
                DialogResult result = addForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
             }

        private void EditButton_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                short id = 0;
                bool converted = short.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Person person = db.People.Find(id);
                EditForm editForm = new EditForm(this);
                editForm.textBox1.Text = person.Id.ToString();
                editForm.textBox2.Text = person.Oid;
                editForm.textBox3.Text = person.NameAndSurname;
                editForm.textBox4.Text = person.Place;
                editForm.textBox5.Text = person.Address;
                editForm.textBox6.Text = person.Phone;
                editForm.textBox7.Text = person.Mail;
                DialogResult result = editForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

            }

        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.People.Where(x => x.NameAndSurname.Contains(textBox1.Text)).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.People.Where(x => x.Oid.Contains(textBox2.Text)).ToList();
        }

        private void Search_File_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Make sure that a separator between different pieces of data is a semicolon (,), otherwise the file won't be read",
                "Important note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files(*.txt)| *.txt"; 
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("OIB", typeof(string));
            dt.Columns.Add("Name and Surname", typeof(string));
            dt.Columns.Add("Place", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("E- Mail", typeof(string));
            if (lines.Count == 0)
            {
                MessageBox.Show("The file is empty!",
                "Important note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                foreach(string line in lines)
                {
                    dt.Rows.Add(line.Split(","));
                }
                dataGridView1.DataSource = dt;
            }
        }
          
    }
    
}