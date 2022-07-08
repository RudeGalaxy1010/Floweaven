using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private int _money;

    public int Money => _money;

    public bool TrySpend(int value)
    {
        if (_money >= value)
        {
            _money -= value;
            return true;
        }

        return false;
    }

    public void AddMoney(int value)
    {
        _money += value;
    }
}
