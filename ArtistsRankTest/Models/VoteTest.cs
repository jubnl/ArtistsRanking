using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtistsRankTest.Models
{
    [TestClass]
    public class VoteTest : AssemblyLoader
    {
        /// <summary>
        /// Vérifie si le type Vote existe
        /// </summary>
        [TestMethod]
        public void TypeVoteExist()
        {
            Assert.IsTrue(Assembly.GetTypes().Any(t => t.Name == "Vote"));
        }

        /// <summary>
        /// Vérifie si le constructeur de la classe vote existe
        /// </summary>
        [TestMethod]
        public void ConstructorExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetConstructors().Any() ?? false);
        }

        /// <summary>
        /// Vérifie si le constructeur de la classe contient les bons type de paramètres
        /// </summary>
        [TestMethod]
        public void ConstructorContainsParameters()
        {
            Assert.IsTrue(
                Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")
                    ?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") }) != null);
        }

        /// <summary>
        /// Vérifie si la classe contient la propriété Id
        /// </summary>
        [TestMethod]
        public void TypeContainsPropertyId()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Id") != null);
        }


        /// <summary>
        /// Vérifie si la propriété id est de type int
        /// </summary>
        [TestMethod]
        public void TypePropertyIdIsTypeInt()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Id").PropertyType == typeof(int));
        }

        /// <summary>
        /// Vérifie si la classe contient la propriété Firstname
        /// </summary>
        [TestMethod]
        public void TypeContainsPropertyFirstname()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Firstname") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Firstname est de type string
        /// </summary>
        [TestMethod]
        public void TypePropertyFirstnameIsTypeString()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Firstname").PropertyType == typeof(string));
        }

        /// <summary>
        /// Vérifie si la classe contient la propriété Lastname
        /// </summary>
        [TestMethod]
        public void TypeContainsPropertyLastname()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Lastname") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Lastname est de type string
        /// </summary>
        [TestMethod]
        public void TypePropertyLastnameIsTypeString()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Lastname").PropertyType == typeof(string));
        }

        /// <summary>
        /// Vérifie si la classe contient la propriété Rank
        /// </summary>
        [TestMethod]
        public void TypeContainsPropertyRank()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Rank") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Rank est de type Int
        /// </summary>
        [TestMethod]
        public void TypePropertyRankIsTypInt()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Rank").PropertyType == typeof(int));
        }

        /// <summary>
        /// Vérifie si la classe contient la propriété Artist
        /// </summary>
        [TestMethod]
        public void TypeContainsPropertyArtist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Artist") != null);
        }


        /// <summary>
        /// Vérifie si la propriété Artist est de type Artist
        /// </summary>
        [TestMethod]
        public void TypePropertyArtistIsTypeArtist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Artist").PropertyType != null && Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Artist").PropertyType == Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist"));
        }

        /// <summary>
        /// Vérifie si la propriété Id est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void IdPropertyCorrectlyInitilized()
        {
            var id = 999;
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")
                ?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") })
                .Invoke(new object[] { id, "", "", 0, null });
            Assert.IsTrue((int)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Id").GetValue(obj) == id);
        }

        /// <summary>
        /// Vérifie si la propriété Firstname est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void FirstnamePropertyCorrectlyInitilized()
        {
            var firstname = "Toto";
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") })
                .Invoke(new object[] { 0, firstname, "", 0, null });
            Assert.IsTrue((string)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Firstname").GetValue(obj) == firstname);
        }

        /// <summary>
        /// Vérifie si la propriété Lastname est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void LastnamePropertyCorrectlyInitilized()
        {
            var lastname = "Toto";
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") })
                .Invoke(new object[] { 0, "", lastname, 0, null });
            Assert.IsTrue((string)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Lastname").GetValue(obj) == lastname);
        }

        /// <summary>
        /// Vérifie si la propriété Rank est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void RankPropertyCorrectlyInitilized()
        {
            var rank = 999;
            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")
                ?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") })
                .Invoke(new object[] { 0, "", "", rank, null });
            Assert.IsTrue((int)Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Rank").GetValue(obj) == rank);
        }

        /// <summary>
        /// Vérifie si la propriété Artist est bien initialisée dans le constructeur
        /// </summary>
        [TestMethod]
        public void ArtistPropertyCorrectlyInitilized()
        {

            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 0, "", null });

            var obj = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")
                ?.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") })
                .Invoke(new object[] { 0, "", "", 0, artist });
            Assert.IsTrue(artist != null && Assembly.GetTypes().FirstOrDefault(t => t.Name == "Vote")?.GetProperty("Artist").GetValue(obj) == artist);
        }
    }
}
