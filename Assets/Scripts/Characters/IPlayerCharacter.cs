public interface IPlayerCharacter : ICharacter
{
    void Init();
    void PinDown();
    void ReleaseFromPinDown();
    IWeaponManager WeaponManager { get; }
    IExperienceManager ExperienceManager { get; }
}