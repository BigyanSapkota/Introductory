using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models.ViewModel
{
    public class ComplainVM
    {
        public int ComplainId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Statement { get; set; }
        public string Address { get; set; }
        public int CustomerNo { get; set; }
        public string IssueDate { get; set; }
        public string CreatedDate { get; set; }
        public int ComplainTypeID { get; set; }
    }
}
