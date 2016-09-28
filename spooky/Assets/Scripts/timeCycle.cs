using UnityEngine;
using System.Collections;

public class timeCycle : MonoBehaviour {

    public int hour = 0;
    public int minute = 0;
    public int second = 0;
    public bool isCreated = false;

    private bool created = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("changeTime", 1, 1f);
        InvokeRepeating("changeTimeSeconds", 0, 0.01666666666f);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void changeTime()
    {
        minute += 1;

        if (minute == 60)
        {
            hour += 1;
            minute = 0;
        }

        if (hour == 24)
        {
            hour = 0;
        }
    }

    void changeTimeSeconds()
    {
        second += 1;

        if (second == 60)
        {
            second = 0;
        }
    }
}