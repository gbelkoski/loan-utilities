namespace FinanceUtilities.Domain
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public byte[] Logo { get; set; }
        public string LogoImageName { get; set; }
        public string LoanContactEmail { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonPhoneNo { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool AskQuoteEnabled { get; set; }
    }
}
