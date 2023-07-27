using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalTime : MonoBehaviour
{
    public float TimeControl;
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = TimeControl;
    }
}