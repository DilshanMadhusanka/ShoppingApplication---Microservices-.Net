namespace ShoppingApplication.Services.WebNew.Models.Dto
{

    // me class ekam services walath hadal thiynawa. ekata hethuwa microservices use kran nisa projects hadanne wena wenam. me project eke ekam solution eke haduwanat 
    // wena ekak ehema haden nathi wenn puluwan e nisa thamai front end eketh ekam response class ekak thiya ganne 



    //  API eka call krankot response eka ganna 
    public class ResponseDto
    {
        public object? Result { get; set; }  // result eka mokkd 
        public bool IsSuccess { get; set; } = true; // success da nadd ( default success kiyanne )
        public string Message { get; set; } = "";  // message ekak dennna 
    }
}
