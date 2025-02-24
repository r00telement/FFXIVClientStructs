﻿using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent {
    [StructLayout(LayoutKind.Explicit, Size = 0xA90)]
    public unsafe struct AgentLobby {

        public static AgentLobby* Instance() => (AgentLobby*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.Lobby);

        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x820)] public byte DataCenter;
        [FieldOffset(0x840)] public uint IdleTime;
    }
}
