public class GoblinJumpState : GoblinState
{
    private void OnEnable()
    {
        Animator.Play("Jump");
    }
}
