using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Data;
using CeyhunApplication.Models;

namespace CeyhunApplication.Concretes.Repositories;

public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
