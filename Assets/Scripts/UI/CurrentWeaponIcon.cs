using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentWeaponIcon : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _player.WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        _image.sprite = weapon.Icon;
    }
}
