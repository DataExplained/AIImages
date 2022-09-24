using System;
using System.Collections.Generic;

namespace AIImages.Models;

public partial class AiimageDetail
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Image { get; set; } = null!;

    public decimal? ConfidenceLevel { get; set; }

    public string? Classes { get; set; }

    public string? ProcessingTime { get; set; }
}
