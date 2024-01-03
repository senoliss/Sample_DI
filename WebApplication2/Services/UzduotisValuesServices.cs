namespace WebApplication2.Services
{
    public interface IUzduotisValuesServices
    {
        List<string> Values { get; set; }
    }
    public class UzduotisValuesServices : IUzduotisValuesServices
    {
        public List<string> Values { get; set;} = new List<string> { "value1", "value2"};
    }
}
