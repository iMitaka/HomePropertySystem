namespace HomePropertySystem.DataTransferModels
{
    public class ServiceResultModel<T>
    {
        public T DataResult { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
