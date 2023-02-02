using System.Collections;
using UnityEngine;

public class GoblinGroundedTransition : GoblinTransition
{
    [SerializeField] private Animator _animator;
    
    private float _jumpTime;

    protected override void OnEnable()
    {
        base.OnEnable();
        _jumpTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(Transit(_jumpTime));
    }

    private IEnumerator Transit(float jumpTime)
    {
        yield return new WaitForSeconds(jumpTime);
        NeedTransit = true;
    }
}
