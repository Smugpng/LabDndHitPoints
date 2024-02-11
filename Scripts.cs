using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    [SerializeField]
    public string charaterName;
    public int characterLvl;
    public string classInput;
    public int conScore;
    public bool isHillDwarf;
    public bool hasTough;
    public bool isAvg;

    public Dictionary<int, int> conDict = new Dictionary<int, int>()
        {
            {1,-5},
        {2,-4},
        {3,-4},
        {4,-3},
        {5,-3},
        {6,-2},
        {7,-2},
        {8,-1},
        {9,-1},
        {10,0},
        {11,0},
        {12,1},
        {13,1},
        {14,2},
        {15,2},
        {16,3},
        {17,3},
        {18,4},
        {19,4},
        {20,5},
        {21,5},
        {22,6},
        {23,6},
        {24,7},
        {25,7},
        {26,8},
        {27,8},
        {28,9},
        {29,9},
        {30,10}
        };
    public Dictionary<string, int> classDict = new Dictionary<string, int>()
        {
            {"Artificer",8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8}
        };

    public void Start()
    {
        int conModValue = 0;
        int hitDieValue = 0;
        int baseHP = 0;
        int abHP = 0;
        int hpFinal = 0;

        CheckValues(classInput, conScore);

        conModValue = conDict[conScore];
        hitDieValue = classDict[classInput];

        if (isAvg)
        {
            baseHP = hpAvgCalc(characterLvl, hitDieValue);
        }
        else
        {
            baseHP = hpRolledCalc(characterLvl, hitDieValue);
        }
        abHP = hpAbCalc(characterLvl, conModValue);
        if (isHillDwarf)
        {
            hpFinal += characterLvl;
        }
        if (hasTough)
        {
            hpFinal += (characterLvl * 2);
        }

        hpFinal += baseHP + abHP;
        printResult(charaterName, characterLvl, classInput, conScore, isHillDwarf, hasTough, isAvg, hpFinal);
    }
    public void CheckValues(string classInput, int con)
    {
        if (!this.classDict.ContainsKey(classInput))
        {
            Debug.Log("Class input invalid, set to wizard");
            this.classInput = "Wizard";
        }

        if (conScore <= 0)
        {
            Debug.Log("Invalid Con Score set to one");
            this.conScore = 1;
        }
        if (conScore >= 31)
        {
            Debug.Log("Con Score invalid set to 30");
            this.conScore = 30;
        }
    }

    public int hpAvgCalc(int characterLvl, int hitDieValue)
    {
        int hpValue = 0;
        hpValue = (characterLvl * ((hitDieValue / 2) + 1));
        return hpValue;
    }

    public int hpRolledCalc(int characterLvl, int hitDieValue)
    {
        int hpValue = 0;
        for (int i = 0; i < characterLvl; i++)
        {
            hpValue += Random.Range(1, (hitDieValue + 1));
        }
        return hpValue;
    }

    public int hpAbCalc(int characterLvl, int conModValue)
    {
        int hpValue = 0;
        if (conModValue < 0)
        {
            hpValue = 0;
            return hpValue;
        }
        hpValue = (characterLvl * conModValue);
        return hpValue;
    }
    public void printResult(string name, int level, string className, int con, bool hilldwarf, bool tough, bool average, int hitpoints)
    {
        string hilldwarfTerm;
        string toughTerm;
        string averageTerm;

        if (hilldwarf)
        {
            hilldwarfTerm = "is";
        }
        else
        {
            hilldwarfTerm = "is not";
        }
        if (tough)
        {
            toughTerm = "has";
        }
        else
        {
            toughTerm = "does not have";
        }
        if (average)
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
}