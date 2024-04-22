using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SharedCore.BaseClasses;

namespace OptionPacksService.Domain.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : BaseDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddEntities(modelBuilder, Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}