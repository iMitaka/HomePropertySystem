namespace HomePropertySystem.Data
{
    public static class DbContextConstants
    {
        private const string debugConnectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog = Homes; Integrated Security = True; MultipleActiveResultSets=True";

        public static string GetConnectionString()
        {
            return debugConnectionString;
        }
    }
}
