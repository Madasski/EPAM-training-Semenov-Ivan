public interface IHealthBar
{
    void SetTarget(IHealth targetHealth, IMover targetMover);
    void DestroyItself();
}