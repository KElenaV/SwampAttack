using UnityEngine;
using Random = UnityEngine.Random;

public class GoblinDistanceTransition : GoblinTransition
{
    [SerializeField] private float _distance;
    [SerializeField] private float _distanceSpread;

    private void Start()
    {
        _distance += Random.Range(-_distanceSpread, _distanceSpread);
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < _distance) 
                NeedTransit = true;
        }
    }
}
