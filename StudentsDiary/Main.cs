using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class btnAdd : Form
    {
        // inny zapis, który może mięc problemy ze slashami ->  private string _filePath = $@"{Environment.CurrentDirectory}\students.txt";

        private string _filePath = 
            Path.Combine(Environment.CurrentDirectory, "students.txt");

        public btnAdd()
        {
            InitializeComponent();

            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;

            /*var students = new List<Student>();
            students.Add(new Student { Name = "Jaśko" });
            students.Add(new Student { Name = "Zbychu" });
            students.Add(new Student { Name = "Zdzicha" });*/

            SerializeToFile(students); 
            /*var students = DeserializeFromFile();

            foreach (var item in students)
            {
                MessageBox.Show(item.Name);
            }*/
        }

        public void SerializeToFile(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }

        public List<Student> DeserializeFromFile()
        {

            if (!File.Exists(_filePath))
            {
                return new List<Student>();
            }
            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamReader = new StreamReader(_filePath))
            {
               var students = (List<Student>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddGreen_Click(object sender, EventArgs e)
        {
            var addEditStudents = new AddEditStudent();
            addEditStudents.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz ucznia, którego dane chcesz edytować");
                return;
            }

            var addEditStudents = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
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
                $"{(selectedStudent.Cells[1].Value.ToString() + " " + selectedStudent.Cells[2].Value.ToString()).Trim()}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);


            if (confirmDelete == DialogResult.OK)
            {
                var students = DeserializeFromFile();
                students.RemoveAll(x => x.Id == Convert.ToInt32(selectedStudent.Cells[0].Value));
                SerializeToFile(students);
                dgvDiary.DataSource = students; 
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;
        }
    }
}
