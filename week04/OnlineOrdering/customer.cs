using System;
using System.Collections.Generic;

// The Customer class holds the customer's name and their address.
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Returns true if the customer lives in the USA by checking their address.
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Returns the customer's name.
    public string GetName()
    {
        return _name;
    }

    // Returns the customer's address object.
    public Address GetAddress()
    {
        return _address;
    }
}