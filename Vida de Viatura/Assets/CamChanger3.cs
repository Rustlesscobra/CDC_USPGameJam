using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChanger3 : MonoBehaviour
{
    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private Collider2D col;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cam0.SetActive(false);
                cam1.SetActive(false);
                cam2.SetActive(true);
                cam3.SetActive(false);
            }
        }
}
