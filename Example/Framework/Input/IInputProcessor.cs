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
using Godot;
namespace Framework.Input
{
    /// <summary>
    /// Required interface for local players with input eg. shifting, crouching, moving, etc.
    /// </summary>
    public interface IInputProcessor : IPlayerComponent
    {
        /// <summary>
        /// Last input storage
        /// </summary>
        /// <value></value>
        public GeneralPlayerInput LastInput { get; }

        public void SetPlayerInputs(GeneralPlayerInput inputs);


        /// <summary>
        /// List of avaiable input keys
        /// </summary>
        /// <value></value>
        public List<string> AvaiableInputs { get; }

        /// <summary>
        /// List of all pressed or unpressed keys
        /// </summary>
        /// <returns></returns>
        /// public Dictionary<string, bool> GetKeys();


        /// <summary>
        /// The current player input for the actualy local tick
        /// </summary>
        /// <returns></returns>
        public GeneralPlayerInput GetInput();


    }
}