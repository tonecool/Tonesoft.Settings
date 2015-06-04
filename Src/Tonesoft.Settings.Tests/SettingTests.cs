using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tonesoft.Settings.Tests
{
    [TestFixture]
    public class SettingTests
    {
        [Test]
        public void FiveEqualsTest()
        {
            var s = 5;
            var ss = 5;
            Assert.AreEqual(s, ss);
        }

        [Test]
        public void SixEqualsTest()
        {
            //
            var s = 7;
            var ss = 7;

            Assert.AreEqual(s, ss);
        }

        [Test]
        public void TypedObjectDeserialization()
        {
            //Product product = new Product();

            //product.Name = "Apple" ;
            //product.ExpiryDate = new DateTime(2008, 12, 28);
            //product.Price = 3.99M;
            //product.Sizes = new string[] { "Small", "Medium", "Large" };

            //string output = JsonConvert.SerializeObject(product);
            ////{
            ////  "Name": "Apple",
            ////  "ExpiryDate": "\/Date(1230375600000+1300)\/",
            ////  "Price": 3.99,
            ////  "Sizes": [
            ////    "Small",
            ////    "Medium",
            ////    "Large"
            ////  ]
            ////}

            //Product deserializedProduct = (Product)JsonConvert.DeserializeObject(output, typeof(Product));

            //Assert.AreEqual("Apple", deserializedProduct.Name);
            //Assert.AreEqual(new DateTime(2008, 12, 28), deserializedProduct.ExpiryDate);
            //Assert.AreEqual(3.99m, deserializedProduct.Price);
            //Assert.AreEqual("Small", deserializedProduct.Sizes[0]);
            //Assert.AreEqual("Medium", deserializedProduct.Sizes[1]);
            //Assert.AreEqual("Large", deserializedProduct.Sizes[2]);
        }

    }
}
