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
            MessageBox.Show("Delete button clicked");
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Person person = db.People.Find(id);
                db.People.Remove(person);
                db.SaveChanges();

                MessageBox.Show("Person deleted");
            }
        }


            private void AddButton_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Add button clicked");
            }
        
    } 
}