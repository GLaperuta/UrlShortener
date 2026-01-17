using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Application.DTO;
using UrlShortener.Application.Services.Interfaces;
using UrlShortener.Infra.Repositories.Interfaces;

namespace UrlShortener.Application.Services;

public class UrlService : IUrlService
{

    private readonly IUrlRepository _repository;

    public UrlService(IUrlRepository repository)
    {
        _repository = repository;
    }

    public Task<UrlResponseDto> CreateUrl(CreateUrlDto url)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUrl(string url)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UrlResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UrlResponseDto> GetUrl(string url)
    {
        throw new NotImplementedException();
    }
}
