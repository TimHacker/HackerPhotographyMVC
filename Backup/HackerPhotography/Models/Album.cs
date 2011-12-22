using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HackerPhotography.Models
{
	public class Album
	{
		public int AlbumId { get; set; }
		[Required]
		public string Name { get; set; }
		public int SortOrder { get; set; }
		public DateTime Date { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }
	}
}