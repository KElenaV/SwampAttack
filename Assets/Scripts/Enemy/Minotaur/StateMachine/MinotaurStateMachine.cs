using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class MinotaurStateMachine : MonoBehaviour
{
    [SerializeField] private MinotaurState _startState;

    private Player _target;
    private MinotaurState _currentState;

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
        
        if(nextState != null)
            Transit(nextState);
    }

    private void Transit(MinotaurState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState?.Enter(_target);
    }
}
