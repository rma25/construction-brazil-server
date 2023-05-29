namespace construction_brazil_server.Extensions.IQueryables
{
    public static class UtilityExtensions
    {
        public static int SkipOver(this int currentPage, int totalPerPage)
        {
            if (currentPage <= 0)
                return 0;
            if (currentPage <= 0 && totalPerPage <= 0)
                return 0;

            var skip = (currentPage - 1) * totalPerPage;

            return skip;
        }
    }
}
