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
        static Product findProduct(Product[] product, string name)
        {
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].name == name)
                {
                    return product[i];
                }
            }
            return null;
        }
        static List<Product> findProductByCategory(Product[] product,int category)
        {
            List<Product> list = new List<Product>();
            for(int i=0;i< product.Length; i++)
            {
                if(category== product[i].categoryId)
                {
                    list.Add(product[i]);
                }    
            }
            return list;
        }
        static List<Product> findProductByPrice(Product[] product,int price)
        {
            List <Product> listproduct = new List<Product>();
            for(int i=0;i<product.Length;i++)
            {
                if (product[i].price <= price)
                {
                    listproduct.Add(product [i]);
                }
            }
            return listproduct;
        }
        static List<Product> SortByRice(Product[] product)
        {
            Product pro1;
            List<Product> listproduct = new List<Product>();
            for(int i=0;i<product.Length;i++)
            {
                for(int j=i+1;j<product.Length;j++)
                {
                    if(product[i].price>product[j].price)
                    {
                        pro1 = product[i];
                        product[i] = product[j];
                        product[j] = pro1;
                    }
                }
            }
            for(int i=0;i<product.Length;i++)
            {
                listproduct.Add(product[i]);
            }
            return listproduct;
        }
        static List<Product> sortByName(Product[] product)
        {
            List<Product> listproduct = new List<Product>();
            for(int i=1;i<product.Length;i++)
            {
                Product val = product[i];
                int pos = i;
                while(pos>0 && product[pos-1].name.Length<val.name.Length)
                {
                    product[pos]=product[pos-1];
                    pos--;
                }
                product[pos]=val;
            }
            for(int i=0;i<product.Length;i++)
            {
                listproduct.Add(product[i]);
            }
            return listproduct;
        }
        static List<Product> sortByCategoryName(Product[] product,Category[] categories)
        {
            List<Product> listproduct = new List<Product>();
            int temp;
            for (int i = 0; i < product.Length; i++)
            {
                for (int j = i + 1; j < product.Length; j++)
                {
                    string categoryNameCurrent = GetCategoryById(product[j].categoryId, categories);
                    string categoryNamePost = GetCategoryById(product[i].categoryId, categories);
                    if (categoryNamePost.CompareTo(categoryNameCurrent) > 0 && categoryNamePost != null)
                    {
                        
                        temp = product[i].categoryId;
                        product[i].categoryId = product[j].categoryId;
                        product[j].categoryId = temp;

                    }
                    
                }
            }
            for (int i = 0; i < product.Length; i++)
            {
                listproduct.Add(product[i]);
            }
            return listproduct;
        }
        static string GetCategoryById(int categoryId,Category[] categories)
        {
            for(int i=0;i< categories.Length;i++)
            {
                if (categoryId == categories[i].categoryId)
                {
                    return categories[i].name;
                }
            }
            return null;
        }
        static ProductCategoryName[] mapProductByCategory(Product[] product, Category[] categories)
        {
            ProductCategoryName[] productCategoryName = new ProductCategoryName[product.Length];
            for(int i=0;i<product.Length;i++)
            {
                productCategoryName[i] = new ProductCategoryName();
                productCategoryName[i].name = product[i].name;
                productCategoryName[i].price = product[i].price;
                productCategoryName[i].categoryId = product[i].categoryId;
                productCategoryName[i].quality = product[i].quality;
                for(int j=0;j<categories.Length;j++)
                {
                    if(productCategoryName[i].categoryId == categories[j].categoryId)
                    {
                        productCategoryName[i].categoryName = categories[j].name;
                    }    
                }    
            }
            return productCategoryName;
        }
        static Product minbyPrice(Product[] product)
        {
            Product min = new Product();
            min = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (min.price > product[i].price)
                {
                    min = product[i];
                }

            }
            return min;
        }
        static Product maxbyPrice(Product[] product)
        {
            Product max = new Product();
            max = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (max.price < product[i].price)
                {
                    max = product[i];
                }

            }
            return max;
        }
        static float calSalary(float salary, float n)
        {
            if (n == 0)
            {
                return salary;
            }
            return calSalary(salary, n - 1) * 110 / 100;
        }
        static float calSalaryBasic(float salary,float n)
        {
            
            for(int i=0;i<n;i++)
            {
                salary = salary + salary / 10;
                n--;
            }
            return salary;
        }
        
        static int calMonth(float money,float rate, int month=0)

        {
            if(rate*month*money/100>=money)
            {
                return month;
            }
            else return calMonth(money,rate,++month);
            
        }
        static int calMonthBasic(float money,float rate)
        {
            float interest = money * rate / 100;
            float month = money / interest;

            return Convert.ToInt32(month);
        }
        public static void Main(string[] args)
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
            product[4] = new Product { name = "Keyboard", price = 30, quality = 8, categoryId = 4 };
            product[5] = new Product { name = "Mouse", price = 25, quality = 50, categoryId = 4 };
            product[6] = new Product { name = "VGA", price = 60, quality = 35, categoryId =3 };
            product[7] = new Product { name = "Monitor", price = 120, quality = 28, categoryId = 2 };
            product[8] = new Product { name = "Case", price = 120, quality = 28, categoryId = 5 };
            Category[] categories = new Category[4];
            categories[0]=new Category { categoryId = 1 ,name="Computer"};
            categories[1] = new Category { categoryId = 2, name = "Memory" };
            categories[2] = new Category { categoryId = 3, name = "Card" };
            categories[3] = new Category { categoryId = 4, name = "Acsesory" };
            Product prodName = new Product();
            Console.WriteLine("Nhap ten product: ");
            string n = Console.ReadLine();
            prodName = findProduct(product, n);
            Console.WriteLine(prodName.name);
            //for (int i = 0; i < 9; i++)
            //{



            //    if (v == name[i])
            //    {
            //        Console.WriteLine("Nhap ten product: ");
            //        Console.WriteLine("Ten product: " + name[i]);


            //    }

            //    Console.ReadKey();
            //}

            Console.WriteLine("Nhap ID: ");
            List<Product> prodcategory = new List<Product>();
            int id = Convert.ToInt32(Console.ReadLine());
            prodcategory = findProductByCategory(product, id);

            for (int i = 0; i < prodcategory.Count; i++)
            {
                Console.WriteLine("Ten :" + prodcategory[i].name + " Gia :" + prodcategory[i].price + "SLuong: " + prodcategory[i].quality);
                //    if(id==categoryId[i])
                //    {


                //        Console.WriteLine("ID la: "+ product[i].categoryId);
                //        Console.WriteLine(product[i].name);
                //        Console.WriteLine(product[i].price);
                //        Console.WriteLine(product[i].quality);
                //    }
            }
            Console.WriteLine("Nhap gia: ");
            List<Product> prodprice = new List<Product>();
            int price1 = Convert.ToInt32(Console.ReadLine());
            prodprice = findProductByPrice(product, price1);
            for (int i = 0; i < prodprice.Count; i++)
            {
                Console.WriteLine("Ten: " + prodprice[i].name);
                //Console.WriteLine();
                //if (product[i].price <= price1)
                //{
                //    Console.WriteLine("Gia: " + product[i].price);
                //}
            }
            Console.ReadKey();
            //List<Product> sortByRice = new List<Product>();
            //sortByRice = SortByRice(product);
            //for (int i = 0; i < sortByRice.Count; i++)
            //{
            //    Console.WriteLine(sortByRice[i].name + " " + sortByRice[i].price);
            //}
            //Console.ReadKey();
            //List<Product> SortName = new List<Product>();
            //SortName = sortByName(product);
            //for (int i = 0; i < SortName.Count; i++)
            //{
            //    Console.WriteLine(SortName[i].name);
            //}
            //Console.ReadKey();
            List<Product> sortbyCategoryName = new List<Product>();
            sortbyCategoryName = sortByCategoryName(product, categories);
            Console.WriteLine("Sort By Category name");
            for (int i = 0; i < sortbyCategoryName.Count; i++)
            {
                Console.WriteLine(sortbyCategoryName[i].name + " " + sortbyCategoryName[i].categoryId);
            }
            List<Product> sortByProName = new List<Product>();
            mapProductByCategory(product, categories);
            Console.WriteLine("Map By Category name");
            for(int i=0;i<product.Length;i++)
            {
                //string getcategoryName = GetCategoryById(product[i].categoryId, categories);
                Console.WriteLine(mapProductByCategory(product, categories)[i].name+ " "+ mapProductByCategory(product, categories)[i].categoryName);
            }    
            Console.ReadKey();
            Product minPro = new Product();
            minPro = minbyPrice(product);
            Console.WriteLine("Min price: " + minPro.price + " " + minPro.name);
            Product maxPro = new Product();
            maxPro = maxbyPrice(product);
            Console.WriteLine("Max price: " + maxPro.price + " " + maxPro.name);
            Console.ReadKey();
            float money, month, moneybasic, monthbasic;
            Console.Write("Nhap so tien luong : ");
            float salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("So nam : ");
            int years = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(calSalary(salary, years));
            Console.Write("Nhap so tien luong : ");
            float salarybasic = Convert.ToInt32(Console.ReadLine());
            Console.Write("So nam : ");
            int yearsbasic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(calSalaryBasic(salary, years));
            Console.WriteLine("Nhap so tien: ");
            money = float.Parse(Console.ReadLine());
            Console.Write("Nhap lai suat : ");
            float rate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap thang: ");
            month = float.Parse(Console.ReadLine());
            Console.WriteLine(calMonth(money, rate) + " month");
            Console.WriteLine("Nhap so tien: ");
            moneybasic = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap lai suat : ");
            float ratebasic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap so thang: ");
            monthbasic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(calMonthBasic(money, rate) + " month");
            Console.ReadKey();
        }
    }
}
