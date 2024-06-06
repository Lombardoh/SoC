using UnityEngine;

public class WeaponManager : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IDamageable>(out var characterManager))
        {
            characterManager.TakeDamage();
        }
    }
}
