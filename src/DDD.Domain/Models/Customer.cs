using System;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Customer : EntityAudit
    {
        protected Customer() { }

        public Customer(Guid id, string firstName, string lastName, string address, string postalCode, string email, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
            Email = email;
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
