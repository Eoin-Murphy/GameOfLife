﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Interfaces;
using GOL.Services;
using GOL.Repositories;
using GOL.Updater.Imperative;

namespace GameOfLife.Infrastructure
{
    /// <summary>
    /// This is a simple Inversion of Control Assembler
    /// 
    /// Normally we'd use NInject or something simlar but that's outside the scope of this project
    /// 
    /// This one is mostly copied from :
    /// http://blogs.msdn.com/b/brunoterkaly/archive/2012/03/08/dependency-injection-inversion-of-control-a-concrete-example-roll-your-own.aspx
    /// </summary>
    public class IoCAssembler
    {
        private delegate object CreateCode();

        private Dictionary<Type, CreateCode> bindings;

        /// <summary>
        /// Initializes an instance of the IoCAssembler class
        /// Builds up our bindings list
        /// </summary>
        public IoCAssembler()
        {
            bindings = new Dictionary<Type, CreateCode>();

            // Adding updater
            this.AddComponent<IGameUpdater>(() =>
            {
                IGameUpdater gameUpdater = new SimpleUpdater();
                return gameUpdater;
            });

            // Adding repo
            this.AddComponent<IGameRepository>(() =>
            {
                IGameRepository gameRepository = new SimpleGameRepository();
                return gameRepository;
            });

            // Adding services
            this.AddComponent<IGameEngine>(() =>
                {
                    IGameEngine gameEngine = new SimpleGameEngine(
                                                            this.Create<IGameRepository>(),
                                                            this.Create<IGameUpdater>());
                    return gameEngine;
                });
        }

        /// <summary>
        /// Create the required class
        /// </summary>
        public T Create<T>()
        {
            return (T)bindings[typeof(T)]();
        }

        /// <summary>
        /// Add required class to the list
        /// </summary>
        private void AddComponent<T>(CreateCode createCode)
        {
            // Remove previous entry, if it exists
            if (bindings.ContainsKey(typeof(T)))
                bindings.Remove(typeof(T));
            // Add the new entry
            bindings.Add(typeof(T), createCode);
        }
    }
}
