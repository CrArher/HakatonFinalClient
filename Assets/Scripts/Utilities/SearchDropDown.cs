using UnityEngine;
using UnityEngine.EventSystems;

namespace Utilities
{
    public class SearchDropDown :MonoBehaviour,IPointerDownHandler
    {
        private bool IsActive;
        public GameObject SearchRoot;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            IsActive = !IsActive;
            SearchRoot.gameObject.SetActive(IsActive);
        }
    }
}