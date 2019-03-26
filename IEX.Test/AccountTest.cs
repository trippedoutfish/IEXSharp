using IEX.V2.Model.Account.Requests;
using IEX.V2.Model.Account.Response;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class AccountTest
    {
        private IEX.V2.IEXClient sandBoxClient;
        private IEX.V2.IEXClient prodClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEX.V2.IEXClient("", "", true);
            prodClient = new IEX.V2.IEXClient("", "", false);
        }

        [Test]
        public void MetadataTest()
        {
            MetadataResponse response = prodClient.Account.Metadata();

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task MetadataAsyncTest()
        {
            MetadataResponse response = await prodClient.Account.MetadataAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        public void UsageTest()
        {
            UsageResponse allResponse = sandBoxClient.Account.Usage(UsageType.All);
            UsageResponse messageResponse = sandBoxClient.Account.Usage(UsageType.Messages);

            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.AlertRecords));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.Alerts));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.RuleRecords));
            Assert.Throws<NotImplementedException>(() => sandBoxClient.Account.Usage(UsageType.Rules));
            Assert.IsNotNull(allResponse);
            Assert.IsNotNull(messageResponse);
            Assert.IsNotNull(messageResponse.messages);
        }

        [Test]
        public async Task UsageAsyncTest()
        {
            UsageResponse allResponse = await sandBoxClient.Account.UsageAsync(UsageType.All);
            UsageResponse messageResponse = await sandBoxClient.Account.UsageAsync(UsageType.Messages);

            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.AlertRecords));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.Alerts));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.RuleRecords));
            Assert.ThrowsAsync<NotImplementedException>(async () => await sandBoxClient.Account.UsageAsync(UsageType.Rules));
            Assert.IsNotNull(allResponse);
            Assert.IsNotNull(messageResponse);
            Assert.IsNotNull(messageResponse.messages);
        }
    }
}