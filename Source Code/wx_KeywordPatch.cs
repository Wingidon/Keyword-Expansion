using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using Il2CppTMPro;
using HarmonyLib;

namespace WingidonExtraKeywords;
public class wx_KeywordPatch // Code by Skill Cycler, absolute legend!
{
    public string PatchTooltip(string tooltip)
    {
        string value = tooltip;
        if (value != null)
        {
            Il2CppSystem.Collections.Generic.List<string> replaceCheckStrings = new();
            Il2CppSystem.Collections.Generic.List<string> replaceReplacements = new();
            Il2CppSystem.Collections.Generic.List<string> replaceReplacementLink = new();
            Il2CppSystem.Collections.Generic.List<string> replaceColour = new();

            // Pure
            replaceCheckStrings.Add("Pure");
            replaceReplacements.Add("Pure");
            replaceReplacementLink.Add("Link_P-ure");
            replaceColour.Add("7AC6FF");

            // Health/Heal
            replaceCheckStrings.Add("Heals");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Healed");
            replaceReplacements.Add("Key1ed");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Healing");
            replaceReplacements.Add("Key1ing");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Health");
            replaceReplacements.Add("Key2");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Heal");
            replaceReplacements.Add("Heal");
            replaceReplacementLink.Add("Link_H-eal");
            replaceColour.Add("2EFF43");
            replaceCheckStrings.Add("Key1ing");
            replaceReplacements.Add("Healing");
            replaceReplacementLink.Add("Link_H-eal");
            replaceColour.Add("2EFF43");
            replaceCheckStrings.Add("Key1ed");
            replaceReplacements.Add("Healed");
            replaceReplacementLink.Add("Link_H-eal");
            replaceColour.Add("2EFF43");
            replaceCheckStrings.Add("Heals");
            replaceReplacements.Add("Heals");
            replaceReplacementLink.Add("Link_H-eal");
            replaceColour.Add("2EFF43");
            replaceCheckStrings.Add("Max Health");
            replaceReplacements.Add("Max Health");
            replaceReplacementLink.Add("Link_H-ealth");
            replaceColour.Add("7AFBFF");
            replaceCheckStrings.Add("Key2");
            replaceReplacements.Add("Health");
            replaceReplacementLink.Add("Link_H-ealth");
            replaceColour.Add("7AFBFF");

            // Damage
            replaceCheckStrings.Add("Damaged");
            replaceReplacements.Add("Key1");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Damage");
            replaceReplacements.Add("Damage");
            replaceReplacementLink.Add("Link_D-amage");
            replaceColour.Add("C72424");
            replaceCheckStrings.Add("Damaging");
            replaceReplacements.Add("Damaging");
            replaceReplacementLink.Add("Link_D-amage");
            replaceColour.Add("C72424");
            replaceCheckStrings.Add("Key1");
            replaceReplacements.Add("Damaged");
            replaceReplacementLink.Add("Link_D-amage");
            replaceColour.Add("C72424");

            // Role/True Role
            replaceCheckStrings.Add("True Role");
            replaceReplacements.Add("Key11");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("True Roles");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Roles");
            replaceReplacements.Add("Key2");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Role");
            replaceReplacements.Add("Role");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");
            replaceCheckStrings.Add("Key11");
            replaceReplacements.Add("True Role");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("True Roles");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");
            replaceCheckStrings.Add("Key2");
            replaceReplacements.Add("Roles");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");
            replaceCheckStrings.Add("roles");
            replaceReplacements.Add("Key2");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("role");
            replaceReplacements.Add("Role");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");
            replaceCheckStrings.Add("Key2");
            replaceReplacements.Add("Roles");
            replaceReplacementLink.Add("Link_R-ole");
            replaceColour.Add("57E69C");

            // Reveal
            replaceCheckStrings.Add("Unreveal");
            replaceReplacements.Add("Key2");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Reveals");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Revealed");
            replaceReplacements.Add("Key1ed");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Revealing");
            replaceReplacements.Add("Key1ing");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Reveal");
            replaceReplacements.Add("Reveal");
            replaceReplacementLink.Add("Link_R-eveal");
            replaceColour.Add("A1E6E2");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("Reveals");
            replaceReplacementLink.Add("Link_R-eveal");
            replaceColour.Add("A1E6E2");
            replaceCheckStrings.Add("Key1ed");
            replaceReplacements.Add("Revealed");
            replaceReplacementLink.Add("Link_R-eveal");
            replaceColour.Add("A1E6E2");
            replaceCheckStrings.Add("Key1ing");
            replaceReplacements.Add("Revealing");
            replaceReplacementLink.Add("Link_R-eveal");
            replaceColour.Add("A1E6E2");

            // Unrevealed
            replaceCheckStrings.Add("Key2");
            replaceReplacements.Add("Unreveal");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            //replaceCheckStrings.Add("Unrevealed");
            //replaceReplacements.Add("Unrevealed");
            //replaceReplacementLink.Add("Link_Unr-eveal");
            //replaceColour.Add("697D91");

            // Bluff
            replaceCheckStrings.Add("Bluffing");
            replaceReplacements.Add("Key1ing");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Bluffed");
            replaceReplacements.Add("Key1ed");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Bluffs");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Bluff");
            replaceReplacements.Add("Bluff");
            replaceReplacementLink.Add("Link_B-luff");
            replaceColour.Add("D96EDB");
            replaceCheckStrings.Add("Key1ing");
            replaceReplacements.Add("Bluffing");
            replaceReplacementLink.Add("Link_B-luff");
            replaceColour.Add("D96EDB");
            replaceCheckStrings.Add("Key1ed");
            replaceReplacements.Add("Bluffed");
            replaceReplacementLink.Add("Link_B-luff");
            replaceColour.Add("D96EDB");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("Bluffs");
            replaceReplacementLink.Add("Link_B-luff");
            replaceColour.Add("D96EDB");

