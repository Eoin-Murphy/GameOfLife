using GOL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using GOL.Interfaces;
using GOL.Models;
using System.Collections.Generic;
using GOL.Repositories;

namespace ServicesTest
{
    
    
    /// <summary>
    ///This is a test class for SimpleGameWorldTest and is intended
    ///to contain all SimpleGameWorldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SimpleGameWorldTest
    {
        private IGameWorld gameWorld;        

        /// <summary>
        /// Sets up the test fixture
        /// </summary>
        [TestInitialize]
        public void SetupSimpleWorldTest()
        {
            IGameRepository mockGameRepository = new MockGameWorldRepository();
            gameWorld = new SimpleGameWorld(mockGameRepository);
        }

        [TestMethod]
        public void LoadGameWorldTest()
        {
            this.gameWorld.LoadGameWorld("Blinker");

            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());
        }

        [TestMethod]
        public void SaveGameWorld()
        {
            this.gameWorld.LoadGameWorld("Blinker");

            this.gameWorld.SaveGameWorld();
        }

        [TestMethod]
        public void GetGameWorldState()
        {
            this.gameWorld.LoadGameWorld("Blinker");

            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());

            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));
        }

        [TestMethod]
        public void TestBlinkerUpdate()
        {
            this.gameWorld.LoadGameWorld("Blinker");

            this.gameWorld.UpdateGameWorld();

            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());

            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

            this.gameWorld.UpdateGameWorld();

            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());

            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameWorld.UpdateGameWorld();

            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());

            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));
        }

    }
}
