using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Application.DTO;

public record UrlResponseDto
{
    public string ShortCode { get; set; } = string.Empty;
    public string OriginalUrl { get; set; } = string.Empty;
    public long UrlAcessCount { get; set; }
    public DateTime CreatedAt {get; set;}
}
