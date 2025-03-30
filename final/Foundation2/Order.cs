using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer {get; set;}

    public Order (Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateProductTotal() 
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            double productPrice = product.CalculatePrice();
            subtotal += productPrice;
        }
        subtotal = Math.Round(subtotal, 2);
        return subtotal;
    }

    public double CalculateTotal()
    {
        double subtotal = CalculateProductTotal();
        double shipping = _customer.CustInUSA() ? 5.00 : 35.00;
        Console.WriteLine($"Shipping Cost: ${shipping}");

        double totalCost = subtotal + shipping;
        totalCost = Math.Round(totalCost, 2);
        return totalCost;
    }

    public void DisplayCosts(double subtotal, double shippingCost, double totalCost)
    {   
        Console.WriteLine($"Subtotal: ${subtotal}");
        Console.WriteLine($"Shipping: ${shippingCost}");
        Console.WriteLine($"Total: ${totalCost}");
    }

    public string DisplayPackingLabel()
    {   
        Console.WriteLine("Packing Label:");
        foreach (Product product in _products)
        {
            product.DisplayProductDetails();
        }
        return "";
    }
    public string DisplayShippingLabel()
    {   
        Console.WriteLine("Shipping Label");
        Console.WriteLine("SHIP TO: ");
        Console.WriteLine(_customer.GetCustomerDetails());
        return "";
    }
}