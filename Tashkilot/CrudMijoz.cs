using Labaratoriya.Models;

namespace Labaratoriya
{
    internal class CrudMijoz
    {
        public void Create()
        {
            using (var db = new AppDbContext())
            {
                Console.Write("Nechta Mijoz qo'shmoqchisiz:");
                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    var Mijoz = new Mijoz();
                    Console.Write($"{i}-Mijoz Nomi: ");
                    Mijoz.Ism = Console.ReadLine();
                    Console.Write($"{i}-Mijoz Yoshi: ");
                    Mijoz.Yosh = int.Parse(Console.ReadLine());
                    db.Add(Mijoz);
                    db.SaveChanges();
                    Console.WriteLine($"{i} ta Mijoz qo'shildi.");
                }
            }
        }
        public void Read()
        {
            using (var db = new AppDbContext())
            {
                if (db.Mijozlar.Any())
                {
                    Console.WriteLine("Mijozlar Ro'yxati:");
                    var Mijozlar = db.Mijozlar.ToList();
                    foreach (var o in Mijozlar)
                    {
                        Console.WriteLine($"{o.Id}.{o.Ism}  Yoshi:{o.Yosh}");
                    }
                }
                else
                {
                    Console.WriteLine("Mijoz ro'yxati hali mavjud emas Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }
        public void Update()
        {
            using (var db = new AppDbContext())
            {
                if (db.Mijozlar.Any())
                {
                    Read();
                    Console.Write("O'zgartiriladigan Mijoz idsini kiriting: ");
                    int MijozId;
                    if (!int.TryParse(Console.ReadLine(), out MijozId))
                    {
                        Console.WriteLine("ID ni kiritishda xato. Iltimos, raqam kiritishingizni tekshiring.");
                        return;
                    }

                    var updatedMijoz = db.Mijozlar.FirstOrDefault(a => a.Id == MijozId);
                    if (updatedMijoz == null)
                    {
                        Console.WriteLine("Berilgan ID bo'yicha Mijoz topilmadi. Iltimos, to'g'ri ID ni kiriting.");
                        return;
                    }

                    Console.Write("Mijozning yangi ismini kiriting: ");
                    updatedMijoz.Ism = Console.ReadLine();
                    Console.WriteLine("Mijozning yangi yoshi kiriting: ");
                    updatedMijoz.Yosh = int.Parse(Console.ReadLine());
                    db.Mijozlar.Update(updatedMijoz);
                    db.SaveChanges();

                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("O'zgargan Mijozlar ro'yxati: ");
                    Read();
                }
                else
                {
                    Console.WriteLine("Mijoz ro'yxati hali mavjud emas. Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }

        public void Delete()
        {
            using (var db = new AppDbContext())
            {
                if (db.Mijozlar.Any())
                {
                    Read();
                    Console.Write("O'chiriladigan Mijoz Idsini kiriting: ");
                    int MijozId;
                    if (int.TryParse(Console.ReadLine(), out MijozId))
                    {
                        var deletedMijoz = db.Mijozlar.FirstOrDefault(b => b.Id == MijozId);
                        if (deletedMijoz != null)
                        {
                            db.Remove(deletedMijoz);
                            db.SaveChanges();

                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("O'chirilgandan keyingi kompaniyalar ro'yxati: ");
                            Read();
                        }
                        else
                        {
                            Console.WriteLine("Xato: Berilgan ID bo'yicha Mijoz topilmadi.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Xato: Iltimos, to'g'ri ID kiriting.");
                    }
                }
                else
                {
                    Console.WriteLine("Mijoz ro'yxati hali mavjud emas. Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }
    }
}
