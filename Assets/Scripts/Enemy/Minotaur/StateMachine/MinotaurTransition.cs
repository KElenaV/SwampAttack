using UnityEngine;

public abstract class MinotaurTransition : MonoBehaviour
{
    [SerializeField] private MinotaurState _nextState;

    public bool NeedTransit { get; protected set; }
    public MinotaurState NextState => _nextState;
    protected Player Target { get; private set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player target)
    {
        Target = target;
    }
}
