using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private int _money;

    public int Money => _money;

    public bool HasMoney(int value) => value >= _money;

    public void SpendMoney(int value)
    {
        _money -= value;
    }

    public void AddMoney(int value)
    {
        _money += value;
    }
}
