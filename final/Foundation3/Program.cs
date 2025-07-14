using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        //Event Planner program
        Console.WriteLine("Hello Foundation3 World!");
        Address addr1 = new Address("100 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("200 Ocean Blvd", "Miami", "FL", "USA");
        Address addr3 = new Address("300 Park Ave", "London", "England", "UK");

        Lecture lecture = new Lecture("AI Future", "Discussion about AI and society", "2025-08-01", "10:00 AM", addr1, "Dr. Jane Doe", 200);
        Reception reception = new Reception("Networking Night", "Connect with professionals", "2025-08-02", "6:00 PM", addr2, "rsvp@events.com");
        OutdoorGathering outdoor = new OutdoorGathering("Summer Festival", "Music, food, and fun!", "2025-08-03", "3:00 PM", addr3, "Sunny, 75°F");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (Event ev in events)
        {
            Console.WriteLine("----- Standard Details -----");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("----- Full Details -----");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("----- Short Description -----");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine("----------------------------\n");
        }
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        this._street = street;
        this._city = city;
        this._state = state;
        this._country = country;
    }

    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}

class Event
{
    protected string _title;
    private string _description;
    protected string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this._title = title;
        this._description = description;
        this._date = date;
        this._time = time;
        this._address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails(); 
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: General\nTitle: {_title}\nDate: {_date}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
            $"\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Lecture\nTitle: {_title}\nDate: {_date}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
            $"\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Reception\nTitle: {_title}\nDate: {_date}";
    }
}

class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
            $"\nEvent Type: Outdoor Gathering\nWeather Forecast: {weather}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Outdoor Gathering\nTitle: {_title}\nDate: {_date}";
    }
}
