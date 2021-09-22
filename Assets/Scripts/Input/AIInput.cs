using UnityEngine;

public class AIInput : IInput
{
    private Vector2 _movementInput;
    private EnemyCharacter _enemyCharacter;

    public bool AttackInput { get; }
    public bool ReloadInput { get; }

    public Vector2 MovementInput
    {
        get
        {
            if (_movementInput.magnitude > 1)
            {
                _movementInput.Normalize();
            }

            return _movementInput;
        }
    }


    public AIInput(EnemyCharacter enemyCharacter)
    {
        _enemyCharacter = enemyCharacter;
    }

    public void Read()
    {
        if (_enemyCharacter.IsPlayerInRange)
        {
            var moveX = _enemyCharacter.Player.Rigidbody.position.x - _enemyCharacter.Rigidbody.position.x;
            var moveZ = _enemyCharacter.Player.Rigidbody.position.z - _enemyCharacter.Rigidbody.position.z;
            _movementInput = new Vector2(moveX,moveZ);
        }
        else
        {
            _movementInput = Vector2.zero;
        }
    }
}