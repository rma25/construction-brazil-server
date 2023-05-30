namespace construction_brazil_server.Dtos.Filters
{
    public class ProfissionalAdminFilterDto
    {
        public int TotalPerPage { get; init; }
        public int CurrentPage { get; init; }
        public string? SearchText { get; init; }
        public DateTimeOffset? StartedOn { get; init; }
        public DateTimeOffset? EndedOn { get; init; }
    }
}
