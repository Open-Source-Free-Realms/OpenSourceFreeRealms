using System.Collections.Generic;

namespace Gateway
{
    public class BaseItemStatDefinition
    {
        public int Unknown { get; set; }
        public int Unknown2 { get; set; }
    }

    public class ClientItemStatDefinition : BaseItemStatDefinition
    {
        public int Unknown3 { get; set; }
        public bool Unknown4 { get; set; }
    }

    public class IconData
    {
        public int Id { get; set; }
        public int TintId { get; set; }
    }

    public class BaseItemDefinition
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public int DescriptionId { get; set; }
        public IconData IconData { get; set; }
        public int Tint { get; set; } //Tint
        public int Unknown5 { get; set; }
        public int Cost { get; set; }
        public int Class { get; set; }
        public int ProfileOverride { get; set; }
        public int Slot { get; set; }
        public bool NoTrade { get; set; }
        public bool NoSale { get; set; }
        public string ModelName { get; set; }
        public string TextureAlias { get; set; }
        public int GenderUsage { get; set; }
        public int Type { get; set; }
        public int CategoryId { get; set; }
        public bool MembersOnly { get; set; }
        public bool NonMiniGame { get; set; }
        public int WeaponTrailEffectId { get; set; }
        public int CompositeEffectId { get; set; }
        public int PowerRating { get; set; }
        public int MinProfileRank { get; set; }
        public int Rarity { get; set; }
        public int ActivatableAbilityId { get; set; }
        public int PassiveAbilityId { get; set; }
        public bool SingleUse { get; set; }
        public int MaxStackSize { get; set; }
        public bool IsTintable { get; set; }
        public string TintAlias { get; set; }
        public bool ForceDisablePreview { get; set; }
        public int MemberDiscount { get; set; }
        public int VipRankRequired { get; set; }
        public int RaceSetId { get; set; }
        public int ClientEquipReqSetId { get; set; }
    }

    public class ItemAbilityEntry
    {
        public int Unknown { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int Unknown4 { get; set; }
    }

    public class ClientItemDefinition : BaseItemDefinition
    {
        public int ResellValue { get; set; }
        public int Unknown36 { get; set; }
        public int Unknown37 { get; set; }
        public int Unknown38 { get; set; }

        public Dictionary<int, ClientItemStatDefinition> ClientItemStatDefinitions { get; set; }
        public List<ItemAbilityEntry> ItemAbilityEntries { get; set; }
    }

    public class PointOfInterestDefinition
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public int LocationId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Heading { get; set; }
        public int IconId { get; set; }
        public int NotificationType { get; set; }
        public int SubNameId { get; set; }
        public int Unknown11 { get; set; }
        public int BreadCrumbQuestId { get; set; }
        public int TeleportLocationId { get; set; }
        public int Unknown15 { get; set; }
        public string AtlasName { get; set; }
    }
    public class ActivePet
    {
        public int PetId { get; set; }
        public ulong PetGUID { get; set; }
        public int PetState { get; set; }
        public float[] Position { get; set; } = new float[4];
        public float[] Rotation { get; set; } = new float[4];
    }
}