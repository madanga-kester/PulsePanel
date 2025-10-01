using System.ComponentModel.DataAnnotations;
namespace PulsePanel.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Fullname => $" {FirstName} {SecondName} ";
        public int StudentId { get; set; }
        public int Age { get; set; }

        public Students()
        { }

        public Students(string aFirstName, string aSecondName, int aStudentId, int aAge)
        {

            FirstName = aFirstName;
            SecondName = aSecondName;
            StudentId = aStudentId;
            Age = aAge;

        }


        public static Students CreateNewstudent(string aFirstName, string aSecondName, int aStudentId, int aAge)
        {
            return new Students(aFirstName, aSecondName, aStudentId, aAge);
        }
    }




    class program
    {

        static void Main(string[] args)
        {
            Students Student1 = new Students("Kester", "Madanga", 4323, 20);

            Console.WriteLine($" The student is: {Student1.Fullname}, Id: {Student1.StudentId}, Age: {Student1.Age}");


        }
    }
}
















