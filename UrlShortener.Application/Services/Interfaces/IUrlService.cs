using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Application.DTO;

namespace UrlShortener.Application.Services.Interfaces;

public interface IUrlService
{
    Task<UrlResponseDto> GetUrl(string url);
    Task<UrlResponseDto> CreateUrl(string url);
    Task DeleteUrl(string url);
    Task<IEnumerable<UrlResponseDto>> GetAll();
}
