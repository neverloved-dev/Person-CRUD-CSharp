using PersonWindows.Models;
namespace PersonWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var db = new PersonContext();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}