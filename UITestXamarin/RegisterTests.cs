using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace UITestXamarin
{
    [TestFixture(Platform.Android)]
    class RegisterTests
    {
        
        IApp _app;
        Platform platform;

        readonly Func<AppQuery, AppQuery> _addUser = e => e.Marked("AddUser");
        readonly Func<AppQuery, AppQuery> _addCedula = e => e.Marked("VCedula");
        readonly Func<AppQuery, AppQuery> _addCorreo = e => e.Marked("VCorreo");
        readonly Func<AppQuery, AppQuery> _addContrasenna = e => e.Marked("VConstrasenna");
        readonly Func<AppQuery, AppQuery> _buttonRegister = e => e.Marked("ButtonRegistrar");
        readonly Func<AppQuery, AppQuery> _successResult = e => e.Marked("SuccessResult");
        readonly Func<AppQuery, AppQuery> _failedResult = e => e.Marked("FailedResult");
        readonly Func<AppQuery, AppQuery> _duplicateResult = e => e.Marked("DuplicateResult");

        public RegisterTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Verificar_Registro_Datos_Correctos_UITest()
        {

            //Arrange
            _app.Tap(_addUser);
            _app.EnterText(_addCedula, "444");
            _app.EnterText(_addCorreo, "test");
            _app.EnterText(_addContrasenna, "12345");

            //Act
            _app.Tap(_buttonRegister);

            //Assert
            Assert.IsTrue(_successResult != null);
        }

        [Test]
        public void Verificar_No_Registro_Datos_Incompletos_UITest()
        {

            //Arrange
            _app.Tap(_addUser);
            _app.EnterText(_addCedula, "444");
            _app.EnterText(_addCorreo, "test");
            _app.EnterText(_addContrasenna, "");

            //Act
            _app.Tap(_buttonRegister);

            //Assert
            Assert.IsTrue(_failedResult != null);
        }

        [Test]
        public void Verificar_No_Registro_Cedula_Duplicada_UITest()
        {

            //Arrange
            _app.Tap(_addUser);
            _app.EnterText(c => c.Marked("VCedula"), "111");
            _app.EnterText(c => c.Marked("VCorreo"), "test");
            _app.EnterText(c => c.Marked("VConstrasenna"), "12345");

            //Act
            _app.Tap(_buttonRegister);

            //Assert
            Assert.IsTrue(_duplicateResult != null);
        }

    }
}
