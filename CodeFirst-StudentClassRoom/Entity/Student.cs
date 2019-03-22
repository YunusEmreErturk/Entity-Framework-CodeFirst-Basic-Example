using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst_StudentClassRoom;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com
namespace CodeFirst_StudentClassRoom.Entity
{
    //[Table("Student")]
    public class Student
    {
        
        public long StudentID { get; set; }
        public string FullName { get; set; }
        public int ClassroomID { get; set; }
        public Classroom classroom { get; set; }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com