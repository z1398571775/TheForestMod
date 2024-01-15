using MelonLoader;
using System;
using TheForest;
using UnityEngine;

namespace TheForestMod
{
    public class MyMod : MelonMod
    {
        DebugConsole exists;
        public override void OnInitializeMelon()
        {

            LoggerInstance.Msg("MyMod has been loaded!");
        }

        public override void OnUpdate()
        {

            LocalPlayerManager.resetPlayerState();
            if (Input.GetKeyDown(KeyCode.T))
            {
                ItemManager.getItems();
                LocalPlayerManager.getPlayerClothing();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
               
                ItemManager.getMood();
                //ItemManager.fakeDrop();
            }
        }
    }
}
