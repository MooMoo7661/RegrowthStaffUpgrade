using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RegrowthStaffUpgrade
{
    public class RegrowthStaffUpgrade : Mod
    {

    }

    public class StaffGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.StaffofRegrowth || entity.type == ItemID.AcornAxe;
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[ItemID.StaffofRegrowth] = true;
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[ItemID.AcornAxe] = true;
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                if (tile.TileType == TileID.Mud)
                {
                    WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.JungleGrass, false, true);
                }
                else if (tile.TileType == TileID.Ash)
                {
                    WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.AshGrass, false, true);
                }
            }
            else if (player.altFunctionUse == 2)
            {
                Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                if (tile.TileType == TileID.Dirt)
                {
                    if (player.ZoneCorrupt)
                    {
                        WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.CorruptGrass, false, true);
                    }
                    else if (player.ZoneCrimson)
                    {
                        WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.CrimsonGrass, false, true);
                    }
                    else if (player.ZoneHallow)
                    {
                        WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.HallowedGrass, false, true);
                    }
                }
                else if (tile.TileType == TileID.Mud)
                {
                    if (player.ZoneGlowshroom)
                    {
                        WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.MushroomGrass, false, true);
                    }
                }
            }

            return true;
        }

        public override bool AltFunctionUse(Item item, Player player)
        {
            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "WandInfo", "Right click to grow biome-specific grasses"));
        }
    }
}