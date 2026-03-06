namespace DataAccessLibrary
{
    class DbDataAccess(string path) : DataAccess(path)
    {
        //public DbDataAccess(string path) : base(path)
        //{

        //}

        public override string GetData()
        {
            return "db data";
        }
    }
}
