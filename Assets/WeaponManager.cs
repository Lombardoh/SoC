using UnityEngine;

public class WeaponManager : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IDamageable>(out var _IUnitManager))
        {
            _IUnitManager.TakeDamage();
        }
    }
}
