namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int Id { get; set; }
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }
    }
}