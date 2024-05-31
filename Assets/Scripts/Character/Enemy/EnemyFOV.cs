using System.Collections;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    private EnemyManager enemy;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public GameObject player;
    private void Awake()
    {
        enemy = GetComponent<EnemyManager>();
    }
    void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new(0.2f);
        while (true)
        {
            yield return wait;
            CheckFieldOfView();
        }
    }

    void CheckFieldOfView()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    enemy.target = target;
                    enemy.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Following);
                }
                else
                {
                    // Player is within the field of view but obstructed
                }
            }
            else
            {
                enemy.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
            }
        }
        else
        {
            enemy.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Idle);
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 fovLine1 = DirectionFromAngle(-viewAngle / 2, false);
        Vector3 fovLine2 = DirectionFromAngle(viewAngle / 2, false);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + fovLine1 * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + fovLine2 * viewRadius);

        if (player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }

}