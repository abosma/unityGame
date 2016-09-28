using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class useDoor : MonoBehaviour {

    private bool inTrigger = false;
    public string level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(level);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject useText = new GameObject();
            useText.gameObject.name = "useText";
            useText.AddComponent<GUIText>();
            useText.transform.position = new Vector3(0.5f, 0.5f, 0f);
            useText.GetComponent<GUIText>().text = "Press E to do the thing";
            useText.GetComponent<GUIText>().color = Color.black;
            useText.GetComponent<GUIText>().pixelOffset = useText.GetComponent<GUIText>().pixelOffset + new Vector2(-100f, -180f);
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
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
