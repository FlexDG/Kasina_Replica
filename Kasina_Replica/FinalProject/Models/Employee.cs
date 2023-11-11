using Microsoft.Build.Framework;

namespace FinalProject.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        public Guid DesignationId { get; set; }

        public Designation Designation { get; set; }

    }
}
