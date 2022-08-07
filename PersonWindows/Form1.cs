using PersonWindows.Models;
namespace PersonWindows
{
    public partial class Form1 : Form
    {
        PersonContext db;
        public Form1()
        {

            InitializeComponent();
            db = new PersonContext();
            var people = from person in db.People select person;
            if (people != null)
            {
                if (people.Count() > 0)
                {
                    dataGridView1.DataSource = people.ToArray();
                }
                else
                {
                    MessageBox.Show("No records have been found.", "People error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null;
                }
            }
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
                short id;
                DialogResult result = addForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
            dataGridView1.DataSource = db.People.ToList();   
             }
        
    } 
}