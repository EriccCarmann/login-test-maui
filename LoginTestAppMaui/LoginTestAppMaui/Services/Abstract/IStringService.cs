namespace LoginTestAppMaui.Services.Abstract
{
    public interface IStringService
    {
        string ToList(IEnumerable<object> items);
        string CheckStringNullOrWhiteSpace(string current);
    }
}
