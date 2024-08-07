using Tashkilot.Models;

using (var db = new AppDbContext())
{
    var kadr1 = new Kadr { Ism = "Otabek", Yosh = 21, Mutaxasist = "Master" };
    var kadr2 = new Kadr { Ism = "Behzod", Yosh = 23, Mutaxasist = "Tadbirkor" };
    var kadr3 = new Kadr { Ism = "Azam", Yosh = 21, Mutaxasist = "Injener" };

    db.Kadrlar.AddRange(kadr1, kadr2, kadr3);   
    db.SaveChanges();

    var kadrlar = db.Kadrlar.ToList();
    foreach (var k in kadrlar)
    {
        Console.WriteLine($"{k.Id}.{k.Ism} Yoshi: {k.Yosh} Mutaxasist: {k.Mutaxasist}");
    }
}