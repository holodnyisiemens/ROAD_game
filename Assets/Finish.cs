using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Restart _res;
    private void OnTriggerEnter(Collider other)
    {
        _res.finish = true;
    }
}
