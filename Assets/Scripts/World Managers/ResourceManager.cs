using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private void OnTakeDamage(Action<bool> response)
    {
        response?.Invoke(true);
    }
}
