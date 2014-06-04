﻿using EasyPost;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EasyPostTest {
    [TestClass]
    public class AddressTest {
        [TestInitialize]
        public void Initialize() {
            Client.apiKey = "cueqNZUb3ldeWTNX7MU3Mel8UXtaAMUi";
        }

        [TestMethod]
        public void TestRetrieve() {
            Address address = Address.Create();
            Address retrieved = Address.Retrieve(address.id);
            Assert.AreEqual(address.id, retrieved.id);
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFound))]
        public void TestRetrieveInvalidId() {
            Address.Retrieve("not-an-id");
        }

        [TestMethod]
        public void TestCreate() {
            Dictionary<string, object> parameters = new Dictionary<string, object>() {
                {"company", "Simpler Postage Inc"}, {"street1", "164 Townsend Street"}, {"street2", "Unit 1"},
                {"city", "San Francisco"}, {"state", "CA"}, {"country", "US"}, {"zip", "94107"}
            };
            Address address = Address.CreateAndVerify(parameters);
            Assert.IsNotNull(address.id);
            Assert.AreEqual(address.company, "Simpler Postage Inc");
            Assert.IsNull(address.name);
        }

        [TestMethod]
        public void TestCreateAndVerify() {
            Dictionary<string, object> parameters = new Dictionary<string, object>() {
                {"company", "Simpler Postage Inc"}, {"street1", "164 Townsend Street"}, {"street2", "Unit 1"},
                {"city", "San Francisco"}, {"state", "CA"}, {"country", "US"}, {"zip", "94107"}
            };
            Address address = Address.CreateAndVerify(parameters);
            Assert.IsNotNull(address.id);
            Assert.AreEqual(address.company, "Simpler Postage Inc");
            Assert.IsNull(address.name);
        }

        [TestMethod]
        public void TestVerify() {
            Dictionary<string, object> parameters = new Dictionary<string, object>() {
                {"company", "Simpler Postage Inc"}, {"street1", "164 Townsend Street"}, {"street2", "Unit 1"},
                {"city", "San Francisco"}, {"state", "CA"}, {"country", "US"}, {"zip", "94107"}
            };
            Address address = Address.Create(parameters);
            address = address.Verify();
            Assert.IsNotNull(address.id);
            Assert.AreEqual(address.company, "Simpler Postage Inc");
            Assert.IsNull(address.name);
        }
    }
}
