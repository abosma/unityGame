using UnityEngine;
using System.Collections;

public class UseComputer : MonoBehaviour
{
    private bool inTrigger = false;
    private bool usingComputer = false;
    public string words;
    public GameObject computerButton1;
    public Texture2D screenTexture;
    CursorLockMode wantedMode;

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void Start()
    {
        words = words.Replace("\\n", "\n");
        wantedMode = CursorLockMode.Locked;
        SetCursorState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject useComputerText = new GameObject();
            useComputerText.gameObject.name = "useComputerText";
            useComputerText.AddComponent<GUIText>();
            useComputerText.transform.position = new Vector3(0.5f, 0.5f, 0f);
            useComputerText.GetComponent<GUIText>().text = words;
            useComputerText.GetComponent<GUIText>().color = Color.black;
            useComputerText.GetComponent<GUIText>().pixelOffset = useComputerText.GetComponent<GUIText>().pixelOffset + new Vector2(-100f, -200f);
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
            usingComputer = false;
            wantedMode = CursorLockMode.Locked;
            SetCursorState();

            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == "useComputerText" || gameObj.name == "computerScreen" || gameObj.name.Contains("desktopButton1"))
                {
                    Destroy(gameObj);
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inTrigger && !usingComputer)
        {
            Instantiate(computerButton1);
            GameObject go = new GameObject();
            go.gameObject.name = "computerScreen";
            go.transform.position = new Vector3(0.5f, 0.5f, 0f);
            go.transform.localScale = new Vector3(1f,1f);

            go.AddComponent<GUITexture>();
            go.GetComponent<GUITexture>().texture = screenTexture;

            usingComputer = true;
            wantedMode = CursorLockMode.None;
            SetCursorState();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && usingComputer){

            usingComputer = false;
            wantedMode = CursorLockMode.Locked;
            SetCursorState();

            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == "computerScreen" || gameObj.name.Contains("desktopButton1"))
                {
                    Destroy(gameObj);
                }
            }
        }
    }
}