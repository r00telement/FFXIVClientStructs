using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge {
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct JobGauge {
        // empty base class for other gauges, this only has the vtable
    }

    #region Healer

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct WhiteMageGauge {
        [FieldOffset(0x0A)] public short LilyTimer;
        [FieldOffset(0x0C)] public byte Lily;
        [FieldOffset(0x0D)] public byte BloodLily;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ScholarGauge {
        [FieldOffset(0x0A)] public byte Aetherflow;
        [FieldOffset(0x0B)] public byte FairyGauge;
        [FieldOffset(0x0C)] public short SeraphTimer;
        [FieldOffset(0x0E)] public byte DismissedFairy;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct AstrologianGauge {
        [FieldOffset(0x08)] public short Timer;
        [FieldOffset(0x0C)] public byte Card;
        [FieldOffset(0x0D)] public fixed byte Seals[3];

        public AstrologianCard CurrentCard => (AstrologianCard)Card;
        public AstrologianSeal[] CurrentSeals => new[] {(AstrologianSeal)Seals[0], (AstrologianSeal)Seals[1], (AstrologianSeal)Seals[2]};
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SageGauge {
        [FieldOffset(0x08)] public short AddersgallTimer;
        [FieldOffset(0x0A)] public byte Addersgall;
        [FieldOffset(0x0B)] public byte Addersting;
        [FieldOffset(0x0C)] public byte Eukrasia;

        public bool EukrasiaActive => this.Eukrasia > 0;
    }

    #endregion

    #region MagicDPS

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct BlackMageGauge {
        [FieldOffset(0x08)] public short EnochianTimer;
        [FieldOffset(0x0A)] public short ElementTimeRemaining;
        [FieldOffset(0x0C)] public sbyte ElementStance;
        [FieldOffset(0x0D)] public byte UmbralHearts;
        [FieldOffset(0x0E)] public byte PolyglotStacks;
        [FieldOffset(0x0F)] public byte Enochian;

        public int UmbralStacks => ElementStance >= 0 ? 0 : ElementStance * -1;
        public int AstralStacks => ElementStance <= 0 ? 0 : ElementStance;
        public bool EnochianActive => Enochian != 0;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SummonerGauge {
        [FieldOffset(0x08)] public short TimerRemaining;
        [FieldOffset(0x0A)] public byte ReturnSummon;
        [FieldOffset(0x0B)] public byte ReturnSummonGlam;
        [FieldOffset(0x0C)] public byte AetherFlags;

        public AetherFlags Flags => (AetherFlags)AetherFlags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct RedMageGauge {
        [FieldOffset(0x08)] public byte WhiteMana;
        [FieldOffset(0x09)] public byte BlackMana;
        [FieldOffset(0x0A)] public byte ManaStacks;
    }

    #endregion

    #region RangeDPS

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct BardGauge {
        [FieldOffset(0x08)] public short SongTimer;
        [FieldOffset(0x0C)] public byte Repertoire;
        [FieldOffset(0x0D)] public byte SoulVoice;
        [FieldOffset(0x0E)] public byte Song;

        public BardSong ActiveSong => Song % 5 == 0 ? (BardSong)Song : BardSong.None;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct MachinistGauge {
        [FieldOffset(0x08)] public short OverheatTimeRemaining;
        [FieldOffset(0x0A)] public short SummonTimeRemaining;
        [FieldOffset(0x0C)] public byte Heat;
        [FieldOffset(0x0D)] public byte Battery;
        [FieldOffset(0x0E)] public byte LastSummonBatteryPower;
        [FieldOffset(0x0F)] public byte TimerActive;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct DancerGauge {
        [FieldOffset(0x08)] public byte Feathers;
        [FieldOffset(0x09)] public byte Esprit;
        [FieldOffset(0x0A)] public fixed byte DanceSteps[4];
        [FieldOffset(0x0E)] public byte StepIndex;

        public DanceStep CurrentStep => (DanceStep)(StepIndex >= 4 ? 0 : DanceSteps[StepIndex]);
    }

    #endregion

    #region MeleeDPS

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct MonkGauge {
        [FieldOffset(0x08)] public byte Chakra;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct DragoonGauge {
        [FieldOffset(0x08)] public short BotdTimer;
        [FieldOffset(0x0A)] public byte BotdState;
        [FieldOffset(0x0B)] public byte EyeCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct NinjaGauge {
        [FieldOffset(0x08)] public int HutonTimer;
        [FieldOffset(0x0C)] public byte Ninki;
        [FieldOffset(0x0D)] public byte HutonManualCasts;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SamuraiGauge {
        [FieldOffset(0x0B)] public byte Kenki;
        [FieldOffset(0x0C)] public byte MeditationStacks;
        [FieldOffset(0x0D)] public byte SenFlags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ReaperGauge {
        [FieldOffset(0x08)] public byte Soul;
    }

    #endregion

    #region Tanks

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct DarkKnightGauge {
        [FieldOffset(0x08)] public byte Blood;
        [FieldOffset(0x0A)] public ushort DarksideTimer;
        [FieldOffset(0x0C)] public byte DarkArtsState;
        [FieldOffset(0x0E)] public ushort ShadowTimer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct PaladinGauge {
        [FieldOffset(0x08)] public byte OathGauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct WarriorGauge {
        [FieldOffset(0x08)] public byte BeastGauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct GunbreakerGauge {
        [FieldOffset(0x08)] public byte Ammo;
        [FieldOffset(0x0A)] public short MaxTimerDuration;
        [FieldOffset(0x0C)] public byte AmmoComboStep;
    }

    #endregion
}
