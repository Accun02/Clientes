namespace TelephoneLine
{
    internal class Program
    {
        static Dictionary<int, Customer> CustomerDictionary = new Dictionary<int, Customer>();
        private static DictionaryManager DictionaryManager = new DictionaryManager();
        static void Main(string[] args)
        {
            DictionaryManager.Initialize(CustomerDictionary);
            DictionaryManager.writeCustomers();
        }
    }
}
