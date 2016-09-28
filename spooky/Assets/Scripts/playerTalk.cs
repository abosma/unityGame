using UnityEngine;
using System.Collections;

public class playerTalk : MonoBehaviour {

    private bool inTrigger = false;
    public Texture2D textBoxSprite;
    public string words;
	// Use this for initialization
	void Start () {
        words = words.Replace("\\n", "\n");
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject go = new GameObject();
                go.gameObject.name = "allyText";
                go.AddComponent<GUIText>();
                go.transform.position = new Vector3(0.5f, 0.1f, 0f);
                go.GetComponent<GUIText>().text = words;
                go.GetComponent<GUIText>().pixelOffset = go.GetComponent<GUIText>().pixelOffset + new Vector2(-190f, 80f);
                go.GetComponent<GUIText>().color = Color.black;

                go.AddComponent<GUITexture>();
                go.GetComponent<GUITexture>().texture = textBoxSprite;
                go.GetComponent<GUITexture>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject useText = new GameObject();
            useText.gameObject.name = "useText";
            useText.AddComponent<GUIText>();
            useText.transform.position = new Vector3(0.5f, 0.5f, 0f);
            useText.GetComponent<GUIText>().text = "Press E to do the thing";
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
