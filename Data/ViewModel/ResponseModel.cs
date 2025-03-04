namespace Data.ViewModel
{
    public class Response
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public System.Net.HttpStatusCode Status { get; set; }
    }


    public class InfinityScroll
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
