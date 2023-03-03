using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnScript : MonoBehaviour
{
    public UnityEvent soundEvent;
    public GameObject clockPrefab;
    public Vector3 lastClockPosition;
    public int clockCount = 3;
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        soundEvent.AddListener(PlayBong);
        for(int i = 1; i < clockCount+1; i++)
        {
            Vector3 clockPosition = new Vector3(i * 3.0f, 2.0f, 0.0f);
            GameObject clock = Instantiate(clockPrefab, clockPosition, Quaternion.identity);
           // clock.GetComponent<ClockScript>().hourHandCube.GetComponent<MeshRenderer>().materials[0].color = Color.cyan;
            lastClockPosition = clockPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            soundEvent.Invoke();
            Vector3 clockPosition = new Vector3(lastClockPosition.x + 3.0f, 2.0f, 0.0f);
            GameObject clock = Instantiate(clockPrefab, clockPosition, Quaternion.identity);
            lastClockPosition = clockPosition;
            int clockHandColor = Random.Range(0, 3);
            clock.GetComponent<ClockScript>().hourHandCube.GetComponent<MeshRenderer>().material.color = colors[clockHandColor];
            clock.GetComponent<ClockScript>().minuteHandCube.GetComponent<MeshRenderer>().material.color = colors[clockHandColor];
            clock.GetComponent<ClockScript>().secondHandCube.GetComponent<MeshRenderer>().material.color = colors[clockHandColor];
        }
    }

    void PlayBong()
    {
        this.GetComponent<AudioSource>().Play();
    }    
}
