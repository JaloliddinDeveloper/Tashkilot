namespace Labaratoriya.Models
{
    internal class Organ
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Holati { get; set; }
        public int MijozId {  get; set; }   
        public Mijoz Mijoz { get; set; }
    }
}
