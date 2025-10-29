using System.Numerics;

namespace InventoryManegment
{
    internal class ProgramInventoryManagement
    {
        static void printC(string msg = "", string color = "w")
        {
            switch (color.ToLower())
            {
                case "red":
                case "r":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "green":
                case "g":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "yellow":
                case "y":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "blue":
                case "b":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "cyan":
                case "c":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case "magenta":
                case "m":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case "white":
                case "w":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        static int ValidInt(string msg = "Enter a Number")
            {
                int value ;
                while (true)
                {
                    printC(msg, "c");
                    if (int.TryParse(Console.ReadLine(), out value)) break;
                    printC("Invalid input Try Again !!\n", "r");

                }

                return value;

            }

        public class Product
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            public Product( int id ,string name, int q , double p)
            {
                Id = id;
                Name = name;
                Quantity = q;
                Price = p;
            }
            public void  Update(int id, string name, int q, double p)
            {
                Id = id;
                Name = name;
                Quantity = q;
                Price = p;
            }


        };

        static Product[]  products = new Product[100];
        static int count = 0;



        static void Main()
            {
            //LoadData();
            printC($"\n========== Welcome To Products Manager =========\n","y");
            while (true)
            {
               
               printC("""

                ========== Main Menu =========
                1=> Add Product
                2=> view All Products
                3=> Update Product
                4=> Remove Product
                5=> Exit
                """, "b");
                printC($"Enter a Number from 1-5 :\n===================\n","c");

                string? c;
                c = Console.ReadLine();

                switch (c)
                {
                    case "1":
                        //add task 
                        AddProduct();
                        break;
                    case "2":
                        ViewProducts();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        printC("Invalid Number","r");
                        break;

                }

            }
        }
    

        static void AddProduct()
        {
            printC($"Enter Product {count + 1} Name","c");

            string Name = Console.ReadLine() ?? "0";
            int Q = ValidInt("Enter Product Quantity ");
            double P = (double)ValidInt("Enter Product Price ");
            products[count] = new Product(count, Name , Q, P);
            printC($"Product {count + 1} Added Successfully \n","g");
            SaveData(count);
            count++;
            ViewProducts();
        }

        static void ViewProducts()
        {
            if (count == 0)
            {
                printC("There are no products yet!\n", "r");
                return;
            }

            printC("\n================= My Products =================\n", "b");

            // Table Header
            printC(String.Format("{0,-5} | {1,-20} | {2,-10} | {3,-10}", "ID", "Name", "Quantity", "Price"), "g");
            printC("\n-----------------------------------------------------------\n", "w");

            // Table Rows
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10:C2}",
                    products[i].Id, products[i].Name, products[i].Quantity, products[i].Price);
                printC("\n-----------------------------------------------------------\n", "w");
            }

        
        }


        static Product Search(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (products[i].Id == id && products[i] != null)
                {
                    return products[i];
                }
            }
            return null;
        }
        static void Shrink(int x)
        {
            for (int i = x; i < count; i++)
            {
                products[i] = products[i + 1];
            }
            count--;
            products[count] = null;
        }

        static void RemoveProduct()
        {
            int id =ValidInt("Enter Product ID") ;
            Product P = Search(id);
            printC($"Task {P.Name} Has been Removed Successfully \n","m");
            P = null;
            Shrink(id);
            ViewProducts();
           
        }

        static void UpdateProduct()
        {
            int ID = ValidInt("Enter Product ID");
            Product P = Search(ID);
            string name =P.Name;
            int quantity =P.Quantity;
            double price = P.Price;

            printC("""
                What Do you Want to Update ?

                1=> Name 
                2=>Quantity
                3=> Price 
                4=> All 

                ""","y");
            printC("Choose a Number 1-3", "b");
            string? c= Console.ReadLine();
            switch (c)
            {
                case "1":
                     printC("Enter The New Name", "c");
                     name = Console.ReadLine() ?? "0";
                    break;
                case "2":
                    quantity = ValidInt("Enter the New  Quantity ");
                    
                    break;
                case "3":
                     price = (double)ValidInt("Enter the New Price ");
                    break;
                case "4":
                    name = Console.ReadLine() ?? "0";
                    quantity = ValidInt("Enter the New  Quantity ");
                    price = (double)ValidInt("Enter the New Price ");
                    break;
                default:
                    printC("Invalid Number", "r");
                    break;


            }

            printC($"Task {P.Name} Has been Updated Successfully \n", "m");
             P.Update(ID, name, quantity, price); ///////////////////

            ViewProducts();

        }

        static void SaveData(int id)
        {
            string filePath = $"Products.csv";

        
            string line = $"{products[id].Id},{products[id].Name},{products[id].Quantity} ,{products[id].Price}\n ";

            File.AppendAllText(filePath, line);

            printC("Data saved successfully to CSV!", "m");


        }
        static void LoadData()
        {
            //string filePath = @"C:\Users\LENOVO\source\repos\test1\InventoryManegment\InventoryManegment\Products.csv";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Products.csv");

            if (!File.Exists(filePath))
            {
                printC("File not found, creating a new one...\n", "r");
                File.WriteAllText(filePath, "\n"); // create empty file
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            count = lines.Length;
            for (int i = 0; i < count; i++)
            {
                string line = lines[i].Trim();

                // skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split(',');

                // make sure the line has enough columns
                if (data.Length < 4)
                    continue;

               

                // use TryParse to avoid crashes
                if (!int.TryParse(data[0].Trim(), out int id))
                    continue;
                string name = data[1];
                if (!int.TryParse(data[2].Trim(), out int quantity))
                    continue;
                if (!double.TryParse(data[3].Trim(), out double price))
                    continue;

                products[i] = new Product(id, name, quantity, price);
            }
            printC("Data loaded successfully!\n", "g");
            
        }

        static void printA<T>(T[] array)
        {

            printC("Random unique numbers: " + string.Join(", ", array), "y");
        }
        static void print2D<T>(T[,] array)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }


    }
}

