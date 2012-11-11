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
    public class SimpleGameEngineTest
    {
        private IGameEngine gameWorld;        

        /// <summary>
        /// Sets up the test fixture
        /// </summary>
        [TestInitialize]
        public void SetupSimpleWorldTest()
        {
            IGameRepository mockGameRepository = new SimpleGameRepository();
            gameWorld = new SimpleGameEngine(mockGameRepository);
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
        public void TestBlockUpdate()
        {
            this.gameWorld.LoadGameWorld("Block");

            // initial block
            Assert.AreEqual(4, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));

            this.gameWorld.UpdateGameWorld();

            // updated block
            Assert.AreEqual(4, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
        }

        [TestMethod]
        public void TestBoatUpdate()
        {
            this.gameWorld.LoadGameWorld("Boat");

            // initial boat
            Assert.AreEqual(5, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameWorld.UpdateGameWorld();

            // updated boat
            Assert.AreEqual(5, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));
        }

        [TestMethod]
        public void TestBlinkerUpdate()
        {
            this.gameWorld.LoadGameWorld("Blinker");

            // vertical state
            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameWorld.UpdateGameWorld();

            // horizontal state
            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

            this.gameWorld.UpdateGameWorld();

            // vertical state
            Assert.AreEqual(3, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

        }

        [TestMethod]
        public void TestToadUpdate()
        {
            this.gameWorld.LoadGameWorld("Toad");

            // initial state
            Assert.AreEqual(6, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 4, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

            this.gameWorld.UpdateGameWorld();

            // updated state
            Assert.AreEqual(6, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 0 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 4, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 4, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 3 }));

            this.gameWorld.UpdateGameWorld();

            // initial state
            Assert.AreEqual(6, this.gameWorld.GetGameWorldState().Count());
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 4, Y = 1 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 1, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 2, Y = 2 }));
            Assert.IsTrue(this.gameWorld.GetGameWorldState().Contains(new Node() { X = 3, Y = 2 }));

        }
    }
}
