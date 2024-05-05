using System;
using SQLite;

namespace JAbarcaS5.Models
{
	[Table("persona")]
	public class Persona
	{
		public Persona()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(25),Unique]
		public string Name { get; set; }
    }
}

