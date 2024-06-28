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
            Debug.Log("Ta��nabilir Obje");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag =="Obje")
        {
            Debug.Log("��eride");
            isInside = true;
            if(pull == true)
            {
                // 'other' collision veya trigger olay�ndan gelen Collider
                Transform firstChildTransform = other.gameObject.transform.GetChild(0);

                // �lk child'�n pozisyonunu al
                Vector3 pos = firstChildTransform.position;

                // Bu objenin pozisyonunu, ilk child'�n pozisyonuna ayarla
                gameObject.transform.position = pos;


            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obje")
        {
            Debug.Log("��k�ld�");
            isInside = false;
            pull = false ;
        }
        
    }
}


