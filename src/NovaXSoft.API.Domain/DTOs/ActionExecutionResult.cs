namespace NovaXSoft.API.Domain.DTOs
{
    public class ActionExecutionResult
    {
        public bool Succeeded { get; set; } = true;

        public string Error { get; set; }
    }
}
