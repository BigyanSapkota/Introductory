using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class ComplainStatus
    {
        [Key]
        public int ComplainStatusID { get; set; }
        public string ComplainStatusName { get; set; }
        public string ComplainStatusCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Users { get; set; }
    }
}
