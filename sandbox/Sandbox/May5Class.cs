using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1
    }
}


class Job
{
    public string _company;
    public string _title;
    public int _startYear, EndYear;
    public void Display()
    {
        Console.WriteLine(${"_title} ({_company}) {_startYear} - {_endYear}
    }
}

class Applicant
{
    public string _firstName;
    public string _lastName;
    public string _phoneNumber;
    public string _emailAddress;
    public int _order

}