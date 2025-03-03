using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 5;

    private PlayerView _playerView;
    private PlayerStateMachine _playerStateMachine;
    private JoystickForMovement _joystickForMovement;
    private Rigidbody _rigidbody;

    public PlayerView PlayerView => _playerView;
    public JoystickForMovement JoystickForMovement => _joystickForMovement;
    public Rigidbody Rigidbody => _rigidbody;
    public int Speed => _speed;

    [Inject]
    public void Construct(JoystickForMovement joystickForMovement)
    {
        _rigidbody = GetComponent<Rigidbody>();

        _playerView = GetComponentInChildren<PlayerView>();
        _playerView.Initialize();

        _playerStateMachine = new PlayerStateMachine(this);
        _joystickForMovement = joystickForMovement;
    }

    private void Update()
    {
        _playerStateMachine.Update();
    }
}
