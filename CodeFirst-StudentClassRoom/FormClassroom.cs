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


//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 

namespace CodeFirst_StudentClassRoom
{
    //Student Formunda yapilan islemlerin aynilarını burada yaptik.Aciklamalar orada mevcuttur.
 
    public partial class FormClassroom : Form
    {
        int selectedClassroomID;
        Classroom selectedClassroom;
        StudentClassroomContext db = new StudentClassroomContext();
        public FormClassroom()
        {
            InitializeComponent();
        }
        
        private void FormClassroom_Load(object sender, EventArgs e)
        {
            dataGridViewClassroom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var classrooms = db.Classrooms.Select(x => new
                {
                    x.Description,
                    x.ClassroomID
                }).ToList();

                dataGridViewClassroom.DataSource = classrooms;
            }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description can't be null");
            }
            else
            {

            try
            {

            Classroom classroom = new Classroom();
            classroom.Description = txtDescription.Text;
            db.Classrooms.Add(classroom);
            db.SaveChanges();


            var classrooms = db.Classrooms.Select(x => new
            {
                x.Description,
                x.ClassroomID
            }).ToList();

            dataGridViewClassroom.DataSource = classrooms;

            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection !");
            }

            }

        }

        private void dataGridViewClassroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            if (dataGridViewClassroom.SelectedRows.Count>1)
            {
                MessageBox.Show("Go to MULTI DELETE !");
            }
            else
            {

            db.Classrooms.Remove(selectedClassroom);
            MessageBox.Show("Delete Successfully");
            db.SaveChanges();


            var classrooms = db.Classrooms.Select(x => new
            {
                x.Description,
                x.ClassroomID
            }).ToList();

            dataGridViewClassroom.DataSource = classrooms;

            }

            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection");
            }

        }

        private void dataGridViewClassroom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedClassroomID = Convert.ToInt32(dataGridViewClassroom.CurrentRow.Cells[1].Value);
            selectedClassroom = db.Classrooms.Find(selectedClassroomID);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            Classroom classroom = db.Classrooms.Find(selectedClassroomID);
            classroom.Description = txtDescription.Text;
            db.SaveChanges();
            MessageBox.Show("Update Successfully");

            var classrooms = db.Classrooms.Select(x => new
            {
                x.Description,
                x.ClassroomID
            }).ToList();


            dataGridViewClassroom.DataSource = classrooms;

            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection");
            }
            //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 

        }

        private void btnDeleteMulti_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewClassroom.SelectedRows.Count<2)
            {
                MessageBox.Show("Go To DELETE !");
            }
            else
            {
                Classroom classroom;
                foreach (DataGridViewRow item in dataGridViewClassroom.SelectedRows)
                {
                    classroom = db.Classrooms.Find(item.Cells["ClassroomID"].Value);
                    db.Classrooms.Remove(classroom);     
                }
                db.SaveChanges();

                MessageBox.Show("Multi Delete is Successfully");

                var classrooms = db.Classrooms.Select(x => new
                {
                    x.Description,
                    x.ClassroomID
                }).ToList();


                dataGridViewClassroom.DataSource = classrooms;

            }
        }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 