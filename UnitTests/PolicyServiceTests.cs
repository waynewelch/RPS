using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using RpsPolicyApp.ResponseObjects;
using RpsPolicyApp.Models;
using RpsPolicyApp.Services;

namespace UnitTests
{
  [TestClass]
  public class PolicyServiceTests
  {
    private static PolicyService _sut;
    private static Policy _policy;
    private static Mock<IPolicy> _policyClassMock;
    private static Mock<IPolicyResponse> _policyListReponseClassMock;
    private static PolicyResponse _policyResponse;
    private static List<PolicyResponse> _policyResponseList;

    //Arrange
    [ClassInitialize]
    public static void Setup(TestContext context)
    {
      // Init the test fixture
      IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());

      // Create new mock policy
      _policy = fixture.Create<Policy>();

      // Create new mock of policy response and a list of policy responses
      _policyResponse = fixture.Create<PolicyResponse>();
      _policyResponseList = new List<PolicyResponse> { _policyResponse};

      // Mock the Policy class
      _policyClassMock = fixture.Freeze<Mock<IPolicy>>();
      _policyClassMock.Setup(x => x.InsertPolicy(It.IsAny<Policy>())).ReturnsAsync(true);

      // Mock the PolicyListResponse class
      _policyListReponseClassMock = fixture.Freeze<Mock<IPolicyResponse>>();
      _policyListReponseClassMock.Setup(x => x.GetPolicyResponse()).Returns(_policyResponseList);

      // Init the policy service
      _sut = fixture.Create<PolicyService>();
    }


    [TestMethod]
    public void CreatePolicy_IsCalled()
    {
      //Act
      var result = _sut.CreatePolicy(_policy);

      //Assert
      _policyClassMock.Verify(x => x.InsertPolicy(It.IsAny<Policy>()), Times.Once);
    }

    [TestMethod]
    public void CreatePolicy_NullObject_Fail()
    {
      //Act
      var result = _sut.CreatePolicy(null);

      //Assert
      Assert.IsNotNull(result);
      Assert.IsFalse(result.Result);
    }

    [TestMethod]
    public void CreatePolicy_PolicyObject_Success()
    {
      //Act
      var result = _sut.CreatePolicy(_policy);

      //Assert
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Result);
    }

    [TestMethod]
    public void GetAllPolicies_IsCalled()
    {
      //Act
      var result = _sut.GetAllPolicies();

      //Assert
      _policyListReponseClassMock.Verify(x => x.GetPolicyResponse(), Times.Once);
    }

    [TestMethod]
    public void GetAllPolicies_Works()
    {
      //Act
      var policies = _sut.GetAllPolicies();

      //Assert
      Assert.IsNotNull(policies);
      Assert.AreEqual(policies, _policyResponseList);
      // Times.AtLeastOnce used here in case All tests are run at the same time
      // in which the count will be 2 instead of 1. 
      _policyListReponseClassMock.Verify(x => x.GetPolicyResponse(), Times.AtLeastOnce);

    }

  }
}
