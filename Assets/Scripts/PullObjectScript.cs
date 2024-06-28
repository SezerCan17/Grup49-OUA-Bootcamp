using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class PullObjectScript : MonoBehaviour
    {

    public bool isInside;
    public bool pull;

    private void Awake()
    {
        isInside = false;
        pull = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            pull = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obje")
        {
            Debug.Log("Taþýnabilir Obje");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag =="Obje")
        {
            Debug.Log("Ýçeride");
            isInside = true;
            if(pull == true)
            {
                // 'other' collision veya trigger olayýndan gelen Collider
                Transform firstChildTransform = other.gameObject.transform.GetChild(0);

                // Ýlk child'ýn pozisyonunu al
                Vector3 pos = firstChildTransform.position;

                // Bu objenin pozisyonunu, ilk child'ýn pozisyonuna ayarla
                gameObject.transform.position = pos;


            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obje")
        {
            Debug.Log("Çýkýldý");
            isInside = false;
            pull = false ;
        }
        
    }
}


