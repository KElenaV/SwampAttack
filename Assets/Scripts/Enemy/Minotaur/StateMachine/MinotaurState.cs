using System.Collections.Generic;
using UnityEngine;

public abstract class MinotaurState : MonoBehaviour
{
    [SerializeField] private List<MinotaurTransition> _transitions;

    protected Player Target;

    public void Enter(Player target)
    {
        Target = target;
        enabled = true;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(target);
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions) 
            transition.enabled = false;

        enabled = false;
    }

    public MinotaurState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
                return transition.NextState;
        }

        return null;
    }
}
