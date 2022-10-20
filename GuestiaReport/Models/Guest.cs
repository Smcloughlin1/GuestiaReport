namespace GuestiaReport.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int GuestGroupId { get; set; }

        public virtual GuestGroup GuestGroup { get; set; }
    }
}
