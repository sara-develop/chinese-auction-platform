using System;

public class CategoryUpdateDto
{
	public CategoryUpdateDto()
	{
		public string Name { get; set; }
		public List<Prize> Prizes { get; set; }
	}
}
