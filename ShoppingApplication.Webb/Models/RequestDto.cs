using ShoppingApplication.Webb.Utility;
using System.Security.AccessControl;
using static ShoppingApplication.Webb.Utility.SD;

namespace ShoppingApplication.Webb.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET; // API type eka get,put, post delet. default thiyanne get eka. enum field ekak add krala thiyenne
        public string Url { get; set; } // API eke
        public object Data { get; set; } //
        public string AccessToken { get; set; } // Authontication ekat use kranawa 

        // public ContentType ContentType { get; set; } = ContentType.Json
    }
}
