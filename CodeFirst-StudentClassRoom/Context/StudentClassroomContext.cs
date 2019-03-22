namespace CodeFirst_StudentClassRoom.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CodeFirst_StudentClassRoom.Entity;
    public class StudentClassroomContext : DbContext
    {
        // Your contexthas been configured to use a 'StudentClassroomContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst_StudentClassRoom.StudentClassroomContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentClassroomContext' 
        // connection string in the application configuration file.
        public StudentClassroomContext()
            : base("name=StudentClassroomContext")
        {
        }


        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}