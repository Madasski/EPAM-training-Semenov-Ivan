using UnityEngine;

    public class Mover
    {
        private Character _character;

        public Mover(Character character)
        {
            _character = character;
        }

        public void Move(Vector2 moveInput)
        {
            var targetPosition = _character.Rigidbody.position + new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * _character.MovementSettings.Speed;
            _character.Rigidbody.MovePosition(targetPosition);
        }
    }
