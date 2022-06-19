using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    // ------------------Variables------------------
        public float timeToDestroy = 0f;


    // ------------------Start------------------
        void Start()
        {
            StartCoroutine(FadeOut(gameObject.GetComponent<SpriteRenderer>(), 2.0f));
        }

    // ------------------Updates------------------
        void FixedUpdate()
        {
            Destroy(gameObject, timeToDestroy);
        }

    // ------------------FadeOut------------------
        IEnumerator FadeOut(SpriteRenderer MyRenderer, float duration)
        {
            float counter = 0;
            Color spriteColor = MyRenderer.material.color;
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1);

            while (counter < duration)
            {
                counter += Time.deltaTime;
                float alpha = Mathf.Lerp(1, 0, counter / duration);

                MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
                yield return null;
            }
        }
}