namespace DataAccessLibrary
{
    public class DataAccessFactory
    {
        public static DataAccess CreateDataAccessObject(int choice)
        {
            DataAccess dataAccess;
            switch (choice)
            {
                case 1:
                    dataAccess = new DbDataAccess("db path");
                    break;

                case 2:
                    dataAccess = new XmlFileDataAccess("excel file path");
                    break;

                default:
                    dataAccess = null;
                    break;
            }
            return dataAccess;
        }
    }
}
