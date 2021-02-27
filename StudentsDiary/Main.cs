using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {

        // inny zapis, który może mięc problemy ze slashami -> 
        // -> private string _filePath = $@"{Environment.CurrentDirectory}\students.txt";


        private FileHelper<List<Student>> _fileHelper =
            new FileHelper<List<Student>>(Program.FilePath);

        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }
            set
            {
                Settings.Default.IsMaximize = value;
            }
        }


        public Main()
        {

            InitializeComponent();

            RefreshDiary();

            SetColumnsHeader();

            if (IsMaximize)
            {
                WindowState = FormWindowState.Maximized;
            }

           
            //nie wiem czy to tu być powinno -> SerializeToFile(students);

            /*var students = new List<Student>();
            students.Add(new Student { Name = "Jaśko" });
            students.Add(new Student { Name = "Zbychu" });
            students.Add(new Student { Name = "Zdzicha" });*/


            /*var students = DeserializeFromFile();

            foreach (var item in students)
            {
                MessageBox.Show(item.Name);
            }*/
        }

        public void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;
        }
        private void SetColumnsHeader()
        {
            dgvDiary.Columns[0].HeaderText = "Numer";
            dgvDiary.Columns[1].HeaderText = "Imię";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Uwagi";
            dgvDiary.Columns[4].HeaderText = "Matematyka";
            dgvDiary.Columns[5].HeaderText = "Technologia";
            dgvDiary.Columns[6].HeaderText = "Fizyka";
            dgvDiary.Columns[7].HeaderText = "Język polski";
            dgvDiary.Columns[8].HeaderText = "Język obcy";
            dgvDiary.Columns[9].HeaderText = "Udział w dodatkowych zajęciach";
            dgvDiary.Columns[10].HeaderText = "Klasa ucznia";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudents = new AddEditStudent();
            addEditStudents.FormClosing += AddEditStudents_FormClosing;
            addEditStudents.ShowDialog();
        }

        private void AddEditStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshDiary();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz ucznia, którego dane chcesz edytować");
                return;
            }

            var addEditStudents = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));

            addEditStudents.FormClosing += AddEditStudents_FormClosing;

            addEditStudents.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz ucznia, którego chcesz usunąć");
                return;
            }
            var selectedStudent = dgvDiary.SelectedRows[0];

            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia " +
                $"{(selectedStudent.Cells[1].Value.ToString() + " " + selectedStudent.Cells[2].Value.ToString() + " ?").Trim()}",
                "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
                RefreshDiary();
            }

        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDiary();
        }


        private void Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                IsMaximize = true;
            }
            else
            {
                IsMaximize = false;
            }
            Settings.Default.Save();
        }

        private void cbxSearchInClasses_Click(object sender, EventArgs e)
        {
            List<Classrooms> classrooms = new List<Classrooms>();
            classrooms.Add(new Classrooms { ClassId = 1, NameOfClass = "1a" });
            classrooms.Add(new Classrooms { ClassId = 2, NameOfClass = "1b" });
            classrooms.Add(new Classrooms { ClassId = 3, NameOfClass = "2a" });
            classrooms.Add(new Classrooms { ClassId = 4, NameOfClass = "2b" });


            foreach (var item in classrooms)
            {
                cbxSearchInClasses.Items.Add(item);
            }

        }
    }
}
