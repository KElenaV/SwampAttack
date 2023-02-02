using UnityEngine;

public class MinotaurAttackState : MinotaurState
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Animator _animator;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
