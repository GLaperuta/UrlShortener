using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Domain.Models;
using UrlShortener.Infra.Database;
using UrlShortener.Infra.Repositories.Interfaces;

namespace UrlShortener.Infra.Repositories;

public class UrlRepository : IUrlRepository
{

    private readonly DatabaseContext _context; 
    
    public UrlRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Add(UrlShort urlShort)
    {
        await _context.UrlShorts.AddAsync(urlShort);
    }
    public async Task Delete(string shortCode)
    {
        var urlShort = await _context.UrlShorts.FindAsync(shortCode);

        if (urlShort == null)
            throw new KeyNotFoundException("URL not found");

        _context.UrlShorts.Remove(urlShort!);
    }
    public async Task<UrlShort?> Get(string shortCode)
    {
        return await _context.UrlShorts.FindAsync(shortCode);
    }
    public async Task<IEnumerable<UrlShort>> Get()
    {
        return await _context.UrlShorts.ToListAsync();
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
