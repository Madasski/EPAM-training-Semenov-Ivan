public interface IHealthBarView : IView
{
    void SetTarget(Health targetHealth);
    void RemoveItself();
}