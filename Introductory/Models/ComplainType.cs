using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class ComplainType
    {
        [Key]
        public int ComplainTypeID { get; set; }
        public string ComplainTypeName { get; set; }
        public string ComplainTypeCode { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
