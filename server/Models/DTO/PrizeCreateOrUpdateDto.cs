﻿using System;

public class PrizeCreateOrUpdateDto
{
    public string Name { get; set; }
    public int Price { get; set; }

    public int CategoryId { get; set; }
    public int DonorId { get; set; }
}
