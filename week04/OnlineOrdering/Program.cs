using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emily Johnson", address2);

        // Create first order (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP001", 899.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MOU001", 29.99, 2));
        order1.AddProduct(new Product("USB Cable", "CAB001", 9.99, 3));

        // Create second order (International customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "PHO001", 699.99, 1));
        order2.AddProduct(new Product("Phone Case", "CAS001", 19.99, 1));

        // Display information for first order
        Console.WriteLine("ORDER 1:");
        Console.WriteLine("========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Display information for second order
        Console.WriteLine("ORDER 2:");
        Console.WriteLine("========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}