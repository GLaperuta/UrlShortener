using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Shared.Securtiy;

namespace UrlShortener.Domain.Models;

public class UrlShort
{
    public string ShortCode { get; private set; } = string.Empty;
    public string OriginalUrl { get; private set; } = string.Empty;
    public long UrlAcessCount { get; set; }
    public DateTime CreatedAt { get; set; }

    private UrlShort() { }

    public UrlShort(string originalUrl)
    {
        
        OriginalUrl = originalUrl;
        UrlAcessCount = 0;
        CreatedAt = DateTime.UtcNow;
        ShortCode = Generics.GenerateShortCode();
    }

    public long AccessCountIncrement()
    => ++UrlAcessCount;
}
