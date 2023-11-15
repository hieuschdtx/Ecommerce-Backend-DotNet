using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities;

public class Categories : BaseEntites
{
    public Categories()
    {
        #region Generated Constructor
        category_News = new HashSet<News>();
        category_ProductCategories = new HashSet<ProductCategories>();
        #endregion
    }

    #region Generated Properties
    public new string id { get; set; }
    private string _name;
    public string name
    {
        get => _name;
        set
        {
            _name = value;
            alias = HandleCharacter.ConvertAlias(value);
        }
    }
    public string description { get; set; }
    public string alias { get; set; }
    public int display_order { get; set; }
    #endregion

    #region Generated Relationships
    public virtual ICollection<News> category_News { get; set; }
    public virtual ICollection<ProductCategories> category_ProductCategories { get; set; }
    #endregion
}