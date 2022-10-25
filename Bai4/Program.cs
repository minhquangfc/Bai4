using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    public class Program
    {
        public static string[] name;
        public static int[] price;
        public static int[] quality;
        public static int[] categoryId;
        public Program(string[] nameproduct, int[] priceproduct, int[] qualityproduct, int[] categoryIdproduct)
        {
            name = nameproduct;
            price = priceproduct;
            quality = qualityproduct;
            categoryId = categoryIdproduct;
        }
        
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            int[] categoryId = new int[9] { 1, 2, 2, 1, 4, 4, 3, 2, 5 };
            Product[] product = new Product[9];
            int[] price = new int[] { };
            int[] quality = new int[] { };
            string[] name = new string[9] {"CPU", "RAM" , "HDD" , "Main" ,"Keyboard","Mouse","VGA","Monitor","Case"};
            product[0] = new Product {name="CPU",price=750,quality=10,categoryId=1};
            product[1] = new Product { name = "RAM", price = 50, quality = 2, categoryId = 2 };
            product[2] = new Product { name = "HDD", price = 70, quality = 1, categoryId = 2 };
            product[3] = new Product { name = "Main", price = 400, quality = 3, categoryId = 1 };
            product[2] = new Product { name = "Keyboard", price = 30, quality = 1, categoryId = 4 };
            product[3] = new Product { name = "Mouse", price = 25, quality = 3, categoryId = 4 };
            product[3] = new Product { name = "VGA", price = 60, quality = 3, categoryId =3 };
            product[3] = new Product { name = "Monitor", price = 120, quality = 3, categoryId = 2 };
            product[3] = new Product { name = "Case", price = 120, quality = 3, categoryId = 5 };
            string v = Console.ReadLine();
            
            for (int i = 0; i < 9; i++)
            {

                

                if (v == name[i])
                {
                    Console.WriteLine("Nhap ten product: ");
                    Console.WriteLine("Ten product: " + name[i]);
                    

                }

                Console.ReadKey();
            }
            
            Console.WriteLine("Nhap ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < 9; i++)
            {
                if(id==categoryId[i])
                {

                    
                    Console.WriteLine("ID la: "+ product[i].categoryId);
                    Console.WriteLine(product[i].name);
                    Console.WriteLine(product[i].price);
                    Console.WriteLine(product[i].quality);
                }
            }
                
            
            
            Console.WriteLine("Nhap gia: ");
            int price1= Convert.ToInt32(Console.ReadLine());
            for(int i=0; i < 9; i++)
            {
                Console.WriteLine();
                if (product[i].price <= price1)
                {
                    Console.WriteLine("Gia: "+ product[i].price);
                }
            }


        }
    }
}
