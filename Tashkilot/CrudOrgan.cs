using Labaratoriya.Models;
using Microsoft.EntityFrameworkCore;

namespace Labaratoriya
{
    internal class CrudOrgan
    {
        
        public void Create()
        {
            using (var db = new AppDbContext())
            {
                var crudMijoz=new CrudMijoz();
                Console.Write("Nechta Organ qo'shmoqchisiz:");
                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    var organ = new Organ();
                    Console.Write($"{i}-Organ Nomi: ");
                    organ.Nomi = Console.ReadLine();
                    Console.Write($"{i}-Organ Xolati: ");
                    organ.Holati = Console.ReadLine();
                    Console.WriteLine("Mijozlar ro'yxati: ");
                    crudMijoz.Read();
                    Console.Write("MijozId: ");
                    organ.MijozId=int.Parse(Console.ReadLine());
                    db.Add(organ);
                    db.SaveChanges();
                    Console.WriteLine($"{i}- ta Organ qo'shildi.");
                }
            }
        }
        public void Read()
        {
            using (var db = new AppDbContext())
            {
                if (db.Organlar.Any())
                {
                    Console.WriteLine("Organlar Ro'yxati:");
                    var organlar = db.Organlar.Include(mijoz=>mijoz.Mijoz).ToList();
                    foreach (var o in organlar)
                    {
                        Console.WriteLine($"{o.Id}.{o.Nomi}  Holati:{o.Holati} Bu organ {o.Mijoz.Ism} ga tegishli.");
                    }
                }
                else
                {
                    Console.WriteLine("Organ ro'yxati hali mavjud emas Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }
        public void Update()
        {
            using (var db = new AppDbContext())
            {
                if (db.Organlar.Any())
                {
                    Read();
                    Console.Write("O'zgartiriladigan organ idsini kiriting: ");
                    int organId;
                    if (!int.TryParse(Console.ReadLine(), out organId))
                    {
                        Console.WriteLine("ID ni kiritishda xato. Iltimos, raqam kiritishingizni tekshiring.");
                        return;
                    }

                    var updatedOrgan = db.Organlar.FirstOrDefault(a => a.Id == organId);
                    if (updatedOrgan == null)
                    {
                        Console.WriteLine("Berilgan ID bo'yicha organ topilmadi. Iltimos, to'g'ri ID ni kiriting.");
                        return;
                    }

                    Console.Write("Organning yangi nomini kiriting: ");
                    updatedOrgan.Nomi = Console.ReadLine();
                    Console.WriteLine("Organning yangi holatini kiriting: ");
                    updatedOrgan.Holati = Console.ReadLine();
                    db.Organlar.Update(updatedOrgan);
                    db.SaveChanges();
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("O'zgargan Organlar ro'yxati: ");
                    Read();
                }
                else
                {
                    Console.WriteLine("Organ ro'yxati hali mavjud emas. Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }

        public void Delete()
        {
            using (var db = new AppDbContext())
            {
                if (db.Organlar.Any())
                {
                    Read();
                    Console.Write("O'chiriladigan organ Idsini kiriting: ");
                    int organId;
                   
                    if (int.TryParse(Console.ReadLine(), out organId))
                    {
                        var deletedOrgan = db.Organlar.FirstOrDefault(b => b.Id == organId);
                        if (deletedOrgan != null)
                        {
                            db.Remove(deletedOrgan);
                            db.SaveChanges();

                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("O'chirilgandan keyingi kompaniyalar ro'yxati: ");
                            Read();
                        }
                        else
                        {
                            Console.WriteLine("Xato: Berilgan ID bo'yicha organ topilmadi.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Xato: Iltimos, to'g'ri ID kiriting.");
                    }
                }
                else
                {
                    Console.WriteLine("Organ ro'yxati hali mavjud emas. Ro'yxatni to'ldiring.");
                    Create();
                }
            }
        }

    }
}
