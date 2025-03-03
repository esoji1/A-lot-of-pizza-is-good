using System;
using System.Collections.Generic;

public class PlayerStateMachine : IStateSwitcher
{
    private Dictionary<Type, MovementState> _states;
    private MovementState _currentState;

    public PlayerStateMachine(Player player)
    {
        _states = new Dictionary<Type, MovementState>
        {
            { typeof(IdleState), new IdleState(player, this) },
            { typeof(RuningState), new RuningState(player, this) },
        };

        _currentState = _states[typeof(IdleState)];
        _currentState.Enter();
    }

    public void SwitcherState<T>() where T : MovementState
    {
        MovementState state = _states[typeof(T)];

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
