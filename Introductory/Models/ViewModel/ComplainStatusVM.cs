using System.ComponentModel.DataAnnotations;

namespace Introductory.Models.ViewModel
{
    public class ComplainStatusVM
    {
        [Key]
        public int ComplainStatusID { get; set; }
        public string ComplainStatusName { get; set; }
        public string ComplainStatusCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
    }
}
