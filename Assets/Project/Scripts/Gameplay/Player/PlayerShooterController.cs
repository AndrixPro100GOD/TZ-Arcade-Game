using Gameplay.Weapon;

using System;

namespace Gameplay.Player
{
    [Serializable]
    public class PlayerShooterController
    {
        [UnityEngine.SerializeField]
        private LaserGun gun;// Cringe but let's keep it)

        public void ShootToggle(bool value)
        {
            (gun as IGun).ShootingToggle(value);
        }
    }
}