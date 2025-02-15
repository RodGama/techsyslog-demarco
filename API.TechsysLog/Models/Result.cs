namespace API.TechsysLog.Models
{
    public class Result
    {
        public string Endpoint { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
    }
}
