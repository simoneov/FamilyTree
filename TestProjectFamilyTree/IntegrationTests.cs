using FamilyTree.Data;
using FamilyTree.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;


namespace TestProjectFamilyTree
{
    public class IntegrationTests : IClassFixture<FamilyTreeWebApplicationFactory<Program>>
    {

        private readonly FamilyTreeWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;


        public IntegrationTests(FamilyTreeWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task getPeople()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                Utilities.ReinitializeDbForTests(db);
            }

            //Act

            var response = await _client.GetAsync("/people");

            var responseString = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<List<Person>>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(7, actualResult?.Count);


        }
    }
}