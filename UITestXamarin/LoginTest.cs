using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestXamarin
{
    [TestFixture(Platform.Android)]
    class LoginTest
    {
        IApp _app;
        Platform platform;
        readonly Func<AppQuery, AppQuery> _entryCedula = e => e.Marked("EntryCedula");
        readonly Func<AppQuery, AppQuery> _entryContrasenna = e => e.Marked("EntryContrasenna");
        readonly Func<AppQuery, AppQuery> _buttonLogin = e => e.Marked("ButtonLogin");
        readonly Func<AppQuery, AppQuery> _resultMsg = e => e.Marked("ResultMsg");

        public LoginTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Verificar_Correcto_Logueo_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "444");
            _app.EnterText(_entryContrasenna, "12345");

            //Act
            _app.Tap(_buttonLogin);

            //Assert
            var appResult = _resultMsg.ToString().Equals("Datos correctos");
            Assert.IsTrue(appResult);

        }

        [Test]
        public void Verificar_No_Logueo_Usuario_Incorrecto_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "2223");
            _app.EnterText(_entryContrasenna, "12345");

            //Act
            _app.Tap(_buttonLogin);

            //Assert
            var appResult = _resultMsg.ToString().Equals("usuario no existe");
            Assert.IsTrue(appResult);

        }
        [Test]
        public void Verificar_No_Logueo_Contrasenna_Incorrecto_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "222");
            _app.EnterText(_entryContrasenna, "1234578");

            //Act
            _app.Tap(_buttonLogin);

            //Assert
            var appResult = _resultMsg.ToString().Equals("contraseña invalida");
            Assert.IsTrue(appResult);

        }
    }
}
