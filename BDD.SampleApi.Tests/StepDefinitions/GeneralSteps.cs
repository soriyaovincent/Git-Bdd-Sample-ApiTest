using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDD.SampleApi.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using BDD.SampleApi.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

    [Binding]
    public sealed class GeneralSteps
    {
        private string actualCatalogueName;

        private string response;

        private Catalogue responseJson;

        [Given(@"I send a call to sample API endpoint with ""(.*)"" parameter")]
        public async Task WhenISendACallToSampleApiEndpointWithParameter(string category)
        {
            var categoriesWebService = new AssuritySampleWebService();
            response = await categoriesWebService.GetCatalouge(category);
        }

        [When(@"I GET the resposne from the sample API endpoint")]
        public void WhenIGETTheResposneFromTheSampleAPIEndpoint()
        {
            responseJson = JsonConvert.DeserializeObject<Catalogue>(response);
        }

        [Then(@"the catalogue name should be ""(.*)""")]
        public void ThenTheCatalogueNameShouldBe(string expectedCatalogueName)
        {
            Assert.AreEqual(expectedCatalogueName, this.responseJson.Name);
        }

        [Then(@"the CanRelist should be ""(.*)""")]
        public void ThenTheCanRelistShouldBe(bool expectedCanRelist)
        {
            Assert.AreEqual(expectedCanRelist, this.responseJson.CanRelist);
        }

        [Then(@"I should should see that the promotion element where name is ""(.*)"" has a description of ""(.*)""")]
        public void ThenIShouldShouldSeeThatThePromotionWhereNameIsHasADescriptionOf(
            string promotionName,
            string promotionDescription)
        {
            var promotions = this.responseJson.Promotions;
            var promotionItem =
                promotions.FirstOrDefault(
                    item => item.Name.Equals(promotionName) && item.Description.Contains(promotionDescription));
            Assert.IsNotNull(promotionItem, "promotions element with " + promotionName + " name does not have " + promotionDescription);

        }
    }
}
