using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestXamarin
{
    [TestFixture(Platform.Android)]
    class EditProfileTest
    {
        IApp _app;
        Platform platform;

        readonly Func<AppQuery, AppQuery> _entryCedula = e => e.Marked("EntryCedula");
        readonly Func<AppQuery, AppQuery> _entryContrasenna = e => e.Marked("EntryContrasenna");
        readonly Func<AppQuery, AppQuery> _buttonLogin = e => e.Marked("ButtonLogin");
        readonly Func<AppQuery, AppQuery> _valueCorreo = e => e.Marked("ValueCorreo");
        readonly Func<AppQuery, AppQuery> _valueCedula = e => e.Marked("ValueCedula");
        readonly Func<AppQuery, AppQuery> _valueContrasenna = e => e.Marked("ValueContrasenna");
        readonly Func<AppQuery, AppQuery> _editButton = e => e.Marked("EditButton");
        readonly Func<AppQuery, AppQuery> _resultSuccess = e => e.Marked("ResultSuc");
        readonly Func<AppQuery, AppQuery> _resultFailed = e => e.Marked("ResultFail");

        public EditProfileTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
           _app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Verificar_Actualizacion_Perfil_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "444");
            _app.EnterText(_entryContrasenna, "12345");
            _app.Tap(_buttonLogin);

            //Act
            _app.EnterText(_valueContrasenna, "123456");
            _app.Tap(_editButton);

            //Assert
            Assert.IsTrue(_resultSuccess != null);
            
        }

        [Test]
        public void Verificar_No_Actualizacion_Cedula_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "222");
            _app.EnterText(_entryContrasenna, "12345");
            _app.Tap(_buttonLogin);

            //Act
            _app.EnterText(_valueCedula, "2223");
            _app.Tap(_editButton);

            //Assert
            var appResult = _resultFailed.ToString().Equals("la cédula no se puede cambiar"); 
            Assert.IsTrue(appResult);


        }

        [Test]
        public void Verificar_No_Actualizacion_Perfil_Incompleto_UITest()
        {
            //Arrange
            _app.EnterText(_entryCedula, "222");
            _app.EnterText(_entryContrasenna, "12345");
            _app.Tap(_buttonLogin);

            //Act
            _app.EnterText(_valueCorreo, "");
            _app.Tap(_editButton);

            //Assert
            var appResult = _resultFailed.ToString().Equals("datos incompletos");
            Assert.IsTrue(appResult);


        }


    }
}
