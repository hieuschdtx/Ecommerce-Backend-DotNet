using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class News : BaseEntites
    {
        public News()
        {
            #region Generated Constructor
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
        public string alias { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public string category_id { get; set; }
        public string? image { get; set; }
        #endregion

        #region Generated Relationships
        public virtual Categories category_Categories { get; set; }
        #endregion

        public void SetImageFileUrl(string imageFileUrl)
        {
            this.image = imageFileUrl;
        }
    }
}