            // Attack/Kill
            replaceCheckStrings.Add("Attacking");
            replaceCheckStrings.Add("Attacked");
            replaceCheckStrings.Add("Attacks");
            replaceCheckStrings.Add("Attacker");
            replaceReplacements.Add("Key1ing");
            replaceReplacements.Add("Key1ed");
            replaceReplacements.Add("Key1s");
            replaceReplacements.Add("Key1er");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Killing");
            replaceCheckStrings.Add("Killed");
            replaceCheckStrings.Add("Kills");
            replaceCheckStrings.Add("Killer");
            replaceReplacements.Add("Key2ing");
            replaceReplacements.Add("Key2ed");
            replaceReplacements.Add("Key2s");
            replaceReplacements.Add("Key2er");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Attack");
            replaceReplacements.Add("Attack");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key1ing");
            replaceReplacements.Add("Attacking");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key1ed");
            replaceReplacements.Add("Attacked");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("Attacks");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key1er");
            replaceReplacements.Add("Attacker");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Kill");
            replaceReplacements.Add("Kill");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key2ing");
            replaceReplacements.Add("Killing");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key2ed");
            replaceReplacements.Add("Killed");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key2s");
            replaceReplacements.Add("Kills");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");
            replaceCheckStrings.Add("Key2er");
            replaceReplacements.Add("Killer");
            replaceReplacementLink.Add("Link_A-ttack");
            replaceColour.Add("FF0037");

            // Dead/Die(s)
            replaceCheckStrings.Add("Dies");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Died");
            replaceReplacements.Add("Key1d");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Dead");
            replaceReplacements.Add("Dead");
            replaceReplacementLink.Add("Link_D-eath");
            replaceColour.Add("B36979");
            replaceCheckStrings.Add("Die");
            replaceReplacements.Add("Die");
            replaceReplacementLink.Add("Link_D-eath");
            replaceColour.Add("B36979");
            replaceCheckStrings.Add("Key1d");
            replaceReplacements.Add("Died");
            replaceReplacementLink.Add("Link_D-eath");
            replaceColour.Add("B36979");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("Dies");
            replaceReplacementLink.Add("Link_D-eath");
            replaceColour.Add("B36979");
            replaceCheckStrings.Add("Dying");
            replaceReplacements.Add("Dying");
            replaceReplacementLink.Add("Link_D-eath");
            replaceColour.Add("B36979");

            // Alive/live
            replaceCheckStrings.Add("Lives");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Lived");
            replaceReplacements.Add("Key1d");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Alive");
            replaceReplacements.Add("Alive");
            replaceReplacementLink.Add("Link_A-live");
            replaceColour.Add("A4EDB7");
            replaceCheckStrings.Add("Live");
            replaceReplacements.Add("Live");
            replaceReplacementLink.Add("Link_A-live");
            replaceColour.Add("A4EDB7");
            replaceCheckStrings.Add("Lives");
            replaceReplacements.Add("Lives");
            replaceReplacementLink.Add("Link_A-live");
            replaceColour.Add("A4EDB7");
            replaceCheckStrings.Add("Lived");
            replaceReplacements.Add("Lived");
            replaceReplacementLink.Add("Link_A-live");
            replaceColour.Add("A4EDB7");
            replaceCheckStrings.Add("Living");
            replaceReplacements.Add("Living");
            replaceReplacementLink.Add("Link_A-live");
            replaceColour.Add("A4EDB7");

