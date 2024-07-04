using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<IDamageable>(out IDamageable damageable);
        damageable?.TakeDamage();
    }

}
