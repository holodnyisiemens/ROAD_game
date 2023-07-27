using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viagra : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] public bool _standing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_standing && transform.rotation.x < 0)
        {
            //вращение знака до прямого состояния
            transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Подъем знака при входе игрока в область знака
        _standing = true;
    }
}
