using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.CompilerServices;
using TucAlgoritmer;

public class App
{
    private static Random rand = new Random((int)DateTime.Now.Ticks);
    List<Car> cars = new List<Car>();

    Dictionary<string, Car> carDict = new Dictionary<string, Car>();

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



    // O(n)
    public Car GetCarShortcut(string regNo)
    {
        foreach (var car in cars)
        {
//            Thread.Sleep(10000);
            if (car.Regno == regNo)
                return car;
        }

        return null;
    }



    int Add(int a, int b, int c, decimal aa)
    {
        return a + b + c + Convert.ToInt32(aa);
    }





    int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    int Add(int a, int b)
    {
        return a + b;
    }
    decimal Add(decimal a, decimal b)
    {
        return a + b;
    }

    


    public class HockeyPlayer
    {
        public int Jersey { get; set; }
        public string Name{ get; set; }

        public bool IsTheBest()
        {
            return Jersey == 13; 
        }
    }

    public class FootballPlayer
    {
        public int Shoesize { get; set; }
        public string Name { get; set; }

    }

    List<HockeyPlayer> ReadPlayers()
    {
        return new List<HockeyPlayer>()
        {
            new HockeyPlayer(),
            new HockeyPlayer()
        };
    }

    List<FootballPlayer> ReadPlayersFootball()
    {
        return new List<FootballPlayer>()
        {
            new FootballPlayer(),
            new FootballPlayer()
        };
    }



    public void Run()
    {
        //var aaa = List<HockeyPlayer>();
        var dc = new DataCache<HockeyPlayer>();
        var aw= dc.GetPlayers(ReadPlayers);
        aw = dc.GetPlayers(ReadPlayers);
        var l = new List<int>();


        var dc33 = new DataCache<FootballPlayer>();
        var aw33 = dc33.GetPlayers(ReadPlayersFootball);
        aw33 = dc33.GetPlayers(ReadPlayersFootball);



        var p = new App.HockeyPlayer();
        if (p.IsFoppa())
        {

        }

        if (p.IsTheBest())
        {

        }

        // EXTENSION METOD
        // en metod som skapas UTANFÖR en klass men
        // attachas till klassen så man kör
        // variabel.Metoden()
        var list = new List<HockeyPlayer>();
        var list2 = new List<int>();
        var list3 = new List<float>();

        list.Add(new HockeyPlayer());
        list.Add(new HockeyPlayer());
        list.CountIsTheBestPlayers();
        //list.CountIsTheBestPlayers();
        //var a = list.Count(p => p.IsTheBest());



        int a = Add(12, 13);
        int b = Add(12, 13, 14);

        // DICTINARY = MAP
        //var dict = new Dictionary<string, decimal>();
        //dict["123 123-123"] = 100;
        //dict["123 555-222"] = 500;


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
            carDict[car.Regno] = car;
        }

        cars = cars.OrderBy(car => car.Regno).ToList();


        watch.Stop();

        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");


        string start = cars[100].Regno;
        string end = cars[cars.Count - 1].Regno;


        if (cars.Count(ca => ca.Year == 1972) > 0)
        {
            Console.WriteLine("Det finns bil(ar) från 1972 ");
        }
        //BÄTTRE 
        if (cars.Any(ca => ca.Year == 1972) )
        {
            Console.WriteLine("Det finns bil(ar) från 1972 ");
        }


        watch.Reset();
        watch.Start();
        Car ca;
        if (carDict.TryGetValue(start, out ca))
        {
            Console.WriteLine("Hittade");
        }
        //Car ca = cars.FirstOrDefault(c => c.Regno == start);
        //Car ca = GetCarShortcut(start);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch.Reset();
        watch.Start();
        Car ca2;
        if (carDict.TryGetValue(end, out ca2))
        {
            Console.WriteLine("Hittade");
        }

        //Car ca2 = GetCarShortcut(end);
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