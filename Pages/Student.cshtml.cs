/*
    Name:           Thi Ty Tran
    Date Created:   Dec 12, 2024
    Description:    ASP.NET Razor Pages - Final Assignment
    Last modified:  Dec 14, 2024
 */

using FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinalAssignment.Pages
{
    // Defining the PageModel for student management
    public class StudentModel : PageModel
    {
        // Database context for accessing student data
        private readonly MyDbContext _context;
        public List<Student> Students { get; set; } = new List<Student>(); // List of students to display

        // Property for binding student ID with validation attributes
        [BindProperty]

        // Validation for required field
        [Required(ErrorMessage = "Student ID is required.")]
        // Validation for 9-digit format
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Student ID must be 9 digits.")]
        public int? StudentId { get; set; }

        // Property for binding student name with validation
        [BindProperty]
        // Validation for required field
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        // Property for binding program name with validation
        [BindProperty]
        // Validation for required field
        [Required(ErrorMessage = "Program Name is required.")]
        public string? ProgramName { get; set; }

        // Property for binding duration with validation
        [BindProperty]
        // Validation for required field
        [Required(ErrorMessage = "Duration is required.")]
        // Validation for range
        [Range(0, 10, ErrorMessage = "Duration must be between 0 and 10.")]
        // Validation for whole number
        [RegularExpression(@"^\d+$", ErrorMessage = "Duration must be a whole number.")]
        public int? Duration { get; set; }

        // Constructor that initializes the database context
        public StudentModel(MyDbContext context)
        {
            _context = context; // Assigning the database context to the private field
        }

        // Handler for GET requests
        public void OnGet()
        {
            // Retrieve the list of students from the database
            Students = _context.Student.ToList();
        }

        // Handler for POST requests
        public IActionResult OnPost()
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Check if a student with the same ID already exists in the database
                if (_context.Student.Any(s => s.Id == StudentId))
                {
                    // Add a model state error if the StudentId is not unique
                    ModelState.AddModelError(nameof(StudentId), "Student ID already exists, please try again");
                }
                else
                {
                    // Create a new student object if validation passes
                    var newStudent = new Student
                    {
                        Id = (int)StudentId!, // Cast StudentId to int
                        Name = Name!, // Assign Name
                        ProgramName = ProgramName!, // Assign ProgramName
                        Duration = (int)Duration! // Cast Duration to int
                    };

                    // Add the new student to the database
                    _context.Student.Add(newStudent);
                    _context.SaveChanges(); // Save changes to the database
                    return RedirectToPage(); // Redirect to the same page after successful submission
                }
            }

            // Refresh the list of students if validation failed
            Students = _context.Student.ToList();
            return Page(); // Return the current page with validation errors
        }
        public IActionResult OnGetEdit(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            StudentId = student.Id;
            Name = student.Name;
            ProgramName = student.ProgramName;
            Duration = student.Duration;
            return Page();
        }

        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                var student = _context.Student.Find((int)StudentId!);
                if (student == null)
                {
                    return NotFound();
                }

                student.Name = Name!;
                student.ProgramName = ProgramName!;
                student.Duration = (int)Duration!;
                _context.SaveChanges();
                return RedirectToPage();
            }

            Students = _context.Student.ToList();
            return Page();
        }

        public IActionResult OnGetDelete(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}