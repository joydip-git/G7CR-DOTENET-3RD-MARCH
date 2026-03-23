namespace OptionsPattern
{
    public interface IErrorLogger
    {
        //[Obsolete("this version of the method logs error in file. use the other version which logs error in database")]
        void LogError(Exception e);
    }
}
