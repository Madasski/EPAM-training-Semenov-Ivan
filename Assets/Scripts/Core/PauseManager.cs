using UnityEngine;

namespace Core
{
    public static class PauseManager
    {
        // private static bool _isPaused = false;

        public static void Pause()
        {
            // _isPaused = true;
            Time.timeScale = 0;
        }

        public static void Resume()
        {
            // _isPaused = false;
            Time.timeScale = 1;
        }
    }
}