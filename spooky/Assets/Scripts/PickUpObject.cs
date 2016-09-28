using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
    public GameObject playerObject;
    public Transform player;
    public float throwForce = 10;
    private bool inTrigger = false;
    bool beingCarried = false;
    public bool inEditMode = false;
    public string words;

    void Start()
    {
        words = words.Replace("\\n", "\n");
    }
    void OnTriggerEnter(Collider other)
    {
        if (inEditMode)
        {
            if (other.tag == "Player")
            {
                GameObject useText = new GameObject();
                useText.gameObject.name = "useText";
                useText.AddComponent<GUIText>();
                useText.transform.position = new Vector3(0.5f, 0.5f, 0f);
                useText.GetComponent<GUIText>().text = words;
                useText.GetComponent<GUIText>().color = Color.black;
                useText.GetComponent<GUIText>().pixelOffset = useText.GetComponent<GUIText>().pixelOffset + new Vector2(-100f, -180f);
                inTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (inEditMode)
        {
            if (other.tag == "Player")
            {
                foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (gameObj.name == "allyText" || gameObj.name == "useText")
                    {
                        Destroy(gameObj);
                    }
                }

                inTrigger = false;
            }
        }
    }

    void Update()
    {
        if (inEditMode)
        {
            if (beingCarried)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(player.forward * throwForce);
                    var currentPos = transform.position;
                    transform.position = new Vector3(Mathf.Round(currentPos.x),
                                                     Mathf.Round(currentPos.y),
                                                     Mathf.Round(currentPos.z));
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && inTrigger)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    transform.parent = player;
                    beingCarried = true;
                }
            }
        }
    }
}