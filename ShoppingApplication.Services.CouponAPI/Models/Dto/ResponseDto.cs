namespace ShoppingApplication.Services.CouponAPI.Models.Dto
{

    //  API responce result display krann hadan ekak 
    public class ResponseDto
    {
        public object? Result { get; set; }  // result eka mokkd 
        public bool IsSuccess { get; set; } = true; // success da nadd ( default success kiyanne )
        public string Message { get; set; } = "";  // message ekak dennna 
    }
}
