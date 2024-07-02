using UnityEngine;
public static class GameUtils
{
    public static Vector3 GetRandomPosition(Vector3 center, float minRange, float maxRange)
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(minRange, maxRange);

        float x = center.x + randomDistance * Mathf.Cos(randomAngle);
        float z = center.z + randomDistance * Mathf.Sin(randomAngle);

        return new Vector3(x, center.y, z);
    }

    public static Transform GetInactiveChild(Transform parent, string childName)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.name == childName)
            {
                return child;
            }

            Transform found = GetInactiveChild(child, childName);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }
}
