//====
//CRUD
//====

using Labaratoriya;

internal class Program
{
    private static void Main(string[] args)
    {
        var crudMijoz = new CrudMijoz();
        var crudOrgan = new CrudOrgan();

        while (true)
        {
            Console.WriteLine("Qaysi model ustida amal bajarmoqchisiz: ");
            Console.WriteLine("1.Mijoz");
            Console.WriteLine("2.Organ");

            string value = Console.ReadLine();
            int n;
            if (int.TryParse(value, out n) && n == 1 && n <= 2)
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Mijoz model ustida qanday amal bajarmoqchisiz: ");
                    Console.WriteLine("1.Create");
                    Console.WriteLine("2.Read");
                    Console.WriteLine("3.Update");
                    Console.WriteLine("4.Delete");
                    Console.WriteLine("5.Back");
                    string _value = Console.ReadLine();
                    int k;
                    if (int.TryParse(_value, out k) && k == 1 && k <= 5)
                    {
                        Console.Clear();
                        crudMijoz.Create();
                    }
                    else if (int.TryParse(_value, out k) && k == 2 && k <= 5)
                    {
                        Console.Clear();
                        crudMijoz.Read();
                    }
                    else if (int.TryParse(_value, out k) && k == 3 && k <= 5)
                    {
                        Console.Clear();
                        crudMijoz.Update();
                    }
                    else if (int.TryParse(_value, out k) && k == 4 && k <= 5)
                    {
                        Console.Clear();
                        crudMijoz.Delete();
                    }
                    else if (int.TryParse(_value, out k) && k == 5 && k <= 5)
                        break;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Mos amalni kiriting 1,2,3,4,5");
                    }
                }
            }
            else if (int.TryParse(value, out n) && n == 2 && n <= 2)
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Organ model ustida qanday amal bajarmoqchisiz: ");
                    Console.WriteLine("1.Create");
                    Console.WriteLine("2.Read");
                    Console.WriteLine("3.Update");
                    Console.WriteLine("4.Delete");
                    Console.WriteLine("5.Back");
                    string value_ = Console.ReadLine();
                    int h;
                    if (int.TryParse(value_, out h) && h == 1 && h <= 5)
                    {
                        Console.Clear();
                        crudOrgan.Create();
                    }
                    else if (int.TryParse(value_, out h) && h == 2 && h <= 5)
                    {
                        Console.Clear();
                        crudOrgan.Read();
                    }
                    else if (int.TryParse(value_, out h) && h == 3 && h <= 5)
                    {
                        Console.Clear();
                        crudOrgan.Update();
                    }
                    else if (int.TryParse(value_, out h) && h == 4 && h <= 5)
                    {
                        Console.Clear();
                        crudOrgan.Delete();
                    }
                    else if (int.TryParse(value_, out h) && h == 5 && h <= 5)
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Mos amalni kiriting 1 yoki 2");
            }
        }
    }
}