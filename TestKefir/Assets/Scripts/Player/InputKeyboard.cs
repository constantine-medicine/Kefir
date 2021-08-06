using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _rightRotate;
    [SerializeField] private KeyCode _leftRotate;
    [SerializeField] private KeyCode _shootOnMachineGun;
    [SerializeField] private KeyCode _shootOnLazerGun;

    public KeyCode Up { get => _up; }
    public KeyCode Down { get => _down; }
    public KeyCode RightRotate { get => _rightRotate; }
    public KeyCode LeftRotate { get => _leftRotate; }
    public KeyCode ShootOnMachineGun { get => _shootOnMachineGun; }
    public KeyCode ShootOnLazerGun { get => _shootOnLazerGun; }
}
