using System.Threading.Tasks;
using Moq;
using RunnersWeather.Http;
using Newtonsoft.Json.Linq;

namespace RunnersWeather.CurrentConditions.Tests
{
    public abstract class CurrentConditionsProviderTestsBase
    {
        protected BaseConditionsProvider TestSubject;
        protected readonly float lng = 17.05177F;
        protected readonly float lat = 51.08804F;
        protected abstract string APIResponse { get; }

        protected void InitTests()
        {
            TestSubject = CreateTestSubject();

            var httpClientMock = new Mock<IHttpClient>();
            httpClientMock.Setup(client => client.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(JObject.Parse(APIResponse)));

            TestSubject.HttpClient = httpClientMock.Object;
        }

        protected abstract BaseConditionsProvider CreateTestSubject();
    }
}
