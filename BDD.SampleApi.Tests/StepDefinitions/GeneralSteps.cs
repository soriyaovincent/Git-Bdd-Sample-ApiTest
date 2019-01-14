using System.Linq;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using BDD.SampleApi.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BDD.SampleApi.Tests.StepDefinitions
{
    [Binding]
    public sealed class GeneralSteps
    {
        private string actualCatalogueName;
        private string response;
        private Catalogue responseCatalogue;

        [Given(@"I send a call to sample API endpoint with ""(.*)"" parameter")]
        public async Task WhenISendACallToSampleApiEndpointWithParameter(string category)
        {
            var categoriesWebService = new SampleWebService();
            response = await categoriesWebService.GetCatalouge(category);
        }

        [When(@"I GET the resposne from the sample API endpoint")]
        public void WhenIGETTheResposneFromTheSampleAPIEndpoint()
        {
            responseCatalogue = JsonConvert.DeserializeObject<Catalogue>(response);
        }

        [Then(@"the catalogue name should be ""(.*)""")]
        public void ThenTheCatalogueNameShouldBe(string expectedCatalogueName)
        {
            Assert.AreEqual(expectedCatalogueName, this.responseCatalogue.Name);
        }

        [Then(@"the CanRelist should be ""(.*)""")]
        public void ThenTheCanRelistShouldBe(bool expectedCanRelist)
        {
            Assert.AreEqual(expectedCanRelist, this.responseCatalogue.CanRelist);
        }

        [Then(@"I should should see that the promotion element where name is ""(.*)"" has a description of ""(.*)""")]
        public void ThenIShouldShouldSeeThatThePromotionWhereNameIsHasADescriptionOf(
            string promotionName,
            string promotionDescription)
        {

            var promotions = this.responseCatalogue.Promotions;
            var promotionItem =
                promotions.FirstOrDefault(
                    item => item.Name.Equals(promotionName) && item.Description.Contains(promotionDescription));
            Assert.IsNotNull(promotionItem, "promotions element with " + promotionName + " name does not have " + promotionDescription);

        }
    }
}
