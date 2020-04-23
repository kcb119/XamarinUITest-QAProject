using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestXamarin
{
    [TestFixture(Platform.Android)]
    class DeleteProfileTest
    {
        IApp _app;
        Platform platform;

        readonly Func<AppQuery, AppQuery> _entryCedula = e => e.Marked("EntryCedula");
        readonly Func<AppQuery, AppQuery> _entryContrasenna = e => e.Marked("EntryContrasenna");
        readonly Func<AppQuery, AppQuery> _buttonLogin = e => e.Marked("ButtonLogin");
        readonly Func<AppQuery, AppQuery> _deleteButton = e => e.Marked("DeleteButton");
        readonly Func<AppQuery, AppQuery> _pageLogin = e => e.Marked("InicioLogin");

        public DeleteProfileTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Verificar_Eliminacion_Perfil_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "444");
            _app.EnterText(_entryContrasenna, "12345");
            _app.Tap(_buttonLogin);

            //Act
            _app.Tap(_deleteButton);

            //Assert
            var result = _app.WaitForElement(_pageLogin);
            Assert.IsTrue(result != null);
           

        }
    }
}
