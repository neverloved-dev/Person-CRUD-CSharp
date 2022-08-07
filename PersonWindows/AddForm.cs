using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonWindows;
using PersonWindows.Models;

namespace PersonWindows
{
    public partial class AddForm : Form
    {   private readonly Form1 form1;
        PersonContext db;
        public AddForm(Form1 frm)
        {
            InitializeComponent();
            db = new PersonContext();
            form1 = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Id = short.Parse(textBox1.Text.ToString());
            person.Oid = textBox2.Text.ToString();
            person.NameAndSurname = textBox3.Text.ToString();
            person.Place = textBox4.Text.ToString();
            person.Address = textBox5.Text.ToString();
            person.Phone = textBox6.Text.ToString();
            person.Mail = textBox7.Text.ToString();
            db.People.Add(person);
            foreach (var people in db.People)
            {
                if (person.Oid == people.Oid)
                {
                    MessageBox.Show("This OID already exists!");
                    db.People.Remove(person);
                    break;
                }
            }
            db.SaveChanges();
           form1.dataGridView1.DataSource = db.People.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
