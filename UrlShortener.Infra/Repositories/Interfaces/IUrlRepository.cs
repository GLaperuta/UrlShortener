using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infra.Repositories.Interfaces;

public interface IUrlRepository
{
    Task<UrlShort?> Get(string shortCode);
    Task<IEnumerable<UrlShort>> Get();
    Task Add(UrlShort urlShort);
    Task Delete (string shortCode);
    Task SaveChanges();
}
