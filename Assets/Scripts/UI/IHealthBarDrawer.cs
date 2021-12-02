public interface IHealthBarDrawer
{
    void DrawHealthBar(IHealth health, IMover mover);
    void RemoveHealthBar(IHealth health);
}