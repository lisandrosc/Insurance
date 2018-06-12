using Insurance.Entities.Contracts;
using Insurance.Mocky;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Service.Test
{
    public class PolicyServiceTest
    {
        [TestFixture]
        public class ClientServiceTest
        {
            #region Members

            private IMockyService _mockyService;
            private IClientService _clientService;
            private PolicyService _target;

            #endregion

            #region Methods
            [SetUp]
            public void Setup()
            {
                _mockyService = MockRepository.GenerateMock<IMockyService>();
                _clientService = MockRepository.GenerateMock<IClientService>();
                _target = new PolicyService(_clientService, _mockyService);
            }

            [Test]
            public void Should_get_policies_by_user_name()
            {
                // Arrange      
                Client client = new Client { Id = "2", Email = "2@test.com", Name = "Mike" };
                _clientService.Expect(e => e.GetClientByName(Arg<string>.Is.Anything)).Return(client);
                _mockyService.Expect(e => e.GetPolicies()).Return(GetFakePolicies());

                // Act.-                
                IEnumerable<Policy> val = _target.GetByUserName("Mike");                

                // Assert.-                
                Assert.IsTrue(val.Count() == 2);                
            }

            [Test]
            public void Should_get_policies_by_clientId()
            {
                // Arrange      
                Client client = new Client { Id = "3", Email = "3@test.com", Name = "Jane" };                
                _mockyService.Expect(e => e.GetPolicies()).Return(GetFakePolicies());

                // Act.-                
                IEnumerable<Policy> val = _target.GetPoliciesByClientId("3");

                // Assert.-                
                Assert.IsTrue(val.Count() == 1);
            }

            [Test]
            public void Should_get_user_by_policy_number()
            {
                // Arrange      
                Client client = new Client { Id = "3", Email = "3@test.com", Name = "Jane" };
                _mockyService.Expect(e => e.GetPolicies()).Return(GetFakePolicies());
                _clientService.Expect(e => e.GetClient(Arg<string>.Is.Anything)).Return(client);

                // Act.-                
                Client val = _target.GetUserByPolicyNumber("f");

                // Assert.-                
                Assert.IsTrue(val.Id.Equals(client.Id));
            }

            private IEnumerable<Policy> GetFakePolicies()
            {
                List<Policy> list = new List<Policy>();
                list.Add(new Policy { Id = "a", ClientId = "1", AmountInsured = "125.35" });                
                list.Add(new Policy { Id = "c", ClientId = "2", AmountInsured = "105.39" });
                list.Add(new Policy { Id = "d", ClientId = "2", AmountInsured = "356.02" });
                list.Add(new Policy { Id = "f", ClientId = "3", AmountInsured = "189.78" });
                return list;
            }
            #endregion
        }
    }
}
