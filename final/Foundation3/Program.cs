using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Ocean Ave", "Miami", "FL", "USA");
        Address address3 = new Address("789 Hilltop Rd", "Denver", "CO", "USA");

        Lecture lecture = new Lecture("Tech Talk", "AI and the Future", "2025-06-12", "10:00 AM", address1, "Dr. Jane Smith", 100);
        Reception reception = new Reception("Company Mixer", "Networking with professionals", "2025-07-01", "6:00 PM", address2, "rsvp@events.com");
        OutdoorGathering outdoor = new OutdoorGathering("Summer Bash", "Live music and food trucks!", "2025-08-15", "4:00 PM", address3, "Sunny with clear skies");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine("STANDARD DETAILS:");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("FULL DETAILS:");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("SHORT DESCRIPTION:");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine(new string('-', 50));
        }
    }
}
