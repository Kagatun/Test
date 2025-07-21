using UnityEngine;

namespace Scripts.Players
{
    public class MoverPlayer : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 50f;
        [SerializeField] private Transform _point;

        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = transform;
        }

        private void Update()
        {
            Vector3 previousPosition = transform.position;
            _playerTransform.RotateAround(_point.position, Vector3.up, _moveSpeed * Time.deltaTime);
            Vector3 moveDirection = _playerTransform.position - previousPosition;
            _playerTransform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}