using Zenject.SpaceFighter;

public class IdleState : MovementState
{
    public IdleState(Player player, IStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        PlayerView.StartIdle();
    }

    public override void Exit()
    {
        PlayerView.StopIdle();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero() == false)
            StateSwitcher.SwitcherState<RuningState>();
    }
}
