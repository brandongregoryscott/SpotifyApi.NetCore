using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpotifyApi.NetCore.Http;
using SpotifyApi.NetCore;
using System.Net.Http;
using System.Collections.Specialized;
using SpotifyApi.NetCore.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace SpotifyApi.NetCore.Tests
{
    [TestClass]
    public class ArtistsApiTests
    {
        [TestCategory("Integration")]
        [TestMethod]
        public async Task GetArtist_ArtistsId_CorrectArtistName()
        {
            // arrange
            const string artistId = "1tpXaFf2F55E7kVJON4j4G";

            var http = new HttpClient();
            var auth = new ApplicationAuthApi(http, TestsHelper.GetLocalConfig());
            var api = new ArtistsApi(http, auth);

            // act
            dynamic response = await api.GetArtist(artistId);

            // assert
            Assert.AreEqual("Black Rebel Motorcycle Club", response.name.ToString());
        }
    }
}