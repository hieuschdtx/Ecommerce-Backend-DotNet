namespace shopecommerce.Domain.Entities
{
    public class Specifications
    {
        public Specifications()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string screen_size { get; set; }
        public string screen_technology { get; set; }
        public string refresh_rate { get; set; }
        public string chipset { get; set; }
        public string gpu { get; set; }
        public string internal_memory { get; set; }
        public string operating_system { get; set; }
        public string rear_camera { get; set; }
        public string bluetooth { get; set; }
        public string battery_capacity { get; set; }
        public string frame_material { get; set; }
        public string back_material { get; set; }
        public bool? dual_sim { get; set; }
        public bool? hd_voice { get; set; }
        public bool? volte { get; set; }
        public string product_id { get; set; }
        public string productvariant_id { get; set; }
        #endregion
        
        #region Generated Relationships
        public virtual Products product_Products { get; set; }
        public virtual ProductVariants productvariant_ProductVariants { get; set; }
        #endregion
    }
}
