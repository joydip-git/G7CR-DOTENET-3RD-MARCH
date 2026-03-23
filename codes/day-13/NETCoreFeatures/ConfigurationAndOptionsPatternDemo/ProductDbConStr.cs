namespace ConfigurationAndOptionsPatternDemo
{
    public class ProductDbConStr
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? Security { get; set; }

        public override string ToString()
        {
            return $"server={Server};database={Database};{Security}";
        }
    }
}
