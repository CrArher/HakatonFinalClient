using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BurgerMenu
{
    public class BurgerMenuComponent : MonoBehaviour,IPointerDownHandler
    {
        private float period = 0.03f;
        private float time;
        private bool OnStart;
        public Image Root;
        public void OnPointerDown(PointerEventData eventData)
        {
            OnStart = !OnStart;
            if (OnStart)
            {
                Root.gameObject.SetActive(true);
            }
        }

        public void Update()
        {
            time -= Time.deltaTime;
            if (OnStart)
            {
                if (Root.transform.localScale.x <15 && time<=0)
                {
                    var scale = Root.transform.localScale;
                    scale.x += 1;
                    scale.y += 1;
                    Root.transform.localScale = scale;
                }
            }
            else
            {
                if (Root.transform.localScale.x>1)
                {
                    if (time<=0)
                    {
                        var scale = Root.transform.localScale;
                        scale.x -= 1;
                        scale.y -= 1;
                        Root.transform.localScale = scale;
                    }
                }
                else
                {
                    Root.gameObject.SetActive(false);
                }
                
            }
            
        }
    }
}