using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod]
        public void RetrieveDecimalValue()
        {
            var repo = new VendorRepository();
            var expect = 12m;

            var sqlMoke = "connection";
            var act = repo.RetrieveValue<decimal>(sqlMoke, 12m);

            Assert.AreEqual(expect, act);


        }

        [TestMethod]
        public void RetrieveVendors()
        {
            //arrange

            var vendor = new VendorRepository();
            var vendors = new List<Vendor>();
            vendors.Add(new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 });
            var expected = 1;
            //act
            var act = vendor.Retrieve();

            //assert

            Assert.AreEqual(expected, act.Count());
            

        }

        [TestMethod]
        public void RetrieveVendor()
        {
            //arrange
            var repo = new VendorRepository();

            var vendor = new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 };

            var expected = new List<Vendor>();
            expected.Add(vendor);

            //act
            var act = repo.Retrieve();

            //assert

            CollectionAssert.AreEqual(expected, act);

        }


        [TestMethod]
        public void RetrieveStringcValue()
        {
            var repo = new VendorRepository();
            var expect = "test";

            var sqlMoke = "connection";
            var act = repo.RetrieveValue<string>(sqlMoke, "test");

            Assert.AreEqual(expect, act);


        }

        [TestMethod]
        public void RetrieveDictionarybyKey()
        {
            //arrange
            var vendorRepo = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                { "Endava", new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 }
                }
            };
            var vendor1 = new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 };

            expected.Add(vendor1.CompanyName, vendor1);
            //act
            var act = vendorRepo.RetrieveDictionary();

            CollectionAssert.AreEqual(expected, act);
            //assert
        }
    }
}