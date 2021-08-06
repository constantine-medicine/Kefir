using UnityEngine;

[CreateAssetMenu(menuName = "Events/BlankEvent", fileName = "BlankEvent", order = 51)]
public class BlankEvent : ScriptableObject
{
    public delegate void OnEvent();

    private event OnEvent _listeners;

    public event OnEvent Listeners
    {
        add
        {
            _listeners -= value;
            _listeners += value;
        }
        remove
        {
            _listeners -= value;
        }
    }

    public void Raise()
    {
        _listeners?.Invoke();
    }
}
