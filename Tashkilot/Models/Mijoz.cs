namespace Labaratoriya.Models
{
    internal class Mijoz
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public int Yosh { get; set; }
        public ICollection<Organ> Organlar { get; set; }
    }
}
