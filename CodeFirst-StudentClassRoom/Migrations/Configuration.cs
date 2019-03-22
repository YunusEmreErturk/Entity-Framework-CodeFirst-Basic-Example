namespace CodeFirst_StudentClassRoom.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst_StudentClassRoom.Context.StudentClassroomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CodeFirst_StudentClassRoom.Context.StudentClassroomContext";
        }

        protected override void Seed(CodeFirst_StudentClassRoom.Context.StudentClassroomContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
