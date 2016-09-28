using UnityEngine;
using System.Collections;
using System;

public class getCurrentTime : MonoBehaviour {

    public GameObject prefabTimeCycleObject;
    private GameObject timeCycleObject;
    public string currentHour;
    public string currentMinute;
    public string currentSecond;

    void Awake()
    {
        if (GameObject.Find("timeCycleObject(Clone)") == null)
        {
            timeCycleObject = Instantiate(prefabTimeCycleObject);
        }else
        {
            timeCycleObject = GameObject.Find("timeCycleObject(Clone)");
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        currentHour = timeCycleObject.gameObject.GetComponent<timeCycle>().hour.ToString("00");
        currentMinute = timeCycleObject.gameObject.GetComponent<timeCycle>().minute.ToString("00");
        currentSecond = timeCycleObject.gameObject.GetComponent<timeCycle>().second.ToString("00");

        GetComponent<TextMesh>().text = currentHour + ":" + currentMinute + ":" + currentSecond;
	}
}
