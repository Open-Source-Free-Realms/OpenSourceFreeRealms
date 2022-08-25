namespace FreeRealms
{
    public static class ClientServerCoreBasePackets
    {
    }
    public static class BasePackets
    {
        public const ushort PacketClientFinishedLoading = 10;
        public const ushort PacketSendSelfToClient = 12;
        public const ushort PacketClientIsReady = 13;
        public const ushort PacketZoneDoneSendingInitialData = 14;
        public const ushort PacketClientLogout = 16;
        public const ushort PacketClientBeginZoning = 31;
        public const ushort BasePlayerUpdatePacket = 35;
        public const ushort BaseClientUpdatePacket = 38;
        public const ushort BaseEncounterPacket = 41;
        public const ushort PacketSendZoneDetails = 43;
        public const ushort PacketClientServerShuttingDown = 73;
        public const ushort PacketLoadWelcomeScreen = 93;
        public const ushort PacketClientGameSettings = 144;
        public const ushort ActivityManagerBasePacket = 147;
        public const ushort BaseAchievementPacket = 150;
        public const ushort PacketInitializationParameters = 166;
        public const ushort MountBasePacket = 168;
        public const ushort AnnouncementBasePacket = 193;
        public const ushort WallOfDataBasePacket = 194;
        public const ushort PacketClientSettings = 195;

        public static class AnnouncementBasePackets
        {
            public const ushort AnnouncementDataRequestPacket = 1;
            public const ushort AnnouncementDataSendPacket = 2;
            public const ushort AnnouncementAdminSendAll = 3;
            public const ushort MemberPanelDataSendPacket = 4;
        }

        public static class MountBasePackets
        {
            public const ushort PacketMountRequest = 1;
            public const ushort PacketMountResponse = 2;
            public const ushort PacketDismountRequest = 3;
            public const ushort PacketDismountResponse = 4;
            public const ushort PacketMountList = 5;
            public const ushort PacketMountSpawn = 6;
            public const ushort PacketMountSpawnByItemDefinitionID = 8;
            public const ushort PacketSetAutomount = 9;
        }

        public static class BasePlayerUpdatePackets
        {
            public const ushort PlayerUpdatePacketAddPc = 1;
            public const ushort PlayerUpdatePacketItemDefinitions = 37;
        }


        public static class BaseEncounterPackets
        {
            public const ushort EncounterOverworldCombatPacket = 132;
        }


        public static class BaseAchievementPackets
        {
            public const ushort AchievementObjectiveActivatedPacket = 6;
        }

        public static class BaseClientUpdatePackets
        {
            public const ushort ClientUpdatePacketHitpoints = 1;
            public const ushort ClientUpdatePacketItemAdd = 2;
            public const ushort ClientUpdatePacketItemUpdate = 3;
            public const ushort ClientUpdatePacketItemDelete = 4;
            public const ushort ClientUpdatePacketEquipItem = 5;
            public const ushort ClientUpdatePacketUnequipSlot = 6;
            public const ushort ClientUpdatePacketUpdateStat = 7;
            public const ushort ClientUpdatePacketCollectionStart = 8;
            public const ushort ClientUpdatePacketCollectionRemove = 9;
            public const ushort ClientUpdatePacketCollectionAddEntry = 10;
            public const ushort ClientUpdatePacketCollectionRemoveEntry = 11;
            public const ushort ClientUpdatePacketUpdateLocation = 12;
            public const ushort ClientUpdatePacketMana = 13;
            public const ushort ClientUpdatePacketUpdateProfileExperience = 14;
            public const ushort ClientUpdatePacketAddProfileAbilitySetApl = 15;
            public const ushort ClientUpdatePacketAddEffectTag = 16;
            public const ushort ClientUpdatePacketRemoveEffectTag = 17;
            public const ushort ClientUpdatePacketUpdateProfileRank = 18;
            public const ushort ClientUpdatePacketCoinCount = 19;
            public const ushort ClientUpdatePacketDeleteProfile = 20;
            public const ushort ClientUpdatePacketActivateProfile = 21;
            public const ushort ClientUpdatePacketAddAbility = 22;
            public const ushort ClientUpdatePacketNotifyPlayer = 23;
            public const ushort ClientUpdatePacketUpdateProfileAbilitySetApl = 24;
            public const ushort ClientUpdatePacketUpdateActionBarSlot = 25;
            public const ushort ClientUpdatePacketDoneSendingPreloadCharacters = 26;
            public const ushort ClientUpdatePacketSetGrandfatheredStatus = 27;
            public const ushort ClientUpdatePacketImmediateActivationFailed = 29;
            public const ushort ClientUpdatePacketImmediateActivationCheck = 30;
            public const ushort ClientUpdatePacketStorage = 31;
        }

        public static class PlayerUpdatePacketUpdatePositions
        {
            public const ushort PlayerUpdatePacketUpdatePositionOnPlatform = 185;
        }

        public static class ReferenceDataPackets
        {
            public const ushort ReferenceDataPacketItemClassDefinitions = 1;
            public const ushort ReferenceDataPacketItemCategoryDefinitions = 2;
            public const ushort ReferenceDataPacketClientProfileData = 3;
        }

        public static class RewardBasePackets
        {
            public const ushort RewardBundlePacket = 1;
            public const ushort RewardNonBundledItem = 2;
            public const ushort RewardPacketNonMemberRewardDeferred = 6;
            public const ushort RewardPacketNonMemberRewardGranted = 7;
        }

        public static class WallOfDataBasePackets
        {
            public const ushort WallOfDataPlayerKeyboardPacket = 2;
            public const ushort WallOfDataPlayerClickMovePacket = 3;
            public const ushort WallOfDataUIEventPacket = 4;
            public const ushort WallOfDataMembershipPurchasePacket = 5;
            public const ushort WallOfDataWalletBalancePacket = 6;
        }
    }


    public static class ClientGatewayBasePackets
    {
        public const ushort PacketLogin = 1;
        public const ushort PacketLoginReply = 2;
        public const ushort PacketLogout = 3;
        public const ushort PacketServerForcedLogout = 4;
        public const ushort PacketTunneledClientPacket = 5;
        public const ushort PacketTunneledClientWorldPacket = 6;
        public const ushort PacketClientIsHosted = 7;
        public const ushort PacketOnlineStatusRequest = 8;
        public const ushort PacketOnlineStatusReply = 9;
        public const ushort PacketTunneledClientGatewayPacket = 10;
    }


    public static class RemoteAssetDeliveryBasePackets
    {
        public const ushort AssetRequestPacket = 1;
        public const ushort ManifestRequestPacket = 2;
        public const ushort ManifestCrcRequestPacket = 3;
        public const ushort AssetDataPacket = 4;
        public const ushort AssetErrorPacket = 5;
        public const ushort ManifestDataPacket = 6;
        public const ushort ManifestCrcDataPacket = 7;
    }
}