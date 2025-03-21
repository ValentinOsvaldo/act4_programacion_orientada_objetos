namespace ProductInterfaces;

public interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
    int Stock { get; set; }
    void Display();
}

public abstract class AbstractProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public AbstractProduct(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public abstract void Display();
}

public class ElectronicProduct : AbstractProduct
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public ElectronicProduct(int id, string name, decimal price, int stock, string brand, string model) : base(id, name, price, stock)
    {
        Brand = brand;
        Model = model;
    }
    public override void Display()
    {
        Console.WriteLine($"Producto Electrónico: {Name}\nMarca: {Brand}\nModelo: {Model}\nPrecio: {Price}\nCantidad: {Stock}");
    }
}

public class FoodProduct : AbstractProduct
{
    public DateTime Expires { get; set; }

    public FoodProduct(int id, string name, decimal price, int stock, DateTime expires) : base(id, name, price, stock)
    {
        Expires = expires;
    }
    public override void Display()
    {
        Console.WriteLine($"Producto Alimenticio: {Name}\nFecha de Caducidad: {Expires.ToShortDateString()}\nPrecio: {Price}\nCantidad: {Stock}");
    }
}

public class InventorySystem
{
    private List<IProduct> products;

    public InventorySystem()
    {
        products = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        products.Add(product);
    }

    public void DisplayProducts()
    {
        foreach (var product in products)
        {
            product.Display();
            Console.WriteLine("\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        InventorySystem inventory = new();
        ElectronicProduct electronicProduct = new(1, "Laptop", 1500, 10, "Dell", "Inspiron 15");
        FoodProduct foodProduct = new(2, "Leche", 40, 100, DateTime.Now);

        inventory.AddProduct(electronicProduct);
        inventory.AddProduct(foodProduct);

        inventory.DisplayProducts();
    }
}


