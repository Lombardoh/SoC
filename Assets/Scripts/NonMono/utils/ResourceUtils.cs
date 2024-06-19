using UnityEngine;

public static class ResourceUtils
{
    public static GameObject FindClosestResource(Transform origin, ResourceType resourceType)
    {
        GameObject[] resources = GameObject.FindGameObjectsWithTag(resourceType.ToString());
        float closestDistance = Mathf.Infinity;
        GameObject closestResource = null;

        foreach (GameObject resource in resources)
        {
            float distance = Vector3.Distance(origin.position, resource.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestResource = resource;
            }
        }
        return closestResource;
    }
}
