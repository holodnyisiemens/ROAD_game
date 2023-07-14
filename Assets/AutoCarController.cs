using UnityEngine;

public class AutoCarController : MonoBehaviour
{
    public float speed = 5f; // Скорость движения машины
    private Rigidbody rb;
    private WheelCollider[] wheelColliders;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheelColliders = GetComponentsInChildren<WheelCollider>();

        // Рассчитываем мощность двигателя для движения вперед
        float engineForce = speed * 1000f; // Настройте мощность двигателя по вашему усмотрению

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