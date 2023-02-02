using System.Collections;
using UnityEngine;

public class GoblinDetonateState : GoblinState
{
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;

    private float _detonateTime;
    
    private void OnEnable()
    {
        if (Target != null)
        {
            Animator.Play("Detonate");
            _detonateTime = _animator.GetCurrentAnimatorStateInfo(0).length;
            StartCoroutine(Detonate());
        }
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(_detonateTime);
        
        if (Target != null) 
            Target.ApplyDamage(_damage);
        
        Destroy(gameObject);
    }
}
