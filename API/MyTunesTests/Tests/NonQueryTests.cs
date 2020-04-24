using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;
using MyTunes.Controllers;

namespace MyTunes.Tests
{
    [TestClass]
    public class NonQueryTests
    {
        [TestMethod]
        public void CreateEditeur_saves_a_editeur_via_context()
        {
            var mockSet = new Mock<DbSet<Editeur>>();

            var optionsBuilder = new DbContextOptionsBuilder<MyTunesContext>();
            optionsBuilder.UseInMemoryDatabase("mytunes");

            var mockContext = new Mock<MyTunesContext>(MockBehavior.Loose, optionsBuilder.Options);
            mockContext.Setup(m => m.EDITEUR).Returns(mockSet.Object);

            var service = new EditeursController(mockContext.Object);
            _ = service.PostEditeur(new Editeur()
            {
                id_editeur = 1,
                nom_editeur = "test_Editeur"
            });

            mockSet.Verify(m => m.Add(It.IsAny<Editeur>()), Times.Once());
        }
    }
}
