namespace Introductory.Models.ViewModel
{
    public class ComplainStatusVM
    {
        public int ComplainStatusID { get; set; }
        public string ComplainStatusName { get; set; }
        public string ComplainStatusCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
