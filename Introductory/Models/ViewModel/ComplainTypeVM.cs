namespace Introductory.Models.ViewModel
{
    public class ComplainTypeVM
    {
        public string ComplainTypeName { get; set; }
        public string ComplainTypeCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
    }
}
