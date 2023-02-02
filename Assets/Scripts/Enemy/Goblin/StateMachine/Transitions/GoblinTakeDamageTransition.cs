using UnityEngine;

public class GoblinTakeDamageTransition : GoblinTransition
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            NeedTransit = true;
        }
    }
}
