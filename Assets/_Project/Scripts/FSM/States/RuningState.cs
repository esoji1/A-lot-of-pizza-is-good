public class RuningState : MovementState
{
    public RuningState(Player player, IStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        PlayerView.StartRuning();
    }

    public override void Exit()
    {
        PlayerView.StopRuning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitcherState<IdleState>();
    }
}
