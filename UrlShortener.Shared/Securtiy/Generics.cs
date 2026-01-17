using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Shared.Securtiy;

public class Generics
{
    public static string GenerateShortCode()
    {
        return Guid.NewGuid().ToString().Substring(0, 8);
    }
}
