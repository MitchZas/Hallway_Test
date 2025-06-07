using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RaycastTest : MonoBehaviour
{
    Ray ray;

    bool BallTaken = false;

    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject Key;

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
                if (hit.collider.gameObject.tag == "Ball")
                {
                    hit.collider.gameObject.SetActive(false);
                    BallTaken = true;
                }
                
                if (hit.collider.gameObject.tag == "LockedDoor")
                {
                    Debug.Log("Door is Locked");
                }

                if (hit.collider.gameObject.tag == "LockedDoor" && BallTaken)
                {
                    Debug.Log("Door is Unlocked");
                    lockedDoor.gameObject.SetActive(false);
                }
                    // Get the name of the Game Object 
                    // Pop up UI with that Game Object Name with a prompt to pick up
                    // Once prompt is hit, "Destroy" game object in scene and place in inventory

                    Debug.Log(hit.collider.gameObject.tag);
                
            }
        }
    }
}
