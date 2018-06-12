using System;
using NUnit.Framework;
using Insurance.Mocky;
using Rhino.Mocks;
using System.Collections;
using Insurance.Entities.Contracts;
using System.Collections.Generic;

namespace Insurance.Service.Test
{
    [TestFixture]
    public class ClientServiceTest
    {
        #region Members

        private IMockyService _mockyService;
        private ClientService _target;

        #endregion

        #region Methods
        [SetUp]
        public void Setup()
        {
            _mockyService = MockRepository.GenerateMock<IMockyService>();
            _target = new ClientService(_mockyService);
        }

        [Test]
        public void Should_get_all_client_list()
        {
            // Act.-
            _target.GetClientList();

            // Assert.-
            _mockyService.AssertWasCalled(e => e.GetClients(), opt => opt.Repeat.Times(1));
        }
        [Test]
        public void Should_get_client_by_email()
        {
            // Arrange         
            Client client = new Client { Id = "2", Email = "2@test.com" , Name = "Mike" };
            _mockyService.Expect(e => e.GetClients()).Return(GetFakeClientList());

            // Act.-
            Client val = _target.GetClientByEmail(client.Email);

            // Assert.-
            Assert.IsTrue(val.Id.Equals(client.Id) && val.Email.Equals(client.Email));
        }

        [Test]
        public void Should_get_client_by_name()
        {
            // Arrange         
            Client client = new Client { Id = "3", Email = "3@test.com" ,Name = "Jane"};
            _mockyService.Expect(e => e.GetClients()).Return(GetFakeClientList());

            // Act.-
            Client val = _target.GetClientByName(client.Name);

            // Assert.-
            Assert.IsTrue(val.Id.Equals(client.Id) && val.Email.Equals(client.Email));
        }

        private IEnumerable<Client> GetFakeClientList()
        {
            List<Client> list = new List<Client>();
            list.Add(new Client { Id = "1", Email = "1@test.com" , Name = "Tomas" });
            list.Add(new Client { Id = "2", Email = "2@test.com" , Name = "Mike" });
            list.Add(new Client { Id = "3", Email = "3@test.com" , Name = "Jane" });
            return list;
        }
        #endregion
    }
}
