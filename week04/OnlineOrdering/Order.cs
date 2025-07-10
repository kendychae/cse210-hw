using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;

        // Calculate total cost of all products
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost
        if (_customer.IsInUSA())
        {
            totalCost += 5.00; // USA shipping cost
        }
        else
        {
            totalCost += 35.00; // International shipping cost
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL:\n";
        packingLabel += "==============\n";

        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL:\n";
        shippingLabel += "===============\n";
        shippingLabel += $"{_customer.GetName()}\n";
        shippingLabel += _customer.GetAddress().GetFullAddress();

        return shippingLabel;
    }
}
