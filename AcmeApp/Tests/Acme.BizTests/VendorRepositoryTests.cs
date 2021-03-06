﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
            vendors.Add( new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 });
            var expected = 2;
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
            var vendor1 = new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 };

            var expected = new List<Vendor>();
            expected.Add(vendor);
            expected.Add(vendor1);

            //act
            var act = repo.Retrieve();

            //assert

            CollectionAssert.AreEqual(expected, act.ToList());

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

            CollectionAssert.AreEqual(expected, act.ToList());
            //assert
        }

        [TestMethod]
        public void RetrieveIterator()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            var vendor = new Vendor() { CompanyName = "Endava", Email = "mail@dava.com", VendorId = 1 };
            var vendor1 = new Vendor() { CompanyName = "NTT", Email = "mail@dava.com", VendorId = 2 };

            expected.Add(vendor);
            expected.Add(vendor1);

            var actual = new List<Vendor>();
            var vendorIteration = repository.RetrieveWithIterator();

            foreach (var item in vendorIteration)
            {
                Console.WriteLine(item);
                actual.Add(item);
            }
 
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RetrieveAllVendors()
        {
            var repo = new VendorRepository();
            var expected = new List<Vendor>()
            {new Vendor{CompanyName="Evozon", Email="mail@evozon.com:=",VendorId =1},
             new Vendor(){CompanyName="Vision", Email="mail@vision.com:=",VendorId =3}
            };
            var vendorList = repo.RetrieveAll();

            //var customList = from v in vendorList
            //                 where v.CompanyName.Contains("on")
            //                 orderby v.VendorId
            //                 select v;

            //customList = (from v in vendorList
            //              where v.VendorId == 1
            //              select v).ToList();

            //var customList = vendorList.Where(FilterVendor)
            //                            .OrderBy(OrderVendorById);


            var customList = vendorList.Where(v => v.CompanyName.Contains("on"))
                                       .OrderBy(v => v.VendorId);
                                       

            CollectionAssert.AreEqual(customList.ToList(), expected);
        }

        private bool FilterVendor(Vendor vendor)
        {
            if (vendor.CompanyName.Contains("on"))
            {
                return true;
            }
            return false;
        }
        private int OrderVendorById(Vendor vendor) => vendor.VendorId;

        

    }
}