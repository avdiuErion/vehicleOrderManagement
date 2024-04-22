using OptionPacksService.DataAccess.Interfaces;
using OptionPacksService.Domain.Context;
using OptionPacksService.Domain.Entities;
using SharedCore.Implementations;

namespace OptionPacksService.DataAccess.Repositories;

public class OptionPacksOrderRepository(ApplicationDbContext context)
    : BaseRepository<OptionPackOrder>(context), IOptionPacksOrderRepository;