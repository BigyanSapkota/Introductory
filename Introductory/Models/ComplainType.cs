using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class ComplainType
    {
        [Key]
        public int ComplainTypeID { get; set; }
        public string ComplainTypeName { get; set; }
        public string ComplainTypeCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}