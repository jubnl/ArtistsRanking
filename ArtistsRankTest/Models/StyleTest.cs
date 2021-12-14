using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtistsRankTest.Models
{
    [TestClass]
    public class StyleTest : AssemblyLoader
    {
        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsTrue(Assembly.GetTypes().Any(t => t.Name == "Style"));
        }

        /// <summary>
        /// Vérifie si c'est un enum
        /// </summary>
        [TestMethod]
        public void TypeIsEnum()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style")?.IsEnum ?? false);
        }

        /// <summary>
        /// Vérifie si'il contient au moins 4 valeurs
        /// </summary>
        [TestMethod]
        public void ContainsAtLeast4Values()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style")?.GetEnumValues().Length >= 4);
        }
    }
}
