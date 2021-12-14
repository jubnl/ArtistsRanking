using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtistsRankTest.Models
{
    [TestClass]
    public class ArtistTest : AssemblyLoader
    {
        /// <summary>
        /// Vérifie si le type Artist existe
        /// </summary>
        [TestMethod]
        public void TypeArtistExist()
        {
            Assert.IsTrue(Assembly.GetTypes().Any(t => t.Name == "Artist"));
        }

        /// <summary>
        /// Vérifie si le constructeur de la classe artiste existe
        /// </summary>
        [TestMethod]
        public void ConstructorExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructors().Any() ?? false);
        }

        /// <summary>
        /// Vérifie si le constructeur de la classe contient les bons type de paramètres
        /// </summary>
        [TestMethod]
        public void ConstructorContainsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }) != null);
        }

        /// <summary>
        /// Vérifie si la classe Artist contient la propriété Id
        /// </summary>
        [TestMethod]
        public void TypeArtistContainsPropertyId()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Id") != null);
        }


        /// <summary>
        /// Vérifie si la propriété id est de type int
        /// </summary>
        [TestMethod]
        public void TypeArtistPropertyIdIsTypeInt()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Id").PropertyType == typeof(int));
        }

        /// <summary>
        /// Vérifie si la classe Artist contient la propriété Name
        /// </summary>
        [TestMethod]
        public void TypeArtistContainsPropertyName()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Name") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Name est de type string
        /// </summary>
        [TestMethod]
        public void TypeArtistPropertyNameIsTypeString()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Name").PropertyType == typeof(string));
        }

        /// <summary>
        /// Vérifie si la classe Artist contient la propriété Style
        /// </summary>
        [TestMethod]
        public void TypeArtistContainsPropertyStyle()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Style") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Style est de type Style
        /// </summary>
        [TestMethod]
        public void TypeArtistPropertyStyleIsTypeStyle()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Style").PropertyType != null && Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Style").PropertyType == Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style"));
        }

        /// <summary>
        /// Vérifie si la propriété Id est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void IdPropertyCorrectlyInitilized()
        {
            var id = 999;
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { id, "", null });
            Assert.IsTrue((int)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Id").GetValue(obj) == id);
        }

        /// <summary>
        /// Vérifie si la propriété Name est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void NamePropertyCorrectlyInitilized()
        {
            var name = "Toto";
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 0, name, null });
            Assert.IsTrue((string)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Name").GetValue(obj) == name);
        }

        /// <summary>
        /// Vérifie si la propriété Style est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void StylePropertyCorrectlyInitilized()
        {

            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);

            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 0, "", style });
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetProperty("Style").GetValue(obj).ToString() == style.ToString());
        }
    }
}
