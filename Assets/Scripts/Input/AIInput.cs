using UnityEngine;

public class AIInput : IInput
{
    private EnemyCharacter _enemyCharacter;
    private Vector2 _movementInput;
    private bool _useWeaponInput;

    public bool ReloadInput { get; }

    public int ChangeWeaponInput => 0;

    public bool UseWeaponInput => _useWeaponInput;

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
        _useWeaponInput = _enemyCharacter.IsPlayerInAttackRange;

        if (_enemyCharacter.IsPlayerInDetectionRange)
        {
            var moveX = _enemyCharacter.Player.Rigidbody.position.x - _enemyCharacter.Rigidbody.position.x;
            var moveZ = _enemyCharacter.Player.Rigidbody.position.z - _enemyCharacter.Rigidbody.position.z;
            _movementInput = new Vector2(moveX, moveZ);
        }
        else
        {
            _movementInput = Vector2.zero;
            return;
        }
    }
}