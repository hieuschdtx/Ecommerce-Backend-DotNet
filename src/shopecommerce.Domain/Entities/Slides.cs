namespace shopecommerce.Domain.Entities
{
    public class Slides : BaseEntites
    {
        public Slides()
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
            }
        }
        public string image { get; set; }
        public string url { get; set; }
        public int display_order { get; set; }
        public bool status { get; set; }
        #endregion

        public void SetImagefileName(string filename)
        {
            this.image = filename;
        }
    }
}
