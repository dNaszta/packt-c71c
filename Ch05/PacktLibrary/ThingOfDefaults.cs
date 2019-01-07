using System;
using System.Collections.Generic;
using Packt.CS7;

public class ThingOfDefaults
{
    public int Population;
    public DateTime When;
    public string Name;
    public List<Person> People;

    public ThingOfDefaults()
    {
        Population = default;
        When = default;
        Name = default;
        People = default;
    }
}