using System;
using System.Collections.Generic;

namespace MemClass
{
    public class Camos
    {
        private string camo { get; set; }
        public Camos(string camo)
        {
            this.camo = camo;
        }

        private enum CamoList : byte
        {
            GOLD = 61,
            DIAMOND,
            DMU,
            GOLDEN_VIPER,
            PLAGUE_DIAMOND,
            DA,
            PAP1,
            PAP2,
            PAP3,
            PAP4 = 116,
            PAP5,
            PAP6,
            PAP7,
            PAP8,
            PAP9,
            CDL1 = 81,
            CDL2 = 84,
            CDL3 = 87,
            CDL4 = 90,
            CDL5 = 93,
            CDL6 = 96,
            CDL7 = 99,
            CDL8 = 102,
            CDL9 = 105,
            CDL10 = 108,
            CDL11 = 111,
            CDL12 = 114,
        };

        private Dictionary<string, CamoList> list
        {
            get
            {
                return new Dictionary<string, CamoList>
                    {
                        { "Gold", CamoList.GOLD },
                        { "Diamond", CamoList.DIAMOND },
                        { "DMU", CamoList.DMU },
                        { "Golden Viper", CamoList.GOLDEN_VIPER },
                        { "Plague Diamond", CamoList.PLAGUE_DIAMOND },
                        { "Dark Aether", CamoList.DA },
                        { "PAP Orange", CamoList.PAP1 },
                        { "PAP Green", CamoList.PAP2 },
                        { "PAP Pink", CamoList.PAP3 },
                        { "PAP Red", CamoList.PAP4 },
                        { "PAP Blue/Green", CamoList.PAP5 },
                        { "PAP Gold", CamoList.PAP6 },
                        { "PAP Colorful", CamoList.PAP7 },
                        { "PAP Glitching Pink", CamoList.PAP8 },
                        { "PAP Glitching Orange", CamoList.PAP9 },
                        { "Atlanta FaZe", CamoList.CDL1 },
                        { "OpTic Chicago", CamoList.CDL2 },
                        { "Dallas Empire", CamoList.CDL3 },
                        { "Florida Mutineers", CamoList.CDL4 },
                        { "Los Angeles Guerrillas", CamoList.CDL5 },
                        { "Los Angeles Thieves", CamoList.CDL6 },
                        { "London Royal Ravens", CamoList.CDL7 },
                        { "Minnesota RØKKR", CamoList.CDL8 },
                        { "New York Subliners", CamoList.CDL9 },
                        { "Paris Legion", CamoList.CDL10 },
                        { "Seattle Surge", CamoList.CDL11 },
                        { "Toronto Ultra", CamoList.CDL12 },
                    };
            }
        }

        public byte getCamo()
        {
            if (list.TryGetValue(camo, out CamoList result))
                return (byte)result;
            throw new ArgumentException("Camo not found in list");
        }
    }
}
