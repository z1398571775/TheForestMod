using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Player.Clothing;

namespace TheForestMod
{
    internal class LocalPlayerManager
    {

        /**
         * 
         * 
         * 重置玩家状态
         */

        public static void resetPlayerState()
        {
            try
            {
                PlayerStats playerStats = TheForest.Utils.LocalPlayer.Stats;
                playerStats.Health = 999999;
                playerStats.HealthTarget = 9999999;
                playerStats.Energy = 999999;
            }
            catch(Exception e)
            {

            }
            

        }
        /// <summary>
        /// 获取玩家穿着
        /// </summary>
        public static void getPlayerClothing()
        {
            Melon<MyMod>.Logger.Msg("============= closing ================");
            try
            {
                PlayerClothing playerClothing = TheForest.Utils.LocalPlayer.Clothing;
                List<List<int>> clothingList = playerClothing.AvailableClothingOutfits;
                foreach (List<int> itemList in clothingList)
                {
                    foreach (var item in itemList)
                    {
                        Melon<MyMod>.Logger.Msg($"clothingId:+{item}");
                    }
                }
            }catch(Exception e)
            {
                Melon<MyMod>.Logger.Msg(e.Message);
            }
            
        }
    }
}
