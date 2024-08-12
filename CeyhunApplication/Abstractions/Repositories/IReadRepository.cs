using CeyhunApplication.Models;

namespace CeyhunApplication.Abstractions.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()   //Marker Pattern
{
    T? GetById(int? id, bool asNoTracking = false, params string[] includes);

}


