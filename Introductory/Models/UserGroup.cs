using System.ComponentModel.DataAnnotations;

namespace Introductory.Models
{
    public class UserGroup
    {
        [Key]
        public int UserGroupID { get; set; }
        public string UserGroupName { get; set; }
        public string UserGroupCode { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }


}
