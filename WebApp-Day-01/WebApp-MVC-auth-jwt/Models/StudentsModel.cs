using Microsoft.AspNetCore.Identity;

namespace WebApp_MVC_auth_jwt.Models
{
    public record class Student(string Id, String Pass, Role Role);
    public record class Role(string Name);

    public static class Students {

        public static Role masterRole = new Role("master");
        public static Role bachelorRole = new Role("bachelor");
        public static Role phdRole = new Role("phd");


        public static List<Student> students = new List<Student> { 
        new Student(Id:"Basil",Pass:"111",Role:phdRole),
        new Student(Id:"Peter",Pass:"111",Role:masterRole),
        new Student(Id:"Andrei",Pass:"111",Role:bachelorRole),

        };

    }

}
    
