using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class Policies : BaseEntites
    {
        public Policies()
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
        public string detail { get; set; }
        public string alias { get; set; }
        #endregion

        #region Generated Relationships
        #endregion
    }
}
