using System;

namespace UI
{
    public interface ISettingsMenu : IScreen
    {
        event Action BackClicked;
    }
}