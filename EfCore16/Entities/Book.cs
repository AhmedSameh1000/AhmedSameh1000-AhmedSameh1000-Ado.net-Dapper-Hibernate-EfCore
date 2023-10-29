using EfCore16.Interface;

namespace C01.BasicSaveWithTracking.Entities
{
    public class Book:ISoftDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Auther { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public override string ToString()
        {
            return $"{Id} Title : ({Title}) Auther Name ({Auther}) IS Deleted({IsDeleted})";
        }
    }
}
