using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtistsRankTest.Controllers
{
    [TestClass]
    public class VoteControllerTest : AssemblyLoader
    {
        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsTrue(Assembly.GetTypes().Any(t => t.Name == "VoteController"));
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodSaveExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("Save") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodSaveContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("Save", new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist") }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodSaveReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("Save").ReturnType == typeof(void));
        }

        /// <summary>
        /// Verifie l'ajout d'un vote
        /// </summary>
        [TestMethod]
        public void SavedNewVoteIsAddedToList()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname,vote, artist });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetVotes").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// L'ajout d'un artiste déjà existant doit retourner une exception
        /// </summary>
        [TestMethod]
        public void SaveExistingArtistsShouldThrowException()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            Assert.ThrowsException<TargetInvocationException>(() => Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist }));
        }


        /// <summary>
        /// Vérifie la valeur de l'id pour le 2ème élément ajouté
        /// </summary>
        [TestMethod]
        public void SecondArtistShouldHaveIdValue2()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, "Tata", lastname, vote, artist });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetVotes").Invoke(controller, new object[0]);

            Assert.IsTrue((int)((IEnumerable<object>)result).Last().GetType().GetProperty("Id").GetValue(((IEnumerable<object>)result).Last()) == 2);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodGetVotessExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotes") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetVotesContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotes", new Type[] { }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodGetVotesReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotes").ReturnType.GetInterface("IEnumerable") != null);
        }

        /// <summary>
        /// Vérifie le contenu de la liste
        /// </summary>
        [TestMethod]
        public void GetVotesWithOneElementShouldContain1()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetVotes").Invoke(controller, new object[0]);

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodGetVotesByArtistExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotesByArtist") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetVotesByArtistContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotesByArtist", new Type[] { typeof(int)}) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodGetVotesByArtistReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetVotesByArtist").ReturnType.GetInterface("IEnumerable") != null);
        }

        /// <summary>
        /// Verifie que la méthode retourne qu'un vote pour l'id artiste 1 alors qu'il y a 2 votes dans la liste
        /// </summary>
        [TestMethod]
        public void GetVotesByArtistWith2VotesOnlistShouldReturn1Element()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var artist2 = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 2, "Test", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist2 });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetVotesByArtist").Invoke(controller, new object[] { 1 });

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 1);
        }

        /// <summary>
        /// Verifie que la méthode retourne 0 vote si l'artiste n'est pas trouvé
        /// </summary>
        [TestMethod]
        public void GetVotesByArtistWith1VoteAndUnexistArtistOnlistShouldReturn0Element()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetVotesByArtist").Invoke(controller, new object[] { 2 });

            Assert.IsTrue(((IEnumerable<object>)result).Count() == 0);
        }

        /// <summary>
        /// Vérifie si la méthode existe
        /// </summary>
        [TestMethod]
        public void MethodGetAverageByArtistByAristExist()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetAverageByArtist") != null);
        }

        /// <summary>
        /// Vérifie si la méthode contient les bons paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetAverageByArtistContainsRightsParameters()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetAverageByArtist", new Type[] { typeof(int) }) != null);
        }

        /// <summary>
        /// Vérifie si la méthode a le bon retour
        /// </summary>
        [TestMethod]
        public void MethodGetAverageByArtistReturnRightType()
        {
            Assert.IsTrue(Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController")?.GetMethod("GetAverageByArtist").ReturnType == typeof(decimal));
        }

        /// <summary>
        /// Verifie le calcul de la moyenne des note par artiste
        /// </summary>
        [TestMethod]
        public void GetAverageByArtistWith2VotesForArtistShouldReturn6()
        {
            int id = 0;
            string firstname = "Toto";
            string lastname = "Toto";
            int vote = 6;
            var artist = Assembly.GetTypes().FirstOrDefault(t => t.Name == "Artist")?.GetConstructor(new Type[] { typeof(int), typeof(string), Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style") }).Invoke(new object[] { 1, "", Assembly.GetTypes().FirstOrDefault(t => t.Name == "Style").GetEnumValues().GetValue(0) });
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);

            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, firstname, lastname, vote, artist });
            Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("Save").Invoke(controller, new object[] { id, "Tata", lastname, vote, artist });
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetAverageByArtist").Invoke(controller, new object[] { 1 });

            Assert.IsTrue((decimal)result == 6m);
        }

        /// <summary>
        /// Le calcul de la moyenne doit retourner 0 si il n'y a pas de vote pour cet artiste
        /// </summary>
        [TestMethod]
        public void GetAverageByArtistWithoutVotesForArtistShouldReturn0()
        {
            var controller = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetConstructor(new Type[0]).Invoke(new object[0]);
            var result = Assembly.GetTypes().FirstOrDefault(t => t.Name == "VoteController").GetMethod("GetAverageByArtist").Invoke(controller, new object[] { 1 });

            Assert.IsTrue((decimal)result == 0m);
        }
    }
}
