using PersonWindows.Models;
using Microsoft.EntityFrameworkCore;
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
                db.SaveChanges();
                dataGridView1.DataSource = db.People.ToList();
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
                dataGridView1.DataSource = db.People.ToList();
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
    }
    
}