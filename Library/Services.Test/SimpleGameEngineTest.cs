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
    ///This is a test class for SimpleGameEngine and is intended
    ///</summary>
    [TestClass]
    public class SimpleGameEngineTest
    {
        private IGameEngine gameEngine;        

        /// <summary>
        /// Sets up the test fixture
        /// Lots of happy trail testing, none failing.
        /// </summary>
        [TestInitialize]
        public void SetupSimpleEngineTest()
        {
            IGameRepository simpleGameRepository = new SimpleGameRepository();
            gameEngine = new SimpleGameEngine(simpleGameRepository);
        }

        [TestMethod]
        public void LoadGameWorldTest()
        {
            this.gameEngine.LoadGameWorld("Blinker");

            Assert.AreEqual(3, this.gameEngine.GetGameWorldState().Count());
        }

        [TestMethod]
        public void SaveGameWorld()
        {
            this.gameEngine.LoadGameWorld("Blinker");

            this.gameEngine.SaveGameWorld();
        }

        [TestMethod]
        public void GetGameWorldState()
        {
            this.gameEngine.LoadGameWorld("Blinker");

            Assert.AreEqual(3, this.gameEngine.GetGameWorldState().Count());

            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));
        }

        [TestMethod]
        public void TestBlockUpdate()
        {
            this.gameEngine.LoadGameWorld("Block");

            // initial block
            Assert.AreEqual(4, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));

            this.gameEngine.UpdateGameWorld();

            // updated block
            Assert.AreEqual(4, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
        }

        [TestMethod]
        public void TestBoatUpdate()
        {
            this.gameEngine.LoadGameWorld("Boat");

            // initial boat
            Assert.AreEqual(5, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameEngine.UpdateGameWorld();

            // updated boat
            Assert.AreEqual(5, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));
        }

        [TestMethod]
        public void TestBlinkerUpdate()
        {
            this.gameEngine.LoadGameWorld("Blinker");

            // vertical state
            Assert.AreEqual(3, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameEngine.UpdateGameWorld();

            // horizontal state
            Assert.AreEqual(3, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

            this.gameEngine.UpdateGameWorld();

            // vertical state
            Assert.AreEqual(3, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

        }

        [TestMethod]
        public void TestToadUpdate()
        {
            this.gameEngine.LoadGameWorld("Toad");

            // initial state
            Assert.AreEqual(6, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 4, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

            this.gameEngine.UpdateGameWorld();

            // updated state
            Assert.AreEqual(6, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 0 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 4, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 4, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameEngine.UpdateGameWorld();

            // initial state
            Assert.AreEqual(6, this.gameEngine.GetGameWorldState().Count());
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 4, Y = 1 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameEngine.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

        }

        /// <summary>
        ///A test for GetCurrentWorldDescription
        ///</summary>
        [TestMethod]
        public void GetCurrentWorldDescriptionTest()
        {
            this.gameEngine.LoadGameWorld("Toad");

            Assert.IsTrue(this.gameEngine.GetCurrentWorldDescription().Equals("Toad", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///A test for GetWorldDescriptions
        ///</summary>
        [TestMethod]
        public void GetWorldDescriptionsTest()
        {
            List<string> descriptions = this.gameEngine.GetWorldDescriptions();

            Assert.IsTrue(descriptions.Contains("Block"));
            Assert.IsTrue(descriptions.Contains("Boat"));
            Assert.IsTrue(descriptions.Contains("Blinker"));
            Assert.IsTrue(descriptions.Contains("Toad"));
            Assert.IsTrue(descriptions.Contains("Beacon"));
        }
    }   
}
