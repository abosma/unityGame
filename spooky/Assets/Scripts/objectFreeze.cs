using UnityEngine;
using System.Collections;

public class objectFreeze : MonoBehaviour {

    private GameObject[] DraggableObjects;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        DraggableObjects = GameObject.FindGameObjectsWithTag("Draggable");
        foreach (GameObject draggableObject in DraggableObjects)
        {
            if (!draggableObject.GetComponent<PickUpObject>().inEditMode)
            {
                draggableObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }else
            {
                draggableObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
