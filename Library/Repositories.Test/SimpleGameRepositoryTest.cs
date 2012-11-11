using GOL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using GOL.Models;
using System.Collections.Generic;
using GOL.Interfaces;

namespace GOL.Repositories.Test
{    
    /// <summary>
    ///This is a test class for SimpleGameRepositoryTest
    ///</summary>
    [TestClass]
    public class SimpleGameRepositoryTest
    {
        private SimpleGameRepository gameRepository;

        /// <summary>
        /// Setup the class for a test
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            this.gameRepository = new SimpleGameRepository();
        }
        
        /// <summary>
        ///A test for DeleteGameWorld
        ///</summary>
        [TestMethod]
        public void DeleteGameWorldTest()
        {            
            Assert.IsNotNull(this.gameRepository.LoadGameWorld("Boat"));

            this.gameRepository.DeleteGameWorld("Boat");

            Assert.IsNull(this.gameRepository.LoadGameWorld("Boat"));
        }

        /// <summary>
        ///A test for LoadGameWorld
        ///</summary>
        [TestMethod]
        public void LoadGameWorldTest()
        {
            GameWorld gameworld = this.gameRepository.LoadGameWorld("Boat");

            Assert.IsNotNull(gameworld);
            Assert.IsNotNull(gameworld.LiveNodes);
            Assert.IsTrue(gameworld.LiveNodes.Any());
        }

        /// <summary>
        ///A test for LoadGameWorldDescriptions
        ///</summary>
        [TestMethod]
        public void LoadGameWorldDescriptionsTest()
        {
            List<string> descriptions = this.gameRepository.LoadGameWorldDescriptions();
            Assert.IsTrue(descriptions.Any());
            Assert.IsTrue(descriptions.Contains("Boat"));
        }

        /// <summary>
        /// A test for SaveGameWorld
        /// </summary>
        [TestMethod]
        public void SaveGameWorldTest()
        {
            GameWorld testWorld = new GameWorld();
            testWorld.Description = "TEST";
            testWorld.LiveNodes.Add(new Node() { X = 1, Y = 1 });

            Assert.IsNull(this.gameRepository.LoadGameWorld("TEST"));

            this.gameRepository.SaveGameWorld(testWorld);

            Assert.IsNotNull(this.gameRepository.LoadGameWorld("TEST"));
        }
    }
}
