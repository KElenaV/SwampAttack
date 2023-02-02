using System.Collections.Generic;
using UnityEngine;

public abstract class GoblinState : MonoBehaviour
{
    [SerializeField] private List<GoblinTransition> _transitions;

    protected Player Target;
    protected Animator Animator;

    public void Enter(Player target, Animator animator)
    {
        Target = target;
        Animator = animator;
        enabled = true;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        enabled = false;
    }

    public GoblinState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
                return transition.NextState;
        }

        return null;
    }
}
