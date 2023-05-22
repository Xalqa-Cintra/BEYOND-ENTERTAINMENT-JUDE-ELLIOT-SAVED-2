using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomesNames : MonoBehaviour
{
    // if "Playerwcam1" is in area then change text to "*Bunker*"
    // if "Playerwcam1" is in area then change text to "*Red Room*"
    // if "Playerwcam1" is in area then change text to "*No mans land*"
    // if "Playerwcam1" is in area then change text to "*Camp*"
    // else text set to "* wilderness*"

    // try to find a grid way to select the grid for a bit of map
    // if player is in box 1 then name "no mans land" or gameobject
    // if player is in box 2 then name "red Room" or gameobject
    // if player is in box 3 then name "Bunker" or gameobject
    // else the player is name "wilderness" 
    // to set the areas as triggers to see if the player is on it

    public Text Grounded;

    public void OnTriggerEnter()
    {

    }
}
