using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderingSystem
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        public Address(string street, string city, string state, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public bool IsInUSA()
        {
            return string.Equals(_country, "USA", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_street);
            stringBuilder.AppendLine($"{_city}, {_state} {_country}");
            return stringBuilder.ToString();
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public bool IsInUSA()
        {
            if (_address != null)
            {
                return _address.IsInUSA();
            }

            return false;
        }
    }

    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _price;
        private int _quantity;

        public Product(string name, string productId, decimal price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal GetTotalCost()
        {
            return _price * _quantity;
        }
    }

    public class Order
    {
        private Customer _customer;
        private List<Product> _products;
        private const decimal SHIPPING_USA = 5.00m;
        private const decimal SHIPPING_INTL = 35.00m;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        private decimal GetShippingCost()
        {
            if (_customer.IsInUSA())
            {
                return SHIPPING_USA;
            }
            else
            {
                return SHIPPING_INTL;
            }
        }

        public decimal GetTotalPrice()
        {
            decimal totalCost = 0;

            foreach (Product product in _products)
            {
                totalCost += product.GetTotalCost();
            }

            return totalCost + GetShippingCost();
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("--- PACKING LABEL ---");

            foreach (Product product in _products)
            {
                label.AppendLine($"Product: {product.Name} | ID: {product.ProductId}");
            }

            label.AppendLine("---------------------");
            return label.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("--- SHIPPING LABEL ---");
            label.AppendLine($"To: {_customer.Name}");
            label.Append(_customer.Address.ToString());
            label.AppendLine("----------------------");
            return label.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Order 1: USA Customer
            Address address1 = new Address("123 Maple Drive", "Springfield", "IL", "USA");
            Customer customer1 = new Customer("John Frank", address1);
            Order order1 = new Order(customer1);

            Product product1 = new Product("Wireless Mouse", "WM-001", 45.00m, 2);
            Product product2 = new Product("Deskstop Keyboard", "DK-600", 85.60m, 1);

            order1.AddProduct(product1);
            order1.AddProduct(product2);

            DisplayOrderDetails(order1, "ORDER #1");

            // Order 2: International Customer
            Address address2 = new Address("15 Lekki Express Way", "Lagos", "Lekki-Lagos", "Nigeria");
            Customer customer2 = new Customer("Simeon Obianwa", address2);
            Order order2 = new Order(customer2);

            Product product3 = new Product("Smart Toy", "ST-105", 15.88m, 3);
            Product product4 = new Product("Monitor Handle", "MH-400", 45.00m, 1);
            Product product5 = new Product("Webcam HD", "WC-668", 66.50m, 1);

            order2.AddProduct(product3);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            DisplayOrderDetails(order2, "ORDER #2");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DisplayOrderDetails(Order order, string title)
        {
            Console.WriteLine($"{title} Details");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine($"Total Price: {order.GetTotalPrice():C2}");
            Console.WriteLine();
        }
    }
}