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

using Godot;
using LiteNetLib.Utils;
using Framework.Input;

namespace Framework.Network.Commands
{
    public struct PlayerInputCommand : INetSerializable
    {
        // The world tick for the first input in the array.
        public uint StartWorldTick;

        // An array of inputs, one entry for tick.  Ticks are guaranteed to be contiguous.
        public GeneralPlayerInput[] Inputs;

        // For each input:
        // Delta between the input world tick and the tick the server was at for that input.
        // TODO: This may be overkill, determining an average is probably better, but for now
        // this will give us 100% accuracy over lag compensation.
        public short[] ClientWorldTickDeltas;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(this.StartWorldTick);

            if (this.Inputs != null)
            {
                writer.Put(this.Inputs.Length);

                for (int i = 0; i < this.Inputs.Length; i++)
                {
                    writer.Put(this.Inputs[i].GetKeyBitfield());
                    writer.Put(this.Inputs[i].ViewDirection);
                    writer.Put(this.ClientWorldTickDeltas[i]);
                }
            }
            else
            {
                writer.Put(0);
            }
        }

        public void Deserialize(NetDataReader reader)
        {
            this.StartWorldTick = reader.GetUInt();
            var length = reader.GetInt();

            this.Inputs = new GeneralPlayerInput[length];
            this.ClientWorldTickDeltas = new short[length];

            for (int i = 0; i < length; i++)
            {
                this.Inputs[i].ApplyKeyBitfield(reader.GetByte());
                this.Inputs[i].ViewDirection = reader.GetQuaternion();
                this.ClientWorldTickDeltas[i] = reader.GetShort();
            }
        }
    }
}