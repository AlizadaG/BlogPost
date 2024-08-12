using CeyhunApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CeyhunApplication.Abstractions.Repositories;

public interface IRepository<T> where T : BaseEntity, new()   //Marker Pattern
{
    DbSet<T> Table { get; }
}


