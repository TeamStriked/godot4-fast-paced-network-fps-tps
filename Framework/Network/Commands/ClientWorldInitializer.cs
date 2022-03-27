
using LiteNetLib.Utils;
using System.Collections.Generic;

namespace Framework.Network.Commands
{
    public struct ClientWorldInitializer : INetSerializable
    {
        public string WorldName { get; set; }
        public uint WorldTick { get; set; }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(this.WorldName);
            writer.Put(this.WorldTick);
        }

        public void Deserialize(NetDataReader reader)
        {
            this.WorldName = reader.GetString();
            this.WorldTick = reader.GetUInt();
        }
    }
}