using UnityEngine;

public class MinotaurCelebrateState : MinotaurState
{
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _animator.Play("Celebrate");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
