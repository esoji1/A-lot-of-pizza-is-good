using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private const string IsIdle = "IsIdle";
    private const string IsRuning = "IsRuning";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void StartRuning() => _animator.SetBool(IsRuning, true);
    public void StopRuning() => _animator.SetBool(IsRuning, false);
}
