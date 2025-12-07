using System;
using IPLabs.lab5.Gifts;
using IPLabs.lab5.Sweets;

namespace IPLabs.lab5;

public class Program
{
    static void Main(string[] args)
    {
        GiftBuilder builder = new GiftBuilder();
        Gift gift = builder.Build();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Новогодний подарок ===");
            Console.WriteLine("1. Добавить шоколадную конфету");
            Console.WriteLine("2. Добавить карамельную конфету");
            Console.WriteLine("3. Добавить печенье");
            Console.WriteLine("4. Показать содержимое подарка");
            Console.WriteLine("5. Отсортировать сладости по весу");
            Console.WriteLine("6. Найти сладость по диапазону сахара");
            Console.WriteLine("7. Удалить сладость по индексу");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddChocolateCandy(gift);
                    break;
                
                case "2":
                    AddCaramelCandy(gift);
                    break;
                
                case "3":
                    AddCookie(gift);
                    break;
                
            }
        }
    }
    
    static void AddChocolateCandy(Gift gift)
    {
        Console.Write("Название: ");
        string name = Console.ReadLine();

        Console.Write("Вес: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Сахар: ");
        double sugar = double.Parse(Console.ReadLine());

        Console.Write("Тип шоколада (Milk/Dark/etc.): ");
        string type = Console.ReadLine();

        gift.AddSweet(new ChocolateCandy(name, weight, sugar, type));
        Console.WriteLine("Добавлено!");
    }
    
    static void AddCaramelCandy(Gift gift)
    {
        Console.Write("Название: ");
        string name = Console.ReadLine();

        Console.Write("Вес: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Сахар: ");
        double sugar = double.Parse(Console.ReadLine());

        gift.AddSweet(new CaramelCandy(name, weight, sugar));
        Console.WriteLine("Добавлено!");
    }
    
    static void AddCookie(Gift gift)
    {
        Console.Write("Название: ");
        string name = Console.ReadLine();

        Console.Write("Вес: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Сахар: ");
        double sugar = double.Parse(Console.ReadLine());

        Console.Write("Содержит шоколад? (true/false): ");
        bool hasChoco = bool.Parse(Console.ReadLine());

        gift.AddSweet(new Cookie(name, weight, sugar, hasChoco));
        Console.WriteLine("Добавлено!");
    }
}