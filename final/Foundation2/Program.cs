using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Order Processing System");
        Console.WriteLine("==========================================================");

        // Add products for the order
        Product product1 = new Product("Thingamabob", "123", 19.99, 2);
        Product product2 = new Product("Doohickey", "456", 29.99, 1);
        Product product3 = new Product("Whatchamacallit", "789", 49.99, 3);
        
        // Create a new customer & address
        Address address1 = new Address("1969 Sesame St", "Jacksonville", "MS", "USA");
        Customer customer1 = new Customer("John", address1);

        // Create a new order
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Calculate costs and display order
        
        Console.WriteLine($"Subtotal: {order1.CalculateProductTotal()}");
        Console.WriteLine($"Total: {order1.CalculateTotal()}");
        Console.WriteLine();
        Console.WriteLine(order1.DisplayPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.DisplayShippingLabel());
        
        Console.WriteLine("---------------------------------------------------------");

        // Add another order

        Product product4 = new Product("Gadget", "101", 15.99, 1);
        Product product5 = new Product("Gizmo", "202", 25.99, 2);
        Product product6 = new Product("Contraption", "303", 35.99, 1);

        Address address2 = new Address("1974 Muppet Ave", "New York", "NY", "USA");
        Customer customer2 = new Customer("Jacob", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        // Calculate costs and display order
        Console.WriteLine($"Subtotal: ${order2.CalculateProductTotal()}");
        Console.WriteLine($"Total: ${order2.CalculateTotal()}");
        Console.WriteLine();
        Console.WriteLine(order2.DisplayPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.DisplayShippingLabel());

        Console.WriteLine("---------------------------------------------------------");
    }
}