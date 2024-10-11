using Microsoft.EntityFrameworkCore;

namespace WebApp_MInimal_Api.Model
{
    public class Student
    {
     public int Id { get; set; }
     public string Name { get; set; }  
     public bool IsReady { get; set; }
    //....

    }

    public class StudentDb : DbContext
    {
        public StudentDb(DbContextOptions<StudentDb> opt
            ) : base(opt)
        { }

        public DbSet<Student> Students => Set<Student>();

    }
}
