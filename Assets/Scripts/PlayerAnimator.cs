using UnityEngine;

namespace Madasski
{
    public class PlayerAnimator : MonoBehaviour
    {
        private readonly int _horizontalSpeed = Animator.StringToHash("HorizontalSpeed");
        private readonly int _isPinned = Animator.StringToHash("IsPinned");

        [SerializeField] private Animator _animator;
        private PlayerCharacter _playerCharacter;

        private void Awake()
        {
            _playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void FixedUpdate()
        {
            float horizontalSpeed = _playerCharacter.Mover.Velocity.magnitude / 7f;
            _animator.SetFloat(_horizontalSpeed, horizontalSpeed);
            _animator.SetBool(_isPinned, _playerCharacter.IsPinnedDown);
        }
    }
}