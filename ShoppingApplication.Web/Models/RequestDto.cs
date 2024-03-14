using System.Net.Mime;
using System.Security.AccessControl;
using static ShoppingApplication.Web.Utility.SD;

namespace ShoppingApplication.Web.Models
{

    // when we are sending the request
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET; // API type eka get,put, post delet. default thiyanne get eka. enum field ekak add krala thiyenne
        public string Url { get; set; } // API eke
        public object Data { get; set; } //
        public string AccessToken { get; set; } // Authontication ekat use kranawa 

       // public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
