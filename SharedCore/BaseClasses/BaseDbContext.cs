using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SharedCore.BaseClasses;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
    
    protected void AddEntities(ModelBuilder modelBuilder, Assembly assembly)
    {
        foreach (var type in assembly.GetTypes()
                     .Where(t => t.IsClass && !t.IsAbstract && t.BaseType == typeof(BaseEntity)))
        {
            modelBuilder.Entity(type);
        }
    }
}