            // Deck
            replaceCheckStrings.Add("Deck View");
            replaceReplacements.Add("Key1");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Deck");
            replaceReplacements.Add("Deck");
            replaceReplacementLink.Add("Link_D-eck");
            replaceColour.Add("789AF0");
            replaceCheckStrings.Add("Key1");
            replaceReplacements.Add("Deck View");
            replaceReplacementLink.Add("Link_D-eck");
            replaceColour.Add("789AF0");

            // Win/Lose
            replaceCheckStrings.Add("Win");
            replaceReplacements.Add("Win");
            replaceReplacementLink.Add("Link_W-in");
            replaceColour.Add("00FF00");
            replaceCheckStrings.Add("Lose");
            replaceReplacements.Add("Lose");
            replaceReplacementLink.Add("Link_L-ose");
            replaceColour.Add("FF0000");

            // Unmask
            replaceCheckStrings.Add("Unmask");
            replaceReplacements.Add("Unmask");
            replaceReplacementLink.Add("Link_U-nmask");
            replaceColour.Add("B5E9FF");

            // Declare
            replaceCheckStrings.Add("Declare");
            replaceReplacements.Add("Declare");
            replaceReplacementLink.Add("Link_D-eclare");
            replaceColour.Add("FFFF00");

            // Cycle
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 1</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 2</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 3</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 4</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 5</color>");
            replaceCheckStrings.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 6</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 1</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 2</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 3</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 4</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 5</color>");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 6</color>");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");
            replaceColour.Add("99CCCC");

            replaceCheckStrings.Add("Cycle");
            replaceReplacements.Add("<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e</color>");
            replaceReplacementLink.Add("Link_C-ycle");
            replaceColour.Add("99CCCC");
            // Alignment
            replaceCheckStrings.Add("<color=#99ff99>A</color><color=#b7f382>l</color><color=#cfe573>i</color><color=#e3d76c>g</color><color=#f2c96d>n</color><color=#fdba73>m</color><color=#ffad7e>e</color><color=#ffa28b>n</color><color=#ff9999>t</color>");
            replaceReplacements.Add("<color=#99ff99>A</color><color=#b7f382>l</color><color=#cfe573>i</color><color=#e3d76c>g</color><color=#f2c96d>n</color><color=#fdba73>m</color><color=#ffad7e>e</color><color=#ffa28b>n</color><color=#ff9999>t</color>");
            replaceReplacementLink.Add("Link_A-lignment");
            replaceColour.Add("C080FF");
            replaceCheckStrings.Add("Alignment");
            replaceReplacements.Add("<color=#99ff99>A</color><color=#b7f382>l</color><color=#cfe573>i</color><color=#e3d76c>g</color><color=#f2c96d>n</color><color=#fdba73>m</color><color=#ffad7e>e</color><color=#ffa28b>n</color><color=#ff9999>t</color>");
            replaceReplacementLink.Add("Link_A-lignment");
            replaceColour.Add("C080FF");

            // Type
            replaceCheckStrings.Add("<color=#B656DD>T</color><color=#C8A500>y</color><color=#D97400>p</color><color=#FF6161>e</color>");
            replaceReplacements.Add("<color=#B656DD>T</color><color=#C8A500>y</color><color=#D97400>p</color><color=#FF6161>e</color>");
            replaceReplacementLink.Add("Link_T-ype");
            replaceColour.Add("B656DD");
            replaceCheckStrings.Add("Type");
            replaceReplacements.Add("<color=#B656DD>T</color><color=#C8A500>y</color><color=#D97400>p</color><color=#FF6161>e</color>");
            replaceReplacementLink.Add("Link_T-ype");
            replaceColour.Add("B656DD");

            // Truthfulness
            replaceCheckStrings.Add("<color=#3a95d6>T</color><color=#0ca3da>r</color><color=#00b1da>u</color><color=#00bdd5>t</color><color=#00c9ce>h</color><color=#25d4c4>f</color><color=#51deb8>u</color><color=#76e7ad>l</color><color=#98efa3>n</color><color=#bbf69b>e</color><color=#ddfb98>s</color><color=#ffff99>s</color>");
            replaceReplacements.Add("<color=#3a95d6>T</color><color=#0ca3da>r</color><color=#00b1da>u</color><color=#00bdd5>t</color><color=#00c9ce>h</color><color=#25d4c4>f</color><color=#51deb8>u</color><color=#76e7ad>l</color><color=#98efa3>n</color><color=#bbf69b>e</color><color=#ddfb98>s</color><color=#ffff99>s</color>");
            replaceReplacementLink.Add("Link_T-ruthfulness");
            replaceColour.Add("99FF99");
            replaceCheckStrings.Add("Truthfulness");
            replaceReplacements.Add("<color=#3a95d6>T</color><color=#0ca3da>r</color><color=#00b1da>u</color><color=#00bdd5>t</color><color=#00c9ce>h</color><color=#25d4c4>f</color><color=#51deb8>u</color><color=#76e7ad>l</color><color=#98efa3>n</color><color=#bbf69b>e</color><color=#ddfb98>s</color><color=#ffff99>s</color>");
            replaceReplacementLink.Add("Link_T-ruthfulness");
            replaceColour.Add("99FF99");

            // Honesty
            replaceCheckStrings.Add("Honesty");
            replaceReplacements.Add("Key1");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Honest");
            replaceReplacements.Add("Honest");
            replaceReplacementLink.Add("Link_H-onest");
            replaceColour.Add("7AC6FF");
            replaceCheckStrings.Add("<color=#7ac6ff>H</color><color=#5cd3f2>o</color><color=#5fddd9>n</color><color=#7fe2bc>e</color><color=#aae4a3>s</color><color=#d6e296>t</color><color=#ffdd99>y</color>");
            replaceReplacements.Add("<color=#7ac6ff>H</color><color=#5cd3f2>o</color><color=#5fddd9>n</color><color=#7fe2bc>e</color><color=#aae4a3>s</color><color=#d6e296>t</color><color=#ffdd99>y</color>");
            replaceReplacementLink.Add("Link_H-onesty");
            replaceColour.Add("7AC6FF");
            replaceCheckStrings.Add("Key1");
            replaceReplacements.Add("<color=#7ac6ff>H</color><color=#5cd3f2>o</color><color=#5fddd9>n</color><color=#7fe2bc>e</color><color=#aae4a3>s</color><color=#d6e296>t</color><color=#ffdd99>y</color>");
            replaceReplacementLink.Add("Link_H-onesty");
            replaceColour.Add("7AC6FF");

            // Purity
            replaceCheckStrings.Add("<color=#7afbff>P</color><color=#61ecff>u</color><color=#71daff>r</color><color=#80c8ff>i</color><color=#94b2ff>t</color><color=#b199ff>y</color>");
            replaceReplacements.Add("<color=#7afbff>P</color><color=#61ecff>u</color><color=#71daff>r</color><color=#80c8ff>i</color><color=#94b2ff>t</color><color=#b199ff>y</color>");
            replaceReplacementLink.Add("Link_P-urity");
            replaceColour.Add("FF7AB8");
            replaceCheckStrings.Add("Purity");
            replaceReplacements.Add("<color=#7afbff>P</color><color=#61ecff>u</color><color=#71daff>r</color><color=#80c8ff>i</color><color=#94b2ff>t</color><color=#b199ff>y</color>");
            replaceReplacementLink.Add("Link_P-urity");
            replaceColour.Add("FF7AB8");

            // Sleepwalk
            replaceCheckStrings.Add("Sleepwalker");
            replaceReplacements.Add("Key1er");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Sleepwalks");
            replaceReplacements.Add("Key1s");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Sleepwalking");
            replaceReplacements.Add("Key1ing");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Sleepwalked");
            replaceReplacements.Add("Key1ed");
            replaceReplacementLink.Add("");
            replaceColour.Add("");
            replaceCheckStrings.Add("Sleepwalk");
            replaceReplacements.Add("Sleepwalk");
            replaceReplacementLink.Add("Link_S-leepwalk");
            replaceColour.Add("092063");
            replaceCheckStrings.Add("Key1er");
            replaceReplacements.Add("Sleepwalker");
            replaceReplacementLink.Add("Link_S-leepwalk");
            replaceColour.Add("092063");
            replaceCheckStrings.Add("Key1s");
            replaceReplacements.Add("Sleepwalks");
            replaceReplacementLink.Add("Link_S-leepwalk");
            replaceColour.Add("092063");
            replaceCheckStrings.Add("Key1ing");
            replaceReplacements.Add("Sleepwalking");
            replaceReplacementLink.Add("Link_S-leepwalk");
            replaceColour.Add("092063");
            replaceCheckStrings.Add("Key1ed");
            replaceReplacements.Add("Sleepwalked");
            replaceReplacementLink.Add("Link_S-leepwalk");
            replaceColour.Add("092063");



            bool shouldReplaceColour = false;
            bool shouldReplaceLink = false;
            for (int i = 0; i < replaceCheckStrings.Count; i++)
            {
                //MelonLogger.Msg($"Replacing {replaceCheckStrings[i]} with {replaceReplacements[i]}");
                shouldReplaceLink = (replaceReplacementLink[i] != "");
                shouldReplaceColour = (replaceColour[i] != "");
                string replacementValue = "";
                if (shouldReplaceLink) replacementValue = $"<link=\"{replaceReplacementLink[i]}\">";
                if (shouldReplaceColour) replacementValue += $"<color=#{replaceColour[i]}>";
                replacementValue += $"{replaceReplacements[i]}";
                if (shouldReplaceColour) replacementValue += $"</color>";
                if (shouldReplaceLink) replacementValue += $"</link>";
                if (value.Contains(replaceCheckStrings[i]))
                {
                    value = value.Replace(
                            $"{replaceCheckStrings[i]}",
                            $"{replacementValue.ToString()}"
                        );
                }
            }
            return value;
        }
        return "We've got problems!";
    }
    [HarmonyPatch(typeof(TextTooltipRecognizer), "GetTooltipInfo")]
    public static class TooltipPatch
    {
        static void Postfix(string linkID, ref TooltipInfo __result)
        {
            wx_KeywordPatch patcher = new();
            if (linkID == "Link_H-onest")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A character who is not Disguised. This means that their True Role is the one that they are claiming."),
                    "Honest",
                    new Color32(122, 198, 255, 255)
                );
            }
            if (linkID == "Link_P-ure")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A character who is not Corrupted."),
                    "Pure",
                    new Color32(122, 198, 255, 255)
                );
            }
            if (linkID == "Link_H-eal")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Increases your remaining Health by the specified amount.\nThis cannot increase your Health to a number higher than your Max Health."),
                    "Heal",
                    new Color32(46, 255, 66, 255)
                );
            }
            if (linkID == "Link_H-ealth")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Your most important resource.\n\nGain Health by saving the village.\nLose health when you Execute a Good character.\nSome character abilities may also Heal or Damage you.\n\nIf your Health drops to zero, you Lose!"),
                    "Health",
                    new Color32(122, 251, 255, 255)
                );
            }
            if (linkID == "Link_D-amage")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Reduces your remaining Health by the specified amount.\nIf this drops your Health to or below zero, you Lose."),
                    "Damage",
                    new Color32(199, 36, 36, 255)
                );
            }
            if (linkID == "Link_R-ole")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A character's Role is what determines their Alignment, Type, abilities, and just about everything else about the way you play.\n\nMost Good characters will be Honest, showing their True Role.\nMost Evil characters will Disguise, hiding their True Role.\n\nMost information about Roles is accurate, but some characters may Register as a different Role.\nA character's True Role is the Role revealed when most characters are Executed. This is also the role that determines nearly everything about the character."),
                    "True Role",
                    new Color32(87, 230, 156, 255)
                );
            }
            if (linkID == "Link_R-eveal")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Clicking on a card Reveals it, flipping it face-up to show you which Role is underneath it.\n\nCertain characters, usually Evil, will Disguise. This hides their True Role, as they will show up as their Disguise when Revealed.\n\nSome roles, such as the Witch, may prevent you from Revealing cards under certain circumstances.\n\nDead characters cannot be Revealed, but Executing a character Reveals them by default."),
                    "Reveal",
                    new Color32(161, 230, 226, 255)
                );
            }
            if (linkID == "Link_Unr-eveal")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A face-down card that has not been Revealed yet.\n\nDead characters don't usually count as Unrevealed, and if killed by a means other than Execution, they don't usually count as Revealed either."),
                    "Unrevealed",
                    new Color32(105, 125, 145, 255)
                );
            }
            if (linkID == "Link_B-luff")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A character who has an attribute other than Type, Alignment & Role that is Registering falsely. This usually refers to a character's Truthfulness or Honesty.\n\nCharacters who check the Bluffed attribute will see that attribute as what it's being Bluffed as, not what it actually is."),
                    "Bluff",
                    new Color32(216, 110, 219, 255)
                );
            }
            if (linkID == "Link_A-ttack")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"The act of Killing a character.\n\nMost characters will Die when they are Attacked, but some may have resistance due to their own ability or another character's ability.\n\nAttacks will most commonly come from Executions, but certain roles will also Attack other characters."),
                    "Attack",
                    new Color32(255, 0, 55, 255)
                );
            }
            if (linkID == "Link_D-eath")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"This character has been Attacked and Killed.\n\nMost Dead characters' abilities deactivate, but some don't.\n\nUnused Pick abilities can still be used, unless the character was Killed while Unrevealed."),
                    "Dead",
                    new Color32(179, 105, 121, 255)
                );
            }
            if (linkID == "Link_A-live")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"This character has not been Killed. If they have been Attacked, they have survived the attack.\n\nMost character abilities only work while the character is Alive, but some may work from beyond the grave."),
                    "Alive",
                    new Color32(164, 237, 183, 255)
                );
            }
            if (linkID == "Link_D-eck")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"The Roles that can appear in the current village.\n\nEvery Role that could be in the current village is in the Deck, but not every Role in the Deck is in the current village.\n\nSome Roles may add other Roles to the Deck, or obscure parts of it."),
                    "Deck",
                    new Color32(120, 154, 240, 255)
                );
            }
            if (linkID == "Link_W-in")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"The village is safe!\n\nVictory can be achieved by killing all Evil characters before your health falls to zero, or through certain character abilities.\n\nWinning a village ends the current round."),
                    "Win",
                    new Color32(0, 255, 0, 255)
                );
            }
            if (linkID == "Link_L-ose")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Evil wins!\n\nDefeat happens when your Health drops to zero via Damage from character abilities or Good Executions. Some Roles also have abilities that can cause a premature loss.\n\nLosing a village ends the current round and resets your streak."),
                    "Lose",
                    new Color32(255, 0, 0, 255)
                );
            }
            if (linkID == "Link_U-nmask")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"This character drops its Disguise and reveals any statuses it has on it."),
                    "Unmask",
                    new Color32(181, 233, 255, 255)
                );
            }
            if (linkID == "Link_D-eclare")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"A statement that is always true, even if the character is Lying."),
                    "Declare",
                    new Color32(255, 255, 0, 255)
                );
            }
            if (linkID == "Link_C-ycle")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Abilities which use a Cycle as their trigger will Activate every X times any character is Revealed, even if the character with the Cycle ability hasn't been Revealed yet."),
                    "Cycle X",
                    new Color32(153, 204, 204, 255)
                );
            }
            if (linkID == "Link_A-lignment")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Whether a character is Good or Evil.\n\nAll Evil characters must be Killed in order for you to Win.\nExecuting a Good character usually deals a significant amount of Damage to you."),
                    "Alignment",
                    new Color32(192, 128, 255, 255)
                );
            }
            if (linkID == "Link_T-ype")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Whether a character is a Villager, an Outcast, a Minion or a Demon.\n\nVillagers and Outcasts are usually Good, while Minions and Demons are usually Evil."),
                    "Type",
                    new Color32(182, 86, 221, 255)
                );
            }
            if (linkID == "Link_T-ruthfulness")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Whether a character is Truthful or Lying.\n\nTruthful characters have the ability they are claiming to have, and information they give will be correct.\nLying characters do not have the ability they are claiming to have, and any information they give will be wrong."),
                    "Truthfulness",
                    new Color32(153, 255, 153, 255)
                );
            }
            if (linkID == "Link_H-onesty")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Whether a character is Honest or Disguised.\n\nAn Honest character reveals their True Role when you Reveal their card.\nA Disguised character instead reveals a fake claim when you Reveal their card.\n\nMost Good characters are Honest, and most Evil characters Disguise."),
                    "Honesty",
                    new Color32(122, 197, 255, 255)
                );
            }
            if (linkID == "Link_P-urity")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"Whether a character is Corrupted or Pure."),
                    "Purity",
                    new Color32(255, 122, 184, 255)
                );
            }
            if (linkID == "Link_S-leepwalk")
            {
                __result = new TooltipInfo(
                    patcher.PatchTooltip($"This character's ability gains an extra charge at Night.\n\nIt is recommended to use their ability during the Day so that the ability can refresh properly at night!"),
                    "Sleepwalk",
                    new Color32(9, 32, 99, 255)
                );
            }
        }
    }
}
