using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    
    public string charaterName;
    public int charaterLvl;
    public  int conScore;
    public bool isHillDawrf;
    public bool hasTough;
    public bool isAvg;
    public string classInput;

    Dictionary<string, int> classHitDie = new Dictionary<string, int>()
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
    // Start is called before the first frame update
    void Start()
    {
        CheckValues(conScore, classInput);
    }

    void CheckValues(int con, string class)
    {

    }
}
