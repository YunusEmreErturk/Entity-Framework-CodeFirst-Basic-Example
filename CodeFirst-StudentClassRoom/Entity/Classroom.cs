using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com

namespace CodeFirst_StudentClassRoom.Entity

{
    //[Table("Clasroom")] DataAnnotation 
    public class Classroom
    {
       // One To Many iliski var
        public Classroom()
        {
            this.students = new HashSet<Student>();

        }
        public int ClassroomID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> students { get; set; }
    }

   
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com