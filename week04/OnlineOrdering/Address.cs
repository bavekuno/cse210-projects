using System;
using System.Collections.Generic;

//The Address class encapsulates all the details of a physical address.
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    //Returns true if the address is in the USA, false otherwise
    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }

    //Returns a formatted string with the complete address.
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}