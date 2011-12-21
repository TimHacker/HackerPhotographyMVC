using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HackerPhotography.Models
{
	public class Photo
	{
		public int PhotoId { get; set; }
		[Required]
		public string Name { get; set; }
		public int SortOrder { get; set; }
		public DateTime Date { get; set; }
		[Required]
		public string Url { get; set; }
		public string AlternateDescription { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int AlbumId { get; set; }

		public virtual Album Album { get; set; }
	}
}