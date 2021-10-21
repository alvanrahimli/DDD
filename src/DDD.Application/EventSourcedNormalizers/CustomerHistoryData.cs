namespace DDD.Application.EventSourcedNormalizers
{
    public class CustomerHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
