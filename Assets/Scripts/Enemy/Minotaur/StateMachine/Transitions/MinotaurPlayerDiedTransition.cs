public class MinotaurPlayerDiedTransition : MinotaurTransition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
