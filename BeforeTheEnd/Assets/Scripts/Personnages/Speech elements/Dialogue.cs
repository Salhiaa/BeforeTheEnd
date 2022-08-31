using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public Monologue[] DialogBoxes;
    int chara;
    int prevChara = 1;

    public void Say(string line)
    {
        string[] splitLine = line.Split('/');//Split character number and text
        prevChara = chara;//Get previous speaking character
        chara = int.Parse(splitLine[0]);//Get previous current character
        if (chara != prevChara)//Compare them
        {
            DialogBoxes[prevChara].Say("", true);//Hide previous speech box if different
        }
        DialogBoxes[chara].Say(splitLine[1], false);//Display dialog
    }

    //Clear last speech box used
    public void clear()
    {
        DialogBoxes[chara].Say("", true);
    }
}