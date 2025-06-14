using System;

public class CategoryWithPrizesDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<PrizeGetDto> Prizes { get; set; } = new();
}
