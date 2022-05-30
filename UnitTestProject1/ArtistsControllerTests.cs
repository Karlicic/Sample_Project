using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ArtistsControllerTests
    {
        [Test]
        public void GetArtist_ShouldReturnArtist_WhenArtistExsists()
        {
            var controller = new ArtistsController(new Context());
        }
    }
}
