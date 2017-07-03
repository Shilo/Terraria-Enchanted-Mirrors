using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnchantedMirrors.Items
{
	public class AngelicMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelic Mirror");
			Tooltip.SetDefault("Gaze in the mirror to teleport to a random player.");
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
            recipe.AddIngredient(ItemID.SoulofLight, 25);
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
            return FirstActivePlayer(Main.player, player) != null;
        }

        public override bool UseItem(Player player)
        {
            Player[] players = (Player[])Main.player.Clone();
            Randomize(players);

            Player randomPlayer = FirstActivePlayer(players, player);
            if (randomPlayer != null)
            {
                player.Teleport(randomPlayer.position);
                return true;
            }
            return false;
        }

        private Player FirstActivePlayer(Player[] players, Player excludePlayer)
        {
            foreach (Player otherPlayer in players)
            {
                if (otherPlayer.active && otherPlayer != excludePlayer)
                {
                    return otherPlayer;
                }
            }
            return null;
        }

        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
