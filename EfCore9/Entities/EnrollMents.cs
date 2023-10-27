namespace EfCore8.Entities
{
	public class EnrollMents
	{
		public int SectionId { get; set; }
		public int StudentId { get; set; }
		public Section  Section { get; set; }
		public Student  Student { get; set; }
	}
}





