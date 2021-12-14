using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtistsRankTest.Controllers
{
    [TestClass]
    public class ArtistControllerTest : AssemblyLoader
    {
        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsTrue(Assembly.GetTypes().Any(t => t.Name == "ArtistController"));
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodSaveExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Save") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodSaveContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Save", new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodSaveReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Save").ReturnType == typeof(void));
        }

        /// <summary>
        /// Verifie l'ajout d'un artiste
        /// </summary>
        [TestMethod]
        public void SavedNewArtistsIsAddedToList()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// L'ajout d'un artiste déjà existant doit retourner une exception
        /// </summary>
        [TestMethod]
        public void SaveExistingArtistsShouldThrowException()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assert.ThrowsException<TargetInvocationException>(() => Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style }));
        }

        /// <summary>
        /// Vérifie la modification du nom de l'artiste
        /// </summary>
        [TestMethod]
        public void SaveExistingArtistShouldModifyName()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { 1, "Tata", style });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).First().GetType().GetProperty("Name").GetValue(((IEnumerable<object>)result).First()).ToString() == "Tata");
        }

        /// <summary>
        /// Vérifie la modification du style
        /// </summary>
        [TestMethod]
        public void SaveExistingArtistShouldModifyStyle()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { 1, name, Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(1) });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).First().GetType().GetProperty("Style").GetValue(((IEnumerable<object>)result).First()).ToString() == Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(1).ToString());
        }

        /// <summary>
        /// Vérifie la valeur de l'id pour le 2ème élément ajouté
        /// </summary>
        [TestMethod]
        public void SecondArtistShouldHaveIdValue2()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { 0, name, Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(1) });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue((int)((IEnumerable<object>)result).Last().GetType().GetProperty("Id").GetValue(((IEnumerable<object>)result).Last()) == 2);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodDeleteExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Delete") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodDeleteContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Delete", new Type[] { typeof(int)}) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodDeleteReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("Delete").ReturnType == typeof(void));
        }

        /// <summary>
        /// Verifie la suppression d'un artist avec un id existant
        /// </summary>
        [TestMethod]
        public void DeleteArtistShouldNotContainAny()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Delete").Invoke(controller, new object[] { 1 });

            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 0);
        }

        /// <summary>
        /// Verifie la suppression d'un artist avec un id inexistant
        /// </summary>
        [TestMethod]
        public void DeleteArtistWithUnexistingIdShouldNotDelete()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Delete").Invoke(controller, new object[] { 8 });

            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodGetArtistsExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetArtists") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetArtistsContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetArtists", new Type[] { }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodGetAtristsReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetArtists").ReturnType.GetInterface("IEnumerable") != null);
        }

        /// <summary>
        /// Vérifie le contenu de la liste
        /// </summary>
        [TestMethod]
        public void GetArtistWithOneElementShouldContain1()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });

            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetArtists").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodGetSelectedArtistExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetSelectedArtist") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetSelectedArtistContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetSelectedArtist", new Type[] { typeof(int) }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodGetSelectedArtistReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") != null && Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController")?.GetMethod("GetSelectedArtist").ReturnType == Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist"));
        }


        /// <summary>
        /// Vérifie la récupération d'un artiste dans la liste avec un id qui existe
        /// </summary>
        [TestMethod]
        public void GetSelectedArtistWithExistingIdShouldReturnArtist()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });

            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetSelectedArtist").Invoke(controller, new object[] { 1 });

            Assert.IsTrue(result.GetType() == Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist"));
        }

        /// <summary>
        /// Vérifie la récupération d'un artiste dans la liste avec un id à 0
        /// </summary>
        [TestMethod]
        public void GetSelectedArtistWithNotExistingIdShouldReturnArtist()
        {
            int id = 0;
            string name = "Toto";
            var style = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0);
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("Save").Invoke(controller, new object[] { id, name, style });

            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "ArtistController").GetMethod("GetSelectedArtist").Invoke(controller, new object[] { 0 });

            Assert.IsNull(result);
        }
    }
}
