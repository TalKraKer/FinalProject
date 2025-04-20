using UnityEngine;

public class PlantRequest : MonoBehaviour
{
    public int waterRequirement;
    public int difficultyRequirement;
    public SunRequirement sunRequirement;

    void Awake()
    {
        GenerateRandomRequest();
    }

    public void GenerateRandomRequest()
    {
        waterRequirement = Random.Range(1, 4);
        difficultyRequirement = Random.Range(1, 4);
        sunRequirement = (SunRequirement)Random.Range(0, 3);
    }
}
