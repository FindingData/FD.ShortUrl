namespace FD.ShortUrl.Domain
{
    public class Contact
    {
        public Contact(string FirstName,string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
