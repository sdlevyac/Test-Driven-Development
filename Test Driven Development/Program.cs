using MySqlConnector;

namespace Test_Driven_Development
{
    public class Program
    {
        //qR%8&!d1eTtY@qCa6D8TqDNd90&Y57xh
        static string connStr = "Server=ND-COMPSCI;User ID=tl_w3;Password=qR%8&!d1eTtY@qCa6D8TqDNd90&Y57xh;Database=w3schools_db";
        public static void Main(string[] args)
        {
            Menu();
        }
        private static void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Search products based on product ID");
                Console.WriteLine("2. Search suppliers based on supplier ID");
                Console.WriteLine("0. Quit");
                string input = Console.ReadLine();
                if (new string[] { "0", "1", "2" }.Contains(input))
                {
                    switch (input)
                    {
                        case "0":
                            running = false;
                            break;
                        case "1":
                            GetProduct(ValidInt());
                            break;
                        case "2":
                            Console.WriteLine("supplier search not implemented");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static int ValidInt()
        {
            string input = "-";
            int output;
            while (!int.TryParse(input, out output))
            {
                Console.WriteLine("Enter an integer: ");
                input = Console.ReadLine();
            }
            return output;
        }
        public static void GetProduct(int productID)
        {

            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("SELECT productName FROM products WHERE productID = @productID;", connection);
            command.Parameters.AddWithValue("@productID", productID);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }


        }
        public static void GetSupplier(int supplierID)
        {            
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("SELECT supplierName FROM suppliers WHERE supplierID = @supplierID;", connection);
            command.Parameters.AddWithValue("@supplierID", supplierID);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }
    }
}
