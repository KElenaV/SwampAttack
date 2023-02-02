using UnityEngine;

public abstract class GoblinTransition : MonoBehaviour
{
    [SerializeField] private GoblinState _nextState;

    protected Player Target;

    public GoblinState NextState => _nextState;
    public bool NeedTransit { get; protected set; }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player target)
    {
        Target = target;
    }
}
