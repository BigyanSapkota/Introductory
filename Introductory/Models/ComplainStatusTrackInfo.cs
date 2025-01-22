using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class ComplainStatusTrackInfo
    {
        [Key]
        public int ComplainStatusTrackInfoID { get; set; }
        public int ComplainID { get; set; }
        public int ComplainStatusID { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("ComplainID")]
        public virtual Complain Complain { get; set; }

        [ForeignKey("ComplainStatusID")]
        public virtual ComplainStatus ComplainStatus { get; set; }
    }
}
