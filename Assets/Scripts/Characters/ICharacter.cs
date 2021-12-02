using System;

public interface ICharacter
{
    event Action<Character> Died;
    IHealth Health { get; }
    IMover Mover { get; }
}