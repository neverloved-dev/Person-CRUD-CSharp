using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using PersonWindows.Models;

namespace PersonWindows
{
    public partial class EditForm : Form
    {
        private readonly Form1 form1;
        PersonContext db;
        public EditForm(Form1 frm)
        {
            InitializeComponent();
            form1 = frm;
            db = new PersonContext();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            short id = short.Parse(textBox1.Text.ToString());
            Person person = db.People.Find(id);
            person.NameAndSurname = textBox3.Text.ToString();
            person.Place = textBox4.Text.ToString();
            person.Address = textBox5.Text.ToString();
            person.Phone = textBox6.Text.ToString();
            person.Mail = textBox7.Text.ToString();

            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("The data for this person has been updated!");
            form1.dataGridView1.DataSource = db.People.ToList();
           
        }
    }
}

