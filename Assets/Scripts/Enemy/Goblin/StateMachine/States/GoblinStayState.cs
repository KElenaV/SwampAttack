public class GoblinStayState : GoblinState
{
    private void OnEnable()
    {
        Animator.Play("Stay");
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }
}
