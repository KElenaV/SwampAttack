using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;
    private bool _isWorking = true;
    
    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;
 
    private void Start()
    {
        _currentHealth = _health;
        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isWorking == true)
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0 && gameObject != null)
            Destroy(gameObject);
    }

    public void BuyWeapon(Weapon weapon)
    {
        RemoveMoney(weapon.Price);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;
        
        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void RemoveMoney(int money)
    {
        Money -= money;
        MoneyChanged?.Invoke(Money);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(weapon);
    }

    public void DisableWorking()
    {
        _isWorking = false;
    }

    public void EnableWorking()
    {
        _isWorking = true;
    }
}
