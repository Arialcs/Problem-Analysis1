using System;
using System.ComponentModel.DataAnnotations;

namespace PA__1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double GPA { get; set; }

        [Required]
        [StringLength(100)]
        public string Program { get; set; }

        // New Field: Goal
        [StringLength(500)]
        public string Goal { get; set; }

        // Computed Properties
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public string GPAScale
        {
            get
            {
                if (GPA >= 3.5) return "Excellent";
                if (GPA >= 3.0) return "Very Good";
                if (GPA >= 2.5) return "Good";
                if (GPA >= 2.0) return "Satisfactory";
                return "Unsatisfactory";
            }
        }
    }
}
