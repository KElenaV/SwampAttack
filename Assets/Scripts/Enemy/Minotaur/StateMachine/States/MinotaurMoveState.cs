using UnityEngine;

public class MinotaurMoveState : MinotaurState
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Target != null)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }
}
