using System;

public interface ISettingsMenuView : IView
{
    event Action BackClicked;
}