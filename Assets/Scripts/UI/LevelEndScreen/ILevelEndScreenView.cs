using System;

public interface ILevelEndScreenView : IView
{
    event Action RestartClicked;
    event Action GoToMenuClicked;
}