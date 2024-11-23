namespace HW13.Configuration
{
    public class Configuration
    {
        public static string configurationstring { get; set; }
        static Configuration()
        {
            //configurationstring = "Data Source=ASO-LOTFI\\SQLEXPRESS;Initial Catalog=LiberariDb;Integrated Security=True;TrustServerCertificate=True";
            configurationstring = "Data Source=ASO\\SQLEXPRESS;Initial Catalog=LiberariDbcw13;Integrated Security=True;TrustServerCertificate=True";
            //configurationstring = "Data Source= ASO - LOTFI\\SQLEXPRESS;Initial Catalog=LiberariDbcw13;Integrated Security=True;TrustServerCertificate=True";
        }
    }
}
