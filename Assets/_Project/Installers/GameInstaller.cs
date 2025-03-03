using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private JoystickForMovement _joystickForMovement;

    public override void InstallBindings()
    {
        PlayerInstaller();
    }

    private void PlayerInstaller()
    {
        Container.BindInterfacesAndSelfTo<JoystickForMovement>().FromInstance(_joystickForMovement).AsSingle();
        Container.Bind<Player>().FromInstance(_player).AsSingle();
    }
}
