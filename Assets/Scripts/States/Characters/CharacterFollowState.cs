using Pathfinding;
using UnityEngine;

public class CharacterFollowState : CharacterBaseState
{
    public override void OnEnter(CharacterManager character)
    {
        Seeker seeker = character.GetComponent<Seeker>();
        seeker.StartPath(character.transform.position, character.target.position, OnPathComplete);

        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }
    public override void OnExit(CharacterManager character)
    {
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0);
    }

    public override void Update(CharacterManager character)
    {
        character.characterController.Move(Time.deltaTime * 5f * character.transform.forward);
        character.characterAnimatorManager.UpdateAnimatorMovementParameter(0, 0.5f);
    }
}
