using System;
using System.Numerics;

public class App
{
    private static Random rand = new Random((int)DateTime.Now.Ticks);
    List<Car> cars = new List<Car>();

    public Car GetCar(string regNo)
    {
        Car carToReturn = null;
        foreach (var car in cars)
        {
            if (car.Regno == regNo)
                carToReturn = car;
        }

        return carToReturn;
    }


    public Car GetCarShortcut(string regNo)
    {
        foreach (var car in cars)
        {
            if (car.Regno == regNo)
                return car;
        }

        return null;
    }


    public void Run()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 0; i < 10000000; i++)
        {
            var regno = GenRegno();
            var car = new Car
            {
                Regno = regno,
                Year = rand.Next(1970, 2023)
            };
            cars.Add(car);
        }

        watch.Stop();

        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");


        string start = cars[100].Regno;
        string end = cars[cars.Count - 1].Regno;



        watch.Reset();
        watch.Start();
        Car ca = GetCar(start);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch.Reset();
        watch.Start();
        Car ca2 = GetCar(end);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

    }

    private string GenRegno()
    { 
        string ret = "";
        for (int i = 0; i < 3; i++)
            ret += GetLetter();
        for (int i = 0; i < 3; i++)
            ret += rand.Next(0, 10).ToString();
        return ret;

    }

    private char GetLetter()
    {
        int num = rand.Next(0, 26); // Zero to 25
        return  (char)('A' + num);

    }
}