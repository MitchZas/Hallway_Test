using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class RaycastTest : MonoBehaviour
{
    Ray ray;

    bool KeyTaken = false;

    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject Key;

    [SerializeField] Canvas keyImage;

    [SerializeField] AudioSource lockedDoorSFX;
    [SerializeField] AudioSource keyGrabSFX;
    [SerializeField] AudioSource unlockedDoorSFX;



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
                if (hit.collider.gameObject.tag == "Key")
                {
                    hit.collider.gameObject.SetActive(false);
                    keyGrabSFX.Play();  
                    keyImage.gameObject.SetActive(true);
                    KeyTaken = true;
                }
                
                if (hit.collider.gameObject.tag == "LockedDoor" && !KeyTaken)
                {
                    lockedDoorSFX.Play();
                    
                    Debug.Log("Door is Locked");
                }

                if (hit.collider.gameObject.tag == "LockedDoor" && KeyTaken)
                {
                    Debug.Log("Door is Unlocked");
                    unlockedDoorSFX.Play();
                    lockedDoor.gameObject.SetActive(false);
                    keyImage.gameObject.SetActive(false);
                }
                    // Get the name of the Game Object 
                    // Pop up UI with that Game Object Name with a prompt to pick up
                    // Once prompt is hit, "Destroy" game object in scene and place in inventory

                    Debug.Log(hit.collider.gameObject.tag);
                
            }
        }
    }
}
