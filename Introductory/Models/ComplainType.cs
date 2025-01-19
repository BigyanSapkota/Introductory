using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class ComplainType
    {
        [Key]
        public int ComplainTypeCode { get; set; }
        public string ComplainTypeName { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
