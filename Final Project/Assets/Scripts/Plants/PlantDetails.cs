using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlantDetailsSO",menuName = "plantSO",order =1)]
public class PlantSO : ScriptableObject
{
    public int Price;
    public int NeededWater;
    public int NeededShade;
    public int Level;
    public Sprite Icon;
}
