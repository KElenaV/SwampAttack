public class GoblinTargetDiedTransition : GoblinTransition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
