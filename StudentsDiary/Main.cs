using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {

        // inny zapis, który może mięc problemy ze slashami -> 
        // -> private string _filePath = $@"{Environment.CurrentDirectory}\students.txt";

        private List<Classrooms> _classrooms;

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
                       
            _classrooms = ClassHelper.GetClasrooms("Wszyscy uczniowie");

            InitClassesCombobox();

            RefreshDiary();
                      
            SetColumnsHeader();

            HideColumns();



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

        private void HideColumns()
        {
            dgvDiary.Columns[nameof(Student.ClassId)].Visible = false;
        }

        private void InitClassesCombobox()
        {
            
                cbxSearchInClasses.DataSource = _classrooms;
                cbxSearchInClasses.DisplayMember = "NameOfClass";
                cbxSearchInClasses.ValueMember = "ClassId";

        }

        public void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();

            var selectedClass = (cbxSearchInClasses.SelectedItem as Classrooms).ClassId;

            if (selectedClass != 0)
            {

                students = students.Where(x => x.ClassId== selectedClass).ToList();
            }

            dgvDiary.DataSource = students;
        }
        private void SetColumnsHeader()
        {
            dgvDiary.Columns[nameof(Student.Id)].HeaderText = "Numer";
            dgvDiary.Columns[nameof(Student.Name)].HeaderText = "Imię";
            dgvDiary.Columns[nameof(Student.Surname)].HeaderText = "Nazwisko";
            dgvDiary.Columns[nameof(Student.Comments)].HeaderText = "Uwagi";
            dgvDiary.Columns[nameof(Student.Math)].HeaderText = "Matematyka";
            dgvDiary.Columns[nameof(Student.Technology)].HeaderText = "Technologia";
            dgvDiary.Columns[nameof(Student.Physics)].HeaderText = "Fizyka";
            dgvDiary.Columns[nameof(Student.Polish)].HeaderText = "Język polski";
            dgvDiary.Columns[nameof(Student.Foreign)].HeaderText = "Język obcy";
            dgvDiary.Columns[nameof(Student.AddLessons)].HeaderText = "Udział w dodatkowych zajęciach";
            dgvDiary.Columns[nameof(Student.ClassOfStudent)].HeaderText = "Klasa ucznia";

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
           
        }
    }
}
