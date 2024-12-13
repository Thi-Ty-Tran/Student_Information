/* 
    Name:           Thi Ty Tran
    Date Created:   Dec 12, 2024
    Description:    ASP.NET Razor Pages - Final Assignment
    Last modified:  Dec 14, 2024
 */

namespace FinalAssignment.Models
{
    // Class representing a student entity
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string ProgramName { get; set; }
		public int Duration   { get; set; }
    }
}
