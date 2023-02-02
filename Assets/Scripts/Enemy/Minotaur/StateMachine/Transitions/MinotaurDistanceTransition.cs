using UnityEngine;
using Random = UnityEngine.Random;

public class MinotaurDistanceTransition : MinotaurTransition
{
    [SerializeField] private float _distanceRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _distanceRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < _distanceRange)
                NeedTransit = true;
        }
    }
}
