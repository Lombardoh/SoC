using UnityEngine;

public static class UnitUtils
{
    public static GameObject FindClosestTarget(Transform unitTransform, TagType tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag.ToString());
        GameObject closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            Vector3 directionToTarget = target.transform.position - unitTransform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestTarget = target;
            }
        }

        return closestTarget;
    }
}
