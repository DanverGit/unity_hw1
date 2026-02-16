using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float destroyXPosition = -10f;
    public int damage = 1;
}