using UnityEngine;

public class GoblinWalkState : GoblinState
{
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        Animator.Play("Walk");
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }

    private void Update()
    {
        if (Target != null)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }
}
