using UnityEngine;

[CreateAssetMenu(fileName = "CardEffect", menuName = "ScriptableObjects/CardEffect", order = 1)]
public class CardEffect : ScriptableObject
{
    
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}