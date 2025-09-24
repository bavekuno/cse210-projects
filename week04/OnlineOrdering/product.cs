using System;
using System.Collections.Generic;

// The Product class encapsulates the details of a single product.
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Calculates and returns the total cost for this product.
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Returns the product's name.
    public string GetName()
    {
        return _name;
    }

    // Returns the product's ID.
    public string GetProductId()
    {
        return _productId;
    }
}