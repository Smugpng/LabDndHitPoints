using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by Nathan Irwin

public class HPCalc2 : MonoBehaviour
{
    public string characterName;
    public int characterLvl;
    public string characterClass;
    public int characterCon;
    public bool isHillDwarf;
    public bool hasTough;
    public bool isAveraged;
    // These variables are editable in the editor.
    // They set up basic info about your character.
    // Note that character class requires a capital letter, and Con score must be a number 1 through 30.

    ConScoreList conMod = new ConScoreList();
    CharClassList hitDie = new CharClassList();
    // These variables reference the other two scripts. They are classes that contain the dictionaries for CON Score and Classes.

    public void Start()
    {
        int conModValue = 0;
        int hitDieValue = 0;
        int baseHP = 0;
        int absHP = 0;
        int finalHP = 0;
        // Additional variables needed to store certain values.

        CheckValues(characterClass, characterCon);
        // Checks the inputs on values with constraints.

        conModValue = conMod.conDict[characterCon];
        //Debug.Log(conModValue);
        hitDieValue = hitDie.classDict[characterClass];
        //Debug.Log(hitDieValue);
        // Assigns values from the dictionaries based on input.

        if(isAveraged)
        {
            baseHP = averageHPCalc(characterLvl, hitDieValue);
            //Debug.Log(baseHP);
        }
        else
        {
            baseHP = rolledHPCalc(characterLvl, hitDieValue);
            //Debug.Log(baseHP);
        }
        // Checks if HP is to be averaged or not.
        // If averaged, calculates base HP with averages.
        // Otherwise, rolls HP.

        absHP = absHPCalc(characterLvl, conModValue);
        //Debug.Log(absHP);
        // Calculates HP that will be added by the CON modifier.

        if(isHillDwarf)
        {
            finalHP += characterLvl;
        }
        if(hasTough)
        {
            finalHP += (characterLvl * 2);
        }
        // Conditionals for adding extra HP based on race and the Tough feat.

        finalHP += baseHP + absHP;
        // Adds Base HP and Ability Score HP to Final HP

        printResult(characterName, characterLvl, characterClass, characterCon, isHillDwarf, hasTough, isAveraged, finalHP);
    }

    public void CheckValues(string charClass, int con)
    {
        if(!this.hitDie.classDict.ContainsKey(charClass))
        {
            Debug.Log("The class you input is not on the list, so I'll give you Rogue instead.");
            this.characterClass = "Rogue";
            //Debug.Log("checking");
        }

        if(characterCon <= 0)
        {
            Debug.Log("The CON score you entered is less than 1, so I set it to 1.");
            this.characterCon = 1;
        }

        if(characterCon >= 31)
        {
            Debug.Log("The CON score you entered is greater than 30, so I set it to 30.");
            this.characterCon = 30;
        }
    }
    // This function checks the input that has constraints.
    // Any class name that doesn't match with the dictionary will instead be a Rogue, with a hit die of 8.
    // Any CON score less than 1 is set to 1. Any above 30 will be set to 30.

    public int averageHPCalc(int level, int hitdie)
    {
        int hpValue = 0;
        hpValue = (level * ((hitdie / 2) + 1));
        return hpValue;
    }
    // This function calculates base HP using the average of the hit die value, rounded up.

    public int rolledHPCalc(int level, int hitdie)
    {
        int hpValue = 0;
        for (int i = 0; i < level; i++)
        {
            hpValue += Random.Range(1, (hitdie + 1));
        }
        return hpValue;
    }
    // This function calculates HP by rolling HP per level using the hit die value of the class.

    public int absHPCalc(int level, int modValue)
    {
        int hpValue = 0;
        if(modValue < 0)
        {
            hpValue = 0;
            return hpValue;
        }
        hpValue = (level * modValue);
        return hpValue;
    }
    // This function calculates HP added through the CON Score mod.
    // If your CON Mod is negative, it will act as though your modifier is 0.

    public void printResult(string name, int level, string className, int con, bool hilldwarf, bool tough, bool average, int hitpoints)
    {
        string hilldwarfTerm;
        string toughTerm;
        string averageTerm;

        if(hilldwarf)
        {
            hilldwarfTerm = "is";
        }
        else
        {
            hilldwarfTerm = "is not";
        }
        if(tough)
        {
            toughTerm = "has";
        }
        else
        {
            toughTerm = "does not have";
        }
        if(average)
        {
            averageTerm = "averaged";
        }
        else
        {
            averageTerm = "rolled";
        }

        Debug.Log("My character " + name + " is a level " + level + " " + className + " with a CON score of " + con + " and " + hilldwarfTerm + " a Hill Dwarf and " + toughTerm + " the Tough feat. I want the HP " + averageTerm + ".");
        Debug.Log("Your final HP is: " + hitpoints);
    }
    // This is the print function for the program.
    // It uses the boolean values to set some language that is used to show what you have input.
    // Then, it tells you what you input and your final HP.
}
