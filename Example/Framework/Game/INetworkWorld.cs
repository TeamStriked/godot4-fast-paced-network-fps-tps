/*
 * Created on Mon Mar 28 2022
 *
 * The MIT License (MIT)
 * Copyright (c) 2022 Stefan Boronczyk, Striked GmbH
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 * and associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System.Collections.Generic;
using Framework.Network;
using Framework.Extensions;
using Framework.Game.Server;

namespace Framework.Game
{
    /// <summary>
    /// The required interface for an game world
    /// </summary>
    public interface INetworkWorld
    {

        /// <summary>
        /// Game logic controller
        /// </summary>
        /// <value></value>
        public GameLogic GameInstance { get; }

        /// <summary>
        /// Destroy the game world
        /// </summary>
        public void Destroy();

        /// <summary>
        /// The physics and network related tick process method
        /// </summary>
        public void Tick(float tickInterval);

        /// <summary>
        /// The current tick of the world
        /// </summary>
        /// <value></value>
        public uint WorldTick { get; }


        /// <summary>
        /// The loaded game level of the world
        /// </summary>
        /// <value></value>
        public INetworkLevel NetworkLevel { get; }

        /// <summary>
        /// The server vars of the world
        /// </summary>
        /// <value></value>
        public VarsCollection ServerVars { get; }

        /// <summary>
        /// All players of the world
        /// </summary>
        /// <value></value>
        public Dictionary<short, NetworkCharacter> Players { get; }

        /// <summary>
        /// Calls when an player is initialized and the map was loaded sucessfulll
        /// </summary>
        /// <param name="p"></param>
        public void OnPlayerInitilaized(INetworkCharacter p);

        /// <summary>
        ///  When level was adding complelty to scene
        /// </summary>
        public void OnLevelAddToScene();

        /// <summary>
        /// Path of the world resource 
        /// </summary>
        /// <value></value>
        public string ResourceWorldPath { get; }

        /// <summary>
        /// Path of the world resource script
        /// </summary>
        /// <value></value>
        public string ResourceWorldScriptPath { get; }
    }
}
