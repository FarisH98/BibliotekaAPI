using AutoMapper;
using BibliotekaAPI.Controllers;
using BibliotekaAPI.Data;
using BibliotekaAPI.Repositrory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;
using System.IO.Pipelines;
using TechTalk.SpecFlow.Assist;

namespace BibliotekaAPI.Specs.StepDefinitions
{
    [Binding]
    public class BibliotekaStepDefinitions
    {
        private readonly BibliotekaController _controller;
        private readonly ScenarioContext _scenarioContext;
        private readonly Mock<IBibliotekaRepository> _repositoryMock = new Mock<IBibliotekaRepository>();

        public BibliotekaStepDefinitions(ScenarioContext scenarioContext)
        {
            _controller = new BibliotekaController(_repositoryMock.Object);
            _scenarioContext = scenarioContext;
        }
        [Given(@"That I have a library")]
        public void GivenThatIHaveALibrary()
        {
            var biblioteka = new Biblioteka
            {
                Id = 1,
                Naziv = "Test"
            };
            _scenarioContext.Add("biblioteka", biblioteka);

        }
        [When(@"I send a GET request with the given library id")]
        public async Task WhenISendAGetRequestWithTheGivenLibrary()
        {
            var biblioteka = _scenarioContext.Get<Biblioteka>("biblioteka");
            _repositoryMock.Setup(x => x.GetBibliotekaByIdAsync(biblioteka.Id)).ReturnsAsync(biblioteka);
            var result = await _controller.DobaviBiblioteka(biblioteka.Id);
            _scenarioContext.Add("result", result);
        }
        [Then(@"I should recieve that library  with the status code (.*)")]
        public void ThenIShouldRecieveThatLibraryIdWithTheStatusCode(int statusCode)
        {
            var result = _scenarioContext.Get<ActionResult<Biblioteka>>("result");
            var biblioteka = _scenarioContext.Get<Biblioteka>("biblioteka");
            var actualResult = result.Result as OkObjectResult;
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(statusCode, actualResult.StatusCode);
            Assert.AreEqual(biblioteka, actualResult.Value);
        }
        [Given(@"the following library:")]
        public void GivenTheFollowingLirbary(Table table)
        {
            var bibliotekaForCreation = table.CreateInstance<BibliotekaForCreation>();
            _scenarioContext.Add("bibliotekaForCreation", bibliotekaForCreation);
        }

        [When(@"I send a post request with the given library as content")]
        public async void WhenISendAPostRequestWithTheGivenLibraryAsContent()
        {
            var bibliotekaForCreation = _scenarioContext.Get<BibliotekaForCreation>("bibliotekaForCreation");
            Biblioteka bibliotekaForPost = new()
            {
                Id = bibliotekaForCreation.Id,
                Naziv = bibliotekaForCreation.Naziv,
                BrojRadnika = bibliotekaForCreation.BrojRadnika,
                RadniDani = bibliotekaForCreation.RadniDani,
                MjesecnaClanarina = bibliotekaForCreation.MjesecnaClanarina,

            };
            _repositoryMock.Setup(x => x.AddBibliotekaAsync(bibliotekaForPost));
            _controller.DodajBiblioteka(bibliotekaForPost);
            _scenarioContext.Add("bibliotekaForPost", bibliotekaForPost);
        }

        [Then(@"I should recieve status code (.*)")]
        public void ThenIShouldRecieveStatusCode(int expectedStatusCode)
        {
            var response = _scenarioContext.Get<Biblioteka>("bibliotekaForPost");
            Assert.AreEqual(5, response.Id);
        }

        [Then(@"I should recieve the given library with a random id in the response")]
        public void ThenIShouldRecieveTheGivenLibraryWithARandomIdInTheResponse()
        {
            var bibliotekaForPost = _scenarioContext.Get<Biblioteka>("bibliotekaForPost");
            var response = _scenarioContext.Get<BibliotekaForCreation>("bibliotekaForCreation");
            _repositoryMock.Verify(x => x.AddBibliotekaAsync(bibliotekaForPost), Times.Once);
            Assert.AreEqual(bibliotekaForPost.Id, response.Id);
            Assert.AreEqual(bibliotekaForPost.Naziv, response.Naziv);
            Assert.AreEqual(bibliotekaForPost.BrojRadnika, response.BrojRadnika);
            Assert.AreEqual(bibliotekaForPost.MjesecnaClanarina, response.MjesecnaClanarina);
            Assert.AreEqual(bibliotekaForPost.RadniDani, response.RadniDani);

        }
    }
    [Binding]
    public class DeleteBibliotekaStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BibliotekaController _controller;
        private readonly Mock<IBibliotekaRepository> _repositoryMock = new Mock<IBibliotekaRepository>();
      
        public DeleteBibliotekaStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _controller = new BibliotekaController(_repositoryMock.Object);
        }

        [Given(@"that I delete a library")]
        public void GivenThatIDeleteALibrary()
        {
            var biblioteka = new Biblioteka
            {
                Id = 1,
                Naziv = "Mostarluk",
                BrojRadnika = 5,
                RadniDani = 5,
                MjesecnaClanarina = 25

            };
            _scenarioContext.Add("biblioteka", biblioteka);
        }

        [When(@"I send a delete request with the given library id")]
        public async void WhenISendADeleteRequestWithTheGivenLibraryId()
        {
            var biblioteka = _scenarioContext.Get<Biblioteka>("biblioteka");
            _repositoryMock.Setup(x => x.DeleteBiblioteka(biblioteka));
            _repositoryMock.Setup(x => x.GetBibliotekaByIdAsync(biblioteka.Id)).ReturnsAsync(biblioteka);
            var response = await _controller.IzbrisiBiblioteka(biblioteka.Id);
            _scenarioContext.Add("response", response);
        }

        [Then(@"the library should be deleted with the status code 200")]
        public void ThenTheLibraryShouldBeDeletedWithTheStatusCode()
        {
            var biblioteka = _scenarioContext.Get<Biblioteka>("biblioteka");
            var response = _scenarioContext.Get<IActionResult>("response");
            _repositoryMock.Verify(x => x.DeleteBiblioteka(biblioteka), Times.Once);
            Assert.AreEqual(200, ((IStatusCodeActionResult)response).StatusCode);
        }
    }
}
