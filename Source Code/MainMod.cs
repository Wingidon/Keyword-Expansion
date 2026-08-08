using WingidonExtraKeywords;
using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Runtime.Remoting.Messaging;
using MelonLoader;
using MelonLoader.Utils;
using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using UnityEngine;
using UnityEngine.Playables;
using static Il2Cpp.GameplayEvents;
using static Il2CppSystem.Array;
using static MelonLoader.Modules.MelonModule;
using Il2CppSystem.Reflection;

[assembly: MelonInfo(typeof(MainMod), "Wingidon's Extra Keywords", "1.0.0", "Wingidon")]
[assembly: MelonGame("UmiArt", "Demon Bluff")]

namespace WingidonExtraKeywords;
public class MainMod : MelonMod
{
    public override void OnInitializeMelon()
    {
        ClassInjector.RegisterTypeInIl2Cpp<wx_KeywordPatch>(); // This is throwing an error on startup but it doesn't seem to affect anything so I don't really care.
    }


    public override void OnLateInitializeMelon()
    {
    }

    public CharacterData[] allDatas = System.Array.Empty<CharacterData>();

    public override void OnUpdate()
    {
        if (allDatas.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int i = 0; i < loadedCharList.Length; i++)
                {
                    allDatas[i] = loadedCharList[i]!.Cast<CharacterData>();
                }
            }
        }
        if (Statics.charactersArray.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                Statics.charactersArray = new CharacterData[loadedCharList.Length];
                for (int i = 0; i < loadedCharList.Length; i++)
                {
                    CharacterData data = loadedCharList[i]!.Cast<CharacterData>();
                    Statics.CheckAddRole(data);
                    Statics.charactersArray[i] = data;
                }
            }
            if (Statics.charactersArray.Length > 0)
            {
                this.OnFirstUpdate();
            }
        }
    }
    public void OnFirstUpdate()
    {
        wx_KeywordPatch patcher = new();
        for (int i = 0; i < allDatas.Count(); i++)
        {
            MelonLogger.Msg($"Patching role: {allDatas[i].characterName}");
            if (allDatas[i].characterId == "Confessor")
            {
                allDatas[i].description = $"If I am Evil or Corrupted, I Declare that \"I am dizzy\".\nOtherwise, I Declare that \"I am Good\".\n\nI am always Truthful, even if Disguised.";
            }
            allDatas[i].description = patcher.PatchTooltip(allDatas[i].description);
            allDatas[i].hints = patcher.PatchTooltip(allDatas[i].hints);
            allDatas[i].ifLies = patcher.PatchTooltip(allDatas[i].ifLies);
        }
    }

    public static class Statics
    {
        public static Dictionary<string, CharacterData> roles = new Dictionary<string, CharacterData>();
        public static CharacterData[] charactersArray = Il2CppSystem.Array.Empty<CharacterData>();
        /*
        public static GameObject createCircle(int size) // I'm just gonna wait for WWW to figure this out
        {
            GameObject circle = new GameObject();
            circle.name = "Circle_" + size;
            circle.transform.SetParent(Characters.Instance.gameObject.transform);
            RectTransform rect = circle.AddComponent<RectTransform>();
            CharactersPool circPool = circle.AddComponent<CharactersPool>();
            GameObject circ6 = Characters.Instance.gameObject.transform.Find("Circle_6").gameObject;
            CharactersPool circ6Pool = circ6.GetComponent<CharactersPool>();
            circPool.characterPrefab = circ6Pool.characterPrefab;
            circPool.characters = new Character[0];
            circPool.cardPlaceHolders = new CardPlaceholder[size];
            for (int i = 0; i < size; i++)
            {
                GameObject cardHolder = new GameObject();
                cardHolder.transform.SetParent(circle.transform);
                string name = "CardPlaceholder";
                if (i > 0)
                {
                    name += " (" + i + ")";
                }
                cardHolder.name = name;
                RectTransform cardRect = cardHolder.AddComponent<RectTransform>();
                cardRect.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                CardPlaceholder placeholder = cardHolder.AddComponent<CardPlaceholder>();
                int angle = i * 360 / size;
                if (angle <= 30)
                {
                    placeholder.actedSide = EActedSide.Down;
                }
                else if (angle <= 149)
                {
                    placeholder.actedSide = EActedSide.Left;
                }
                else if (angle <= 210)
                {
                    placeholder.actedSide = EActedSide.Up;
                }
                else if (angle <= 329)
                {
                    placeholder.actedSide = EActedSide.Right;
                }
                else
                {
                    placeholder.actedSide = EActedSide.Down;
                }
                circPool.cardPlaceHolders[i] = placeholder;
            }
            circle.transform.position = new UnityEngine.Vector3(0f, 1f, 85.9444f);
            circle.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
            circle.SetActive(false);
            addToCharsPool(circPool);
            return circle;
        }
        */
        public static void addToCharsPool(CharactersPool pool)
        {
            CharactersPool[] pools = Characters.Instance.characterPool;
            CharactersPool[] newPools = new CharactersPool[pools.Length + 1];
            for (int i = 0; i < pools.Length; i++)
            {
                newPools[i] = pools[i];
            }
            newPools[pools.Length] = pool;
            Characters.Instance.characterPool = newPools;
        }

        public static void GetStartingRoles()
        {
            AscensionsData allCharactersAscension = ProjectContext.Instance.gameData.allCharactersAscension;
            foreach (CharacterData data in allCharactersAscension.startingTownsfolks)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingOutsiders)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingMinions)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingDemons)
            {
                CheckAddRole(data);
            }
        }
        public static void CheckAddRole(CharacterData data)
        {
            string name = data.name;
            if (!roles.ContainsKey(name))
            {
                roles.Add(name, data);
            }
        }

    }



    string customHint(string type, string parameter)
    {
        string hint = "Custom hint not working, please report to Wingidon";
        if (type == "Ability Refresh Hint")
        {
            if (parameter == "Each Night")
            {
                hint = "My ability refreshes each night and may be used again each day.";
            }
            if (parameter == "Once Per Game")
            {
                hint = "My ability does not refresh each night.";
            }
        }
        if (type == "Keyword")
        {
            if (parameter == "Setup")
            {
                hint = $"<b>Setup:</b>\nThis ability applies <i>before</i> <b>Game Start</b> abilities. It only works if the current Demon is the primary Demon of the current board.\nThese effects are reflected in the role counts.";
            }
            if (parameter == "Bluff")
            {
                hint = $"<b>Bluff</b>:\nCharacters think I have the attribute that I am {formattedKeyText("Bluffing")}.";
            }
            /*
            if (parameter == "Poison")
            {
                hint = $"<b>Poison</b>:\nThis character is Corrupted & acts as such.\nAfter a certain number of {formattedKeyText("Reveals")}, they die.\nThe {roleColour("Villager")}Alchemist</color> can Cure the Corruption, but can't stop the {formattedKeyText("Poison")} from killing the victim.";
            }
            */
            if (parameter == "Cycle")
            {
                hint = $"<b>Cycle X</b>:\nThis ability happens every X times any character is {formattedKeyText("Revealed")}.";
            }
            if (parameter == "TrustLong")
            {
                hint = $"<b>Trust</b>:\nA measure of how much you can {formattedKeyText("Trust")} a character.\nVillagers, Outcasts, Minions and Demons are 5x, 3x, 3x and 1x as {formattedKeyText("Trustworthy")} respectively.\nGood characters are 3x as {formattedKeyText("Trustworthy")}.\n{formattedKeyText("Truthful")} characters are 3x as {formattedKeyText("Trustworthy")}.\n{formattedKeyText("Honest")} characters are 2.5x as {formattedKeyText("Trustworthy")}.";
            }
            if (parameter == "TrustShort")
            {
                hint = $"<b>Trust</b>:\nA measure of how much you can {formattedKeyText("Trust")} a character.\nGenerally speaking, the more innocent traits a character exhibits, the more {formattedKeyText("Trustworthy")} they are.";
            }
            if (parameter == "Declare")
            {
                hint = $"<b>Declare</b>:\nThis character makes a statement that is always true, even if they're Lying.";
            }
        }
        return hint;
    }
    string formattedKeyText(string target)
    {
        switch (target)
        {
            // Keywords
            case "Honest": return "<color=#7AC6FF>Honest</color>";
            case "Pure": return "<color=#7AFBFF>Pure</color>";
            case "Cure": return "<color=#7AFBFF>Cure</color>";
            case "Cured": return "<color=#7AFBFF>Cured</color>";
            case "Heal": return "<color=#2EFF43>Heal</color>";
            case "Max Health": return "<color=#7AFBFF>Max Health</color>";
            case "Health": return "<color=#7AFBFF>Health</color>";
            case "Damage": return "<color=#C72424>Damage</color>";
            case "True Role": return "<color=#57E69C>True Role</color>";
            case "Truthful": return "<color=#3A95D6>Truthful</color>";
            case "Truth": return "<color=#3A95D6>Truth</color>";
            case "Reveal": return "<color=#A1E6E2>Reveal</color>";
            case "Reveals": return "<color=#A1E6E2>Reveals</color>";
            case "Revealed": return "<color=#A1E6E2>Revealed</color>";
            case "Hidden": return "<color=#697D91>Hidden</color>";
            case "Unrevealed": return "<color=#697D91>Unrevealed</color>";
            case "Bluff": return "<color=#D96EDB>Bluff</color>";
            case "Bluffs": return "<color=#D96EDB>Bluffs</color>";
            case "Bluffing": return "<color=#D96EDB>Bluffing</color>";
            case "Attack": return "<color=#FF0037>Attack</color>";
            case "Attacked": return "<color=#FF0037>Attacked</color>";
            case "Kill": return "<color=#FF0037>Kill</color>";
            case "Killed": return "<color=#FF0037>Killed</color>";
            case "Killing": return "<color=#FF0037>Killing</color>";
            case "Dead": return "<color=#B36979>Dead</color>";
            case "Die": return "<color=#B36979>Die</color>";
            case "Dies": return "<color=#B36979>Dies</color>";
            case "Alive": return "<color=#A4EDB7>Alive</color>";
            case "Living": return "<color=#A4EDB7>Living</color>";
            case "Deck": return "<color=#789AF0>Deck</color>";
            case "Lose": return "<color=#FF0000>Lose</color>";
            case "Unmask": return "<color=#B5E9FF>Unmask</color>";
            case "Declare": return "<color=#FFFF00>Declare</color>";
            // case "Alignment": return "<color=#99FF99>Align</color><color=#FF9999>ment</color>"; // Making an alternate one for Alignment

            // Cycle is gonna be a long one because of the fancy gradient I'm doing
            case "Cycle": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e</color>";
            case "Cycle 1": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 1</color>";
            case "Cycle 2": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 2</color>";
            case "Cycle 3": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 3</color>";
            case "Cycle 4": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 4</color>";
            case "Cycle 5": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 5</color>";
            case "Cycle 6": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 6</color>"; // Cycles beyond 6 are pointless

            // I'm doing gradients or multicolours for these, so they'll end up being fairly long.
            case "Alignment": return "<color=#99ff99>A</color><color=#b7f382>l</color><color=#cfe573>i</color><color=#e3d76c>g</color><color=#f2c96d>n</color><color=#fdba73>m</color><color=#ffad7e>e</color><color=#ffa28b>n</color><color=#ff9999>t</color>";
            case "Type": return "<color=#B656DD>T</color><color=#C8A500>y</color><color=#D97400>p</color><color=#FF6161>e</color>";
            case "Truthfulness": return "<color=#3a95d6>T</color><color=#0ca3da>r</color><color=#00b1da>u</color><color=#00bdd5>t</color><color=#00c9ce>h</color><color=#25d4c4>f</color><color=#51deb8>u</color><color=#76e7ad>l</color><color=#98efa3>n</color><color=#bbf69b>e</color><color=#ddfb98>s</color><color=#ffff99>s</color>";
            case "Honesty": return "<color=#7ac6ff>H</color><color=#5cd3f2>o</color><color=#5fddd9>n</color><color=#7fe2bc>e</color><color=#aae4a3>s</color><color=#d6e296>t</color><color=#ffdd99>y</color>";
            case "Purity": return "<color=#7afbff>P</color><color=#61ecff>u</color><color=#71daff>r</color><color=#80c8ff>i</color><color=#94b2ff>t</color><color=#b199ff>y</color>";

            // Custom role keywords
            case "Poison": return "<color=#3F8538>Poison</color>"; // For unused Toxomancer role.
            case "Poisoned": return "<color=#3F8538>Poisoned</color>";
            case "Trick": return "<color=#70E8FF>Trick</color>"; // Used by Faerie.
            case "Tricked": return "<color=#70E8FF>Tricked</color>";
            case "Bewildered": return "<color=#70E8FF>Bewil</color><color=#FF00DD>dered</color>"; // Also used by Faerie.
            case "Misled": return "<color=#FF00AE>Misled</color>"; // Used by Venelum and Vidiyon.
            case "Trustworthy": return "<color=#9999FF>Trustworthy</color>"; // Used by Empath
            case "Trustworthiness": return "<color=#9999FF>Trustworthiness</color>";
            case "Trust": return "<color=#9999FF>Trust</color>";


            // Devs
            case "Normandia": return "<color=#CE1119>Normandia</color>";
            case "Uzabi": return "<color=#CE1119>Uzabi</color>";

            // Modders
            case "@wingidon": return "<color=#7289DA>@</color><color=#C080FF>wingidon</color>";
            case "Wingidon": return "<color=#C080FF>Wingidon</color>";
            case "WWW": return "<color=#3BA55C>WWW is not taken</color>";
            case "@WWW": return "<color=#7289DA>@</color><color=#3BA55C>wwwisnottaken</color>";
            case "Carlz": return "<color=#5FC4F9>Carlz</color>";
            case "@Carlz": return "<color=#7289DA>@</color><color=#5FC4F9>carlz54339</color>";

            // Art credits
            case "Blue Cheesed": return "<color=#D8D8D8>Blue Cheesed</color>"; // Arithmetician
            case "@Blue Cheesed": return "<color=#7289DA>@</color><color=#D8D8D8>hydethefish</color>";
            case "WeekendWolf": return "<color=#5476ff>WeekendWolf</color>"; // Forager, Sentinel, Lunatic
            case "@weekendwolf": return "<color=#7289DA>@</color><color=#5476ff>hellzalley</color>";
            case "Astery": return "<color=#d506c7>Astery</color>"; // Gemcrafter
            case "@astery": return "<color=#7289DA>@</color><color=#d506c7>astery__</color>";
            case "LostIllustrator": return "<color=#45e0f8>Lost Illustrator</color>"; // Scavenger
            case "@lostillustrator": return "<color=#7289DA>@</color><color=#45e0f8>lostillustrator</color>";
            case "Hiraeth": return "<color=#4b53d5>Hiraeth</color>"; // Warden
            case "@hiraeth": return "<color=#7289DA>@</color><color=#4b53d5>lullabiesmourn</color>";
            case "Panda": return "<color=#cadee6>Panda</color>"; // Spy
            case "@Panda": return "<color=#7289DA>@</color><color=#cadee6>@pandacharly</color>";
            case "Derpy_Feesh": return "<color=#7948d7>Derpy_Feesh</color>"; // Leviathan
            case "@derpy_feesh": return "<color=#7289DA>@</color><color=#7948d7>derpy_feesh</color>"; // Leviathan
            case "Cycler": return "<color=#45E0F8>Cycler</color>"; // Cycler
            case "@skillcycler": return "<color=#7289DA>@</color><color=#45E0F8>skillcycler</color>"; // Cycler
            case "LimeOn": return "<color=#7289DA>@</color><color=#94EECC>LimeOn</color>"; // Empath
            case "@limeon": return "<color=#7289DA>@</color><color=#94EECC>lime_0n1337</color>"; // Empath

            // Special thanks
            case "NoLucksGiven": return "<color=#FFC07B>NoLucksGiven</color>"; // Played mod on YouTube, brought attention to it.
            case "D_NoLucksGiven": return "<color=#7289DA>@</color><color=#FFC07B>nolucksgiven</color>";
            case "Y_NoLucksGiven": return $"<color=#FFC07B>https://www.{formattedKeyText("YouTube")}.com/c/NoLucksGiven</color>";
            case "Fi": return "<color=#96EAFF>Fi the Dragonfly</color>"; // Faerie character is literally Fi lmao
            case "@fithedragonfly": return "<color=#96EAFF>@fithedragonfly</color>";

            // Colours
            case "VillagerColour": return "<color=#B656DD>";
            case "VillagerAltColour": return "<color=#C080FF>";
            case "OutcastColour": return "<color=#F6FF72>";
            case "OutcastAltColour": return "<color=#C8A500>";
            case "MinionColour": return "<color=#D97400>";
            case "DemonColour": return "<color=#FF6161>";

            // Colours, Alignment Flip
            case "EvilVillagerColour": return "<color=#9B2FAE>";
            case "EvilOutcastColour": return "<color=#FF00DD>";
            case "GoodMinionColour": return "<color=#33D1C6>";
            case "GoodDemonColour": return "<color=#7A5CFF>";

            // Colours, Other Mods
            case "WeatherColour": return "<color=#FF7AE0>"; // Weather (Power Play)
            case "NeutralColour": return "<color=#8FA7B3>"; // Neutral (Power Play)

            // Platforms
            case "Discord": return "<color=#7289DA>Discord</color>";
            case "Tumblr": return "<color=#36465D>Tumblr</color>";
            case "YouTube": return "<color=#FE0000>YouTube</color>";
            case "Youtube": return "<color=#FE0000>YouTube</color>";
        }
        return "Formatted key text invalid, please report this to Wingidon.";
    }
}