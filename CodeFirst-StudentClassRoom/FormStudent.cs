using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirst_StudentClassRoom.Context;
using CodeFirst_StudentClassRoom.Entity;
namespace CodeFirst_StudentClassRoom
{
    //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com
    public partial class FormStudent : Form
    {
        //Comboboxlardan idleri alip tutacagım ve o idye ait Student nesnelerini selectedStudent degiskenine verecegim.
        int selectedStudentID;
        Student selectedStudent;

        StudentClassroomContext db = new StudentClassroomContext();
        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

            FillStudents();
            FillClassrooms();
        }

        //Classromların comboboxa getirilmesi.
        public void FillClassrooms()
        {
            var classrooms = db.Classrooms.Select(x => new
            {
                x.Description,
                x.ClassroomID
            }).ToList();

            cmbClassroom.DisplayMember = "Description";
            cmbClassroom.ValueMember = "ClassroomID";
            cmbClassroom.DataSource = classrooms;   

        }

        //studentların  datagridview'a getirilmesi.
        public void FillStudents()
        {
            var students = db.Students.Select(x => new
            {
                x.StudentID,
                x.FullName,
                x.classroom.Description
                
            }).ToList();

            dataGridViewStudent.DataSource = students;

        }
        //Secili sinifa ogrenci ekleme
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Fullname can't be null");
            }
            else
            {

            try
            {
                Student student = new Student();
                student.FullName = txtFullname.Text;
                student.ClassroomID = Convert.ToInt32(cmbClassroom.SelectedValue);
                db.Students.Add(student);
                MessageBox.Show("Add Student Successfully");
                db.SaveChanges();
                FillStudents();
            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection ");
            }

            }

        }
        //datagridview'dan secilen ogrencilerin bulunmasi
        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedStudentID = Convert.ToInt32(dataGridViewStudent.CurrentRow.Cells[0].Value);
            selectedStudent = db.Students.Find(selectedStudentID);

        }
        //ogrencilerin tekli silinmesi
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            if (dataGridViewStudent.SelectedRows.Count>1)
            {
                MessageBox.Show("Go To Multi Delete !");
            }
            else
            {

            db.Students.Remove(selectedStudent);
            db.SaveChanges();
            MessageBox.Show("Delete Successfully");
            FillStudents();

            }

            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection");
            }
        }
        //guncelleme islemlerinin yapılmasi
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            Student student = db.Students.Find(selectedStudentID);
            student.FullName = txtFullname.Text;
            student.ClassroomID =Convert.ToInt32(cmbClassroom.SelectedValue);
            db.SaveChanges();
            FillStudents();


            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection");
            }
        }

        //coklu silme islemi
        private void btnDeleteMulti_Click(object sender, EventArgs e)
        {
         
            if (dataGridViewStudent.SelectedRows.Count < 2)
            {
                MessageBox.Show("Go To DELETE !");
            }
            else
            {
                Student student;
                foreach (DataGridViewRow item in dataGridViewStudent.SelectedRows)
                {
                    student = db.Students.Find(item.Cells["StudentID"].Value);
                    db.Students.Remove(student);
                }
                db.SaveChanges();

                MessageBox.Show("Multi Delete is Successfully");

                FillStudents();

            }
           
        }
    }
}
