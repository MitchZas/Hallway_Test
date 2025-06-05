using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RaycastTest : MonoBehaviour
{
    Ray ray;
    void Start()
    {
        
       
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        ColliderCheck();
    }

    void ColliderCheck()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.tag);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
