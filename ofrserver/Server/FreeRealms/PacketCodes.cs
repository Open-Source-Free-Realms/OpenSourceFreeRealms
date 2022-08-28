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
        public const ushort BaseChatPacket = 15;
        public const ushort PacketClientLogout = 16;
        public const ushort PacketTargetClientNotOnline = 22;
        public const ushort BaseCommandPacket = 26;
        public const ushort PacketClientBeginZoning = 31;
        public const ushort BaseCombatPacket = 32;
        public const ushort BaseVehicleRacePacket = 33;
        public const ushort BaseCehicleDemolitionDerbyPacket = 34;
        public const ushort BasePlayerUpdatePacket = 35;
        public const ushort BaseAbilityPacket = 36;
        public const ushort BaseClientUpdatePacket = 38;
        public const ushort BaseMiniGamePacket = 39;
        public const ushort BaseGroupPacket = 40;
        public const ushort BaseEncounterPacket = 41;
        public const ushort BaseInventoryPacket = 42;
        public const ushort PacketSendZoneDetails = 43;
        public const ushort ReferenceDataPacket = 44;
        public const ushort BaseObjectivePacket = 45;
        public const ushort BaseUiPacket = 47;
        public const ushort BaseQuestPacket = 49;
        public const ushort RewardBasePacket = 50;
        public const ushort PacketGameTimeSync = 52;
        public const ushort PetBasePacket = 53;
        public const ushort PacketPointOfInterestDefinitionRequest = 56;
        public const ushort PacketPointOfInterestDefinitionReply = 57;
        public const ushort PacketWorldTeleportRequest = 58;
        public const ushort BaseTradePacket = 59;
        public const ushort EncounterDataCommon = 62;
        public const ushort BaseRecipePacket = 63;
        public const ushort PacketBaseInGamePurchase = 66;
        public const ushort BaseQuickChatPacket = 67;
        public const ushort BaseReportPacket = 68;
        public const ushort BaseAcquaintancePacket = 72;
        public const ushort PacketClientServerShuttingDown = 73;
        public const ushort BaseFriendsPacket = 74;
        public const ushort BaseSoccerPacket = 76;
        public const ushort BaseBroadcastPacket = 77;
        public const ushort PacketClientKickedFromServer = 81;
        public const ushort PacketUpdateClientSessionData = 82;
        public const ushort BaseBugSubmissionPacket = 83;
        public const ushort PacketWorldDisplayInfo = 86;
        public const ushort PacketMOTD = 87;
        public const ushort PacketSetLocale = 88;
        public const ushort PacketSetClientArea = 89;
        public const ushort PacketZoneTeleportRequest = 90;
        public const ushort PacketWorldShutdownNotice = 92;
        public const ushort PacketLoadWelcomeScreen = 93;
        public const ushort BaseShipCombatPacket = 94;
        public const ushort BaseMiniGameAdminPacket = 95;
        public const ushort PacketZonePing = 96;
        public const ushort ClientPathBasePacket = 98;
        public const ushort PacketMembershipActivation = 100;
        public const ushort BaseLobbyPacket = 101;
        public const ushort BaseLobbyGameDefinitionPacket = 102;
        public const ushort PacketShowSystemMessage = 103;
        public const ushort PacketPOIChangeMessage = 104;
        public const ushort PacketClientMetrics = 105;
        public const ushort BaseFireTimeEventPacket = 107;
        public const ushort BaseClaimPacket = 108;
        public const ushort PacketClientLog = 109;
        public const ushort BaseIgnorePacket = 112;
        public const ushort BasePromotionalPacket = 114;
        public const ushort PacketAddClientPortraitCrc = 115;
        public const ushort OneTimeSessionRequestPacket = 117;
        public const ushort OneTimeSessionResponsePacket = 118;
        public const ushort PacketZoneSafeTeleportRequest = 122;
        public const ushort PlayerUpdatePacketUpdatePositon = 125;
        public const ushort PlayerUpdatePacketCameraUpdate = 126;
        public const ushort BaseHousingPacket = 127;
        public const ushort BaseGuildPacket = 129;
        public const ushort BaseBrokerPacket = 130;
        public const ushort BaseAdminGuildPacket = 131;
        public const ushort BaseAdminBrokerPacket = 132;
        public const ushort BaseBattleMagesPacket = 133;
        public const ushort BaseVehicleLoadoutPacket = 137;
        public const ushort BaseFishingPacket = 138;
        public const ushort BaseVehiclePartPacket = 139;
        //public const ushort EncounterMatchmaking::BaseMatchmakingPacket = 141;
        public const ushort PacketClientLuaMetrics = 142;
        public const ushort BaseReaptingActivityPacket = 143;
        public const ushort PacketClientGameSettings = 144;
        public const ushort PacketClientTrailProfileUpsell = 145;
        public const ushort ActivityManagerBasePacket = 147;
        public const ushort BaseInspectPacket = 149;
        public const ushort BaseAchievementPacket = 150;
        public const ushort BasePlayerTitlePacket = 152;
        public const ushort JobCustomizationBasePacket = 155;
        public const ushort BaseFotomatPacket = 156;
        public const ushort PacketUpdateUserAge = 157;
        public const ushort PlayerUpdatePacketJump = 164;
        public const ushort BaseCoinStorePacket = 165;
        public const ushort PacketInitializationParameters = 166;
        public const ushort BaseActivityServicePacket = 167;
        public const ushort MountBasePacket = 168;
        public const ushort PacketClientInitializationDetails = 169;
        public const ushort PacketClientNotifyCoinSpinAvailable = 171;
        public const ushort PacketClientAreaTimer = 172;
        public const ushort BaseLoyaltyRewardPacket = 173;
        public const ushort BaseRatingPacket = 174;
        public const ushort ClientActivityLaunchBasePacket = 175;
        public const ushort PacketClientFlashTimer = 177;
        public const ushort PacketInviteAndStartMiniGamepacket = 180;
        public const ushort PlayerUpdatePacketFlourish = 181;
        public const ushort PacketClientMembershipVipInfo = 186;
        public const ushort BaseFactoryPacket = 188;
        public const ushort PacketMembershipSubscriptionInfo = 189;
        public const ushort PacketCleintCaisNotification = 190;
        //public const ushort NameChange::BaseNameChangePacket = 192;
        public const ushort AnnouncementBasePacket = 193;
        public const ushort WallOfDataBasePacket = 194;
        public const ushort PacketClientSettings = 195;
        public const ushort PacketClientSubstringBlacklist = 196;
        public const ushort BaseSnsIntegrationPacket = 197;
        public const ushort PacketClientTrailPetUpsell = 199;
        public const ushort PacketClientTrailMountUpsell = 201;
        public const ushort MysteryChestBasePacket = 202;
        public const ushort NudgeBasePacket = 203;
        public const ushort PacketEnterSocialZoneRequest = 204;
        public const ushort BaseSocialSharePacket = 205;
        public const ushort BaseProgressiveQuestPacket = 207;
        public const ushort PacketUpdateClientAreaCompositeEffect = 208;
        public const ushort BaseAdventurersJournalPacket = 209;
        public const ushort PacketCheckNameRequest = 210;
        public const ushort PacketCheckNameReply = 211;

        public static class ActivityManagerBasePackets
        {
            public const ushort ActivityJoinErrorPacket = 2;
            public const ushort ActivityProfileListPacket = 3;
        }

        public static class AnnouncementBasePackets
        {
            public const ushort AnnouncementDataRequestPacket = 1;
            public const byte AnnouncementDataSendPacket = 2;
            public const ushort AnnouncementAdminSendAll = 3;
            public const ushort MemberPanelDataSendPacket = 4;
        }

        public static class BaseAbilityPackets
        {
            public const ushort AbilityPacketAbilityDefinition = 13;
            public const ushort AbilityPacketCastInterrupt = 18;
            public const ushort AbilityPacketClientMoveAndCast = 6;
            public const ushort AbilityPacketClientRequestStartAbility = 10;
            public const ushort AbilityPacketDetonateProjectile = 14;
            public const ushort AbilityPacketExecuteClientLua = 17;
            public const ushort AbilityPacketFailed = 1;
            public const ushort AbilityPacketLaunchAndLand = 4;
            public const ushort AbilityPacketMeleeRefresh = 11;
            public const ushort AbilityPacketPulseLocationTargeting = 15;
            public const ushort AbilityPacketPurchaseAbility = 7;
            public const ushort AbilityPacketReceivePulseLocation = 16;
            public const ushort AbilityPacketRequestAbilityDefinition = 12;
            public const ushort AbilityPacketSetDefinition = 5;
            public const ushort AbilityPacketStartCasting = 3;
            public const ushort AbilityPacketStopAura = 9;
            public const ushort AbilityPacketUpdateAbilityExperience = 8;
        }
        public static class BaseAchievementPackets
        {
            public const ushort AchievementAddPacket = 2;
            public const ushort AchievementCompletePacket = 3;
            public const ushort AchievementInitializePacket = 4;
            public const ushort AchievementObjectiveActivatedPacket = 6;
            public const ushort AchievementObjectiveAddedPacket = 5;
            public const ushort AchievementObjectiveCompletePacket = 8;
            public const ushort AchievementObjectiveUpdatePacket = 7;
        }

        public static class BaseAcquaintancePackets
        {
            public const ushort AcquaintanceOnlinePacket = 3;
            public const ushort AddAcquaintancePacket = 1;
            public const ushort RemoveAcquaintancePacket = 2;
        }

        public static class BaseActivityServicePackets
        {
            public const ushort BaseActivityPacket = 1;
            public static class BaseActivityPackets
            {
                public const ushort ActivityPacketActivityListRefreshRequest = 4;
                public const ushort ActivityPacketJoinActivityRequest = 2;
                public const ushort ActivityPacketListOfActivities = 1;
                public const ushort ActivityPacketUpdateActivityFeaturedStatus = 5;
                public const ushort ScheduledActivityPacketListOfActivities = 1;
            }

            public const ushort BaseScheduledActivityPacket = 2;
        }

        public static class BaseAdminBrokerPackets
        {
            public const ushort AdminBrokerServerVersionPacket = 17;
        }

        public static class BaseAdminGuildPackets
        {
            public const ushort AdminGuildServerVersionPacket = 41;
        }

        public static class BaseAdventurersJournalPackets
        {
            public const ushort AdventurersJournalInfoPacket = 1;
            public const ushort AdventurersJournalQuestUpdatePacket = 2;
        }

        public static class BaseBattleMagesPackets
        {
            public const ushort BattleMagesPacketCameraConfig = 8;
            public const ushort BattleMagesPacketCommand = 1;
            public const ushort BattleMagesPacketCreateProxiedPlayer = 4;
            public const ushort BattleMagesPacketCreateProxiedProjectile = 11;
            public const ushort BattleMagesPacketDestroyProxiedProjectile = 12;
            public const ushort BattleMagesPacketKickProxiedPlayer = 5;
            public const ushort BattleMagesPacketRegisterPlayer = 3;
            public const ushort BattleMagesPacketRequestAttack = 9;
            public const ushort BattleMagesPacketUpdateData = 2;
            public const ushort BattleMagesPacketUpdateGameState = 6;
            public const ushort BattleMagesPacketUpdatePlayerState = 7;
            public const ushort BattleMagesPacketUpdateProxiedProjectile = 13;
        }

        public static class BaseBroadcastPackets
        {
            public const ushort BroadcastPacketWorld = 3;
        }

        public static class BaseBrokerPackets
        {
            public const ushort BrokerBuyItemPacket = 5;
            public const ushort BrokerCancelItemPacket = 6;
            public const ushort BrokerErrorPacket = 16;
            public const ushort BrokerInformationPacket = 12;
            public const ushort BrokerMyItemAddedPacket = 9;
            public const ushort BrokerMyItemsPacket = 8;
            public const ushort BrokerPlaceItemPacket = 3;
            public const ushort BrokerReListItemPacket = 4;
            public const ushort BrokerRemoveItemFromListsPacket = 11;
            public const ushort BrokerRequestItemSaleCoinPacket = 7;
            public const ushort BrokerSearchItemsPacket = 10;
            public const ushort BrokerSearchPacket = 2;
        }

        public static class BaseBugSubmissionPackets
        {
            public const ushort BugSubmissionpacketAddBug = 1;
        }

        public static class BaseChatPackets
        {
            public const ushort ChatPacketDebugChat = 3;
            public const ushort ChatPacketEnterArea = 2;
            public const ushort ChatPacketFromStringId = 4;
            public const ushort PacketChat = 1;
            public const ushort TellEchoPacket = 5;
        }

        public static class BaseClaimPackets
        {
            public const ushort Unknown = 5;
            public const ushort ClaimItemsItemDefinitionsResponse = 6;
            public const ushort ClaimItemsRequestPacket = 3;
            public const ushort ClaimItemsResponsePacket = 4;
            public const ushort GetAllAvailableClaimItemsRequestPacket = 1;
            public const ushort GetAllAvailableClaimItemsResponsePacket = 2;
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

        public static class BaseCoinStorePackets
        {
            public const ushort CoinStoreBuyBackRequestPacket = 15;
            public const ushort CoinStoreBuyBackResponsePacket = 13;
            public const ushort CoinStoreBuyFromClientRequestPacket = 5;
            public const ushort CoinStoreClearTransactionHistoryPacket = 11;
            public const ushort CoinStoreGiftTransactionCompletePacket = 18;
            public const ushort CoinStoreItemDefinitionsRequestPacket = 2;
            public const ushort CoinStoreItemDefinitionsResponsePacket = 3;
            public const ushort CoinStoreItemDynamicListUpdateRequestPacket = 8;
            public const ushort CoinStoreItemDynamicListUpdateResponsePacket = 9;
            public const ushort CoinStoreItemListPacket = 1;
            public const ushort CoinStoreMerchantListPacket = 10;
            public const ushort CoinStoreOpenPacket = 7;
            public const ushort CoinStoreReceiveGiftItemPacket = 17;
            public const ushort CoinStoreSellToClientAndGiftRequestPacket = 14;
            public const ushort CoinStoreSellToClientRequestPacket = 4;
            public const ushort CoinStoreTransactionCompletePacket = 6;
        }

        public static class BaseCombatPackets
        {
            public const ushort CombatPacketAttackAttackerMissed = 5;
            public const ushort CombatPacketAttackProcessed = 7;
            public const ushort CombatPacketAttackTargetDamage = 4;
            public const ushort CombatPacketAttackTargetDodged = 6;
            public const ushort CombatPacketAutoAttackTarget = 1;
            public const ushort CombatPacketEnableBossDisplay = 9;
            public const ushort CombatPacketSingleAttackTarget = 3;
        }

        public static class BaseCommandPackets
        {
            public const ushort AdminCommandPacketShipCombatCommand = 1169;
            public const ushort ClearInteractionMerchantSetId = 43;
            public const ushort CommandPacketActivateProfileFailed = 26;
            public const ushort CommandPacketAddFriendRequest = 14;
            public const ushort CommandPacketChatChannelOff = 33;
            public const ushort CommandPacketChatChannelOn = 32;
            public const ushort CommandPacketClosedMinigameEndScreen = 42;
            public const ushort CommandPacketConfirmFriendRequest = 16;
            public const ushort CommandPacketConfirmFriendResponse = 17;
            public const ushort CommandPacketDirectInspect = 45;
            public const ushort CommandPacketEndDialog = 4;
            public const ushort CommandPacketFriendsPositionRequest = 21;
            public const ushort CommandPacketIgnoreRequest = 30;
            public const ushort CommandPacketInteractionList = 9;
            public const ushort CommandPacketInteractionSelect = 10;
            public const ushort CommandPacketInteractionStartWheel = 11;
            public const ushort CommandPacketInteractRequest = 8;
            public const ushort CommandPacketMoveAndInteract = 22;
            public const ushort CommandPacketPlayDialogEffect = 28;
            public const ushort CommandPacketPlaySoundAtLocation = 7;
            public const ushort CommandPacketPlaySoundIdOnTarget = 39;
            public const ushort CommandPacketQuestAbandon = 23;
            public const ushort CommandPacketRecipeStart = 24;
            public const ushort CommandPacketRemoveFriendRequest = 15;
            public const ushort CommandPacketRequestPlayerPositions = 34;
            public const ushort CommandPacketRequestPlayerPositionsReply = 35;
            public const ushort CommandPacketRequestPlayIntroEncounter = 40;
            public const ushort CommandPacketRequestRewardPreviewUpdate = 37;
            public const ushort CommandPacketRequestRewardPreviewUpdateReply = 38;
            public const ushort CommandPacketRequestStorageCheck = 44;
            public const ushort CommandPacketSelectPlayer = 19;
            public const ushort CommandPacketSetActiveVehicleGuid = 31;
            public const ushort CommandPacketSetChatBubbleColor = 18;
            public const ushort CommandPacketSetProfile = 13;
            public const ushort CommandPacketSetProfileByItemDefinitionId = 36;
            public const ushort CommandPacketShowDialog = 3;
            public const ushort CommandPacketShowRecipeWindow = 25;
            public const ushort CommandPacketStartFlashGame = 12;
            public const ushort CommandPacketWhoReply = 2;
            public const ushort FreeInteractionNpc = 20;
            public const ushort PacketDialogResponse = 6;
        }

        public static class BaseEncounterPackets
        {
            public const ushort EncounterDetailsResponsePacket = 114;
            public const ushort EncounterDuelInvitationPacket = 104;
            public const ushort EncounterDuelInvitationResponsePacket = 105;
            public const ushort EncounterInvitationPacket = 102;
            public const ushort EncounterInvitationResponsePacket = 103;
            public const ushort EncounterOverworldCombatPacket = 132;
            public const ushort EncounterPacketEncounterComplete = 3;
            public const ushort EncounterPacketEncounterLaunchFailed = 4;
            public const ushort EncounterPacketEncounterShutdown = 6;
            public const ushort EncounterPacketIsFighting = 133;
            public const ushort EncounterPacketObjectiveState = 5;
            public const ushort EncounterPacketPlayerEnter = 2;
            public const ushort EncounterParticipantCancelPendingEncounterPacket = 124;
            public const ushort EncounterParticipantMessagePacket = 120;
            public const ushort EncounterParticipantRequestEntrancePacket = 108;
            public const ushort EncounterParticipantRequestExitPacket = 109;
            public const ushort EncounterParticipantResumePacket = 122;
            public const ushort EncounterParticipantTerminateEncounterPacket = 121;
            public const ushort EncounterRunningListRequestPacket = 129;
            public const ushort EncounterRunningListResponsePacket = 130;
            public const ushort EncounterShowRespawnWindowPacket = 125;
            public const ushort EncounterStatePacket = 106;
            public const ushort EncounterZoneIsReadyPacket = 107;
        }

        public static class BaseFactoryPackets
        {
            public const ushort FactoryPacketAddBlueprintToFoundationFailure = 20;
            public const ushort FactoryPacketCreateBlueprintRequest = 8;
            public const ushort FactoryPacketCreateBlueprintResponse = 25;
            public const ushort FactoryPacketDoUpsell = 30;
            public const ushort FactoryPacketEquipToolRequest = 7;
            public const ushort FactoryPacketEquipToolResponse = 23;
            public const ushort FactoryPacketListToolsRequest = 6;
            public const ushort FactoryPacketListToolsResponse = 22;
            public const ushort FactoryPacketNpcTooltipReply = 21;
            public const ushort FactoryPacketNpcTooltipRequest = 5;
            public const ushort FactoryPacketOpenBlueprintBrowserOnFoundation = 24;
            public const ushort FactoryPacketOpenBlueprintGenerator = 27;
            public const ushort FactoryPacketOpenToolshed = 26;
            public const ushort FactoryPacketRequestAddBlueprintToFoundation = 2;
            public const ushort FactoryPacketRequestRecipeReward = 14;
            public const ushort FactoryPacketUpdateBlueprint = 17;
            public const ushort FactoryPacketUpdateExperience = 29;
            public const ushort FactoryPacketUpdateFactoryInfo = 1;
            public const ushort FactoryPacketUpdateFoundation = 16;
            public const ushort FactoryPacketUpdatePlot = 28;
        }

        public static class BaseFirstTimeEventPackets
        {
            public const ushort FirstTimeEventTriggerRequest = 1;
            public const ushort FirstTimeEventStatePacket = 2;
            public const ushort FirstTimeEventClearRequest = 3;
            public const ushort FirstTimeEventEnablePacket = 4;
            public const ushort FirstTimeEventScriptPacket = 5;
        }

        public static class BaseFishingPackets
        {
            public const ushort FishingPacketCastAnimRequest = 5;
            public const ushort FishingPacketCastRequest = 6;
            public const ushort FishingPacketDespawnProxiedFishingSchool = 12;
            public const ushort FishingPacketFishInfoUpdate = 4;
            public const ushort FishingPacketFishingResult = 14;
            public const ushort FishingPacketReelInRequest = 7;
            public const ushort FishingPacketRegisterPlayerRequest = 2;
            public const ushort FishingPacketRegisterPlayerResponse = 3;
            public const ushort FishingPacketSpawnFishRun = 18;
            public const ushort FishingPacketSpawnProxiedFishingBobber = 8;
            public const ushort FishingPacketSpawnProxiedFishingSchool = 11;
            public const ushort FishingPacketSpecialRequest = 15;
            public const ushort FishingPacketSpecialRespons = 16;
            public const ushort FishingPacketUpdateData = 1;
            public const ushort FishingPacketUpdateProxiedFishingBobber = 10;
            public const ushort FishingPacketUpdateProxiedFishingSchool = 13;
        }

        public static class BaseFormatPackets
        {
            public const ushort PacketGeneratePortraitRequest = 1;
            public const ushort PacketPlayerImageData = 3;
            public const ushort PacketPortraitDataRequest = 2;
            public const ushort PacketSnapshotRequest = 4;
        }

        public static class BaseFriendPackets
        {
            public const ushort FriendAddPacket = 6;
            public const ushort FriendListPacket = 1;
            public const ushort FriendMessagePacket = 0;
            public const ushort FriendOfflinePacket = 3;
            public const ushort FriendOnlinePacket = 2;
            public const ushort FriendRemovePacket = 7;
            public const ushort FriendRenamePacket = 10;
            public const ushort FriendStatusPacket = 9;
            public const ushort FriendUpdatePositionsPacket = 5;
        }

        public static class BaseGroupPackets
        {
            public const ushort GroupChangingJobPacket = 14;
            public const ushort GroupChangingJobUpdatePacket = 15;
            public const ushort GroupInMinigamePacket = 17;
            public const ushort GroupMapPingPacket = 16;
            public const ushort GroupPacketAnnounceEncounterReply = 13;
            public const ushort GroupPacketGroupAccept = 4;
            public const ushort GroupPacketGroupAcceptReply = 5;
            public const ushort GroupPacketGroupInvite = 1;
            public const ushort GroupPacketGroupInviteReply = 2;
            public const ushort GroupPacketGroupKick = 6;
            public const ushort GroupPacketGroupKickReply = 7;
            public const ushort GroupPacketGroupLeave = 3;
            public const ushort GroupPacketGroupMemberUpdate = 9;
            public const ushort GroupPacketGroupUpdate = 8;
            public const ushort GroupPacketRenamePlayer = 11;
        }

        public static class BaseGuildPackets
        {
            public const ushort GuildCanCreateGuildPacket = 32;
            public const ushort GuildCreatePacket = 1;
            public const ushort GuildDataFullPacket = 22;
            public const ushort GuildDeleteNotificationPacket = 29;
            public const ushort GuildDeletePacket = 2;
            public const ushort GuildDemotePacket = 5;
            //public const ushort GuildErrorPacket = ?;
            //public const ushort GuildInviteAcceptNotificationPacket = ?;
            //public const ushort GuildInviteDeclineNotificationPacket = ?;
            public const ushort GuildInviteAcceptPacket = 8;
            public const ushort GuildInviteCancelPacket = 26;
            public const ushort GuildInviteDeclinePacket = 9;
            public const ushort GuildInviteNotificationPacket = 24;
            public const ushort GuildInvitePacket = 3;
            public const ushort GuildInviteTimeOutPacket = 10;
            public const ushort GuildMemberLocationRequest = 15;
            public const ushort GuildMemberLocationUpdatePacket = 25;
            public const ushort GuildMemberStatusUpdatePacket = 17;
            public const ushort GuildMotdUpdatePacket = 11;
            public const ushort GuildNameAcceptedPacket = 19;
            public const ushort GuildNameRejectedPacket = 20;
            public const ushort GuildNameRequestPacket = 14;
            public const ushort GuildNameUpdatePacket = 18;
            public const ushort GuildPaidRenameCheckReplyPacket = 30;
            public const ushort GuildPaidRenameCheckRequestPacket = 16;
            public const ushort GuildPlayerStatusUpdatePacket = 31;
            public const ushort GuildPromotePacket = 4;
            public const ushort GuildQuitPacket = 7;
            public const ushort GuildRemovePacket = 6;
            public const ushort GuildRenameGuildPacket = 13;
            public const ushort GuildRoleNameChangedPacket = 21;
        }

        public static class BaseHousingPackets
        {
            public const ushort AdminHousingServerVersionPacket = 57;
            public const ushort ClientHousingPacketApplyCustomizationToFixtureGroupAndType = 59;
            public const ushort ClientHousingPacketChangeHouseName = 9;
            public const ushort ClientHousingPacketDeclineInvite = 16;
            public const ushort ClientHousingPacketEnterRequest = 19;
            public const ushort ClientHousingPacketExplosionResetRequest = 18;
            public const ushort ClientHousingPacketInvitePlayer = 15;
            public const ushort ClientHousingPacketLeaveHouse = 10;
            public const ushort ClientHousingPacketLockHouse = 22;
            public const ushort ClientHousingPacketPayUpkeep = 7;
            public const ushort ClientHousingPacketPickupAllFixtures = 4;
            public const ushort ClientHousingPacketPickupFixture = 3;
            public const ushort ClientHousingPacketPlaceFixture = 2;
            public const ushort ClientHousingPacketPlaceFixtureRequest = 1;
            public const ushort ClientHousingPacketPreviewByItemDefinitionIdRequest = 20;
            public const ushort ClientHousingPacketRemoveCustomizationFromFixtureGroupAndType = 60;
            public const ushort ClientHousingPacketRequestGrant = 23;
            public const ushort ClientHousingPacketRequestName = 17;
            public const ushort ClientHousingPacketRequestPlayerHouses = 14;
            public const ushort ClientHousingPacketRequestVisitToNeighbor = 21;
            public const ushort ClientHousingPacketSaveFixture = 5;
            public const ushort ClientHousingPacketSetEditMode = 6;
            public const ushort ClientHousingPacketToggleFloraAllowed = 12;
            public const ushort ClientHousingPacketToggleLocked = 11;
            public const ushort ClientHousingPacketTogglePetAutospawn = 13;
            public const ushort HousingPacketDeclineNotification = 48;
            public const ushort HousingPacketExplosion = 55;
            public const ushort HousingPacketExplosionReset = 56;
            public const ushort HousingPacketFixtureAsset = 42;
            public const ushort HousingPacketFixtureItemList = 43;
            public const ushort HousingPacketFixturePlacementDenied = 53;
            public const ushort HousingPacketFixtureRemove = 41;
            public const ushort HousingPacketFixtureUpdate = 40;
            public const ushort HousingPacketHousingError = 46;
            public const ushort HousingPacketInstanceData = 28;
            public const ushort HousingPacketInstanceList = 39;
            public const ushort HousingPacketInviteNotification = 47;
            public const ushort HousingPacketNotifyHouseAdded = 49;
            public const ushort HousingPacketSetHeadSize = 50;
            public const ushort HousingPacketUpdateFixturePosition = 51;
            public const ushort HousingPacketUpdateHouseInfo = 44;
            public const ushort HousingPacketZoneData = 45;
        }

        public static class BaseignorePackets
        {
            public const ushort IgnoreAddPacket = 2;
            public const ushort IgnoreListPacket = 1;
            public const ushort IgnoreRemovePacket = 3;
        }

        public static class BaseInspectPackets
        {
            public const ushort StartInspectPacket = 1;
            public const ushort StopInspectPacket = 2;
            public const ushort WorldInspectReplyPacket = 3;
        }

        public static class BaseInventoryPackets
        {
            public const ushort InventoryPacketCheckImmediateActivationItem = 16;
            public const ushort InventoryPacketEquipByGuid = 3;
            public const ushort InventoryPacketEquipByItemRecord = 8;
            public const ushort InventoryPacketEquipItemGroup = 14;
            public const ushort InventoryPacketEquipLightsaber = 13;
            public const ushort InventoryPacketEquippedRemove = 2;
            public const ushort InventoryPacketItemActionBarAssign = 6;
            public const ushort InventoryPacketItemActionBarAssignByItemRecord = 9;
            public const ushort InventoryPacketItemRequirementRequest = 4;
            public const ushort InventoryPacketMoveItemToStorage = 17;
            public const ushort InventoryPacketPreviewStyleCard = 11;
            public const ushort InventoryPacketUseImmediateActivationItem = 15;
            public const ushort InventoryPacketUseStyleCard = 10;
            public const ushort InventoryPacketUseStyleCardByItemRecord = 12;
        }

        public static class BaseLobbyGameDefinitionPackets
        {
            public const ushort LobbyGameDefinitionPacketDefinitionsRequest = 1;
            public const ushort LobbyGameDefinitionPacketDefinitionsResponse = 2;
        }

        public static class BaseLobbyPackets
        {
            public const ushort CreateLobbyGamePacket = 5;
            public const ushort JoinLobbyGamePacket = 1;
            public const ushort LeaveLobbyGamePacket = 2;
            public const ushort LeaveLobbyPacket = 9;
            public const ushort LobbyErrorMessagePacket = 11;
            public const ushort RemoveLobbyGamePacket = 8;
            public const ushort SendLeaveLobbyToClientPacket = 7;
            public const ushort SendLobbyToClientPacket = 6;
            public const ushort ShowLobbyUiPacket = 12;
            public const ushort StartLobbyGamePacket = 3;
            public const ushort UpdateLobbyGamePacket = 4;
        }

        public static class BaseLoyaltyRewardPackets
        {
            public const ushort SetLoyaltyRewardLogoutInformation = 0;
        }

        public static class BaseMiniGameAdminPackets
        {
            public const ushort MiniGameFlashCommandAdminPacket = 63;
        }

        public static class BaseMiniGamePackets
        {
            public const ushort BaseMiniGameBossPacket = 62;
            public static class BaseMiniGameBossPackets
            {
                public const ushort MiniGameBossDeletePacket = 2;
                public const ushort MiniGameBossUpdatePacket = 1;
            }

            public const ushort MiniGameCreateGameResultPacket = 67;
            public const ushort MiniGameDataLockedPacket = 1;
            public const ushort MiniGameDataUnlockedPacket = 2;
            public const ushort MiniGameGameEndScorePacket = 47;
            public const ushort MiniGameGameOverPacket = 18;
            public const ushort MiniGameGroupInfoPacket = 50;
            public const ushort MiniGameInfoPacket = 16;
            public const ushort MiniGameKnockOutPacket = 23;
            public const ushort MiniGameLootWheelOnRotationStoppedPacket = 46;
            public const ushort MiniGameLootWheelSetItemToLandOnPacket = 45;
            public const ushort MiniGameMessagePacket = 15;
            public const ushort MiniGamePayloadPacket = 14;
            public const ushort MiniGameRewardStatusPacket = 22;
            public const ushort MiniGameStarsEarnedPacket = 21;
            public const ushort MiniGameStoreAdvertisementWorldClient = 44;
            public const ushort MiniGameUpdateGameTimeScalar = 20;
            public const ushort MiniGameUpdateRewardPacket = 68;
            public const ushort RequestTCGChallengePacket = 38;
            public const ushort TradingCardStartGamePacket = 40;
        }

        public static class BasePlayerTitlePackets
        {
            public const ushort PlayerTitleAddPacket = 1;
            public const ushort PlayerTitleRefreshRequestPacket = 5;
            public const ushort PlayerTitleRemovePacket = 2;
            public const ushort PlayerTitleRequestSelectPacket = 4;
            public const ushort PlayerTitleSNSUpdatePacket = 7;
            public const ushort PlayerTitleUpdateAllPacket = 3;
        }

        public static class BaseObjectivePackets
        {
            public const ushort ObjectiveActivatePacket = 1;
            public const ushort ObjectiveClientClearPacket = 8;
            public const ushort ObjectiveClientCompleteFailedPacket = 9;
            public const ushort ObjectiveClientCompletePacket = 7;
            public const ushort ObjectiveCompletePacket = 3;
            public const ushort ObjectiveFailPacket = 4;
            public const ushort ObjectiveFirstMovementPacket = 11;
            public const ushort ObjectiveHousingFixtureMovePacket = 12;
            public const ushort ObjectiveLookAtPacket = 6;
            public const ushort ObjectiveUIEventPacket = 10;
            public const ushort ObjectiveUnhidePacket = 5;
            public const ushort ObjectiveUpdatePacket = 2;
        }

        public static class BasePlayerUpdatePackets
        {
            public const ushort PlayerUpdatePacketAddPc = 1;
            public const ushort PlayerUpdatePacketAddNpc = 2;
            public const ushort PlayerUpdatePacketRemovePlayer = 3;
            public static class PlayerUpdatePacketRemovePlayerG
            {
                public const ushort PlayerUpdatePacketRemovePlayerGracefully = 1;
            }

            public const ushort PlayerUpdatePacketKnockback = 4;
            public const ushort PlayerUpdatePacketUpdateHitpoints = 5;
            public const ushort PlayerUpdatePacketEquipItemChange = 6;
            public const ushort PlayerUpdatePacketEquippedItemsChange = 7;
            public const ushort PlayerUpdatePacketSetAnimation = 8;
            public const ushort PlayerUpdatePacketUpdateMana = 9;
            public const ushort PlayerUpdatePacketAddNotifications = 10;
            public const ushort PlayerUpdatePacketRemoveNotifications = 11;
            public const ushort PlayerUpdatePacketNpcRelevance = 12;
            public const ushort PlayerUpdatePacketUpdateScale = 13;
            public const ushort PlayerUpdatePacketUpdateTemporaryAppearance = 14;
            public const ushort PlayerUpdatePacketRemoveTemporaryAppearance = 15;
            public const ushort PlayerUpdatePacketPlayCompositeEffect = 16;
            public const ushort PlayerUpdatePacketSetLookAt = 17;
            public const ushort PlayerUpdatePacketUpdateLivesRemaining = 18;
            public const ushort PlayerUpdatePacketRenamePlayer = 19;
            public const ushort PlayerUpdatePacketUpdateCharacterState = 20;
            public const ushort PlayerUpdatePacketUpdateWalkAnim = 21;
            public const ushort PlayerUpdatePacketQueueAnimation = 22;
            public const ushort PlayerUpdatePacketExpectedSpeed = 23;
            public const ushort PlayerUpdatePacketScriptedAnimation = 24;
            public const ushort PlayerUpdatePacketUpdateRunAnim = 25;
            public const ushort PlayerUpdatePacketUpdateIdleAnim = 26;
            public const ushort PlayerUpdatePacketThoughtBubble = 27;
            public const ushort PlayerUpdatePacketSetDisposition = 28;
            public const ushort PlayerUpdatePacketLootEvent = 29;
            public const ushort PlayerUpdatePacketHeadInflationScale = 30;
            public const ushort PlayerUpdatePacketSlotCompositeEffectOverride = 31;
            public const ushort PlayerUpdatePacketFreeze = 32;
            public const ushort PlayerUpdatePacketRequestStripEffect = 33;
            public const ushort PlayerUpdatePacketItemDefinitionRequest = 34;
            public const ushort PlayerUpdatePacketHitPointModification = 35;
            public const ushort PlayerUpdateTriggerEffectPackagePacket = 36;
            public const ushort PlayerUpdatePacketItemDefinitions = 37;
            public const ushort PlayerUpdatePacketPreferredLanguages = 38;
            public const ushort PlayerUpdatePacketCustomizationChange = 39;
            public const ushort PlayerUpdatePacketPlayerTitle = 40;
            public const ushort PlayerUpdatePacketAddEffectTagCompositeEffect = 41;
            public const ushort PlayerUpdatePacketRemoveEffectTagCompositeEffect = 42;
            public const ushort PlayerUpdatePacketEffectTagCompositeEffectsEnable = 43;
            public const ushort PlayerUpdatePacketStartRentalUpsell = 44;
            public const ushort PlayerUpdatePacketSetSpawnAnimation = 45;
            public const ushort PlayerUpdatePacketCustomizeNpc = 46;
            public const ushort PlayerUpdatePacketSetSpawnerActivationEffect = 47;
            public const ushort PlayerUpdatePacketRemoveNpcCustomization = 48;
            public const ushort PlayerUpdatePacketReplaceBaseModel = 49;
            public const ushort PlayerUpdatePacketSetCollidable = 50;
            public const ushort PlayerUpdatePacketUpdateOwner = 51;
            public const ushort PlayerUpdatePacketUpdateTintAlias = 52;
            public const ushort PlayerUpdatePacketMoveOnRail = 53;
            public const ushort PlayerUpdatePacketClearMovementRail = 54;
            public const ushort PlayerUpdatePacketMoveOnRelativeRail = 55;
            public const ushort PlayerUpdatePacketDestroyed = 56;
            public const ushort PlayerUpdatePacketUpdateShields = 57;
            public const ushort PlayerUpdatePacketHitPointAndShieldsModification = 58;
            public const ushort PlayerUpdatePacketSeekTarget = 59;
            public const ushort PlayerUpdatePacketSeekTargetUpdate = 60;
            public const ushort PlayerUpdatePacketUpdateActiveWieldType = 61;
            public const ushort PlayerUpdateLaunchProjectilePacket = 62;
            public const ushort PlayerUpdatePacketSetSynchronizedAnimations = 63;
            public const ushort HudMessagePacket = 64;
            public const ushort PlayerUpdatePacketCustomizationData = 65;
            public const ushort PlayerMemberStatusUpdatePacket = 66;
            public const ushort PlayerUpdatePacketPopup = 70;
            public const ushort PlayerUpdateProfileNameplateImageIdPacket = 71;
        }

        public static class BaseProgressiveQuestPackets
        {
            public const ushort ProgressiveQuestClientDataPacket = 1;
            public const ushort ProgressiveQuestNotifyRewardItemPacket = 7;
            public const ushort ProgressiveQuestRequestClaimPrizePacket = 4;
            public const ushort ProgressiveQuestRequestClaimSlotPacket = 3;
            public const ushort ProgressiveQuestRequestStartQuestPacket = 2;
            public const ushort ProgressiveQuestShowWindowPacket = 0;
        }

        public static class BasePromotionalPackets
        {
            public const ushort KeyCodeRedemptionNotificationPacket = 1;
            public const ushort PromotionalBundleDataPacket = 2;
        }

        public static class BaseQuestPackets
        {
            public const ushort CompletedQuestCountUpdatePacket = 12;
            public const ushort QuestAbandonedPacket = 6;
            public const ushort QuestAddPacket = 3;
            public const ushort QuestCompletePacket = 4;
            public const ushort QuestEndBlockedPacket = 16;
            public const ushort QuestEndPacket = 13;
            public const ushort QuestEndReplyPacket = 14;
            public const ushort QuestFailedPacket = 5;
            public const ushort QuestInfoPacket = 1;
            public const ushort QuestObjectiveActivatedPacket = 8;
            public const ushort QuestObjectiveAddedPacket = 7;
            public const ushort QuestObjectiveCompletePacket = 10;
            public const ushort QuestObjectiveFailedPacket = 11;
            public const ushort QuestObjectiveUpdatePacket = 9;
            public const ushort QuestReplyPacket = 2;
            public const ushort QuestStartBreadcrumbPacket = 15;
        }

        public static class BaseQuickChatPackets
        {
            public const ushort QuickChatSendChatPacketBase = 0;
            public static class QuickChatSendChatPacketBases
            {
                public const ushort QuickChatSendChatToChannelPacket = 3;
                public const ushort QuickChatSendTellPacket = 2;
            }

            public const ushort QuickChatSendDataPacket = 1;
        }

        public static class BaseRatingPackets
        {
            public const ushort RatingPacketAddCandidate = 6;
            public const ushort RatingPacketAddVote = 8;
            public const ushort RatingPacketCandidateInfoReply = 17;
            public const ushort RatingPacketCandidateInfoRequest = 16;
            public const ushort RatingPacketClientDataRequest = 3;
            public const ushort RatingPacketDataReply = 5;
            public const ushort RatingPacketRemoveCandidate = 7;
            public const ushort RatingPacketRequestFeatured = 20;
            public const ushort RatingPacketSearchReply = 13;
            public const ushort RatingPacketSearchRequest = 12;
            public const ushort RatingPacketSendFeatured = 22;
            public const ushort RatingPacketVersion = 23;
            public const ushort RatingPacketVoteReply = 18;
        }

        public static class BaseRecipePackets
        {
            public const ushort RecipeAddPacket = 1;
            public const ushort RecipeComponentUpdatePacket = 2;
            public const ushort RecipeRemovePacket = 3;
            public const ushort RecipeUpdatePacket = 5;
        }

        public static class BaseRepeatingActivityPackets
        {
            //public const ushort RepeatingActivityBaseAdminPacket = -1;
            public static class RepeatingActivityBaseAdminPackets
            {
                public const ushort RepeatingActivityAddCountPacket = 6;
                public const ushort RepeatingActivityAddCountResultPacket = 7;
                public const ushort RepeatingActivityCountRemainingInfoPacket = 10;
                public const ushort RepeatingActivityGetCountRemainingPacket = 9;
                public const ushort RepeatingActivitySetCountPacket = 8;
            }

            public const ushort RepeatingActivityClearRequest = 4;
            public const ushort RepeatingActivityConsecutiveMsgPacket = 3;
            public const ushort RepeatingActivitySetConsecutivePacket = 5;
            public const ushort RepeatingActivityStatePacket = 2;
            public static class RepeatingActivityStatePackets
            {
                //public const ushort RepeatingActivityAddPacket = ?;
            }
        }

        public static class BaseReportPackets
        {
            public const ushort ReportPacketReportHouse = 1;
            public const ushort ReportPacketReportPalyer = 1;
        }

        public static class BaseShipCombatPackets
        {
            public const ushort ShipCombatPacketAIDebugData = 36;
            public const ushort ShipCombatPacketAnnouncerMessage = 34;
            public const ushort ShipCombatPacketCameraConfig = 13;
            public const ushort ShipCombatPacketCreateProxiedPickup = 28;
            public const ushort ShipCombatPacketCreateProxiedShip = 9;
            public const ushort ShipCombatPacketCreateProxiedStructure = 31;
            public const ushort ShipCombatPacketDespawnProjectile = 27;
            public const ushort ShipCombatPacketDestroyProxiedPickup = 29;
            public const ushort ShipCombatPacketDestroyProxiedShip = 10;
            public const ushort ShipCombatPacketDestroyProxiedStructure = 32;
            public const ushort ShipCombatPacketFireAtLocation = 20;
            public const ushort ShipCombatPacketMarkTreasurePickups = 30;
            public const ushort ShipCombatPacketPlayerAwards = 24;
            public const ushort ShipCombatPacketPlaySound = 25;
            public const ushort ShipCombatPacketRefreshUI = 4;
            public const ushort ShipCombatPacketRegisterShipPlayer = 5;
            public const ushort ShipCombatPacketRemoveShipPlayer = 6;
            public const ushort ShipCombatPacketRenderDebugData = 35;
            public const ushort ShipCombatPacketResetProxiedShip = 11;
            public const ushort ShipCombatPacketSelectShip = 21;
            public const ushort ShipCombatPacketSetPlayerCount = 7;
            public const ushort ShipCombatPacketShipHit = 23;
            public const ushort ShipCombatPacketSpawnProjectile = 26;
            public const ushort ShipCombatPacketSpecialMove = 22;
            public const ushort ShipCombatPacketUpdateGameState = 2;
            public const ushort ShipCombatPacketUpdatePlayer = 8;
            public const ushort ShipCombatPacketUpdatePlayerGameStates = 3;
            public const ushort ShipCombatPacketUpdatePlayerState = 17;
            public const ushort ShipCombatPacketUpdateProxiedStructure = 33;
            public const ushort ShipCombatPacketUpdateShipCannons = 19;
            public const ushort ShipCombatPacketUpdateShipPhysics = 16;
            public const ushort ShipCombatPacketUpdateWorldForces = 18;
            public const ushort ShipCombatPacketZoneConfig = 12;
        }

        public static class BaseSnsIntegrationPackets
        {
            public const ushort SnsIntegrationFirstTimeLogin = 2;
            public const ushort SnsIntegrationGuildCreated = 3;
            public const ushort SnsIntegrationMaxLevelReached = 5;
            public const ushort SnsIntegrationSecureSignatureRequest = 6;
            public const ushort SnsIntegrationSecureSignatureResponse = 1;
        }

        public static class BaseSoccerPackets
        {
            public const ushort SoccerPacketAcquireBall = 11;
            public const ushort SoccerPacketAcquirePickUp = 10;
            public const ushort SoccerPacketBallBounce = 25;
            public const ushort SoccerPacketFreeBall = 12;
            public const ushort SoccerPacketGoalMade = 2;
            public const ushort SoccerPacketHighArcBall = 18;
            public const ushort SoccerPacketImpulseBall = 13;
            public const ushort SoccerPacketPlayerVariableStats = 19;
            public const ushort SoccerPacketRegisterPlayer = 3;
            public const ushort SoccerPacketSendAIInfo = 24;
            public const ushort SoccerPacketSetClientConfig = 7;
            public const ushort SoccerPacketSetPlayerTeam = 6;
            public const ushort SoccerPacketSetSoccerPlayerOneTimeStats = 21;
            public const ushort SoccerPacketSpawnPickUp = 9;
            public const ushort SoccerPacketSpecialAnimTime = 22;
            public const ushort SoccerPacketStatRollInfo = 17;
            public const ushort SoccerPacketTeamColours = 8;
            public const ushort SoccerPacketUpdateGameState = 5;
            public const ushort SoccerPacketUpdateGameTime = 23;
            public const ushort SoccerPacketUpdatePlayerControls = 16;
            public const ushort SoccerPacketUpdatePlayerPos = 1;
            public const ushort SoccerPacketUpdatePlayerState = 14;
            public const ushort SoccerPacketUpdatePlayerStats = 15;
            public const ushort SoccerPacketUpdateSoccerBall = 4;
        }

        public static class BaseSocialSharePackets
        {
            public const ushort SocialSharePacketGetProviderStatusRequest = 1;
            public const ushort SocialSharePacketGetProviderStatusResponse = 2;
            public const ushort SocialSharePacketPublishRequest = 3;
            public const ushort SocialSharePacketPublishResponse = 4;
        }

        public static class BaseTradePackets
        {
            public const ushort TradeAcceptPacket = 6;
            public const ushort TradeCancelPacket = 7;
            public const ushort TradeCoinCountPacket = 10;
            public const ushort TradeConfirmPacket = 18;
            public const ushort TradeEndSessionPacket = 5;
            public const ushort TradeInvitePacket = 2;
            public const ushort TradeInviteReplyPacket = 3;
            public const ushort TradeItemRemovedPacket = 19;
            public const ushort TradeLockPacket = 8;
            public const ushort TradeMessagePacket = 15;
            public const ushort TradeOfferItemPacket = 9;
            public const ushort TradeRejectedPacket = 16;
            public const ushort TradeStartSessionPacket = 4;
            public const ushort TradeUpdateAcceptPacket = 14;
            public const ushort TradeUpdateAddItemPacket = 12;
            public const ushort TradeUpdateCoinCountPacket = 11;
            public const ushort TradeUpdateItemCountPacket = 13;
            public const ushort TradeUpdateLockPacket = 17;
        }

        public static class BaseUiPackets
        {
            //public const ushort BaseTaskPacket = -1;
            public static class BaseTaskPackets
            {
                public const ushort TaskAddPacket = 1;
                public const ushort TaskCompletePacket = 3;
                public const ushort TaskFailPacket = 4;
                public const ushort TaskUpdatePacket = 2;
            }

            public const ushort CinematicStartLookAtPacket = 16;
            public const ushort ExecuteScriptPacket = 7;
            public const ushort ExecuteScriptWithStringParamsPacket = 8;
            public const ushort LoadingScreenPacket = 9;
            public const ushort ObjectiveTargetUpdatePacket = 14;
            public const ushort SelectedQuestLockedPacket = 13;
            public const ushort SelectQuestPacket = 12;
            public const ushort SelectTaskRequest = 6;
            public const ushort StartTimerPacket = 10;
            public const ushort UiMessagePacket = 15;
        }

        public static class BaseVehicleDemolitionDerbyPackets
        {
            public const ushort VehicleDemolitionDerbyPacketAnnouncerMessage = 20;
            public const ushort VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby = 10;
            public const ushort VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup = 12;
            public const ushort VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerby = 8;
            public const ushort VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerbyPickup = 13;
            public const ushort VehicleDemolitionDerbyPacketItemExpired = 17;
            public const ushort VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby = 9;
            public const ushort VehicleDemolitionDerbyPacketPickupHitRequest = 14;
            public const ushort VehicleDemolitionDerbyPacketPickupHitResponse = 15;
            public const ushort VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer = 6;
            public const ushort VehicleDemolitionDerbyPacketResetProxiedVehicleDemolitionDerby = 18;
            public const ushort VehicleDemolitionDerbyPacketSetDerbyConfig = 19;
            public const ushort VehicleDemolitionDerbyPacketUpdateNpcCount = 4;
            public const ushort VehicleDemolitionDerbyPacketUpdatePlayerCount = 3;
            public const ushort VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData = 5;
            public const ushort VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyStateData = 11;
            public const ushort VehicleDemolitionDerbyPacketUpdateVehicleGamePlayerState = 2;
            public const ushort VehicleDemolitionDerbyPacketUpdateVehicleGameState = 1;
            public const ushort VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus = 7;
            public const ushort VehicleDemolitionDerbyPacketVehicleHit = 16;
        }

        public static class BaseVehicleLoadoutPackets
        {
            public const ushort VehicleRefreshConfigsPacket = 3;
            public const ushort VehicleUpdateConfigPacket = 1;
            public const ushort VehicleUpdateItemPacket = 2;
        }

        public static class BaseVehiclePartPackets
        {
            public const ushort VehiclePartPacketRequestRemovePartFromSlot = 6;
            public const ushort VehiclePartPacketRequestSelectVehicle = 5;
            public const ushort VehiclePartPacketRequestVehicleConfig = 1;
            public const ushort VehiclePartPacketRequestVehicleEquipmentArrayUpdate = 3;
            public const ushort VehiclePartPacketVehicleConfig = 2;
            public const ushort VehiclePartPacketVehicleUpdateDecal = 4;
        }

        public static class BaseVehicleRacePackets
        {
            public const ushort VehicleRacePacketBoostAwardRequest = 22;
            public const ushort VehicleRacePacketBoostAwardResponse = 23;
            public const ushort VehicleRacePacketCreateProxiedVehicleRace = 11;
            public const ushort VehicleRacePacketCreateProxiedVehicleRaceExplosion = 27;
            public const ushort VehicleRacePacketCreateProxiedVehicleRaceMine = 29;
            public const ushort VehicleRacePacketCreateProxiedVehicleRaceMissile = 24;
            public const ushort VehicleRacePacketCreateProxiedVehicleRacePickup = 15;
            public const ushort VehicleRacePacketDestroyProxiedVehicleRace = 12;
            public const ushort VehicleRacePacketDestroyProxiedVehicleRaceExplosion = 28;
            public const ushort VehicleRacePacketDestroyProxiedVehicleRaceMine = 30;
            public const ushort VehicleRacePacketDestroyProxiedVehicleRaceMissile = 25;
            public const ushort VehicleRacePacketDestroyProxiedVehicleRacePickup = 16;
            public const ushort VehicleRacePacketGateHit = 7;
            public const ushort VehicleRacePacketItemExpired = 21;
            public const ushort VehicleRacePacketKickProxiedVehicleRace = 13;
            public const ushort VehicleRacePacketPickupHitRequest = 17;
            public const ushort VehicleRacePacketPickupHitResponse = 18;
            public const ushort VehicleRacePacketRegisterVehicleRacePlayer = 9;
            public const ushort VehicleRacePacketResetNpcsRequest = 32;
            public const ushort VehicleRacePacketResetProxiedVehicleRace = 33;
            public const ushort VehicleRacePacketSetRaceConfig = 34;
            public const ushort VehicleRacePacketUpdateNpcCount = 4;
            public const ushort VehicleRacePacketUpdatePlayerCount = 3;
            public const ushort VehicleRacePacketUpdateVehicleGamePlayerState = 2;
            public const ushort VehicleRacePacketUpdateVehicleGameState = 1;
            public const ushort VehicleRacePacketUpdateVehicleRaceClientData = 5;
            public const ushort VehicleRacePacketUpdateVehicleRaceMineData = 31;
            public const ushort VehicleRacePacketUpdateVehicleRaceMissileData = 26;
            public const ushort VehicleRacePacketUpdateVehicleRaceProgressData = 14;
            public const ushort VehicleRacePacketUpdateVehicleRaceServerData = 6;
            public const ushort VehicleRacePacketUseItemRequest = 19;
            public const ushort VehicleRacePacketUseItemResponse = 20;
            public const ushort VehicleRacePacketVehicleHit = 8;
            public const ushort VehicleRacePacketVehicleRaceCountdownStatus = 10;
        }

        public static class ClientActivityLaunchBasePackets
        {
            public const ushort ClientActivityLaunchPacketActivityCanceled = 6;
            public const ushort ClientActivityLaunchPacketActivityLaunched = 5;
            public const ushort ClientActivityLaunchPacketAddMember = 7;
            //public const ushort ClientActivityLaunchPacketInviteDetails<SoeUtil::List<ClientActivityLaunchMember,-1>> = 1;
            //public const ushort ClientActivityLaunchPacketInviteDetails<SoeUtil::List<ClientActivityLaunchPacketMember,-1>> = 1;
            public const ushort ClientActivityLaunchPacketInviteMemberReply = 2;
            public const ushort ClientActivityLaunchPacketInviteMemberRequest = 20;
            public const ushort ClientActivityLaunchPacketInviteMemberResult = 3;
            public const ushort ClientActivityLaunchPacketInviteResponse = 17;
            public const ushort ClientActivityLaunchPacketKickMemberEvent = 13;
            public const ushort ClientActivityLaunchPacketKickMemberRequest = 21;
            public const ushort ClientActivityLaunchPacketMemberQuit = 19;
            public const ushort ClientActivityLaunchPacketMemberReady = 18;
            public const ushort ClientActivityLaunchPacketOnMatchmakingCancel = 16;
            public const ushort ClientActivityLaunchPacketOnMatchmakingLaunch = 15;
            public const ushort ClientActivityLaunchPacketOnMatchmakingStart = 14;
            public const ushort ClientActivityLaunchPacketOwnerLaunchRequest = 22;
            public const ushort ClientActivityLaunchPacketOwnerMatchmakingRequest = 23;
            public const ushort ClientActivityLaunchPacketPlayerHasBeenAccepted = 4;
            public const ushort ClientActivityLaunchPacketRemoveMember = 8;
            public const ushort ClientActivityLaunchPacketUpdateMemberState = 8;
        }

        public static class ClientPathBasePackets
        {
            public const ushort ClientPathReplyPacket = 2;
            public const ushort ClientPathRequestPacket = 1;
        }

        //public static class EncounterMatchmaking::BaseMatchmakingPackets
        //{
        //    public const ushort EncounterMatchmaking::ListQueuesRequestPacket = 1;
        //    public const ushort EncounterMatchmaking::ListQueuesResponsePacket = 2;
        //    public const ushort EncounterMatchmaking::AddMatchRequestPacket = 3;
        //    public const ushort EncounterMatchmaking::AddMatchRequestResponsePacket = 4;
        //    public const ushort EncounterMatchmaking::ClearMatchRequestPacket = 5; 
        //    public const ushort EncounterMatchmaking::CancelMatchRequestPacket = 6;
        //    public const ushort EncounterMatchmaking::MatchInvitationRequestPacket = 7;
        //    public const ushort EncounterMatchmaking::MatchInvitationResponsePacket = 8;
        //    public const ushort EncounterMatchmaking::SelectQueueForUserPacket = 9;
        //    public const ushort EncounterMatchmaking::QueueStatsRequestPacket = 10;
        //    public const ushort EncounterMatchmaking::QueueStatsResponsePacket = 11;
        //    public const ushort EncounterMatchmaking::MatchmakingServerStatusPacket = 12;
        //    public const ushort EncounterMatchmaking::RemoveParticipantFromQueueResponsePacket = 13;
        //}

        public static class JobCustomizationBasePackets
        {
            public const ushort BegingJobCustomizationPacket = 1;
            public const ushort FinalizeJobCustomizationPacket = 2;
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
            public const ushort PacketMountStartTrial = 10;
            public const ushort PacketMountEndTrial = 11;
            public const ushort PacketMountTrialFailed = 13;
            public const ushort PacketMountUpgradeRequest = 14;
            public const ushort PacketMountUpgradeResponse = 15;
        }

        public static class MysteryChestBasePackets
        {
            public const ushort MysteryChestInfoRequestPacket = 1;
            public const ushort MysteryChestInfoReplyPacket = 2;
        }

        //public static class NameChange::BaseNameChangePacket
        //{
        //    public const ushort NameChange::CheckNamePacket = 1;
        //    public const ushort NameChange::CheckNameResponsePacket = 2;
        //    public const ushort NameChange::ChangeNameRequestPacket = 3;
        //    public const ushort NameChange::NameChangeResponsePacket = 4;
        //    public const ushort NameChange::ChangeNameRequestStatusPacket = 5;
        //    public const ushort NameChange::CheckNameStatusResponsePacket = 6;
        //}

        public static class NudgeBasePackets
        {
            public const ushort NudgeUpdatePacket = 4;
        }

        public static class PacketBaseInGamePurchases
        {
            public const ushort PacketInGamePurchaseGiftNotification = 0;
            //public const ushort PacketInGamePurchasePreviewOrder<GameCommerce::ClientInGamePurchaseOrder> = 1;
            public const ushort PacketInGamePurchasePreviewOrderResponse = 2;
            //public const ushort PacketInGamePurchasePlaceOrderPacket<GameCommerce::ClientInGamePurchaseOrder> = 3;
            public const ushort PacketInGamePurchasePlaceOrderResponse = 4;
            public const ushort PacketInGamePurchaseStoreBundleBase = 5;
            public static class PacketInGamePurchaseStoreBundleBases
            {
                //public const ushort PacketInGamePurchaseStoreBundles<AppStoreBundleDefinition> = 1;
                //public const ushort PacketInGamePurchaseStoreBundleUpdate<AppStoreBundleDefinition> = 2;
            }

            public const ushort PacketInGamePurchaseStoreBundleCategoryGroups = 6;
            public const ushort PacketInGamePurchaseStoreBundleCategories = 7;
            //public const ushort PacketInGamePurchaseExclusivePartnerStoreBundles<SoeUtil::HashList<AppStoreBundleDefinition,32,-1>> = 8;
            public const ushort PacketInGamePurchaseStoreBundleGroups = 9;
            public const ushort PacketInGamePurchaseWalletInfoRequest = 10;
            public const ushort PacketInGamePurchaseWalletInfoResponse = 11;
            public const ushort PacketInGamePurchaseServerStatusRequest = 12;
            public const ushort PacketInGamePurchaseServerStatusResponse = 13;
            public const ushort PacketInGamePurchaseStationCashProductsRequest = 14;
            public const ushort PacketInGamePurchaseStationCashProductsResponse = 15;
            public const ushort PacketInGamePurchaseCurrencyCodesRequest = 16;
            public const ushort PacketInGamePurchaseCurrencyCodesResponse = 17;
            public const ushort PacketInGamePurchaseStateCodesRequest = 18;
            public const ushort PacketInGamePurchaseStateCodesResponse = 19;
            public const ushort PacketInGamePurchaseCountryCodesRequest = 20;
            public const ushort PacketInGamePurchaseCountryCodesResponse = 21;
            public const ushort PacketInGamePurchaseSubscriptionProductsRequest = 22;
            public const ushort PacketInGamePurchaseSubscriptionProductsResponse = 23;
            public const ushort PacketInGamePurchaseEnableMarketplace = 24;
            public const ushort PacketInGamePurchaseAccountInfoRequest = 25;
            public const ushort PacketInGamePurchaseAccountInfoResponse = 26;
            public const ushort PacketInGamePurchaseStoreBundleContentRequest = 27;
            public const ushort PacketInGamePurchaseStoreBundleContentResponse = 28;
            //public const ushort PacketInGamePurchaseStoreClientStatistics<GameCommerce::ClientInGamePurchaseOrder> = 29;
            public const ushort PacketInGamePurchaseDisplayMannequinStoreBundles = 31;
            //public const ushort PacketInGamePurchaseIOTD<AppStoreBundleDefinition> = 32;
            public const ushort PacketInGamePurchaseStoreEnablePaymentSources = 33;
            //public const ushort PacketInGamePurchasePlaceOrderClientTicket<GameCommerce::ClientInGamePurchaseOrder> = 36;
            public const ushort InGamePurchaseUpdateItemRequirementsRequest = 38;
            public const ushort InGamePurchaseUpdateItemRequirementsReply = 39;
            public const ushort InGamePurchaseUpdateSaleDisplay = 40;
            //public const ushort PacketInGamePurchaseBOTD<AppStoreBundleDefinition> = 41;
            public const ushort InGamePurchaseMerchantListPacket = 42;
            public const ushort InGamePurchaseBuyBundleFromMerchantRequest = 43;
            public const ushort InGamePurchaseBuyBundleFromMerchantResponse = 44;
            public const ushort InGamePurchaseUpdateMerchantSellBundleQuantityAvailableForPurchase = 45;
        }

        public static class PacketInviteAndStartMiniGamePackets
        {
            public const ushort PacketInviteAndStartMiniGameInvitePacket = 1;
            public const ushort PacketInviteAndStartMiniGameStartGamePacket = 3;
        }

        public static class PetBasePackets
        {
            public const ushort PetDecisionPacket = 1;
            public const ushort PetResponsePacket = 2;
            public const ushort PetStatusPacket = 3;
            public const ushort PetSummonRecallPacket = 4;
            public const ushort PetListPacket = 5;
            public const ushort PetRequestNamePacket = 6;
            public const ushort PetPerformTrickPacket = 7;
            public const ushort PetTrickGestureResult = 8;
            public const ushort PetActivePacket = 9;
            public const ushort PetSetNamePacket = 10;
            public const ushort PetEquipPacket = 11;
            public const ushort PetTrickSkillLevelPacket = 12;
            public const ushort PetTrickAddPacket = 13;
            public const ushort PetTrickFavoriteSetPacket = 14;
            public const ushort PetTrickNotifyPacket = 15;
            public const ushort PetUtilityPacket = 16;
            public const ushort PetDeletePacket = 17;
            public const ushort PetUtilityGroomPacket = 18;
            public const ushort PetUtilityFeedPacket = 19;
            public const ushort PetUtilityNotifyPacket = 20;
            public const ushort PetUpdateUtilityItemChangePacket = 21;
            public const ushort PetTactileNotify = 22;
            public const ushort PetExpireTimePacket = 23;
            public const ushort PetUiModePacket = 24;
            public const ushort PetBuyRequestPacket = 25;
            public const ushort PetCanGoLocationPacket = 26;
            public const ushort PetInWaterPacket = 28;
            public const ushort PetTempLockoutError = 29;
            public const ushort PetWorldToClientBuyResponse = 31;
            public const ushort PetSummonByItemIdPacket = 32;
            public const ushort PetPlayWithToyPacket = 33;
            public const ushort PetMoodListPacket = 34;
            public const ushort PetEquipByItemRecordPacket = 35;
            public const ushort PetPacketOfferUpsell = 36;
            public const ushort PetPreviewRequestPacket = 38;
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