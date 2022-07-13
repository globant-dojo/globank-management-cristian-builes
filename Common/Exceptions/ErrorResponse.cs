using Newtonsoft.Json;

namespace Common.Exceptions
{
    public class ErrorResponse
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
