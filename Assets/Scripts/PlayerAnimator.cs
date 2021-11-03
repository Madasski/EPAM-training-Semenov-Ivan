using UnityEngine;

namespace Madasski
{
    public class PlayerAnimator : MonoBehaviour
    {
        private readonly int _horizontalSpeed = Animator.StringToHash("HorizontalSpeed");

        [SerializeField] private Animator _animator;
        private PlayerCharacter _playerCharacter;

        private void Awake()
        {
            _playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void FixedUpdate()
        {
            //TODO: remove hard code
            float horizontalSpeed = _playerCharacter.Mover.Velocity.magnitude/7f;
            Debug.Log(horizontalSpeed);
            _animator.SetFloat(_horizontalSpeed, horizontalSpeed);
        }
    }
}