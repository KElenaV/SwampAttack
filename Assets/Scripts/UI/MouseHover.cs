using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Player _player;
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
            _player.DisableWorking();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            _player.EnableWorking();
    }
}
