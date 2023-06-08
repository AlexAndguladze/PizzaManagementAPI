namespace PizzaManagement.API.Infrastructure.RequestResponseModels
{
    public class ResponseModel
    {
        public DateTime? ResponseTime { get; set; }
        public string Status { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public string Body { get; set; }
        public string ContentType { get; set; }
    }
}
