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
        public int Unknown { get; set; }
        public int Unknown2 { get; set; }
    }

    public class BaseItemDefinition
    {
        public int Unknown { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public IconData IconData { get; set; }
        public int Unknown4 { get; set; }
        public int Unknown5 { get; set; }
        public int Unknown6 { get; set; }
        public int Unknown7 { get; set; }
        public int Unknown8 { get; set; }
        public int Unknown9 { get; set; }
        public bool Unknown10 { get; set; }
        public bool Unknown11 { get; set; }
        public string Unknown12 { get; set; }
        public string Unknown13 { get; set; }
        public int Unknown14 { get; set; }
        public int Unknown15 { get; set; }
        public int Unknown16 { get; set; }
        public bool Unknown17 { get; set; }
        public bool Unknown18 { get; set; }
        public int Unknown19 { get; set; }
        public int Unknown20 { get; set; }
        public int Unknown21 { get; set; }
        public int Unknown22 { get; set; }
        public int Unknown23 { get; set; }
        public int Unknown24 { get; set; }
        public int Unknown25 { get; set; }
        public bool Unknown26 { get; set; }
        public int Unknown27 { get; set; }
        public bool Unknown28 { get; set; }
        public string Unknown29 { get; set; }
        public bool Unknown30 { get; set; }
        public int Unknown31 { get; set; }
        public int Unknown32 { get; set; }
        public int Unknown33 { get; set; }
        public int Unknown34 { get; set; }
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
        public int Unknown35 { get; set; }
        public int Unknown36 { get; set; }
        public int Unknown37 { get; set; }
        public int Unknown38 { get; set; }

        public Dictionary<int, ClientItemStatDefinition> ClientItemStatDefinitions { get; set; }
        public List<ItemAbilityEntry> ItemAbilityEntries { get; set; }
    }
}