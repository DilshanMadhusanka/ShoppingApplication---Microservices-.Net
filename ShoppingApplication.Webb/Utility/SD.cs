namespace ShoppingApplication.Webb.Utility
{

    // class for selecting appropirat method
    public class SD
    {
       public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            PUT,
            POST,
            DELETE
        }
    }
}
