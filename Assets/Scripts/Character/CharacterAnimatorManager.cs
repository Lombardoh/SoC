using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    private void Awake()
    {
        character = GetComponent<CharacterManager>();
    }
    public void UpdateAnimatorMovementParameter(float horizontalValue, float verticalValue)
    {
        character.animator.SetFloat("Horizontal", horizontalValue);
        character.animator.SetFloat("Vertical", verticalValue);
    }
}
