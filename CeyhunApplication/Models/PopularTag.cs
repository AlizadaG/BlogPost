namespace CeyhunApplication.Models;
public class PopularTag : BaseEntity
{
    public string Title { get; set; } = null!;
    public virtual ICollection<PopularTagPost>? PopularTagPosts { get; set; }
}
