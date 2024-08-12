using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Data;
using CeyhunApplication.Models;

namespace CeyhunApplication.Concretes.Repositories;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
