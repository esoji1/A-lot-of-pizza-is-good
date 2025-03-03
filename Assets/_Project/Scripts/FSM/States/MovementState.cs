using Unity.VisualScripting;
using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;

    private readonly Player _player;

    protected JoystickForMovement JoystickForMovement => _player.JoystickForMovement;
    protected PlayerView PlayerView => _player.PlayerView;

    private Vector3 InputVector => JoystickForMovement.VectorDirection();

    public MovementState(Player player, IStateSwitcher stateSwitcher)
    {
        _player = player;
        StateSwitcher = stateSwitcher;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        if (IsHorizontalInputZero() == false)
        {
            _player.Rigidbody.MovePosition((_player.Speed * Time.deltaTime * InputVector) + _player.Rigidbody.position);
            RotatePlayer();
        }

    }

    protected bool IsHorizontalInputZero() => InputVector == Vector3.zero;

    private void RotatePlayer()
    {
        if (Vector3.Angle(_player.transform.forward, InputVector) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(_player.transform.forward, InputVector, 10f, 0);
            _player.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
