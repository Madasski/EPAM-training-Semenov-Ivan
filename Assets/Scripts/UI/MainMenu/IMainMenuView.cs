using System;

public interface IMainMenuView : IView
{
    event Action NewGameClicked;
    event Action LoadGameClicked;
    event Action SettingsClicked;
    event Action ExitClicked;
}