using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_StudentClassRoom
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void defineClassroomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClassroom frm = new FormClassroom();
            frm.Show();
        }

        private void defineStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStudent frm = new FormStudent();
            frm.Show();
        }
        //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
        private void FormMenu_Load(object sender, EventArgs e)
        {
            //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
        }
    }
}
