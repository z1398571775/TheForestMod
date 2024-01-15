using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using TheForest.Buildings.Creation;
using TheForest.Items;
using TheForest.Items.Craft;
using TheForest.Player.Clothing;
using UnityEngine;
using Bolt;
using static CoopPlayerUpgrades;
using TheForest.Utils;

namespace TheForestMod
{
    internal class ItemManager
    {
        public static void getItems()
        {
            try
            {
                TheForest.Items.Item[] Items = ItemDatabase.Items;
                foreach (TheForest.Items.Item item in Items)
                {
                    Melon<MyMod>.Logger.Msg($"物品名称:+{item._name}\t===== \t 物品ID:{item._id}");
                    try
                    {
                        TheForest.Utils.LocalPlayer.Inventory.AddItem(item._id, 99999, false);
                    }catch(Exception ex) { }
                    
                }
            }catch(Exception e)
            {
                Melon<MyMod>.Logger.Msg(e.Message);
            }
            


            Melon<MyMod>.Logger.Msg("===================== clothing ==============================");

            try
            {
                ClothingItem[] clothingItems = ClothingItemDatabase.Items;
                foreach (ClothingItem item in clothingItems)
                {
                    Melon<MyMod>.Logger.Msg($"物品名称:+{item._name}\t===== \t 物品ID:{item._id}");
                    try
                    {
                        TheForest.Utils.LocalPlayer.Inventory.AddItem(item._id, 99999, false);
                    }
                    catch (Exception ex) { }
                    
                }
            }
            catch (Exception e)
            {
                Melon<MyMod>.Logger.Msg(e.Message);
            }
           
        }


        /***
         * 
         * 获取木头
         */
        public static void getMood()
        {
            TheForest.Utils.LocalPlayer.Inventory.AddItem(78, 2, false);
            Scene.ActiveMB.StartCoroutine(BuildAllGhostsRoutine());
        }

        public static IEnumerator BuildAllGhostsRoutine()
        {
            Craft_Structure[] css = UnityEngine.Object.FindObjectsOfType<Craft_Structure>();
            if (css != null && css.Length > 0)
            {
                Melon<MyMod>.Logger.Msg("$> Begin build all " + css.Length + " ghosts");
                foreach (Craft_Structure cs in css)
                {
                    ReceipeIngredient[] presentAll = cs.GetPresentIngredients();
                    List<Craft_Structure.BuildIngredients> requiredAll = cs._requiredIngredients;
                    int i = 0;
                    while (i < requiredAll.Count && i < presentAll.Length)
                    {
                        if (requiredAll[i]._amount != presentAll[i]._amount)
                        {
                            Craft_Structure.BuildIngredients needed = requiredAll[i];
                            ReceipeIngredient present = presentAll[i];
                            for (int k = needed._amount - present._amount; k > 0; k--)
                            {
                                cs.SendMessage("AddIngredient", i);
                            }
                            if (BoltNetwork.isRunning)
                            {
                                yield return null;
                            }
                        }
                        i++;
                    }
                    yield return null;
                }
                Melon<MyMod>.Logger.Msg("$> Done building all " + css.Length + " ghosts");
            }
            else
            {
                Melon<MyMod>.Logger.Msg("$> found no ghost buildings to complete");
            }
            yield break;
        }

        /**
         * 
         * 扔掉木头
         */
        public static void fakeDrop()
        {
            for (int i = 0; i < 100; i++)
            {
                TheForest.Utils.LocalPlayer.Inventory.FakeDrop(78, null);
            }
            
        }
        
    }
}
