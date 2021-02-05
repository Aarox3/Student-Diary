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
        private string _filePath =
               Path.Combine(Environment.CurrentDirectory, "students.txt");
        private int _studentId;

        public AddEditStudent(int id = 0)
        {
            InitializeComponent();
            _studentId = id;


            if (id != 0)
            {
                var students = DeserializeFromFile();
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }
                tbId.Text = student.Id.ToString();
                tbName.Text = student.Name;
                tbSurname.Text = student.Surname;
                tbMath.Text = student.Math;
                tbPhysic.Text = student.Physics;
                tbLanguage.Text = student.Foreign;
                tbPolish.Text = student.Polish;
                tbtech.Text = student.Technology;
                rtbComments.Text = student.Comments;
            }
            tbName.Select();
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
            var students = DeserializeFromFile();

            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {

                var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();
                var _studentId = 0;

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
            };
            students.Add(student);
            SerializeToFile(students);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}

