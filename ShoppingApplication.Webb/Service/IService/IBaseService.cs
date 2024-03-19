using ShoppingApplication.Webb.Models;

namespace ShoppingApplication.Webb.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto); // method ekak hadanwa "SendAsync " kiyala API call krankot use wenna. meke parameters widihat denne "RequestDto"
                                                             // input eka "RequestDto" nam response eka  "ResponseDto" type ekak.                                           
    }

}
