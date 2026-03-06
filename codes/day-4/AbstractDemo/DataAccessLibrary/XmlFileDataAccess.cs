namespace DataAccessLibrary
{
    class XmlFileDataAccess(string path) : FileDataAccess(path)
    {
        public override string GetData()
        {
            return "xml file data";
        }
    }
}
