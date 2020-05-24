using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            //ways of definning array
            //var colorOptions = new string[3] { "green", "white", "yellow" };
            //string[] colorOption = new string[3];
            //  string[] colorOptions = { "green", "white", "yellow" };           
            //foreach(var i in colorOptions)
            //{
            //  Console.WriteLine(i);
            //}
            //var index = Array.IndexOf(colorOptions, "yellow");

            //  var  

            //List<string> str = new List<string>();
            //// var str = new List<string> { "first", "second" };
            //str.Add("green");
            //str.Add("black");
            //str.Add("yellow");
            //str.Insert(2, "orange");

            //var contains = str.Contains("green");

            //foreach(var x in str)
            //{
            //    Console.WriteLine(x);
            //}
            
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            string message = "";
           
            if(markupPercent <0.10m)
            {
                message = "need higher value";
                
            }
            else
            {
              
                message = "succesfull";
            }
            decimal price = this.Cost + (this.Cost * markupPercent);

            return new OperationResult<decimal>(price, message);
                
        }
             

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
