using UnityEngine;

public class Gun : Weapon
{
    private Bullet _bullet = null;
    
    public override void Shoot(Transform shootPoint)
    {
        if (_bullet == null)
        {
            _bullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        }
    }
}
