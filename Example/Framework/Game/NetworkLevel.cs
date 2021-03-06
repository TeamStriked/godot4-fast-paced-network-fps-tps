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

using System.Linq;
using Godot;

namespace Framework.Game
{
    /// <summary>
    /// A basic class for an game level
    /// </summary>
    public partial class NetworkLevel : Node3D, INetworkLevel
    {
        /// <summary>
        /// The node path to the world environment node
        /// </summary>
        [Export]
        public NodePath EnvironmentPath;

        /// <summary>
        /// The world environment of the levelk
        /// </summary>
        /// <value></value>
        public Environment Environment
        {
            get
            {
                var worldEnv = this.GetNodeOrNull<WorldEnvironment>(this.EnvironmentPath);
                if (worldEnv != null)
                    return worldEnv.Environment;

                return null;
            }
        }

        /// <inheritdoc />
        public SpawnPoint[] GetAllSpawnPoints()
        {
            return GetChildren().OfType<SpawnPoint>().ToArray<SpawnPoint>();
        }

        /// <inheritdoc />
        public SpawnPoint[] GetFreeSpawnPoints()
        {
            return GetAllSpawnPoints().Where(df => df.isFree()).ToArray();
        }
    }
}
