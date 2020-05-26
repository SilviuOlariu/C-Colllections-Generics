using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        List<Vendor> vendors = null;

        Dictionary<string, Vendor> vendorDictionary = null;


       public ICollection<Vendor> Retrieve()
        {
            if (vendors == null)

                vendors = new List<Vendor>();
            vendors.Add(new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 });
            vendors.Add(new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 });

            return vendors;            
            
        }

        public IDictionary<string, Vendor> RetrieveDictionary()
        {
            var vendor = new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 };
            var vendor1 = new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 };
            if (vendorDictionary == null)

           vendorDictionary = new Dictionary<string, Vendor>();

            vendorDictionary.Add(vendor.CompanyName, vendor);
            vendorDictionary.Add(vendor1.CompanyName, vendor1);

            foreach(var item in vendorDictionary.Keys)
            {
                Console.WriteLine(item);
            }

            //foreach(var item in vendorDictionary.Values)
            //{
            //    Console.WriteLine(item);
            //}


            //foreach(var item in vendorDictionary)
            //{
            //    var key = item.Key;
            //    var value = item.Value;

            //    Console.WriteLine($" {key}, {value}");
            //}


            //Console.WriteLine(vendorDictionary["Endava"]);
            return vendorDictionary;             

        }


        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            //code that retrieveValue from database
            //T value = defaultValue;

            return defaultValue;

        }
       
        

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }


        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            //vendors = new List<Vendor>();
            //  vendors.Retrieve();

            this.Retrieve();

            foreach( var item in vendors)
            {
                Console.WriteLine($"Vendor id {item.VendorId}");
                yield return item;
            }

        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {new Vendor{CompanyName="Evozon", Email="mail@evozon.com:=",VendorId =1},
             new Vendor(){CompanyName="Asist", Email="mail@asists.com:=",VendorId =2},
             new Vendor(){CompanyName="Vision", Email="mail@vision.com:=",VendorId =3},
             new Vendor(){CompanyName="Tehno", Email="mail@tehno.com:=",VendorId =4},
             new Vendor(){CompanyName="Beazley", Email="mail@beazley.com:=",VendorId =5},
             new Vendor(){CompanyName="Unirisx", Email="mail@unirisx.com:=",VendorId =6},
             new Vendor(){CompanyName="Metro", Email="mail@metro.com:=",VendorId =7}
            };

            return vendors;
        }

    }
}
