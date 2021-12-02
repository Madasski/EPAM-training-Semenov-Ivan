public interface IPlayerCharacter : ICharacter
{
    void PinDown();
    void ReleaseFromPinDown();
    IWeaponManager WeaponManager { get; }
}