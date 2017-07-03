using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnchantedMirrors.Items
{
	public class DemonicMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic Mirror");
			Tooltip.SetDefault("Gaze in the mirror to teleport to last death location.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MagicMirror);
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.SoulofNight, 25);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();

            //uncomment below to allow crafting back to Magic Mirror
            /*
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.MagicMirror);
            recipe.AddRecipe();
            */
		}

		public override bool CanUseItem(Player player)
        {
            return player.lastDeathTime > DateTime.MinValue;
        }

        public override bool UseItem(Player player)
        {
            player.Teleport(new Vector2(player.lastDeathPostion.X, player.lastDeathPostion.Y-(player.height*0.6666666666666667f)));
            return true;
        }
    }
}
