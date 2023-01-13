using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Gateway.Login
{
    public static class ClientPcData
    {

        public static byte[] ReadFromPcData(ClientPcDatas clientPcData)
        {
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);

            bw.Write(clientPcData.Unknown);
            bw.Write(clientPcData.PlayerGUID);
            bw.Write(clientPcData.PlayerModel);
            WriteString(bw, clientPcData.PlayerHead);
            WriteString(bw, clientPcData.PlayerHair);
            bw.Write(clientPcData.HairColor);
            bw.Write(clientPcData.EyeColor);
            WriteString(bw, clientPcData.Skintone);
            WriteString(bw, clientPcData.FacePaint);
            WriteString(bw, clientPcData.HumanBeardsPixieWings);
            bw.Write(clientPcData.Unknown11);
            bw.Write(clientPcData.Unknown12);
            bw.Write(clientPcData.Unknown13);
            bw.Write(clientPcData.Unknown14);
            bw.Write(clientPcData.Unknown15);

            for (var i = 0; i < clientPcData.PlayerPosition.Length; i++)
                bw.Write(clientPcData.PlayerPosition[i]);

            for (var i = 0; i < clientPcData.CameraRotation.Length; i++)
                bw.Write(clientPcData.CameraRotation[i]);

            bw.Write(clientPcData.Unknown24);
            bw.Write(clientPcData.Unknown25);
            bw.Write(clientPcData.Unknown26);
            WriteString(bw, clientPcData.FirstName);
            WriteString(bw, clientPcData.LastName);
            bw.Write(clientPcData.Coins);
            bw.Write(clientPcData.AccountBirthday);
            bw.Write(clientPcData.AccountAge);
            bw.Write(clientPcData.AccountPlayTime);
            bw.Write(clientPcData.Unknown33);
            bw.Write(clientPcData.Unknown34);
            bw.Write(clientPcData.MembershipStatus);
            bw.Write(clientPcData.Unknown36);
            bw.Write(clientPcData.Unknown37);
            bw.Write(clientPcData.Unknown38);
            bw.Write(clientPcData.Unknown39);
            bw.Write(clientPcData.Unknown40);
            bw.Write(clientPcData.Unknown41);
            bw.Write(clientPcData.Unknown42);
            bw.Write(clientPcData.Unknown43);
            bw.Write(clientPcData.Unknown44);

            bw.Write(clientPcData.ClientPcProfiles.Count);

            foreach (var clientPcProfile in clientPcData.ClientPcProfiles)
            {
                bw.Write(clientPcProfile.JobGUID);
                bw.Write(clientPcProfile.JobName);
                bw.Write(clientPcProfile.JobDescription);
                bw.Write(clientPcProfile.EnableAbility);
                bw.Write(clientPcProfile.JobIcon);
                bw.Write(clientPcProfile.Unknown6);
                bw.Write(clientPcProfile.JobBadgeBorder);
                bw.Write(clientPcProfile.JobBadge);
                bw.Write(clientPcProfile.MembersOnly);
                bw.Write(clientPcProfile.IsCombat);

                bw.Write(clientPcProfile.ItemClassData.Count);

                foreach (var itemClassData in clientPcProfile.ItemClassData)
                {
                    bw.Write(itemClassData.Item1);
                    bw.Write(itemClassData.Item2.Unknown);
                    bw.Write(itemClassData.Item2.Unknown2);
                }

                bw.Write(clientPcProfile.Unknown11);
                bw.Write(clientPcProfile.Unknown12);
                bw.Write(clientPcProfile.Unknown13);
                bw.Write(clientPcProfile.Unknown14);
                bw.Write(clientPcProfile.Unknown15);
                bw.Write(clientPcProfile.JobLevel);
                bw.Write(clientPcProfile.JobLevelXP);
                bw.Write(clientPcProfile.JobLevelTotalXP);
                bw.Write(clientPcProfile.Unknown19);
                bw.Write(clientPcProfile.Unknown20);

                bw.Write(clientPcProfile.Items.Count);

                foreach (var profileItem in clientPcProfile.Items)
                {
                    bw.Write(profileItem.Item1);
                    bw.Write(profileItem.Item2.ItemGUID);
                    bw.Write(profileItem.Item2.Category);

                }

                bw.Write(clientPcProfile.Unknown21);

                bw.Write(clientPcProfile.AbilitySet.Capacity);

                foreach (var abilitySet in clientPcProfile.AbilitySet)
                {
                    bw.Write(abilitySet.Unknown);

                    if (abilitySet.Unknown != 0)
                    {
                        if (abilitySet.Unknown == 1 || abilitySet.Unknown == 3)
                        {
                            bw.Write(abilitySet.Unknown2);
                            bw.Write(abilitySet.Unknown3);
                        }
                        else if (abilitySet.Unknown == 2)
                        {
                            bw.Write(abilitySet.Unknown4);
                        }

                        bw.Write(abilitySet.Unknown5);
                        bw.Write(abilitySet.Unknown6);
                        bw.Write(abilitySet.Unknown7);
                        bw.Write(abilitySet.Unknown8);
                        bw.Write(abilitySet.Unknown9);
                        bw.Write(abilitySet.Unknown10);
                        bw.Write(abilitySet.Unknown11);
                        bw.Write(abilitySet.Unknown12);
                    }
                }

                //bw.Write(clientPcProfile.UnknownSet.Capacity);

                foreach (var unknownSet1 in clientPcProfile.UnknownSet)
                {
                    bw.Write(unknownSet1.Unknown);

                    if (unknownSet1.Unknown == 0)
                        break;

                    bw.Write(unknownSet1.Unknown2);
                    bw.Write(unknownSet1.Unknown3);
                    bw.Write(unknownSet1.Unknown4);
                    bw.Write(unknownSet1.Unknown5);
                    bw.Write(unknownSet1.Unknown6);
                    bw.Write(unknownSet1.Unknown7);
                    bw.Write(unknownSet1.Unknown8);
                    bw.Write(unknownSet1.Unknown9);
                    bw.Write(unknownSet1.Unknown10);
                }
            }

            bw.Write(clientPcData.Class);

            bw.Write(clientPcData.Unknown2List.Count);

            foreach (var unknownSet2 in clientPcData.Unknown2List)
            {
                bw.Write(unknownSet2.Unknown);
                bw.Write(unknownSet2.Unknown2);
            }

            bw.Write(clientPcData.PlayerCollections.Count);

            foreach (var unknownSet3 in clientPcData.PlayerCollections)
            {
                bw.Write(unknownSet3.Unknown);
                bw.Write(unknownSet3.Unknown2);
                bw.Write(unknownSet3.Unknown3);
                bw.Write(unknownSet3.Unknown4);
                bw.Write(unknownSet3.IconData.Unknown);
                bw.Write(unknownSet3.IconData.Unknown2);
                bw.Write(unknownSet3.Unknown5);
                unknownSet3.RewardBundle.Serialize(bw);
                bw.Write(unknownSet3.Unknown4List.Count);

                foreach (var unknownSet4 in unknownSet3.Unknown4List)
                {
                    bw.Write(unknownSet4.Item1);
                    bw.Write(unknownSet4.Item2.Unknown);
                    bw.Write(unknownSet4.Item2.Unknown2);
                    bw.Write(unknownSet4.Item2.Unknown3);
                    bw.Write(unknownSet4.Item2.Unknown4);
                    bw.Write(unknownSet4.Item2.IconData.Unknown);
                    bw.Write(unknownSet4.Item2.IconData.Unknown2);
                    bw.Write(unknownSet4.Item2.Unknown5);
                    bw.Write(unknownSet4.Item2.Unknown6);
                }
            }

            bw.Write(clientPcData.ClientItems.Count);

            foreach (var clientItems in clientPcData.ClientItems)
            {

                bw.Write(clientItems.Definition);
                bw.Write(clientItems.Tint);
                bw.Write(clientItems.Guid);
                bw.Write(clientItems.Count);
                bw.Write(clientItems.ConsumedCount);
                bw.Write(clientItems.LastCastTime);

                bw.Write(clientItems.ItemStruct.HasItemStruct);

                if (clientItems.ItemStruct.HasItemStruct)
                {
                    bw.Write(clientItems.ItemStruct.RentalExpirationTime);
                    bw.Write(clientItems.ItemStruct.RentalUpsellsSent);
                    bw.Write(clientItems.ItemStruct.MarketplaceBundleId);
                }

                bw.Write(clientItems.Unknown);
                bw.Write(clientItems.Unknown2);

            }

            bw.Write(clientPcData.GenderFilter);
            bw.Write(clientPcData.ClientQuestData.ClientQuests.Count);

            foreach (var clientQuests in clientPcData.ClientQuestData.ClientQuests)
            {
                bw.Write(clientQuests.Unknown);
                bw.Write(clientQuests.Unknown2);
                bw.Write(clientQuests.Unknown3);
                bw.Write(clientQuests.Unknown4);
                bw.Write(clientQuests.Unknown5);
                bw.Write(clientQuests.Unknown6);
                bw.Write(clientQuests.Unknown7);
                bw.Write(clientQuests.Unknown8);
                bw.Write(clientQuests.Unknown9);
                clientQuests.RewardBundle.Serialize(bw);
                bw.Write(clientQuests.QuestObjectives.Count);

                foreach (var questObjectives in clientQuests.QuestObjectives)
                {
                    bw.Write(questObjectives.Item1);
                    bw.Write(questObjectives.Item2.Unknown);
                    bw.Write(questObjectives.Item2.Unknown2);
                    bw.Write(questObjectives.Item2.Unknown3);
                    bw.Write(questObjectives.Item2.Unknown4);
                    questObjectives.Item2.RewardBundle.Serialize(bw);
                    bw.Write(questObjectives.Item2.Unknown5);
                    bw.Write(questObjectives.Item2.Unknown6);
                    bw.Write(questObjectives.Item2.Unknown7);
                    bw.Write(questObjectives.Item2.Unknown8);
                    bw.Write(questObjectives.Item2.Unknown9);
                    bw.Write(questObjectives.Item2.Unknown10);

                }
                bw.Write(clientQuests.Unknown10);
                bw.Write(clientQuests.Unknown11);
                bw.Write(clientQuests.Unknown12);
            }

            bw.Write(clientPcData.ClientQuestData.Unknown);
            bw.Write(clientPcData.ClientQuestData.Unknown2);
            bw.Write(clientPcData.ClientQuestData.Unknown3);
            bw.Write(clientPcData.ClientQuestData.Unknown4);
            bw.Write(clientPcData.ClientQuestData.Unknown5);
            bw.Write(clientPcData.ClientAchievementData.ClientAchievements.Count);

            foreach (var clientAchievements in clientPcData.ClientAchievementData.ClientAchievements)
            {
                bw.Write(clientAchievements.Unknown);
                bw.Write(clientAchievements.Unknown2);
                bw.Write(clientAchievements.Unknown3);
                bw.Write(clientAchievements.Unknown4);
                bw.Write(clientAchievements.Unknown5);
                bw.Write(clientAchievements.Unknown6);
                bw.Write(clientAchievements.Unknown7);
                clientAchievements.RewardBundle.Serialize(bw);
                bw.Write(clientAchievements.AchievementObjectives.Count);

                foreach (var achievementObjectives in clientAchievements.AchievementObjectives)
                {
                    bw.Write(achievementObjectives.Item1);
                    bw.Write(achievementObjectives.Item2.Unknown);
                    bw.Write(achievementObjectives.Item2.Unknown2);
                    bw.Write(achievementObjectives.Item2.Unknown3);
                    bw.Write(achievementObjectives.Item2.Unknown4);
                    achievementObjectives.Item2.RewardBundle.Serialize(bw);
                    bw.Write(achievementObjectives.Item2.Unknown5);
                    bw.Write(achievementObjectives.Item2.Unknown6);
                    bw.Write(achievementObjectives.Item2.Unknown7);
                    bw.Write(achievementObjectives.Item2.Unknown8);
                    bw.Write(achievementObjectives.Item2.Unknown9);
                    bw.Write(achievementObjectives.Item2.Unknown10);
                }

                bw.Write(clientAchievements.IconData.Unknown);
                bw.Write(clientAchievements.IconData.Unknown2);

                bw.Write(clientAchievements.Unknown8);
                bw.Write(clientAchievements.Unknown9);
                bw.Write(clientAchievements.Unknown10);
                bw.Write(clientAchievements.Unknown11);
            }

            bw.Write(clientPcData.ClientAchievementData.Unknown);
            bw.Write(clientPcData.Acquaintances.Count);

            foreach (var acquaintances in clientPcData.Acquaintances)
            {
                bw.Write(acquaintances.PlayerGUID);
                WriteString(bw, acquaintances.PlayerName);
                bw.Write(acquaintances.Unknown3);
                bw.Write(acquaintances.PlayerBirthdate);
                bw.Write(acquaintances.Online);

            }

            bw.Write(clientPcData.Recipes.Count);

            foreach (var recipes in clientPcData.Recipes)
            {

                bw.Write(recipes.Unknown);
                bw.Write(recipes.Unknown2);
                bw.Write(recipes.IconData.Unknown);
                bw.Write(recipes.IconData.Unknown2);
                bw.Write(recipes.Unknown3);
                bw.Write(recipes.Unknown4);
                bw.Write(recipes.Unknown5);
                bw.Write(recipes.Unknown6);
                bw.Write(recipes.ComponentData.Count);

                foreach (var recipeComponent in recipes.ComponentData)
                {
                    bw.Write(recipeComponent.Unknown);
                    bw.Write(recipeComponent.IconData.Unknown);
                    bw.Write(recipeComponent.IconData.Unknown2);
                    bw.Write(recipeComponent.Unknown2);
                    bw.Write(recipeComponent.Unknown3);
                    bw.Write(recipeComponent.Unknown4);
                    bw.Write(recipeComponent.Unknown5);
                    bw.Write(recipeComponent.Unknown6);
                }

                bw.Write(recipes.Unknown7);
                bw.Write(recipes.Unknown8);
                bw.Write(recipes.Unknown9);
            }

            bw.Write(clientPcData.Pets.Count);

            foreach (var pets in clientPcData.Pets)
            {
                pets.Serialize(bw);
            }

            bw.Write(clientPcData.Unknown47);
            bw.Write(clientPcData.Unknown48);
            bw.Write(clientPcData.Mounts.Count);

            foreach (var mounts in clientPcData.Mounts)
            {
                bw.Write(mounts.MountNumber);
                bw.Write(mounts.MountName);
                bw.Write(mounts.MountIcon);
                bw.Write(mounts.MountGUID);
                bw.Write(mounts.MembersOnly);
                bw.Write(mounts.MountColor);
                WriteString(bw, mounts.MountTexture);
                bw.Write(mounts.FlyTraining);
                bw.Write(mounts.AbleToFly);
            }

            bw.Write(clientPcData.ActionBars.Count);

            foreach (var actionBars in clientPcData.ActionBars)
            {
                bw.Write(actionBars.Item1);
                actionBars.Item2.Serialize(bw);
            }

            bw.Write(clientPcData.Unknown49);

            bw.Write(clientPcData.UnknownSet.Count);

            foreach (var unknownSet in clientPcData.UnknownSet)
            {
                bw.Write(unknownSet);
            }

            bw.Write(clientPcData.UnknownSet2.Count);

            foreach (var unknownSet2 in clientPcData.UnknownSet2)
            {
                bw.Write(unknownSet2);
            }

            bw.Write(clientPcData.EffectTags.Count);

            foreach (var effectTags in clientPcData.EffectTags)
            {
                bw.Write(effectTags.Item1);
                effectTags.Item2.Serialize(bw);
            }

            bw.Write(clientPcData.NameChanges.Count);

            foreach (var nameChanges in clientPcData.NameChanges)
            {
                nameChanges.Serialize(bw);
            }

            bw.Write(clientPcData.CharacterStats.Count);

            foreach (var characterStats in clientPcData.CharacterStats)
            {
                bw.Write(characterStats.Item1);
                characterStats.Item2.Serialize(bw);
            }

            clientPcData.VehicleStruct.Serialize(bw);
            clientPcData.PlayerTitleStruct.Serialize(bw);

            bw.Write(clientPcData.VIPLevel);
            bw.Write(clientPcData.Unknown51);
            bw.Write(clientPcData.Unknown52);

            bw.Write(clientPcData.ClientNudges.Count);

            foreach (var clientNudges in clientPcData.ClientNudges)
            {
                clientNudges.Serialize(bw);
            }
            return ms.ToArray();
        }

        private static void WriteString(BinaryWriter bw, string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            bw.Write(bytes.Length);
            bw.Write(bytes);
        }


        public class ClientNudgeData
        {
            // TODO: Unused at the moment.

            public void Serialize(BinaryWriter bw)
            {
            }
        }

        public class PlayerTitleData
        {
            public int Id { get; set; }
            public int Place { get; set; }
            public int TitleName { get; set; }
            public int Unknown4 { get; set; }

            public void Serialize(BinaryWriter bw)
            {
                bw.Write(Id);
                bw.Write(Place);
                bw.Write(TitleName);
                bw.Write(Unknown4);
            }
        }

        public class PlayerTitleStruct
        {
            public List<PlayerTitleData> PlayerTitles { get; set; } = new List<PlayerTitleData>();

            public int Title { get; set; }

            public void Serialize(BinaryWriter bw)
            {
                bw.Write(PlayerTitles.Count);

                foreach (var playerTitles in PlayerTitles)
                {

                    playerTitles.Serialize(bw);

                }
                bw.Write(Title);
            }
        }

        public class VehicleLoadout
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }

            public List<ItemGuid> ItemGuids { get; set; } = new List<ItemGuid>();

            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public bool Unknown6 { get; set; }

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);
                bw.Write(Unknown2);

                bw.Write(ItemGuids.Count);

                foreach (var itemGuid in ItemGuids)
                {
                    bw.Write(itemGuid.Unknown);
                }

                bw.Write(Unknown3);
                bw.Write(Unknown4);
                bw.Write(Unknown5);
                bw.Write(IconData.Unknown);
                bw.Write(IconData.Unknown2);
                bw.Write(Unknown6);
            }
        }

        public class VehicleStruct
        {
            public int Unknown { get; set; }

            public List<(int, VehicleLoadout)> VehicleLoadouts { get; set; } = new List<(int, VehicleLoadout)>();

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);

                bw.Write(VehicleLoadouts.Count);

                foreach (var vehicleLoadouts in VehicleLoadouts)
                {
                    bw.Write(vehicleLoadouts.Item1);

                    vehicleLoadouts.Item2.Serialize(bw);
                }
            }
        }

        public class CharacterStat
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);
                bw.Write(Unknown2);

                if (Unknown2 == 0 || Unknown2 == 1)
                    bw.Write(Unknown3);
            }
        }

        public class NameChangeInfo
        {
            public int Unknown { get; set; }
            public long Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public string Unknown4 { get; set; } = string.Empty;
            public string Unknown5 { get; set; } = string.Empty;

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);
                bw.Write(Unknown2);
                bw.Write(Unknown3);
                WriteString(bw, Unknown4);
                WriteString(bw, Unknown5);
            }
        }

        public class EffectTag
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public bool Unknown8 { get; set; }
            public long Unknown9 { get; set; }
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public int Unknown12 { get; set; }
            public int Unknown13 { get; set; }
            public long Unknown14 { get; set; }
            public int Unknown15 { get; set; }
            public int Unknown16 { get; set; }
            public bool Unknown17 { get; set; }
            public bool Unknown18 { get; set; }
            public bool Unknown19 { get; set; }

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);
                bw.Write(Unknown2);
                bw.Write(Unknown3);
                bw.Write(Unknown4);
                bw.Write(Unknown5);
                bw.Write(Unknown6);
                bw.Write(Unknown7);
                bw.Write(Unknown8);
                bw.Write(Unknown9);
                bw.Write(Unknown10); // Date.Time.Ticks
                bw.Write(Unknown11);
                bw.Write(Unknown12);
                bw.Write(Unknown13);
                bw.Write(Unknown14);
                bw.Write(Unknown15);
                bw.Write(Unknown16);
                bw.Write(Unknown17);
                bw.Write(Unknown18);
                bw.Write(Unknown19);
            }
        }

        public class ClientEffectTag : EffectTag
        {
            public int Unknown20 { get; set; }
            public bool Unknown21 { get; set; }
            public int Unknown22 { get; set; }
            public int Unknown23 { get; set; }

            public override void Serialize(BinaryWriter bw)
            {
                base.Serialize(bw);

                bw.Write(Unknown20);
                bw.Write(Unknown21);
                bw.Write(Unknown22);
                bw.Write(Unknown23);
            }
        }

        public class ActionBarSlot
        {
            public bool ItemEmpty { get; set; }
            public int Icon { get; set; }
            public int Unknown3 { get; set; }
            public int ItemName { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public bool Usable { get; set; }
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public int Unknown12 { get; set; }
            public int ItemQuanity { get; set; }
            public bool Unknown14 { get; set; }
            public int Unknown15 { get; set; }

            public void Serialize(BinaryWriter bw)
            {
                bw.Write(ItemEmpty);
                bw.Write(Icon);
                bw.Write(Unknown3);
                bw.Write(ItemName);
                bw.Write(Unknown5);
                bw.Write(Unknown6);
                bw.Write(Unknown7);
                bw.Write(Unknown8);
                bw.Write(Usable);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
                bw.Write(Unknown12);
                bw.Write(ItemQuanity);
                bw.Write(Unknown14);
                bw.Write(Unknown15);
            }
        }

        public class ClientActionBar
        {
            public int Unknown { get; set; }

            public List<(int, ActionBarSlot)> ActionBarSlots { get; set; } = new List<(int, ActionBarSlot)>();

            public virtual void Serialize(BinaryWriter bw)
            {
                bw.Write(Unknown);
                bw.Write(ActionBarSlots.Count);

                foreach (var actionBarSlots in ActionBarSlots)
                {
                    bw.Write(actionBarSlots.Item1);
                    actionBarSlots.Item2.Serialize(bw);
                }
            }
        }

        public class PacketMountInfo
        {
            public int MountNumber { get; set; }
            public int MountName { get; set; }
            public int MountIcon { get; set; }
            public ulong MountGUID { get; set; }
            public bool MembersOnly { get; set; }
            public int MountColor { get; set; }
            public string MountTexture { get; set; } = string.Empty;
            public bool FlyTraining { get; set; }
            public bool AbleToFly { get; set; }

            public int MountModel { get; set; }
            public string MountTextureType { get; set; } = string.Empty;
        }

        public class PetTrickInfo
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public bool Unknown9 { get; set; }
        }

        public class ItemGuid
        {
            public int Unknown { get; set; }
        }

        public class UnknownPetStruct
        {
            public int PetId { get; set; }
            public bool Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public float Food { get; set; }
            public float Groom { get; set; }
            public float Exercise { get; set; }
            public float Happiness { get; set; }
            public bool Unknown8 { get; set; }

            public List<(int, PetTrickInfo)> PetTricks { get; set; } = new List<(int, PetTrickInfo)>();
            public List<ItemGuid> ItemGuids { get; set; } = new List<ItemGuid>();
            public List<(int, ProfileItemClassData)> ProfileItems { get; set; } = new List<(int, ProfileItemClassData)>();

            public string PetName { get; set; } = string.Empty;
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public string TextureAlias { get; set; } = string.Empty;
            public int IconId { get; set; }
            public bool Unknown14 { get; set; }
            public int Unknown15 { get; set; }
            public bool Unknown16 { get; set; }
            public int[] Unknown17 { get; set; } = new int[4];
            public int[] Unknown18 { get; set; } = new int[8];
            public int ModelId { get; set; }

            public void Serialize(BinaryWriter bw)
            {
                bw.Write(PetId);
                bw.Write(Unknown2);
                bw.Write(Unknown3);
                bw.Write(Food);
                bw.Write(Groom);
                bw.Write(Exercise);
                bw.Write(Happiness);
                bw.Write(Unknown8);

                bw.Write(PetTricks.Count);

                foreach (var petTricks in PetTricks)
                {
                    bw.Write(petTricks.Item1);
                    bw.Write(petTricks.Item2.Unknown);
                    bw.Write(petTricks.Item2.Unknown2);
                    bw.Write(petTricks.Item2.Unknown3);
                    bw.Write(petTricks.Item2.Unknown4);
                    bw.Write(petTricks.Item2.Unknown5);
                    bw.Write(petTricks.Item2.Unknown6);
                    bw.Write(petTricks.Item2.Unknown7);
                    bw.Write(petTricks.Item2.Unknown8);
                    bw.Write(petTricks.Item2.Unknown9);
                }

                bw.Write(ItemGuids.Count);

                foreach (var itemGuids in ItemGuids)
                {
                    bw.Write(itemGuids.Unknown);
                }

                bw.Write(ProfileItems.Count);

                foreach (var profileItems in ProfileItems)
                {
                    bw.Write(profileItems.Item1);
                    bw.Write(profileItems.Item2.Unknown);
                    bw.Write(profileItems.Item2.Unknown2);
                }

                WriteString(bw, PetName);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
                WriteString(bw, TextureAlias);
                bw.Write(IconId);
                bw.Write(Unknown14);
                bw.Write(Unknown15);
                bw.Write(Unknown16);

                for (var i = 0; i < Unknown17.Length; i++)
                    bw.Write(Unknown17[i]);

                for (var i = 0; i < Unknown18.Length; i++)
                    bw.Write(Unknown18[i]);
            }
        }

        public class UnknownItemStruct
        {

            public bool HasItemStruct { get; set; }
            public long RentalExpirationTime { get; set; }
            public int RentalUpsellsSent { get; set; }
            public int MarketplaceBundleId { get; set; }
        }

        public class ItemRecord
        {
            public int Definition { get; set; }
            public int Tint { get; set; }
        }

        public class ItemInstance : ItemRecord
        {
            public int Guid { get; set; }
            public int Count { get; set; }
            public int ConsumedCount { get; set; }
            public int LastCastTime { get; set; }

            public UnknownItemStruct ItemStruct { get; set; } = new UnknownItemStruct();

            public int Unknown { get; set; }
        }

        public class ClientItem : ItemInstance
        {
            public bool Unknown2 { get; set; }
        }

        public class ObjectiveData
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public bool Unknown4 { get; set; }

            public RewardBundleBase RewardBundle { get; set; } = new RewardBundleBase();

            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public bool Unknown9 { get; set; }
            public int Unknown10 { get; set; }
        }

        public class ClientQuest
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public bool Unknown5 { get; set; }
            public long Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public bool Unknown8 { get; set; }
            public int Unknown9 { get; set; }

            public RewardBundleBase RewardBundle { get; set; } = new RewardBundleBase();

            public List<(int, ObjectiveData)> QuestObjectives { get; set; } = new List<(int, ObjectiveData)>();

            public int Unknown10 { get; set; }
            public bool Unknown11 { get; set; }
            public bool Unknown12 { get; set; }
        }

        public class ClientQuestData
        {
            public List<ClientQuest> ClientQuests { get; set; } = new List<ClientQuest>();

            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public bool Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
        }

        public class ClientAchievement
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public bool Unknown4 { get; set; }
            public long Unknown5 { get; set; }
            public long Unknown6 { get; set; }
            public int Unknown7 { get; set; }

            public RewardBundleBase RewardBundle { get; set; } = new RewardBundleBase();

            public List<(int, ObjectiveData)> AchievementObjectives { get; set; } = new List<(int, ObjectiveData)>();

            public IconData IconData { get; set; } = new IconData();

            public int Unknown8 { get; set; }
            public int Unknown9 { get; set; }
            public bool Unknown10 { get; set; }
            public int Unknown11 { get; set; }
        }

        public class ClientAchievementData
        {
            public List<ClientAchievement> ClientAchievements { get; set; } = new List<ClientAchievement>();

            public int Unknown { get; set; }
        }

        public class RecipeComponentData
        {
            public int Unknown { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
        }

        public class RecipeData
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public bool Unknown5 { get; set; }
            public int Unknown6 { get; set; }

            public List<RecipeComponentData> ComponentData { get; set; } = new List<RecipeComponentData>();

            public int Unknown7 { get; set; }
            public bool Unknown8 { get; set; }
            public int Unknown9 { get; set; }
        }

        public class Acquaintance
        {
            public long PlayerGUID { get; set; }
            public string PlayerName { get; set; } = string.Empty;
            public int Unknown3 { get; set; }
            public long PlayerBirthdate { get; set; }
            public bool Online { get; set; }
        }

        public class UnknownStruct4
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public int Unknown5 { get; set; }
            public bool Unknown6 { get; set; }
        }

        public class RewardBundleEntryZoneFlag : RewardBundleEntryBase
        {
            public string Unknown9 { get; set; } = string.Empty;
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                WriteString(bw, Unknown9);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
            }
        }

        public class RewardBundleEntryWheelSpin : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryTrophy : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryToken : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryRecipe : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
            }
        }

        public class RewardBundleEntryQuestAdd : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
            }
        }

        public class RewardBundleEntryProfileAdd : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
            }
        }

        public class RewardBundleEntryPetTrickExperience : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }
            public int Unknown10 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
                bw.Write(Unknown10);
            }
        }

        public class RewardBundleEntryItem : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                if (unknownCheck)
                {
                    bw.Write(Unknown9);
                }
            }
        }

        public class RewardBundleEntryFactoryExperience : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryExperience : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryCollectionEntryAdd : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public int Unknown12 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
                bw.Write(Unknown12);
            }
        }

        public class RewardBundleEntryCollectionAdd : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
            }
        }

        public class RewardBundleEntryClientExitUrl : RewardBundleEntryBase
        {
        }

        public class RewardBundleEntryChest : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                if (unknownCheck)
                {
                    bw.Write(Unknown9);
                }
            }
        }

        public class RewardBundleEntryCharacterFlag : RewardBundleEntryBase
        {
            public string Unknown9 { get; set; } = string.Empty;
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public bool Unknown12 { get; set; }
            public int Unknown13 { get; set; }
            public bool Unknown14 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                WriteString(bw, Unknown9);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
                bw.Write(Unknown12);
                bw.Write(Unknown13);
                bw.Write(Unknown14);
            }
        }

        public class RewardBundleEntryAbilityLine : RewardBundleEntryBase
        {
            public int Unknown9 { get; set; }

            public override void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                base.Serialize(bw, unknownCheck);

                bw.Write(Unknown9);
            }
        }

        public class RewardBundleEntryBase
        {
            public bool Unknown { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public string Unknown6 { get; set; } = string.Empty;
            public int Unknown7 { get; set; }
            public bool Unknown8 { get; set; }

            public virtual void Serialize(BinaryWriter bw, bool unknownCheck = false)
            {
                bw.Write(Unknown);
                bw.Write(IconData.Unknown);
                bw.Write(IconData.Unknown2);
                bw.Write(Unknown2);
                bw.Write(Unknown3);
                bw.Write(Unknown4);
                bw.Write(Unknown5);
                WriteString(bw, Unknown6);
                bw.Write(Unknown7);
                bw.Write(Unknown8);
            }
        }

        public class RewardBundleBase
        {
            public bool Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public int Unknown9 { get; set; }
            public int Unknown10 { get; set; }
            public long Unknown11 { get; set; }
            public long Unknown12 { get; set; }
            public int Unknown13 { get; set; }
            public int Unknown14 { get; set; }

            public List<RewardBundleEntryBase> RewardBundleEntries { get; set; } = new List<RewardBundleEntryBase>();

            public int Unknown15 { get; set; }

            public void Serialize(BinaryWriter bw)
            {

                bw.Write(Unknown);
                bw.Write(Unknown2);
                bw.Write(Unknown3);
                bw.Write(Unknown4);
                bw.Write(Unknown5);
                bw.Write(Unknown6);
                bw.Write(Unknown7);
                bw.Write(Unknown8);
                bw.Write(Unknown9);
                bw.Write(Unknown10);
                bw.Write(Unknown11);
                bw.Write(Unknown12);
                bw.Write(Unknown13);
                bw.Write(Unknown14);

                bw.Write(RewardBundleEntries.Count);

                foreach (var rewardBundleEntry in RewardBundleEntries)
                {
                    if (rewardBundleEntry is RewardBundleEntryItem) bw.Write(1);
                    else if (rewardBundleEntry is RewardBundleEntryExperience) bw.Write(3);
                    else if (rewardBundleEntry is RewardBundleEntryQuestAdd) bw.Write(6);
                    else if (rewardBundleEntry is RewardBundleEntryProfileAdd) bw.Write(7);
                    else if (rewardBundleEntry is RewardBundleEntryAbilityLine) bw.Write(8);
                    else if (rewardBundleEntry is RewardBundleEntryCollectionAdd) bw.Write(10);
                    else if (rewardBundleEntry is RewardBundleEntryCollectionEntryAdd) bw.Write(11);
                    else if (rewardBundleEntry is RewardBundleEntryToken) bw.Write(12);
                    else if (rewardBundleEntry is RewardBundleEntryPetTrickExperience) bw.Write(13);
                    else if (rewardBundleEntry is RewardBundleEntryRecipe) bw.Write(14);
                    else if (rewardBundleEntry is RewardBundleEntryZoneFlag) bw.Write(15);
                    else if (rewardBundleEntry is RewardBundleEntryCharacterFlag) bw.Write(17);
                    else if (rewardBundleEntry is RewardBundleEntryWheelSpin) bw.Write(18);
                    else if (rewardBundleEntry is RewardBundleEntryTrophy) bw.Write(19);
                    else if (rewardBundleEntry is RewardBundleEntryClientExitUrl) bw.Write(20);
                    else if (rewardBundleEntry is RewardBundleEntryFactoryExperience) bw.Write(22);
                    else if (rewardBundleEntry is RewardBundleEntryChest) bw.Write(23);

                    if (rewardBundleEntry is RewardBundleEntryItem || rewardBundleEntry is RewardBundleEntryChest)
                        rewardBundleEntry.Serialize(bw, Unknown);
                    else
                        rewardBundleEntry.Serialize(bw);
                }

                bw.Write(Unknown15);
            }
        }

        public class IconData
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
        }

        public class Collections
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }

            public IconData IconData { get; set; } = new IconData();

            public int Unknown5 { get; set; }

            public RewardBundleBase RewardBundle { get; set; } = new RewardBundleBase();
            public List<(int, UnknownStruct4)> Unknown4List { get; set; } = new List<(int, UnknownStruct4)>();
        }

        public class UnknownStruct2
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
        }

        public class UnknownStruct
        {
            public int Unknown { get; set; }
            public bool Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public int Unknown9 { get; set; }
            public int Unknown10 { get; set; }
        }

        public class Ability
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
            public int Unknown3 { get; set; }
            public int Unknown4 { get; set; }
            public int Unknown5 { get; set; }
            public int Unknown6 { get; set; }
            public int Unknown7 { get; set; }
            public int Unknown8 { get; set; }
            public int Unknown9 { get; set; }
            public int Unknown10 { get; set; }
            public int Unknown11 { get; set; }
            public bool Unknown12 { get; set; }
        }

        public class ProfileItemClassData
        {
            public int Unknown { get; set; }
            public int Unknown2 { get; set; }
        }

        public class ProfileItem
        {
            public int ItemGUID { get; set; }
            public int Category { get; set; }
        }

        public class ClientPcProfile
        {
            public int JobGUID { get; set; }
            public int JobName { get; set; }
            public int JobDescription { get; set; }
            public int EnableAbility { get; set; }
            public int JobIcon { get; set; }
            public int Unknown6 { get; set; }
            public int JobBadgeBorder { get; set; }
            public int JobBadge { get; set; }
            public bool MembersOnly { get; set; }
            public int IsCombat { get; set; }

            public List<(int, ProfileItemClassData)> ItemClassData { get; set; } = new List<(int, ProfileItemClassData)>();

            public bool Unknown11 { get; set; }
            public int Unknown12 { get; set; }
            public int Unknown13 { get; set; }
            public bool Unknown14 { get; set; }
            public int Unknown15 { get; set; }
            public int JobLevel { get; set; }
            public int JobLevelXP { get; set; }
            public int JobLevelTotalXP { get; set; }
            public int Unknown19 { get; set; }
            public int Unknown20 { get; set; }

            public List<(int, ProfileItem)> Items { get; set; } = new List<(int, ProfileItem)>();

            public int Unknown21 { get; set; }

            public List<Ability> AbilitySet { get; set; } = new List<Ability>(8);
            public List<UnknownStruct> UnknownSet { get; set; } = new List<UnknownStruct>(8);
        }

        public class ClientPcDatas
        {
            public long Unknown { get; set; }
            public long PlayerGUID { get; set; }
            public int PlayerModel { get; set; }
            public string PlayerHead { get; set; } = string.Empty;
            public string PlayerHair { get; set; } = string.Empty;
            public int HairColor { get; set; }
            public int EyeColor { get; set; }
            public string Skintone { get; set; } = string.Empty;
            public string FacePaint { get; set; } = string.Empty;
            public string HumanBeardsPixieWings { get; set; } = string.Empty;
            public int Unknown11 { get; set; }
            public int Unknown12 { get; set; }
            public int Unknown13 { get; set; }
            public int Unknown14 { get; set; }
            public int Unknown15 { get; set; }
            public float[] PlayerPosition { get; set; } = new float[4];
            public float[] CameraRotation { get; set; } = new float[4];
            public int Unknown24 { get; set; }
            public int Unknown25 { get; set; }
            public int Unknown26 { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public int Coins { get; set; }
            public long AccountBirthday { get; set; }
            public int AccountAge { get; set; }
            public int AccountPlayTime { get; set; }
            public bool Unknown33 { get; set; }
            public bool Unknown34 { get; set; }
            public int MembershipStatus { get; set; }
            public bool Unknown36 { get; set; }
            public int Unknown37 { get; set; }
            public int Unknown38 { get; set; }
            public int Unknown39 { get; set; }
            public int Unknown40 { get; set; }
            public int Unknown41 { get; set; }
            public bool Unknown42 { get; set; }
            public int Unknown43 { get; set; }
            public int Unknown44 { get; set; }

            public List<ClientPcProfile> ClientPcProfiles { get; set; } = new List<ClientPcProfile>();

            public int Class { get; set; }

            public List<UnknownStruct2> Unknown2List { get; set; } = new List<UnknownStruct2>();
            public List<Collections> PlayerCollections { get; set; } = new List<Collections>();
            public List<ClientItem> ClientItems { get; set; } = new List<ClientItem>();

            public int GenderFilter { get; set; }

            public ClientQuestData ClientQuestData { get; set; } = new ClientQuestData();
            public ClientAchievementData ClientAchievementData { get; set; } = new ClientAchievementData();

            public List<Acquaintance> Acquaintances { get; set; } = new List<Acquaintance>();
            public List<RecipeData> Recipes { get; set; } = new List<RecipeData>();

            public List<UnknownPetStruct> Pets { get; set; } = new List<UnknownPetStruct>();

            public int Unknown47 { get; set; }
            public long Unknown48 { get; set; }

            public List<PacketMountInfo> Mounts { get; set; } = new List<PacketMountInfo>();

            public List<(int, ClientActionBar)> ActionBars { get; set; } = new List<(int, ClientActionBar)>();

            public bool Unknown49 { get; set; }

            public List<int> UnknownSet { get; set; } = new List<int>();
            public List<int> UnknownSet2 { get; set; } = new List<int>();

            public List<(int, ClientEffectTag)> EffectTags { get; set; } = new List<(int, ClientEffectTag)>();

            public List<NameChangeInfo> NameChanges { get; set; } = new List<NameChangeInfo>();

            public List<(int, CharacterStat)> CharacterStats { get; set; } = new List<(int, CharacterStat)>();

            public VehicleStruct VehicleStruct { get; set; } = new VehicleStruct();
            public PlayerTitleStruct PlayerTitleStruct { get; set; } = new PlayerTitleStruct();

            public float VIPLevel { get; set; }
            public int Unknown51 { get; set; }
            public int Unknown52 { get; set; }

            public List<ClientNudgeData> ClientNudges { get; set; } = new List<ClientNudgeData>();
        }
    }
}
