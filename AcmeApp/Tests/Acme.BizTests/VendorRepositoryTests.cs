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
        public void RetrieveStringcValue()
        {
            var repo = new VendorRepository();
            var expect = "test";

            var sqlMoke = "connection";
            var act = repo.RetrieveValue<string>(sqlMoke, "test");

            Assert.AreEqual(expect, act);


        }
    }
}