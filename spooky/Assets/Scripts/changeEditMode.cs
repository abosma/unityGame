using UnityEngine;
using System.Collections;

public class changeEditMode : MonoBehaviour {

    public GameObject[] DraggableObjects;

    // Use this for initialization
    void Start () {
        foreach (GameObject draggableObject in DraggableObjects)
        {
            draggableObject.GetComponent<PickUpObject>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        DraggableObjects = GameObject.FindGameObjectsWithTag("Draggable");
    }

    public void changeMode()
    {
        foreach (GameObject draggableObject in DraggableObjects)
        {
            if (!draggableObject.GetComponent<PickUpObject>().inEditMode)
            {
                draggableObject.GetComponent<PickUpObject>().inEditMode = true;
                draggableObject.GetComponent<PickUpObject>().enabled = true;
            }
            else if (draggableObject.GetComponent<PickUpObject>().inEditMode)
            {
                foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (gameObj.name == "useText")
                    {
                        Destroy(gameObj);
                    }
                }
                draggableObject.GetComponent<PickUpObject>().inEditMode = false;
                draggableObject.GetComponent<PickUpObject>().enabled = false;
            }
        }
    }
}
