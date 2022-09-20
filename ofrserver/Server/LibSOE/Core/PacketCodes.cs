namespace SOE
{
    public enum ClientServerCoreBasePackets
    {
    }
    public enum BasePackets
    {
         PacketClientFinishedLoading = 10,
         PacketSendSelfToClient = 12,
         PacketClientIsReady = 13,
         PacketZoneDoneSendingInitialData = 14,
         BaseChatPacket = 15,
         PacketClientLogout = 16,
         PacketTargetClientNotOnline = 22,
         BaseCommandPacket = 26,
         PacketClientBeginZoning = 31,
         BaseCombatPacket = 32,
         BaseVehicleRacePacket = 33,
         BaseCehicleDemolitionDerbyPacket = 34,
         BasePlayerUpdatePacket = 35,
         BaseAbilityPacket = 36,
         BaseClientUpdatePacket = 38,
         BaseMiniGamePacket = 39,
         BaseGroupPacket = 40,
         BaseEncounterPacket = 41,
         BaseInventoryPacket = 42,
         PacketSendZoneDetails = 43,
         ReferenceDataPacket = 44,
         BaseObjectivePacket = 45,
         BaseUiPacket = 47,
         BaseQuestPacket = 49,
         RewardBasePacket = 50,
         PacketGameTimeSync = 52,
         PetBasePacket = 53,
         PacketPointOfInterestDefinitionRequest = 56,
         PacketPointOfInterestDefinitionReply = 57,
         PacketWorldTeleportRequest = 58,
         BaseTradePacket = 59,
         EncounterDataCommon = 62,
         BaseRecipePacket = 63,
         PacketBaseInGamePurchase = 66,
         BaseQuickChatPacket = 67,
         BaseReportPacket = 68,
         BaseAcquaintancePacket = 72,
         PacketClientServerShuttingDown = 73,
         BaseFriendsPacket = 74,
         BaseSoccerPacket = 76,
         BaseBroadcastPacket = 77,
         PacketClientKickedFromServer = 81,
         PacketUpdateClientSessionData = 82,
         BaseBugSubmissionPacket = 83,
         PacketWorldDisplayInfo = 86,
         PacketMOTD = 87,
         PacketSetLocale = 88,
         PacketSetClientArea = 89,
         PacketZoneTeleportRequest = 90,
         PacketZoneTeleportResponse = 91,
         PacketWorldShutdownNotice = 92,
         PacketLoadWelcomeScreen = 93,
         BaseShipCombatPacket = 94,
         BaseMiniGameAdminPacket = 95,
         PacketZonePing = 96,
         ClientPathBasePacket = 98,
         PacketMembershipActivation = 100,
         BaseLobbyPacket = 101,
         BaseLobbyGameDefinitionPacket = 102,
         PacketShowSystemMessage = 103,
         PacketPOIChangeMessage = 104,
         PacketClientMetrics = 105,
         BaseFireTimeEventPacket = 107,
         BaseClaimPacket = 108,
         PacketClientLog = 109,
         BaseIgnorePacket = 112,
         BasePromotionalPacket = 114,
         PacketAddClientPortraitCrc = 115,
         OneTimeSessionRequestPacket = 117,
         OneTimeSessionResponsePacket = 118,
         PacketZoneSafeTeleportRequest = 122,
         PlayerUpdatePacketUpdatePosition = 125,
         PlayerUpdatePacketCameraUpdate = 126,
         BaseHousingPacket = 127,
         BaseGuildPacket = 129,
         BaseBrokerPacket = 130,
         BaseAdminGuildPacket = 131,
         BaseAdminBrokerPacket = 132,
         BaseBattleMagesPacket = 133,
         BaseVehicleLoadoutPacket = 137,
         BaseFishingPacket = 138,
         BaseVehiclePartPacket = 139,
        // EncounterMatchmaking::BaseMatchmakingPacket = 141,
         PacketClientLuaMetrics = 142,
         BaseReaptingActivityPacket = 143,
         PacketClientGameSettings = 144,
         PacketClientTrailProfileUpsell = 145,
         ActivityManagerBasePacket = 147,
         BaseInspectPacket = 149,
         BaseAchievementPacket = 150,
         BasePlayerTitlePacket = 152,
         JobCustomizationBasePacket = 155,
         BaseFotomatPacket = 156,
         PacketUpdateUserAge = 157,
         PlayerUpdatePacketJump = 164,
         BaseCoinStorePacket = 165,
         PacketInitializationParameters = 166,
         BaseActivityServicePacket = 167,
         MountBasePacket = 168,
         PacketClientInitializationDetails = 169,
         PacketClientNotifyCoinSpinAvailable = 171,
         PacketClientAreaTimer = 172,
         BaseLoyaltyRewardPacket = 173,
         BaseRatingPacket = 174,
         ClientActivityLaunchBasePacket = 175,
         PacketClientFlashTimer = 177,
         PacketInviteAndStartMiniGamepacket = 180,
         PlayerUpdatePacketFlourish = 181,
         PacketClientMembershipVipInfo = 186,
         BaseFactoryPacket = 188,
         PacketMembershipSubscriptionInfo = 189,
         PacketCleintCaisNotification = 190,
        // NameChange::BaseNameChangePacket = 192,
         AnnouncementBasePacket = 193,
         WallOfDataBasePacket = 194,
         PacketClientSettings = 195,
         PacketClientSubstringBlacklist = 196,
         BaseSnsIntegrationPacket = 197,
         PacketClientTrailPetUpsell = 199,
         PacketClientTrailMountUpsell = 201,
         MysteryChestBasePacket = 202,
         NudgeBasePacket = 203,
         PacketEnterSocialZoneRequest = 204,
         BaseSocialSharePacket = 205,
         BaseProgressiveQuestPacket = 207,
         PacketUpdateClientAreaCompositeEffect = 208,
         BaseAdventurersJournalPacket = 209,
         PacketCheckNameRequest = 210,
         PacketCheckNameReply = 211
    };

    public enum ActivityManagerBasePackets
    {
         ActivityProfileListPacket = 1,
         ActivityJoinErrorPacket = 2,
    };

    public enum AnnouncementBasePackets
    {
         AnnouncementDataRequestPacket = 1,
         AnnouncementDataSendPacket = 2,
         AnnouncementAdminSendAll = 3,
         MemberPanelDataSendPacket = 4
    };

    public enum BaseAbilityPackets
    {
         AbilityPacketAbilityDefinition = 13,
         AbilityPacketCastInterrupt = 18,
         AbilityPacketClientMoveAndCast = 6,
         AbilityPacketClientRequestStartAbility = 10,
         AbilityPacketDetonateProjectile = 14,
         AbilityPacketExecuteClientLua = 17,
         AbilityPacketFailed = 1,
         AbilityPacketLaunchAndLand = 4,
         AbilityPacketMeleeRefresh = 11,
         AbilityPacketPulseLocationTargeting = 15,
         AbilityPacketPurchaseAbility = 7,
         AbilityPacketReceivePulseLocation = 16,
         AbilityPacketRequestAbilityDefinition = 12,
         AbilityPacketSetDefinition = 5,
         AbilityPacketStartCasting = 3,
         AbilityPacketStopAura = 9,
         AbilityPacketUpdateAbilityExperience = 8
    };

    public enum BaseAchievementPackets
    {
         AchievementAddPacket = 2,
         AchievementCompletePacket = 3,
         AchievementInitializePacket = 4,
         AchievementObjectiveActivatedPacket = 6,
         AchievementObjectiveAddedPacket = 5,
         AchievementObjectiveCompletePacket = 8,
         AchievementObjectiveUpdatePacket = 7
    };

    public enum BaseAcquaintancePackets
    {
         AcquaintanceOnlinePacket = 3,
         AddAcquaintancePacket = 1,
         RemoveAcquaintancePacket = 2
    };

    public enum BaseActivityServicePackets
    {
        BaseActivityPacket = 1,
         BaseScheduledActivityPacket = 2
    };
    public enum BaseActivityPackets
    {
        ActivityPacketActivityListRefreshRequest = 4,
        ActivityPacketJoinActivityRequest = 2,
        ActivityPacketListOfActivities = 1,
        ActivityPacketUpdateActivityFeaturedStatus = 5,
        ScheduledActivityPacketListOfActivities = 1
    };

    public enum BaseAdminBrokerPackets
    {
         AdminBrokerServerVersionPacket = 17
    };

    public enum BaseAdminGuildPackets
    {
         AdminGuildServerVersionPacket = 41
    };

    public enum BaseAdventurersJournalPackets
    {
         AdventurersJournalInfoPacket = 1,
         AdventurersJournalQuestUpdatePacket = 2
    };

    public enum BaseBattleMagesPackets
    {
         BattleMagesPacketCameraConfig = 8,
         BattleMagesPacketCommand = 1,
         BattleMagesPacketCreateProxiedPlayer = 4,
         BattleMagesPacketCreateProxiedProjectile = 11,
         BattleMagesPacketDestroyProxiedProjectile = 12,
         BattleMagesPacketKickProxiedPlayer = 5,
         BattleMagesPacketRegisterPlayer = 3,
         BattleMagesPacketRequestAttack = 9,
         BattleMagesPacketUpdateData = 2,
         BattleMagesPacketUpdateGameState = 6,
         BattleMagesPacketUpdatePlayerState = 7,
         BattleMagesPacketUpdateProxiedProjectile = 13
    };

    public enum BaseBroadcastPackets
    {
         BroadcastPacketWorld = 3
    };

    public enum BaseBrokerPackets
    {
         BrokerBuyItemPacket = 5,
         BrokerCancelItemPacket = 6,
         BrokerErrorPacket = 16,
         BrokerInformationPacket = 12,
         BrokerMyItemAddedPacket = 9,
         BrokerMyItemsPacket = 8,
         BrokerPlaceItemPacket = 3,
         BrokerReListItemPacket = 4,
         BrokerRemoveItemFromListsPacket = 11,
         BrokerRequestItemSaleCoinPacket = 7,
         BrokerSearchItemsPacket = 10,
         BrokerSearchPacket = 2
    };

    public enum BaseBugSubmissionPackets
    {
         BugSubmissionpacketAddBug = 1
    };

    public enum BaseChatPackets
    {
         ChatPacketDebugChat = 3,
         ChatPacketEnterArea = 2,
         ChatPacketFromStringId = 4,
         PacketChat = 1,
         TellEchoPacket = 5
    };

    public enum BaseClaimPackets
    {
         Unknown = 5,
         ClaimItemsItemDefinitionsResponse = 6,
         ClaimItemsRequestPacket = 3,
         ClaimItemsResponsePacket = 4,
         GetAllAvailableClaimItemsRequestPacket = 1,
         GetAllAvailableClaimItemsResponsePacket = 2
    };

    public enum BaseClientUpdatePackets
    {
         ClientUpdatePacketHitpoints = 1,
         ClientUpdatePacketItemAdd = 2,
         ClientUpdatePacketItemUpdate = 3,
         ClientUpdatePacketItemDelete = 4,
         ClientUpdatePacketEquipItem = 5,
         ClientUpdatePacketUnequipSlot = 6,
         ClientUpdatePacketUpdateStat = 7,
         ClientUpdatePacketCollectionStart = 8,
         ClientUpdatePacketCollectionRemove = 9,
         ClientUpdatePacketCollectionAddEntry = 10,
         ClientUpdatePacketCollectionRemoveEntry = 11,
         ClientUpdatePacketUpdateLocation = 12,
         ClientUpdatePacketMana = 13,
         ClientUpdatePacketUpdateProfileExperience = 14,
         ClientUpdatePacketAddProfileAbilitySetApl = 15,
         ClientUpdatePacketAddEffectTag = 16,
         ClientUpdatePacketRemoveEffectTag = 17,
         ClientUpdatePacketUpdateProfileRank = 18,
         ClientUpdatePacketCoinCount = 19,
         ClientUpdatePacketDeleteProfile = 20,
         ClientUpdatePacketActivateProfile = 21,
         ClientUpdatePacketAddAbility = 22,
         ClientUpdatePacketNotifyPlayer = 23,
         ClientUpdatePacketUpdateProfileAbilitySetApl = 24,
         ClientUpdatePacketUpdateActionBarSlot = 25,
         ClientUpdatePacketDoneSendingPreloadCharacters = 26,
         ClientUpdatePacketSetGrandfatheredStatus = 27,
         ClientUpdatePacketImmediateActivationFailed = 29,
         ClientUpdatePacketImmediateActivationCheck = 30,
         ClientUpdatePacketStorage = 31
    };

    public enum BaseCoinStorePackets
    {
         CoinStoreBuyBackRequestPacket = 15,
         CoinStoreBuyBackResponsePacket = 13,
         CoinStoreBuyFromClientRequestPacket = 5,
         CoinStoreClearTransactionHistoryPacket = 11,
         CoinStoreGiftTransactionCompletePacket = 18,
         CoinStoreItemDefinitionsRequestPacket = 2,
         CoinStoreItemDefinitionsResponsePacket = 3,
         CoinStoreItemDynamicListUpdateRequestPacket = 8,
         CoinStoreItemDynamicListUpdateResponsePacket = 9,
         CoinStoreItemListPacket = 1,
         CoinStoreMerchantListPacket = 10,
         CoinStoreOpenPacket = 7,
         CoinStoreReceiveGiftItemPacket = 17,
         CoinStoreSellToClientAndGiftRequestPacket = 14,
         CoinStoreSellToClientRequestPacket = 4,
         CoinStoreTransactionCompletePacket = 6
    };

    public enum BaseCombatPackets
    {
         CombatPacketAttackAttackerMissed = 5,
         CombatPacketAttackProcessed = 7,
         CombatPacketAttackTargetDamage = 4,
         CombatPacketAttackTargetDodged = 6,
         CombatPacketAutoAttackTarget = 1,
         CombatPacketEnableBossDisplay = 9,
         CombatPacketSingleAttackTarget = 3
    };

    public enum BaseCommandPackets
    {
         AdminCommandPacketShipCombatCommand = 1169,
         ClearInteractionMerchantSetId = 43,
         CommandPacketActivateProfileFailed = 26,
         CommandPacketAddFriendRequest = 14,
         CommandPacketChatChannelOff = 33,
         CommandPacketChatChannelOn = 32,
         CommandPacketClosedMinigameEndScreen = 42,
         CommandPacketConfirmFriendRequest = 16,
         CommandPacketConfirmFriendResponse = 17,
         CommandPacketDirectInspect = 45,
         CommandPacketEndDialog = 4,
         CommandPacketFriendsPositionRequest = 21,
         CommandPacketIgnoreRequest = 30,
         CommandPacketInteractionList = 9,
         CommandPacketInteractionSelect = 10,
         CommandPacketInteractionStartWheel = 11,
         CommandPacketInteractRequest = 8,
         CommandPacketMoveAndInteract = 22,
         CommandPacketPlayDialogEffect = 28,
         CommandPacketPlaySoundAtLocation = 7,
         CommandPacketPlaySoundIdOnTarget = 39,
         CommandPacketQuestAbandon = 23,
         CommandPacketRecipeStart = 24,
         CommandPacketRemoveFriendRequest = 15,
         CommandPacketRequestPlayerPositions = 34,
         CommandPacketRequestPlayerPositionsReply = 35,
         CommandPacketRequestPlayIntroEncounter = 40,
         CommandPacketRequestRewardPreviewUpdate = 37,
         CommandPacketRequestRewardPreviewUpdateReply = 38,
         CommandPacketRequestStorageCheck = 44,
         CommandPacketSelectPlayer = 19,
         CommandPacketSetActiveVehicleGuid = 31,
         CommandPacketSetChatBubbleColor = 18,
         CommandPacketSetProfile = 13,
         CommandPacketSetProfileByItemDefinitionId = 36,
         CommandPacketShowDialog = 3,
         CommandPacketShowRecipeWindow = 25,
         CommandPacketStartFlashGame = 12,
         CommandPacketWhoReply = 2,
         FreeInteractionNpc = 20,
         PacketDialogResponse = 6
    };

    public enum BaseEncounterPackets
    {
         EncounterDetailsResponsePacket = 114,
         EncounterDuelInvitationPacket = 104,
         EncounterDuelInvitationResponsePacket = 105,
         EncounterInvitationPacket = 102,
         EncounterInvitationResponsePacket = 103,
         EncounterOverworldCombatPacket = 132,
         EncounterPacketEncounterComplete = 3,
         EncounterPacketEncounterLaunchFailed = 4,
         EncounterPacketEncounterShutdown = 6,
         EncounterPacketIsFighting = 133,
         EncounterPacketObjectiveState = 5,
         EncounterPacketPlayerEnter = 2,
         EncounterParticipantCancelPendingEncounterPacket = 124,
         EncounterParticipantMessagePacket = 120,
         EncounterParticipantRequestEntrancePacket = 108,
         EncounterParticipantRequestExitPacket = 109,
         EncounterParticipantResumePacket = 122,
         EncounterParticipantTerminateEncounterPacket = 121,
         EncounterRunningListRequestPacket = 129,
         EncounterRunningListResponsePacket = 130,
         EncounterShowRespawnWindowPacket = 125,
         EncounterStatePacket = 106,
         EncounterZoneIsReadyPacket = 107
    };

    public enum BaseFactoryPackets
    {
         FactoryPacketAddBlueprintToFoundationFailure = 20,
         FactoryPacketCreateBlueprintRequest = 8,
         FactoryPacketCreateBlueprintResponse = 25,
         FactoryPacketDoUpsell = 30,
         FactoryPacketEquipToolRequest = 7,
         FactoryPacketEquipToolResponse = 23,
         FactoryPacketListToolsRequest = 6,
         FactoryPacketListToolsResponse = 22,
         FactoryPacketNpcTooltipReply = 21,
         FactoryPacketNpcTooltipRequest = 5,
         FactoryPacketOpenBlueprintBrowserOnFoundation = 24,
         FactoryPacketOpenBlueprintGenerator = 27,
         FactoryPacketOpenToolshed = 26,
         FactoryPacketRequestAddBlueprintToFoundation = 2,
         FactoryPacketRequestRecipeReward = 14,
         FactoryPacketUpdateBlueprint = 17,
         FactoryPacketUpdateExperience = 29,
         FactoryPacketUpdateFactoryInfo = 1,
         FactoryPacketUpdateFoundation = 16,
         FactoryPacketUpdatePlot = 28
    };

    public enum BaseFirstTimeEventPackets
    {
         FirstTimeEventTriggerRequest = 1,
         FirstTimeEventStatePacket = 2,
         FirstTimeEventClearRequest = 3,
         FirstTimeEventEnablePacket = 4,
         FirstTimeEventScriptPacket = 5
    };

    public enum BaseFishingPackets
    {
         FishingPacketCastAnimRequest = 5,
         FishingPacketCastRequest = 6,
         FishingPacketDespawnProxiedFishingSchool = 12,
         FishingPacketFishInfoUpdate = 4,
         FishingPacketFishingResult = 14,
         FishingPacketReelInRequest = 7,
         FishingPacketRegisterPlayerRequest = 2,
         FishingPacketRegisterPlayerResponse = 3,
         FishingPacketSpawnFishRun = 18,
         FishingPacketSpawnProxiedFishingBobber = 8,
         FishingPacketSpawnProxiedFishingSchool = 11,
         FishingPacketSpecialRequest = 15,
         FishingPacketSpecialRespons = 16,
         FishingPacketUpdateData = 1,
         FishingPacketUpdateProxiedFishingBobber = 10,
         FishingPacketUpdateProxiedFishingSchool = 13
    };

    public enum BaseFormatPackets
    {
         PacketGeneratePortraitRequest = 1,
         PacketPlayerImageData = 3,
         PacketPortraitDataRequest = 2,
         PacketSnapshotRequest = 4
    };

    public enum BaseFriendPackets
    {
         FriendAddPacket = 6,
         FriendListPacket = 1,
         FriendMessagePacket = 0,
         FriendOfflinePacket = 3,
         FriendOnlinePacket = 2,
         FriendRemovePacket = 7,
         FriendRenamePacket = 10,
         FriendStatusPacket = 9,
         FriendUpdatePositionsPacket = 5
    };

    public enum BaseGroupPackets
    {
         GroupChangingJobPacket = 14,
         GroupChangingJobUpdatePacket = 15,
         GroupInMinigamePacket = 17,
         GroupMapPingPacket = 16,
         GroupPacketAnnounceEncounterReply = 13,
         GroupPacketGroupAccept = 4,
         GroupPacketGroupAcceptReply = 5,
         GroupPacketGroupInvite = 1,
         GroupPacketGroupInviteReply = 2,
         GroupPacketGroupKick = 6,
         GroupPacketGroupKickReply = 7,
         GroupPacketGroupLeave = 3,
         GroupPacketGroupMemberUpdate = 9,
         GroupPacketGroupUpdate = 8,
         GroupPacketRenamePlayer = 11
    };

    public enum BaseGuildPackets
    {
         GuildCanCreateGuildPacket = 32,
         GuildCreatePacket = 1,
         GuildDataFullPacket = 22,
         GuildDeleteNotificationPacket = 29,
         GuildDeletePacket = 2,
         GuildDemotePacket = 5,
        // GuildErrorPacket = ?,
        // GuildInviteAcceptNotificationPacket = ?,
        // GuildInviteDeclineNotificationPacket = ?,
         GuildInviteAcceptPacket = 8,
         GuildInviteCancelPacket = 26,
         GuildInviteDeclinePacket = 9,
         GuildInviteNotificationPacket = 24,
         GuildInvitePacket = 3,
         GuildInviteTimeOutPacket = 10,
         GuildMemberLocationRequest = 15,
         GuildMemberLocationUpdatePacket = 25,
         GuildMemberStatusUpdatePacket = 17,
         GuildMotdUpdatePacket = 11,
         GuildNameAcceptedPacket = 19,
         GuildNameRejectedPacket = 20,
         GuildNameRequestPacket = 14,
         GuildNameUpdatePacket = 18,
         GuildPaidRenameCheckReplyPacket = 30,
         GuildPaidRenameCheckRequestPacket = 16,
         GuildPlayerStatusUpdatePacket = 31,
         GuildPromotePacket = 4,
         GuildQuitPacket = 7,
         GuildRemovePacket = 6,
         GuildRenameGuildPacket = 13,
         GuildRoleNameChangedPacket = 21
    };

    public enum BaseHousingPackets
    {
         AdminHousingServerVersionPacket = 57,
         ClientHousingPacketApplyCustomizationToFixtureGroupAndType = 59,
         ClientHousingPacketChangeHouseName = 9,
         ClientHousingPacketDeclineInvite = 16,
         ClientHousingPacketEnterRequest = 19,
         ClientHousingPacketExplosionResetRequest = 18,
         ClientHousingPacketInvitePlayer = 15,
         ClientHousingPacketLeaveHouse = 10,
         ClientHousingPacketLockHouse = 22,
         ClientHousingPacketPayUpkeep = 7,
         ClientHousingPacketPickupAllFixtures = 4,
         ClientHousingPacketPickupFixture = 3,
         ClientHousingPacketPlaceFixture = 2,
         ClientHousingPacketPlaceFixtureRequest = 1,
         ClientHousingPacketPreviewByItemDefinitionIdRequest = 20,
         ClientHousingPacketRemoveCustomizationFromFixtureGroupAndType = 60,
         ClientHousingPacketRequestGrant = 23,
         ClientHousingPacketRequestName = 17,
         ClientHousingPacketRequestPlayerHouses = 14,
         ClientHousingPacketRequestVisitToNeighbor = 21,
         ClientHousingPacketSaveFixture = 5,
         ClientHousingPacketSetEditMode = 6,
         ClientHousingPacketToggleFloraAllowed = 12,
         ClientHousingPacketToggleLocked = 11,
         ClientHousingPacketTogglePetAutospawn = 13,
         HousingPacketDeclineNotification = 48,
         HousingPacketExplosion = 55,
         HousingPacketExplosionReset = 56,
         HousingPacketFixtureAsset = 42,
         HousingPacketFixtureItemList = 43,
         HousingPacketFixturePlacementDenied = 53,
         HousingPacketFixtureRemove = 41,
         HousingPacketFixtureUpdate = 40,
         HousingPacketHousingError = 46,
         HousingPacketInstanceData = 28,
         HousingPacketInstanceList = 39,
         HousingPacketInviteNotification = 47,
         HousingPacketNotifyHouseAdded = 49,
         HousingPacketSetHeadSize = 50,
         HousingPacketUpdateFixturePosition = 51,
         HousingPacketUpdateHouseInfo = 44,
         HousingPacketZoneData = 45
    };

    public enum BaseignorePackets
    {
         IgnoreAddPacket = 2,
         IgnoreListPacket = 1,
         IgnoreRemovePacket = 3
    };

    public enum BaseInspectPackets
    {
         StartInspectPacket = 1,
         StopInspectPacket = 2,
         WorldInspectReplyPacket = 3
    };

    public enum BaseInventoryPackets
    {
         InventoryPacketCheckImmediateActivationItem = 16,
         InventoryPacketEquipByGuid = 3,
         InventoryPacketEquipByItemRecord = 8,
         InventoryPacketEquipItemGroup = 14,
         InventoryPacketEquipLightsaber = 13,
         InventoryPacketEquippedRemove = 2,
         InventoryPacketItemActionBarAssign = 6,
         InventoryPacketItemActionBarAssignByItemRecord = 9,
         InventoryPacketItemRequirementRequest = 4,
         InventoryPacketMoveItemToStorage = 17,
         InventoryPacketPreviewStyleCard = 11,
         InventoryPacketUseImmediateActivationItem = 15,
         InventoryPacketUseStyleCard = 10,
         InventoryPacketUseStyleCardByItemRecord = 12
    };

    public enum BaseLobbyGameDefinitionPackets
    {
         LobbyGameDefinitionPacketDefinitionsRequest = 1,
         LobbyGameDefinitionPacketDefinitionsResponse = 2
    };

    public enum BaseLobbyPackets
    {
         CreateLobbyGamePacket = 5,
         JoinLobbyGamePacket = 1,
         LeaveLobbyGamePacket = 2,
         LeaveLobbyPacket = 9,
         LobbyErrorMessagePacket = 11,
         RemoveLobbyGamePacket = 8,
         SendLeaveLobbyToClientPacket = 7,
         SendLobbyToClientPacket = 6,
         ShowLobbyUiPacket = 12,
         StartLobbyGamePacket = 3,
         UpdateLobbyGamePacket = 4
    };

    public enum BaseLoyaltyRewardPackets
    {
         SetLoyaltyRewardLogoutInformation = 0
    };

    public enum BaseMiniGameAdminPackets
    {
         MiniGameFlashCommandAdminPacket = 63
    };

    public enum BaseMiniGamePackets
    {
         BaseMiniGameBossPacket = 62,
         MiniGameCreateGameResultPacket = 67,
         MiniGameDataLockedPacket = 1,
         MiniGameDataUnlockedPacket = 2,
         MiniGameGameEndScorePacket = 47,
         MiniGameGameOverPacket = 18,
         MiniGameGroupInfoPacket = 50,
         MiniGameInfoPacket = 16,
         MiniGameKnockOutPacket = 23,
         MiniGameLootWheelOnRotationStoppedPacket = 46,
         MiniGameLootWheelSetItemToLandOnPacket = 45,
         MiniGameMessagePacket = 15,
         MiniGamePayloadPacket = 14,
         MiniGameRewardStatusPacket = 22,
         MiniGameStarsEarnedPacket = 21,
         MiniGameStoreAdvertisementWorldClient = 44,
         MiniGameUpdateGameTimeScalar = 20,
         MiniGameUpdateRewardPacket = 68,
         RequestTCGChallengePacket = 38,
         TradingCardStartGamePacket = 40
    };

    public enum BaseMiniGameBossPackets
    {
        MiniGameBossDeletePacket = 2,
        MiniGameBossUpdatePacket = 1
    };

    public enum BasePlayerTitlePackets
    {
         PlayerTitleAddPacket = 1,
         PlayerTitleRefreshRequestPacket = 5,
         PlayerTitleRemovePacket = 2,
         PlayerTitleRequestSelectPacket = 4,
         PlayerTitleSNSUpdatePacket = 7,
         PlayerTitleUpdateAllPacket = 3
    };

    public enum BaseObjectivePackets
    {
         ObjectiveActivatePacket = 1,
         ObjectiveClientClearPacket = 8,
         ObjectiveClientCompleteFailedPacket = 9,
         ObjectiveClientCompletePacket = 7,
         ObjectiveCompletePacket = 3,
         ObjectiveFailPacket = 4,
         ObjectiveFirstMovementPacket = 11,
         ObjectiveHousingFixtureMovePacket = 12,
         ObjectiveLookAtPacket = 6,
         ObjectiveUIEventPacket = 10,
         ObjectiveUnhidePacket = 5,
         ObjectiveUpdatePacket = 2
    };

    public enum BasePlayerUpdatePackets
    {
         PlayerUpdatePacketAddPc = 1,
         PlayerUpdatePacketAddNpc = 2,
         PlayerUpdatePacketRemovePlayer = 3,
         PlayerUpdatePacketKnockback = 4,
         PlayerUpdatePacketUpdateHitpoints = 5,
         PlayerUpdatePacketEquipItemChange = 6,
         PlayerUpdatePacketEquippedItemsChange = 7,
         PlayerUpdatePacketSetAnimation = 8,
         PlayerUpdatePacketUpdateMana = 9,
         PlayerUpdatePacketAddNotifications = 10,
         PlayerUpdatePacketRemoveNotifications = 11,
         PlayerUpdatePacketNpcRelevance = 12,
         PlayerUpdatePacketUpdateScale = 13,
         PlayerUpdatePacketUpdateTemporaryAppearance = 14,
         PlayerUpdatePacketRemoveTemporaryAppearance = 15,
         PlayerUpdatePacketPlayCompositeEffect = 16,
         PlayerUpdatePacketSetLookAt = 17,
         PlayerUpdatePacketUpdateLivesRemaining = 18,
         PlayerUpdatePacketRenamePlayer = 19,
         PlayerUpdatePacketUpdateCharacterState = 20,
         PlayerUpdatePacketUpdateWalkAnim = 21,
         PlayerUpdatePacketQueueAnimation = 22,
         PlayerUpdatePacketExpectedSpeed = 23,
         PlayerUpdatePacketScriptedAnimation = 24,
         PlayerUpdatePacketUpdateRunAnim = 25,
         PlayerUpdatePacketUpdateIdleAnim = 26,
         PlayerUpdatePacketThoughtBubble = 27,
         PlayerUpdatePacketSetDisposition = 28,
         PlayerUpdatePacketLootEvent = 29,
         PlayerUpdatePacketHeadInflationScale = 30,
         PlayerUpdatePacketSlotCompositeEffectOverride = 31,
         PlayerUpdatePacketFreeze = 32,
         PlayerUpdatePacketRequestStripEffect = 33,
         PlayerUpdatePacketItemDefinitionRequest = 34,
         PlayerUpdatePacketHitPointModification = 35,
         PlayerUpdateTriggerEffectPackagePacket = 36,
         PlayerUpdatePacketItemDefinitions = 37,
         PlayerUpdatePacketPreferredLanguages = 38,
         PlayerUpdatePacketCustomizationChange = 39,
         PlayerUpdatePacketPlayerTitle = 40,
         PlayerUpdatePacketAddEffectTagCompositeEffect = 41,
         PlayerUpdatePacketRemoveEffectTagCompositeEffect = 42,
         PlayerUpdatePacketEffectTagCompositeEffectsEnable = 43,
         PlayerUpdatePacketStartRentalUpsell = 44,
         PlayerUpdatePacketSetSpawnAnimation = 45,
         PlayerUpdatePacketCustomizeNpc = 46,
         PlayerUpdatePacketSetSpawnerActivationEffect = 47,
         PlayerUpdatePacketRemoveNpcCustomization = 48,
         PlayerUpdatePacketReplaceBaseModel = 49,
         PlayerUpdatePacketSetCollidable = 50,
         PlayerUpdatePacketUpdateOwner = 51,
         PlayerUpdatePacketUpdateTintAlias = 52,
         PlayerUpdatePacketMoveOnRail = 53,
         PlayerUpdatePacketClearMovementRail = 54,
         PlayerUpdatePacketMoveOnRelativeRail = 55,
         PlayerUpdatePacketDestroyed = 56,
         PlayerUpdatePacketUpdateShields = 57,
         PlayerUpdatePacketHitPointAndShieldsModification = 58,
         PlayerUpdatePacketSeekTarget = 59,
         PlayerUpdatePacketSeekTargetUpdate = 60,
         PlayerUpdatePacketUpdateActiveWieldType = 61,
         PlayerUpdateLaunchProjectilePacket = 62,
         PlayerUpdatePacketSetSynchronizedAnimations = 63,
         HudMessagePacket = 64,
         PlayerUpdatePacketCustomizationData = 65,
         PlayerMemberStatusUpdatePacket = 66,
         PlayerUpdatePacketPopup = 70,
         PlayerUpdateProfileNameplateImageIdPacket = 71
    };

    public enum PlayerUpdatePacketRemovePlayerG
    {
        PlayerUpdatePacketRemovePlayerGracefully = 1
    };

    public enum BaseProgressiveQuestPackets
    {
         ProgressiveQuestClientDataPacket = 1,
         ProgressiveQuestNotifyRewardItemPacket = 7,
         ProgressiveQuestRequestClaimPrizePacket = 4,
         ProgressiveQuestRequestClaimSlotPacket = 3,
         ProgressiveQuestRequestStartQuestPacket = 2,
         ProgressiveQuestShowWindowPacket = 0
    };

    public enum BasePromotionalPackets
    {
         KeyCodeRedemptionNotificationPacket = 1,
         PromotionalBundleDataPacket = 2
    };

    public enum BaseQuestPackets
    {
         CompletedQuestCountUpdatePacket = 12,
         QuestAbandonedPacket = 6,
         QuestAddPacket = 3,
         QuestCompletePacket = 4,
         QuestEndBlockedPacket = 16,
         QuestEndPacket = 13,
         QuestEndReplyPacket = 14,
         QuestFailedPacket = 5,
         QuestInfoPacket = 1,
         QuestObjectiveActivatedPacket = 8,
         QuestObjectiveAddedPacket = 7,
         QuestObjectiveCompletePacket = 10,
         QuestObjectiveFailedPacket = 11,
         QuestObjectiveUpdatePacket = 9,
         QuestReplyPacket = 2,
         QuestStartBreadcrumbPacket = 15
    };

    public enum BaseQuickChatPackets
    {
        QuickChatSendDataPacket = 1,
        QuickChatSendTellPacket = 2,
        QuickChatSendChatToChannelPacket = 3
    };

    public enum BaseRatingPackets
    {
         RatingPacketAddCandidate = 6,
         RatingPacketAddVote = 8,
         RatingPacketCandidateInfoReply = 17,
         RatingPacketCandidateInfoRequest = 16,
         RatingPacketClientDataRequest = 3,
         RatingPacketDataReply = 5,
         RatingPacketRemoveCandidate = 7,
         RatingPacketRequestFeatured = 20,
         RatingPacketSearchReply = 13,
         RatingPacketSearchRequest = 12,
         RatingPacketSendFeatured = 22,
         RatingPacketVersion = 23,
         RatingPacketVoteReply = 18
    };

    public enum BaseRecipePackets
    {
         RecipeAddPacket = 1,
         RecipeComponentUpdatePacket = 2,
         RecipeRemovePacket = 3,
         RecipeUpdatePacket = 5
    };


    public enum BaseRepeatingActivityPackets
    {
        // RepeatingActivityBaseAdminPacket = -1,
         RepeatingActivityClearRequest = 4,
         RepeatingActivityConsecutiveMsgPacket = 3,
         RepeatingActivitySetConsecutivePacket = 5,
         RepeatingActivityStatePacket = 2
    };

    public enum RepeatingActivityBaseAdminPackets
    {
        RepeatingActivityAddCountPacket = 6,
        RepeatingActivityAddCountResultPacket = 7,
        RepeatingActivityCountRemainingInfoPacket = 10,
        RepeatingActivityGetCountRemainingPacket = 9,
        RepeatingActivitySetCountPacket = 8
    };

    public enum RepeatingActivityStatePackets
    {
        // RepeatingActivityAddPacket = ?,
    };


    public enum BaseReportPackets
    {
        ReportPacketReportPlayer = 1,
        ReportPacketReportHouse = 3
    };

    public enum BaseShipCombatPackets
    {
         ShipCombatPacketAIDebugData = 36,
         ShipCombatPacketAnnouncerMessage = 34,
         ShipCombatPacketCameraConfig = 13,
         ShipCombatPacketCreateProxiedPickup = 28,
         ShipCombatPacketCreateProxiedShip = 9,
         ShipCombatPacketCreateProxiedStructure = 31,
         ShipCombatPacketDespawnProjectile = 27,
         ShipCombatPacketDestroyProxiedPickup = 29,
         ShipCombatPacketDestroyProxiedShip = 10,
         ShipCombatPacketDestroyProxiedStructure = 32,
         ShipCombatPacketFireAtLocation = 20,
         ShipCombatPacketMarkTreasurePickups = 30,
         ShipCombatPacketPlayerAwards = 24,
         ShipCombatPacketPlaySound = 25,
         ShipCombatPacketRefreshUI = 4,
         ShipCombatPacketRegisterShipPlayer = 5,
         ShipCombatPacketRemoveShipPlayer = 6,
         ShipCombatPacketRenderDebugData = 35,
         ShipCombatPacketResetProxiedShip = 11,
         ShipCombatPacketSelectShip = 21,
         ShipCombatPacketSetPlayerCount = 7,
         ShipCombatPacketShipHit = 23,
         ShipCombatPacketSpawnProjectile = 26,
         ShipCombatPacketSpecialMove = 22,
         ShipCombatPacketUpdateGameState = 2,
         ShipCombatPacketUpdatePlayer = 8,
         ShipCombatPacketUpdatePlayerGameStates = 3,
         ShipCombatPacketUpdatePlayerState = 17,
         ShipCombatPacketUpdateProxiedStructure = 33,
         ShipCombatPacketUpdateShipCannons = 19,
         ShipCombatPacketUpdateShipPhysics = 16,
         ShipCombatPacketUpdateWorldForces = 18,
         ShipCombatPacketZoneConfig = 12
    };

    public enum BaseSnsIntegrationPackets
    {
         SnsIntegrationFirstTimeLogin = 2,
         SnsIntegrationGuildCreated = 3,
         SnsIntegrationMaxLevelReached = 5,
         SnsIntegrationSecureSignatureRequest = 6,
         SnsIntegrationSecureSignatureResponse = 1
    };

    public enum BaseSoccerPackets
    {
         SoccerPacketAcquireBall = 11,
         SoccerPacketAcquirePickUp = 10,
         SoccerPacketBallBounce = 25,
         SoccerPacketFreeBall = 12,
         SoccerPacketGoalMade = 2,
         SoccerPacketHighArcBall = 18,
         SoccerPacketImpulseBall = 13,
         SoccerPacketPlayerVariableStats = 19,
         SoccerPacketRegisterPlayer = 3,
         SoccerPacketSendAIInfo = 24,
         SoccerPacketSetClientConfig = 7,
         SoccerPacketSetPlayerTeam = 6,
         SoccerPacketSetSoccerPlayerOneTimeStats = 21,
         SoccerPacketSpawnPickUp = 9,
         SoccerPacketSpecialAnimTime = 22,
         SoccerPacketStatRollInfo = 17,
         SoccerPacketTeamColours = 8,
         SoccerPacketUpdateGameState = 5,
         SoccerPacketUpdateGameTime = 23,
         SoccerPacketUpdatePlayerControls = 16,
         SoccerPacketUpdatePlayerPos = 1,
         SoccerPacketUpdatePlayerState = 14,
         SoccerPacketUpdatePlayerStats = 15,
         SoccerPacketUpdateSoccerBall = 4
    };

    public enum BaseSocialSharePackets
    {
         SocialSharePacketGetProviderStatusRequest = 1,
         SocialSharePacketGetProviderStatusResponse = 2,
         SocialSharePacketPublishRequest = 3,
         SocialSharePacketPublishResponse = 4
    };

    public enum BaseTradePackets
    {
         TradeAcceptPacket = 6,
         TradeCancelPacket = 7,
         TradeCoinCountPacket = 10,
         TradeConfirmPacket = 18,
         TradeEndSessionPacket = 5,
         TradeInvitePacket = 2,
         TradeInviteReplyPacket = 3,
         TradeItemRemovedPacket = 19,
         TradeLockPacket = 8,
         TradeMessagePacket = 15,
         TradeOfferItemPacket = 9,
         TradeRejectedPacket = 16,
         TradeStartSessionPacket = 4,
         TradeUpdateAcceptPacket = 14,
         TradeUpdateAddItemPacket = 12,
         TradeUpdateCoinCountPacket = 11,
         TradeUpdateItemCountPacket = 13,
         TradeUpdateLockPacket = 17
    };

    public enum BaseUiPackets
    {
        // BaseTaskPacket = -1,
        

         CinematicStartLookAtPacket = 16,
         ExecuteScriptPacket = 7,
         ExecuteScriptWithStringParamsPacket = 8,
         LoadingScreenPacket = 9,
         ObjectiveTargetUpdatePacket = 14,
         SelectedQuestLockedPacket = 13,
         SelectQuestPacket = 12,
         SelectTaskRequest = 6,
         StartTimerPacket = 10,
         UiMessagePacket = 15
    };

    public enum BaseTaskPackets
    {
        TaskAddPacket = 1,
        TaskCompletePacket = 3,
        TaskFailPacket = 4,
        TaskUpdatePacket = 2
    };

    public enum BaseVehicleDemolitionDerbyPackets
    {
         VehicleDemolitionDerbyPacketAnnouncerMessage = 20,
         VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby = 10,
         VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup = 12,
         VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerby = 8,
         VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerbyPickup = 13,
         VehicleDemolitionDerbyPacketItemExpired = 17,
         VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby = 9,
         VehicleDemolitionDerbyPacketPickupHitRequest = 14,
         VehicleDemolitionDerbyPacketPickupHitResponse = 15,
         VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer = 6,
         VehicleDemolitionDerbyPacketResetProxiedVehicleDemolitionDerby = 18,
         VehicleDemolitionDerbyPacketSetDerbyConfig = 19,
         VehicleDemolitionDerbyPacketUpdateNpcCount = 4,
         VehicleDemolitionDerbyPacketUpdatePlayerCount = 3,
         VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData = 5,
         VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyStateData = 11,
         VehicleDemolitionDerbyPacketUpdateVehicleGamePlayerState = 2,
         VehicleDemolitionDerbyPacketUpdateVehicleGameState = 1,
         VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus = 7,
         VehicleDemolitionDerbyPacketVehicleHit = 16
    };

    public enum BaseVehicleLoadoutPackets
    {
         VehicleRefreshConfigsPacket = 3,
         VehicleUpdateConfigPacket = 1,
         VehicleUpdateItemPacket = 2
    };

    public enum BaseVehiclePartPackets
    {
         VehiclePartPacketRequestRemovePartFromSlot = 6,
         VehiclePartPacketRequestSelectVehicle = 5,
         VehiclePartPacketRequestVehicleConfig = 1,
         VehiclePartPacketRequestVehicleEquipmentArrayUpdate = 3,
         VehiclePartPacketVehicleConfig = 2,
         VehiclePartPacketVehicleUpdateDecal = 4
    };

    public enum BaseVehicleRacePackets
    {
         VehicleRacePacketBoostAwardRequest = 22,
         VehicleRacePacketBoostAwardResponse = 23,
         VehicleRacePacketCreateProxiedVehicleRace = 11,
         VehicleRacePacketCreateProxiedVehicleRaceExplosion = 27,
         VehicleRacePacketCreateProxiedVehicleRaceMine = 29,
         VehicleRacePacketCreateProxiedVehicleRaceMissile = 24,
         VehicleRacePacketCreateProxiedVehicleRacePickup = 15,
         VehicleRacePacketDestroyProxiedVehicleRace = 12,
         VehicleRacePacketDestroyProxiedVehicleRaceExplosion = 28,
         VehicleRacePacketDestroyProxiedVehicleRaceMine = 30,
         VehicleRacePacketDestroyProxiedVehicleRaceMissile = 25,
         VehicleRacePacketDestroyProxiedVehicleRacePickup = 16,
         VehicleRacePacketGateHit = 7,
         VehicleRacePacketItemExpired = 21,
         VehicleRacePacketKickProxiedVehicleRace = 13,
         VehicleRacePacketPickupHitRequest = 17,
         VehicleRacePacketPickupHitResponse = 18,
         VehicleRacePacketRegisterVehicleRacePlayer = 9,
         VehicleRacePacketResetNpcsRequest = 32,
         VehicleRacePacketResetProxiedVehicleRace = 33,
         VehicleRacePacketSetRaceConfig = 34,
         VehicleRacePacketUpdateNpcCount = 4,
         VehicleRacePacketUpdatePlayerCount = 3,
         VehicleRacePacketUpdateVehicleGamePlayerState = 2,
         VehicleRacePacketUpdateVehicleGameState = 1,
         VehicleRacePacketUpdateVehicleRaceClientData = 5,
         VehicleRacePacketUpdateVehicleRaceMineData = 31,
         VehicleRacePacketUpdateVehicleRaceMissileData = 26,
         VehicleRacePacketUpdateVehicleRaceProgressData = 14,
         VehicleRacePacketUpdateVehicleRaceServerData = 6,
         VehicleRacePacketUseItemRequest = 19,
         VehicleRacePacketUseItemResponse = 20,
         VehicleRacePacketVehicleHit = 8,
         VehicleRacePacketVehicleRaceCountdownStatus = 10
    };

    public enum ClientActivityLaunchBasePackets
    {
         ClientActivityLaunchPacketActivityCanceled = 6,
         ClientActivityLaunchPacketActivityLaunched = 5,
         ClientActivityLaunchPacketAddMember = 7,
        // ClientActivityLaunchPacketInviteDetails<SoeUtil::List<ClientActivityLaunchMember,-1>> = 1,
        // ClientActivityLaunchPacketInviteDetails<SoeUtil::List<ClientActivityLaunchPacketMember,-1>> = 1,
         ClientActivityLaunchPacketInviteMemberReply = 2,
         ClientActivityLaunchPacketInviteMemberRequest = 20,
         ClientActivityLaunchPacketInviteMemberResult = 3,
         ClientActivityLaunchPacketInviteResponse = 17,
         ClientActivityLaunchPacketKickMemberEvent = 13,
         ClientActivityLaunchPacketKickMemberRequest = 21,
         ClientActivityLaunchPacketMemberQuit = 19,
         ClientActivityLaunchPacketMemberReady = 18,
         ClientActivityLaunchPacketOnMatchmakingCancel = 16,
         ClientActivityLaunchPacketOnMatchmakingLaunch = 15,
         ClientActivityLaunchPacketOnMatchmakingStart = 14,
         ClientActivityLaunchPacketOwnerLaunchRequest = 22,
         ClientActivityLaunchPacketOwnerMatchmakingRequest = 23,
         ClientActivityLaunchPacketPlayerHasBeenAccepted = 4,
         ClientActivityLaunchPacketRemoveMember = 8,
         ClientActivityLaunchPacketUpdateMemberState = 8
    };

    public enum ClientPathBasePackets
    {
         ClientPathReplyPacket = 2,
         ClientPathRequestPacket = 1
    };

    //public enum EncounterMatchmaking::BaseMatchmakingPackets
    //{
    //     EncounterMatchmaking::ListQueuesRequestPacket = 1,
    //     EncounterMatchmaking::ListQueuesResponsePacket = 2,
    //     EncounterMatchmaking::AddMatchRequestPacket = 3,
    //     EncounterMatchmaking::AddMatchRequestResponsePacket = 4,
    //     EncounterMatchmaking::ClearMatchRequestPacket = 5, 
    //     EncounterMatchmaking::CancelMatchRequestPacket = 6,
    //     EncounterMatchmaking::MatchInvitationRequestPacket = 7,
    //     EncounterMatchmaking::MatchInvitationResponsePacket = 8,
    //     EncounterMatchmaking::SelectQueueForUserPacket = 9,
    //     EncounterMatchmaking::QueueStatsRequestPacket = 10,
    //     EncounterMatchmaking::QueueStatsResponsePacket = 11,
    //     EncounterMatchmaking::MatchmakingServerStatusPacket = 12,
    //     EncounterMatchmaking::RemoveParticipantFromQueueResponsePacket = 13,
    //}

    public enum JobCustomizationBasePackets
    {
         BegingJobCustomizationPacket = 1,
         FinalizeJobCustomizationPacket = 2
    };

    public enum MountBasePackets
    {
         PacketMountRequest = 1,
         PacketMountResponse = 2,
         PacketDismountRequest = 3,
         PacketDismountResponse = 4,
         PacketMountList = 5,
         PacketMountSpawn = 6,
         PacketMountSpawnByItemDefinitionID = 8,
         PacketSetAutomount = 9,
         PacketMountStartTrial = 10,
         PacketMountEndTrial = 11,
         PacketMountTrialFailed = 13,
         PacketMountUpgradeRequest = 14,
         PacketMountUpgradeResponse = 15
    };

    public enum MysteryChestBasePackets
    {
         MysteryChestInfoRequestPacket = 1,
         MysteryChestInfoReplyPacket = 2
    };

    //public enum NameChange::BaseNameChangePacket
    //{
    //     NameChange::CheckNamePacket = 1,
    //     NameChange::CheckNameResponsePacket = 2,
    //     NameChange::ChangeNameRequestPacket = 3,
    //     NameChange::NameChangeResponsePacket = 4,
    //     NameChange::ChangeNameRequestStatusPacket = 5,
    //     NameChange::CheckNameStatusResponsePacket = 6,
    //}

    public enum NudgeBasePackets
    {
         NudgeUpdatePacket = 4
    };

    public enum PacketBaseInGamePurchases
    {
         PacketInGamePurchaseGiftNotification = 0,
        // PacketInGamePurchasePreviewOrder<GameCommerce::ClientInGamePurchaseOrder> = 1,
         PacketInGamePurchasePreviewOrderResponse = 2,
        // PacketInGamePurchasePlaceOrderPacket<GameCommerce::ClientInGamePurchaseOrder> = 3,
         PacketInGamePurchasePlaceOrderResponse = 4,
         PacketInGamePurchaseStoreBundleBase = 5,
         PacketInGamePurchaseStoreBundleCategoryGroups = 6,
         PacketInGamePurchaseStoreBundleCategories = 7,
        // PacketInGamePurchaseExclusivePartnerStoreBundles<SoeUtil::HashList<AppStoreBundleDefinition,32,-1>> = 8,
         PacketInGamePurchaseStoreBundleGroups = 9,
         PacketInGamePurchaseWalletInfoRequest = 10,
         PacketInGamePurchaseWalletInfoResponse = 11,
         PacketInGamePurchaseServerStatusRequest = 12,
         PacketInGamePurchaseServerStatusResponse = 13,
         PacketInGamePurchaseStationCashProductsRequest = 14,
         PacketInGamePurchaseStationCashProductsResponse = 15,
         PacketInGamePurchaseCurrencyCodesRequest = 16,
         PacketInGamePurchaseCurrencyCodesResponse = 17,
         PacketInGamePurchaseStateCodesRequest = 18,
         PacketInGamePurchaseStateCodesResponse = 19,
         PacketInGamePurchaseCountryCodesRequest = 20,
         PacketInGamePurchaseCountryCodesResponse = 21,
         PacketInGamePurchaseSubscriptionProductsRequest = 22,
         PacketInGamePurchaseSubscriptionProductsResponse = 23,
         PacketInGamePurchaseEnableMarketplace = 24,
         PacketInGamePurchaseAccountInfoRequest = 25,
         PacketInGamePurchaseAccountInfoResponse = 26,
         PacketInGamePurchaseStoreBundleContentRequest = 27,
         PacketInGamePurchaseStoreBundleContentResponse = 28,
        // PacketInGamePurchaseStoreClientStatistics<GameCommerce::ClientInGamePurchaseOrder> = 29,
         PacketInGamePurchaseDisplayMannequinStoreBundles = 31,
        // PacketInGamePurchaseIOTD<AppStoreBundleDefinition> = 32,
         PacketInGamePurchaseStoreEnablePaymentSources = 33,
        // PacketInGamePurchasePlaceOrderClientTicket<GameCommerce::ClientInGamePurchaseOrder> = 36,
         InGamePurchaseUpdateItemRequirementsRequest = 38,
         InGamePurchaseUpdateItemRequirementsReply = 39,
         InGamePurchaseUpdateSaleDisplay = 40,
        // PacketInGamePurchaseBOTD<AppStoreBundleDefinition> = 41,
         InGamePurchaseMerchantListPacket = 42,
         InGamePurchaseBuyBundleFromMerchantRequest = 43,
         InGamePurchaseBuyBundleFromMerchantResponse = 44,
         InGamePurchaseUpdateMerchantSellBundleQuantityAvailableForPurchase = 45
    };

    public enum PacketInGamePurchaseStoreBundleBases
    {
        // PacketInGamePurchaseStoreBundles<AppStoreBundleDefinition> = 1,
        // PacketInGamePurchaseStoreBundleUpdate<AppStoreBundleDefinition> = 2,
    };

    public enum PacketInviteAndStartMiniGamePackets
    {
         PacketInviteAndStartMiniGameInvitePacket = 1,
         PacketInviteAndStartMiniGameStartGamePacket = 3
    };

    public enum PetBasePackets
    {
         PetDecisionPacket = 1,
         PetResponsePacket = 2,
         PetStatusPacket = 3,
         PetSummonRecallPacket = 4,
         PetListPacket = 5,
         PetRequestNamePacket = 6,
         PetPerformTrickPacket = 7,
         PetTrickGestureResult = 8,
         PetActivePacket = 9,
         PetSetNamePacket = 10,
         PetEquipPacket = 11,
         PetTrickSkillLevelPacket = 12,
         PetTrickAddPacket = 13,
         PetTrickFavoriteSetPacket = 14,
         PetTrickNotifyPacket = 15,
         PetUtilityPacket = 16,
         PetDeletePacket = 17,
         PetUtilityGroomPacket = 18,
         PetUtilityFeedPacket = 19,
         PetUtilityNotifyPacket = 20,
         PetUpdateUtilityItemChangePacket = 21,
         PetTactileNotify = 22,
         PetExpireTimePacket = 23,
         PetUiModePacket = 24,
         PetBuyRequestPacket = 25,
         PetCanGoLocationPacket = 26,
         PetInWaterPacket = 28,
         PetTempLockoutError = 29,
         PetWorldToClientBuyResponse = 31,
         PetSummonByItemIdPacket = 32,
         PetPlayWithToyPacket = 33,
         PetMoodListPacket = 34,
         PetEquipByItemRecordPacket = 35,
         PetPacketOfferUpsell = 36,
         PetPreviewRequestPacket = 38
    };

    public enum PlayerUpdatePacketUpdatePositions
    {
         PlayerUpdatePacketUpdatePositionOnPlatform = 185
    };

    public enum ReferenceDataPackets
    {
         ReferenceDataPacketItemClassDefinitions = 1,
         ReferenceDataPacketItemCategoryDefinitions = 2,
         ReferenceDataPacketClientProfileData = 3
    };

    public enum RewardBasePackets
    {
         RewardBundlePacket = 1,
         RewardNonBundledItem = 2,
         RewardPacketNonMemberRewardDeferred = 6,
         RewardPacketNonMemberRewardGranted = 7
    };

    public enum WallOfDataBasePackets
    {
         WallOfDataPlayerKeyboardPacket = 2,
         WallOfDataPlayerClickMovePacket = 3,
         WallOfDataUIEventPacket = 4,
         WallOfDataMembershipPurchasePacket = 5,
         WallOfDataWalletBalancePacket = 6
    };

    public enum ClientGatewayBasePackets
    {
         PacketLogin = 1,
         PacketLoginReply = 2,
         PacketLogout = 3,
         PacketServerForcedLogout = 4,
         PacketTunneledClientPacket = 5,
         PacketTunneledClientWorldPacket = 6,
         PacketClientIsHosted = 7,
         PacketOnlineStatusRequest = 8,
         PacketOnlineStatusReply = 9,
         PacketTunneledClientGatewayPacket = 10
    };


    public enum RemoteAssetDeliveryBasePackets
    {
         AssetRequestPacket = 1,
         ManifestRequestPacket = 2,
         ManifestCrcRequestPacket = 3,
         AssetDataPacket = 4,
         AssetErrorPacket = 5,
         ManifestDataPacket = 6,
         ManifestCrcDataPacket = 7
    };
}