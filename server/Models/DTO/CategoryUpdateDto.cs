using System;
using System.ComponentModel.DataAnnotations;

public class CategoryUpdateDto
{
    [Required]
    public string Name { get; set; }

	public List<int> PrizesId { get; set; }	
}
