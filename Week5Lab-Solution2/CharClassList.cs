using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by Nathan Irwin

public class CharClassList
{
    public Dictionary<string, int> classDict = new Dictionary<string, int>()
        {
            { "Artificer", 8 },
            { "Barbarian", 12 },
            { "Bard", 8 },
            { "Cleric", 8 },
            { "Druid", 8 },
            { "Fighter", 10 },
            { "Monk", 8 },
            { "Ranger", 10 },
            { "Rogue", 8 },
            { "Paladin", 10 },
            { "Sorcerer", 6 },
            { "Wizard", 6 },
            { "Warlock", 8 }
        };
}
// This class holds the dictionary for character classes and their respective hit die values.
