using System;
using System.Collections.Generic;

// The Address class encapsulates all the details of a physical address.
// The Customer class holds the customer's name and their address.
// The Product class encapsulates the details of a single product.
// The Order class manages a customer and a list of products.

// The Program class is the entry point for the application.
public class Program
{
    public static void Main(string[] args)
    {
        // Create an address for a USA customer.
        Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer usaCustomer = new Customer("John Smith", usaAddress);

        // Create an order for the USA customer.
        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(new Product("Laptop", "LAP101", 1200.00, 1));
        usaOrder.AddProduct(new Product("Mouse", "MOU202", 25.50, 2));

        // Display the details for the USA order.
        Console.WriteLine("Order 1 (USA Customer)");
        Console.WriteLine(usaOrder.GetPackingLabel());
        Console.WriteLine("---");
        Console.WriteLine(usaOrder.GetShippingLabel());
        Console.WriteLine("---");
        Console.WriteLine($"Total Order Cost: ${usaOrder.GetTotalCost():F2}");
        Console.WriteLine("\n------------------------------------------\n");

        // Create an address for a non-USA customer.
        Address nonUsaAddress = new Address("456 International Blvd", "Global City", "Ontario", "Canada");
        Customer nonUsaCustomer = new Customer("Jane Doe", nonUsaAddress);

        // Create an order for the non-USA customer.
        Order nonUsaOrder = new Order(nonUsaCustomer);
        nonUsaOrder.AddProduct(new Product("Keyboard", "KEY303", 75.00, 1));
        nonUsaOrder.AddProduct(new Product("Monitor", "MON404", 300.00, 1));
        nonUsaOrder.AddProduct(new Product("Webcam", "CAM505", 50.00, 3));

        // Display the details for the non-USA order.
        Console.WriteLine("Order 2 (Non-USA Customer)");
        Console.WriteLine(nonUsaOrder.GetPackingLabel());
        Console.WriteLine("---");
        Console.WriteLine(nonUsaOrder.GetShippingLabel());
        Console.WriteLine("---");
        Console.WriteLine($"Total Order Cost: ${nonUsaOrder.GetTotalCost():F2}");
    }
}