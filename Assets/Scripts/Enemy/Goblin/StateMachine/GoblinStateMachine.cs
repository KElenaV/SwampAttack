using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class GoblinStateMachine : MonoBehaviour
{
    [SerializeField] private GoblinState _startState;
    [SerializeField] private Animator _animator;

    private GoblinState _currentState;
    private Player _target;
    
    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Transit(_startState);
    }

    private void Update()
    {
        if(_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(GoblinState nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;
        
        _currentState?.Enter(_target, _animator);
    }
}
