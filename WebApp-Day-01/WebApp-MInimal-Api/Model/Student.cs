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
        private ILogger<StudentDb> logger;

        public StudentDb(DbContextOptions<StudentDb> opt,
                         ILogger<StudentDb> logger) : base(opt)
        { 
          this.logger = logger;
            logger.LogInformation($"+++ Db Ctx {ContextId}");
        }

        public DbSet<Student> Students => Set<Student>();

    }
}
