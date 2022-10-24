namespace Gameplay.Player
{
    public interface IPlayerController
    {
        bool IsEnable { get; set; }

        void SetEnable(bool value);
    }
}