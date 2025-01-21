using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models
{
    public class UserGroup
    {
        [Key]
        public int UserGroupID { get; set; }
        public string UserGroupName { get; set; }
        public string UserGroupCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey("CreatedBy")]
        public virtual Users Users { get; set; }

    }


}
