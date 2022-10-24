using System;

namespace Core
{
    public static class GameEvents
    {
        //IU
        public static Action OnPlayerPressedPlayButton { get; set; }

        public static Action OnPlayerHitPause { get; set; }

        //player
        public static Action OnPlayerDied { get; set; }

        public static Action OnPlayerRespawned { get; set; }

        //level
        public static Action<bool> OnGameOver { get; set; }

        //Score
        public static Action<int> OnKillGiveScore { get; set; }

        public static Func<int> GetCurrentScore { get; set; }
        public static Func<int> GetMaxScore { get; set; }
    }
}