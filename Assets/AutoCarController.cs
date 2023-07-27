using EvolveGames;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoCarController : MonoBehaviour
{
    private float _speed = 2000f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private WheelCollider[] wheelColliders;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _start = false;
    [SerializeField] private float _minZ;   // область реагирования на игрока 
    [SerializeField] private float _maxZ;
    //[SerializeField] private Transform _stone;
    [SerializeField] public Restart _restart;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheelColliders = GetComponentsInChildren<WheelCollider>();
    }
    private void Update()
    {
        if (_player.position.z > _minZ && _player.position.z < _maxZ)
        {
            _start = true;
            GameObject post = GameObject.Find("Speed-Post-Low-Plain - 20");
            if (post != null)
            {
                if (post.GetComponent<Viagra>()._standing)
                {
                    _speed = 100f;
                }
            }

            GameObject stone5 = GameObject.Find("Stone_1");
            GameObject stone6 = GameObject.Find("Stone_2");
            if (stone5 != null)
            {
                if (stone5.GetComponent<Transform>().position.z > _minZ && stone5.GetComponent<Transform>().position.z < _maxZ)
                {
                    _speed = 0f;
                }
            }
            if (stone6 != null)
            {
                if (stone6.GetComponent<Transform>().position.z > _minZ && stone6.GetComponent<Transform>().position.z < _maxZ)
                {
                    _start = false;
                }
            }
        }

        if (_start)
        {
            {
                rb = GetComponent<Rigidbody>();
                wheelColliders = GetComponentsInChildren<WheelCollider>();

                // Мощность двигателя для движения вперед
                float engineForce = _speed;

                foreach (WheelCollider wheelCollider in wheelColliders)
                {
                    // Применяем мощность двигателя к каждому колесу
                    wheelCollider.motorTorque = engineForce;

                    // Устанавливаем нулевой угол поворота колес для прямолинейного движения
                    wheelCollider.steerAngle = 0f;

                    // Отключаем тормозные силы для непрерывного движения
                    wheelCollider.brakeTorque = 0f;
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        _restart.loss = true;
    }
}