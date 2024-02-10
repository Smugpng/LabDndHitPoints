using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    [SerializeField]
    public string charaterName;
    public int charaterLvl;
    public int conScore;
    public bool isHillDawrf;
    public bool hasTough;
    public bool isAvg;
    public string classInput;

    public int CalcTotalHp()
    {
        Dictionary<string, int> hitDice = new Dictionary<string, int>()
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
        Dictionary<int, int> conScoreFind = new Dictionary<int, int>()
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

        int hp = 0;
        if (hitDice.ContainsKey(Class))
        {
            int hitDie = hitDice[Class];
            int totalHitDice = GetTotalHitDice();
            int conModifier = GetConModifier();

            hp = totalHitDice + hitDie + (totalHitDice * conModifier);

        }
        if (isHillDawrf)
        {
            hp += 1;
        }
        if (hasTough)
        {
            hp += (2 * GetTotalHitDice());
        }
        return hp;
    }
    private int GetTotalHitDice()
    {
        return 1 + charaterLvl;
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new Player("charaterName", "classInput", "charaterLvl", true, true);
            int totalHP = player.CalculateTotalHP();
            Console.WriteLine($"Total HP for {player.Name} is {totalHP}");
        }
    }
    //???


}
