using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Abstractions.Services;
using CeyhunApplication.Models;

namespace CeyhunApplication.Concretes.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public CategoryService(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public Category GetCategoryById(int id)
    {
        Category? category = _categoryReadRepository.GetById(id, false, "ParentCategory");

        if (category is null)
        {
            throw new Exception($"Category not found with this {id}");
        }

        return category;

    }
}
