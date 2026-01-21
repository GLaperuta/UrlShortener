using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Application.DTO;
using UrlShortener.Application.Services.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Infra.Repositories.Interfaces;

namespace UrlShortener.Application.Services;

public class UrlService : IUrlService
{

    private readonly IUrlRepository _repository;

    public UrlService(IUrlRepository repository)
    {
        _repository = repository;
    }

    public async Task<UrlResponseDto> CreateUrl(string url)
    {
        var entry = new UrlShort(url);
        await _repository.Add(entry);
        await _repository.SaveChanges();

        return new UrlResponseDto()
        {
            ShortCode = entry.ShortCode,
            OriginalUrl = entry.OriginalUrl,
            UrlAcessCount = entry.UrlAcessCount,
            CreatedAt = entry.CreatedAt
        };
    }

    public async Task DeleteUrl(string url)
    {
        await _repository.Delete(url);
        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<UrlResponseDto>> GetAll()
    {
        var urls = await _repository.Get();

        return urls.Select(entry => new UrlResponseDto()
        {
            ShortCode = entry.ShortCode,
            OriginalUrl = entry.OriginalUrl,
            UrlAcessCount = entry.UrlAcessCount,
            CreatedAt = entry.CreatedAt
        }).ToList();

    }

    public async Task<UrlResponseDto> GetUrl(string url)
    {

        var entry = await _repository.Get(url);

        if (entry == null)
            throw new KeyNotFoundException("URL not found");

        return new UrlResponseDto()
        {
            ShortCode = entry.ShortCode,
            OriginalUrl = entry.OriginalUrl,
            UrlAcessCount = entry.UrlAcessCount,
            CreatedAt = entry.CreatedAt
        };

    }
}
