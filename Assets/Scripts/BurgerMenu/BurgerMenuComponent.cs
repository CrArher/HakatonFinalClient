using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BurgerMenu
{
    public class BurgerMenuComponent : MonoBehaviour
    {
        public GameObject MenuRoot;
        private float speed = 30f;
        private bool Jumping;
        private int jump = 0;
        private float period = 0.03f;
        private float time;
        public bool OnStart;
        public Image Root;
        public Button Show;

        public void Update()
        {
            time -= Time.deltaTime;
            if (OnStart)
            {
                if (time <= 0)
                {
                    time = period;
                    if (Root.transform.position.y > 1000 - Root.rectTransform.rect.height / 2 && !Jumping)
                    {
                        var vector = Root.transform.position;
                        vector.y -= speed;
                        Root.transform.position = vector;
                    }
                    else
                    {
                        if (jump < 0)
                        {
                            Jumping = true;
                            if (Root.transform.position.y <
                                1000 - Root.rectTransform.rect.height / 2 + 100 / (1 + jump))
                            {
                                var vector = Root.transform.position;
                                vector.y += speed;
                                speed -= 1f;
                                Root.transform.position = vector;
                            }
                            else
                            {
                                Jumping = false;
                                jump++;
                            }
                        }
                    }
                }
            }
            else
            {
                if (time <= 0)
                {
                    time = period;
                    if (Root.transform.position.y < 1100 + Root.rectTransform.rect.height / 2 && !Jumping)
                    {
                        var vector = Root.transform.position;
                        vector.y += speed;
                        Root.transform.position = vector;
                    }
                }
            }
        }
    }
}