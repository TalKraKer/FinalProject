using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantSO[] PlantTypes;
    [SerializeField] PlantSO currentPlantType;
    void Start()
    {
        if (currentPlantType == null)
        {
            currentPlantType = PlantTypes[Random.Range(0,PlantTypes.Length)];
        }
        GetComponent<SpriteRenderer>().sprite = currentPlantType.Image;
    }
}
