using ShoppingApplication.Services.Web.Models.Dto;
using ShoppingApplication.Web.Models;

namespace ShoppingApplication.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto?> SendAsync(RequestDto requestDto); // method ekak hadanwa "SendAsync " kiyala API call krankot use wenna. meke parameters widihat denne "RequestDto"
                                                                                    // input eka "RequestDto" nam response eka  "ResponseDto" type ekak.
                                                                                    //
    }
}
