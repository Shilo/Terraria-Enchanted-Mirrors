using Terraria.ModLoader;

namespace EnchantedMirrors
{
	class EnchantedMirrors : Mod
	{
		public EnchantedMirrors()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
