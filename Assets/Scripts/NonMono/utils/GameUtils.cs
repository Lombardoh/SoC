using UnityEngine;
public static class GameUtils
{
    public static Vector3 GetRandomPosition(Vector3 center, float maxRange)
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(0f, maxRange);

        float x = center.x + randomDistance * Mathf.Cos(randomAngle);
        float z = center.z + randomDistance * Mathf.Sin(randomAngle);

        return new Vector3(x, center.y, z);
    }
}
