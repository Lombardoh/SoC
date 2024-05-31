using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private CharacterManager character;
    void Start()
    {
        character = GetComponent<CharacterManager>();           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IDamageable>(out var characterManager))
        {
            characterManager.TakeDamage();
        }
    }
}
