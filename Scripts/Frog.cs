using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    // ------------------Variables------------------
        public GameObject muerte;           // GameObject de muerte
        public Collider2D froggy;           // GameObject de la rana
        public static bool stop = false;    // Variable para saber si el juego esta en pausa
        public static int avance = -6;      // Avance que lleva el personaje para aumentar puntos (-6 es el comienzo)


    // ------------------Updates------------------
        private void Update()
        {
            // Solo puede avanzar si no se esta en la pausa de cuando se pierde o se gana
            if (stop == false)
            {
                // Arriba
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    if ((transform.position + Vector3.up)[1] <= 6)
                    {
                        transform.position += Vector3.up;
                    }
                }
                // Abajo
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    if ((transform.position + Vector3.down)[1] >= -6)
                    {
                        transform.position += Vector3.down;
                    }

                }
                // Izquierda
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    if ((transform.position + Vector3.left)[0] >= -9.33)
                    {
                        transform.position += Vector3.left;
                    }
                }
                // Derecha
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    if ((transform.position + Vector3.right)[0] <= 9.33)
                    {
                        transform.position += Vector3.right;
                    }
                }
                checkPoints();
            }
        }


    // ------------------Verificar avance de puntos------------------
        void checkPoints()
        {
            // Checa si avanzo solamente de manera vertical
            if ( transform.position[1] > avance)
            {
                avance++;
                Score.score += 10;
            }
        }


    // ------------------Triggers------------------
        void OnTriggerEnter2D(Collider2D col)
        {
            // Toca una plataforma movediza (los troncos)
            if ( froggy.IsTouchingLayers(1 << 8) )
            {
                transform.SetParent(col.transform);
                return;
            }
            else
            {
                transform.SetParent(null);
            }

            // Toca a un enemigo
            if (froggy.IsTouchingLayers(1 << 10))
            {
                ActivarMuerte();
                transform.SetParent(null);
                transform.position = new Vector3(0, -6, 0);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                Vidas.vidas--;
            }

            // Toca el agua 
            else if ( froggy.IsTouchingLayers(1 << 9) )
            {
                ActivarMuerte();
                transform.SetParent(null);
                transform.position = new Vector3(0, -6, 0);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                Vidas.vidas--;
            }

            // Toca una de las casitas
            else if (froggy.IsTouchingLayers(1 << 11))
            {
                // Si no esta activa se activa
                if (col.transform.GetChild(0).gameObject.activeSelf == false)
                {
                    Score.score += 100;
                    Score.ranitasCasita++;
                    transform.SetParent(null);
                    col.transform.GetChild(0).gameObject.SetActive(true);
                    transform.position = new Vector3(0, -6, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    avance = -6;
                }
                // Si esta activa se muere
                else
                {
                    ActivarMuerte();
                    transform.SetParent(null);
                    transform.position = new Vector3(0, -6, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    Vidas.vidas--;
                }
            }


        }

        void OnTriggerStay2D(Collider2D col)
        {
            // Mientras este dentro del Collider del agua
            if (col.tag == "Water")
            {
                // Toca el agua pero no una plataforma
                if ( !froggy.IsTouchingLayers(1 << 8) )
                {
                    ActivarMuerte();
                    transform.SetParent(null);
                    transform.position = new Vector3(0, -6, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    Vidas.vidas--;
                }

                // Toca el agua y la barrera
                else if (froggy.IsTouchingLayers(1 << 10))
                {
                    ActivarMuerte();
                    transform.SetParent(null);
                    transform.position = new Vector3(0, -6, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    Vidas.vidas--;
                }
            }

        }


    // ------------------Muerte------------------
        void ActivarMuerte()
        {
            Instantiate(muerte, transform.position, Quaternion.Euler(0, 0, 0));
            //muerte.transform.position = transform.position;
            
            StartCoroutine(WaitTime(2));
    }


    // ------------------Timer------------------
        public IEnumerator WaitTime(float t)
        {
            yield return new WaitForSeconds(t);
        }
}