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

    public partial class AddEditStudent : Form
    {
        public delegate void MySimpleDelegate();
        public event MySimpleDelegate StudentAdded;

        private int _studentId;
        private Student _student;

        public static List<Classrooms> Classrooms = new List<Classrooms>();


        private List<Classrooms> _classrooms; 

        private FileHelper<List<Student>> _fileHelper =
            new FileHelper<List<Student>>(Program.FilePath);

        public AddEditStudent(int id = 0)
        {
            InitializeComponent();

            _studentId = id;

            _classrooms = ClassHelper.GetClasrooms("Brak klasy");
           
            InitClassesCombobox();

            GetStudentData();

            tbName.Select();
                   
        }

        private void InitClassesCombobox()
        {
            {
                cbxClass.DataSource =_classrooms;
                cbxClass.DisplayMember = "NameOfClass";
                cbxClass.ValueMember = "ClassId";

                foreach (var item in Classrooms)
                {
                    cbxClass.Items.Add(item);
                }
            }
        }

        private void GetStudentData()
        {
            
            if (_studentId != 0)
            {
                Text = "Edytowanie danych ucznia";

                var students = _fileHelper.DeserializeFromFile();

                _student = students.FirstOrDefault(x => x.Id == _studentId);

                if (_student == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }
                
                FillTextBoxes();

            }

        }

        private void FillTextBoxes()
        {
            tbId.Text = _student.Id.ToString();
            tbName.Text = _student.Name;
            tbSurname.Text = _student.Surname;
            tbMath.Text = _student.Math;
            tbPhysic.Text = _student.Physics;
            tbLanguage.Text = _student.Foreign;
            tbPolish.Text = _student.Polish;
            tbtech.Text = _student.Technology;
            rtbComments.Text = _student.Comments;
            chbxAddLessons.Checked = _student.AddLessons;
            //cbxClass.Text = _student.ClassOfStudent;
            cbxClass.SelectedItem = _classrooms.FirstOrDefault(x => x.ClassId == _student.ClassId);

            /*cbxClass.Items.Add("1a");
            cbxClass.Items.Add("1b");
            cbxClass.Items.Add("2a");
            cbxClass.Items.Add("2b");*/

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbSurname_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_studentId != 0)

                students.RemoveAll(x => x.Id == _studentId);

            else

                AssignIdToNewStudent(students);

            AddNewUserToList(students);


            _fileHelper.SerializeToFile(students);

            Close();
        }

        private void AddNewUserToList(List<Student> students)
        {
            
            var student = new Student
            {
                Id = _studentId,
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Comments = rtbComments.Text,
                Foreign = tbLanguage.Text,
                Math = tbMath.Text,
                Physics = tbPhysic.Text,
                Polish = tbPolish.Text,
                Technology = tbtech.Text,
                AddLessons = chbxAddLessons.Checked,
                ClassOfStudent = cbxClass.Text,
                // ClassId = cbxClass.Text,
                ClassId = (cbxClass.SelectedItem as Classrooms).ClassId
            };
            students.Add(student);
        }

        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();


            if (studentWithHighestId == null)
            {
                _studentId = 1;
            }
            else
            {
                _studentId = studentWithHighestId.Id + 1;
            }
            // var _studentId = studentWithHighestId == null ? 1 : studentWithHighestId.Id + 1;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

