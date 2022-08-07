using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonWindows.Models;

namespace PersonWindows
{
    public partial class DeleteForm : Form
    {
        private readonly Form1 form1;
        PersonContext db;
        public DeleteForm(Form1 frm)
        {
            InitializeComponent();
            db = new PersonContext();
            form1 = frm;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            short id = short.Parse(label9.Text.ToString());
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            form1.dataGridView1.DataSource = db.People.ToList();
            MessageBox.Show("This person has been deleted!");
            this.Close();
           
        }
    }
}
