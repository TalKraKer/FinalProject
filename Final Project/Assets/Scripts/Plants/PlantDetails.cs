using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlantDetailsSO",menuName = "plant",order =1)]
public class PlantD : ScriptableObject
{
    [SerializeField] int Price;
    [SerializeField] int NeededWater;
    [SerializeField] int NeededShade;
    [SerializeField] int Level;
    [SerializeField] Sprite Icon;
}
