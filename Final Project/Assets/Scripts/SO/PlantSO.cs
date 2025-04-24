using UnityEngine;

[CreateAssetMenu(fileName = "PlantSO", menuName = "plantSO", order = 1)]
public class PlantSO : ScriptableObject
{
        public int Price;
        public int waterRequirement;
        public int sunRequirement;
        public int difficultyLevel;
        public Sprite Image;
}