using System;
using System.Collections.Generic;
using ProtoBuf;

namespace GTAServer
{
    public enum PacketType
    {
        VehiclePositionData = 0,
        ChatData = 1,
        PlayerDisconnect = 2,
        PedPositionData = 3,
        NpcVehPositionData = 4,
        NpcPedPositionData = 5,
        WorldSharingStop = 6,
        DiscoveryResponse = 7,
        ConnectionRequest = 8,
        NativeCall = 9,
        NativeResponse = 10,
        PlayerKilled = 11,
        NativeTick = 12,
        NativeTickRecall = 13,
        NativeOnDisconnect = 14,
        NativeOnDisconnectRecall = 15,
    }

    public enum ScriptVersion
    {
        Unknown = 0,
        VERSION_0_6 = 1,
        VERSION_0_6_1 = 2,
        VERSION_0_7 = 3,
        VERSION_0_8_1 = 4,
        VERSION_0_9 = 5,
    }

    [ProtoContract]
    public class DiscoveryResponse
    {
        [ProtoMember(1)]
        public string ServerName { get; set; }
        [ProtoMember(2)]
        public int MaxPlayers { get; set; }
        [ProtoMember(3)]
        public int PlayerCount { get; set; }
        [ProtoMember(4)]
        public bool PasswordProtected { get; set; }
        [ProtoMember(5)]
        public int Port { get; set; }
        [ProtoMember(6)]
        public string Gamemode { get; set; }
    }

    [ProtoContract]
    public class ConnectionRequest
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(3)]
        public string DisplayName { get; set; }

        [ProtoMember(4)]
        public int GameVersion { get; set; }

        [ProtoMember(5)]
        public byte ScriptVersion { get; set; }
    }

    [ProtoContract]
    public class PlayerDisconnect
    {
        [ProtoMember(1)]
        public long Id { get; set; }
    }

    [Flags]
    public enum VehicleDataFlags
    {
        IsPressingHorn = 1 << 0,
        IsSirenActive = 1 << 1,
    }

    [ProtoContract]
    public class VehicleData
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int VehicleModelHash { get; set; }
        [ProtoMember(4)]
        public int PedModelHash { get; set; }
        [ProtoMember(5)]
        public int PrimaryColor { get; set; }
        [ProtoMember(6)]
        public int SecondaryColor { get; set; }
        [ProtoMember(7)]
        public Vector3 Position { get; set; }
        [ProtoMember(8)]
        public Vector3 Quaternion { get; set; }
        [ProtoMember(9)]
        public int VehicleSeat { get; set; }
        [ProtoMember(10)]
        public int VehicleHealth { get; set; }
        [ProtoMember(11)]
        public int PlayerHealth { get; set; }
        [ProtoMember(12)]
        public float Latency { get; set; }
        [ProtoMember(13)]
        public Dictionary<int, int> VehicleMods { get; set; }
        [ProtoMember(14)]
        public float Speed { get; set; }
        [ProtoMember(15)]
        public bool IsEngineRunning { get; set; }
        [ProtoMember(16)]
        public float WheelSpeed { get; set; }
        [ProtoMember(17)]
        public float Steering { get; set; }
        [ProtoMember(18)]
        public int RadioStation { get; set; }
        [ProtoMember(19)]
        public string Plate { get; set; }
        [ProtoMember(20)]
        public Vector3 Velocity { get; set; }
        [ProtoMember(21)]
        public Dictionary<int, int> PedProps { get; set; }
    }



    [Flags]
    public enum PedDataFlags
    {
        IsJumping = 1 << 0,
        IsShooting = 1 << 1,
        IsAiming = 1 << 2,
        IsParachuteOpen = 1 << 3
    }

    [ProtoContract]
    public class PedData
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int PedModelHash { get; set; }
        [ProtoMember(4)]
        public Vector3 Position { get; set; }
        [ProtoMember(5)]
        public Vector3 Quaternion { get; set; }
        [ProtoMember(6)]
        public Vector3 AimCoords { get; set; }
        [ProtoMember(7)]
        public int WeaponHash { get; set; }
        [ProtoMember(8)]
        public int PlayerHealth { get; set; }
        [ProtoMember(9)]
        public float Latency { get; set; }
        [ProtoMember(10)]
        public Dictionary<int, int> PedProps { get; set; }
        [ProtoMember(11)]
        public byte? Flag { get; set; }

    }



    [ProtoContract]
    public class Vector3
    {
        public Vector3()
        {
            X = 0f;
            Y = 0f;
            Z = 0f;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        [ProtoMember(1)]
        public float X { get; set; }
        [ProtoMember(2)]
        public float Y { get; set; }
        [ProtoMember(3)]
        public float Z { get; set; }
    }

    [ProtoContract]
    public class Quaternion
    {
        [ProtoMember(1)]
        public float X { get; set; }
        [ProtoMember(2)]
        public float Y { get; set; }
        [ProtoMember(3)]
        public float Z { get; set; }
        [ProtoMember(4)]
        public float W { get; set; }
    }
}