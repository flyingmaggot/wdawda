using System;
using System.Collections.Generic;
using ReflectionUtility;
using UnityEngine;

namespace thing
{
    public class Main : MonoBehaviour
    {
        bool flag = !Config.gameLoaded;
        if (!flag)
        {
            bool flag2 = !Main.initialized;
            if (flag2)
        {
            this.init();
        }
        Main.initialized = true;
      }
    }
    
    public static void init()
    {
        ActorTrait newTrait = new ActorTrait();
        
        newTrait.id = "test";
        newTrait.icon = AssetManager.resources.get("fat").icon;
        
        newTrait.baseStats.warfare = -3;
        newTrait.baseStats.diplomacy = 3;
        //newTrait.type = traitType.positive; why did i do this
        
        AssetManager.traits.add(newTrait);
        Main.addLocalization("trait_" + newTrait.id, "test");
        Main.addLocalization("trait_" + newTrait.id, + "_info", "test");
    }
    
    public static void addLocalization(string key, string value)
    {
        Dictionary<string, string> dictionary = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
        dictionary.Add(key, value)
    }
    
    private static bool initialized;
  }
}
