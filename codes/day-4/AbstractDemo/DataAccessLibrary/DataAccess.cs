namespace DataAccessLibrary
{
    public abstract class DataAccess(string path)
    {
        //string path;
        //public DataAccess(string path)
        //{
        //    this.path = path;
        //}

        public string Path { get => path; set => path = value; }
        //public abstract string Path { get; set;}

        public abstract string GetData();
    }
}
