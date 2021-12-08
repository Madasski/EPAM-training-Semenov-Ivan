using System;

public interface ILevelUpScreenView : IView
{
    event Action SpeedClicked;
    event Action HealthClicked;
    event Action PowerClicked;
}