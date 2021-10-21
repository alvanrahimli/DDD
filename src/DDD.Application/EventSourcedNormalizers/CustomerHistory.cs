using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DDD.Domain.Core.Events;

namespace DDD.Application.EventSourcedNormalizers
{
    public class CustomerHistory
    {
        public static IList<CustomerHistoryData> HistoryData { get; set; }

        public static IList<CustomerHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CustomerHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CustomerHistoryData>();
            var last = new CustomerHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CustomerHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? "" : change.Id,
                    FirstName = string.IsNullOrWhiteSpace(change.FirstName) || change.FirstName == last.FirstName
                        ? "" : change.FirstName,
                    LastName = string.IsNullOrWhiteSpace(change.LastName) || change.LastName == last.LastName
                        ? "" : change.LastName,
                    Address = string.IsNullOrWhiteSpace(change.Address) || change.Address == last.Address
                        ? "" : change.Address,
                    PostalCode = string.IsNullOrWhiteSpace(change.PostalCode) || change.PostalCode == last.PostalCode
                        ? "" : change.PostalCode,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? "" : change.Email,
                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == last.BirthDate
                        ? "" : change.BirthDate.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CustomerHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.FirstName = values["FirstName"];
                        slot.LastName = values["LastName"];
                        slot.Address = values["Address"];
                        slot.PostalCode = values["PostalCode"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.FirstName = values["FirstName"];
                        slot.LastName = values["LastName"];
                        slot.Address = values["Address"];
                        slot.PostalCode = values["PostalCode"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
