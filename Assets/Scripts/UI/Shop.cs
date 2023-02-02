using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponCard _weaponCard;
    [SerializeField] private GameObject _shopContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var item = Instantiate(_weaponCard, _shopContainer.transform);
        item.SellButtonClick += OnSellButtonClick;

        item.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponCard weaponCard)
    {
        TrySellWeapon(weapon, weaponCard);
    }

    private void TrySellWeapon(Weapon weapon, WeaponCard weaponCard)
    {
        if (_player.Money >= weapon.Price)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponCard.SellButtonClick -= OnSellButtonClick;
        }
    }
}