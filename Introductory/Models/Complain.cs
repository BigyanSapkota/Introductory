using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models
{
    public class Complain
    {
        [Key]
        public int ComplainId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Statement { get; set; } //ckeditor
        public string Address { get; set; }
        public int CustomerNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ComplainTypeID { get; set; }

        [ForeignKey("ComplainTypeID")]
        public virtual ComplainType ComplainType { get; set; }

    }
}
