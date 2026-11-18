namespace SchoolSystem.Dtos.Request
{
    public class DataTableRequest
    {
        public int Draw { get; set; }

        public int Start { get; set; }

        public int Length { get; set; } = 10;

        public string? Search { get; set; }
    }
}
