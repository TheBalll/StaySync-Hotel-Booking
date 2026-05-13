using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities; // ВАЖНО: За да знае какво е Entity-то
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Services;

// Сменяме името тук, за да не се бие с името на таблицата
public class AdditionalServiceImplementation : IAdditionalService
{
    private readonly StaySyncDbContext _context;
    private readonly IMapper _mapper;

    public AdditionalServiceImplementation(StaySyncDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdditionalServiceResponse>> GetAllActiveAsync()
    {
        // Тук вече няма да свети, защото _context знае кои са AdditionalServices
        var services = await _context.AdditionalServices
            .Where(s => s.IsActive)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AdditionalServiceResponse>>(services);
    }
}