namespace PluginImageProcessor.Core.Models.ResponseModels
{
    public class ApiResponseModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ApiResponseModel(bool success, string? message = null, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
