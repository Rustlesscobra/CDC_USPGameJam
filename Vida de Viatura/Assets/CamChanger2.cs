using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChanger2 : MonoBehaviour
{
    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private Collider2D col;

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cam0.SetActive(false);
                cam1.SetActive(true);
                cam2.SetActive(false);
                cam3.SetActive(false);
            }
        }  
}

