using UnityEngine;

namespace Gameplay.Obstacles
{
    public class SimpleObstacle : BaseObstacle
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Player.Player player))
            {
                player.Die();
            }
            else if (collision.transform.TryGetComponent(out Weapon.Bullet.LaserBullet bullet))
            {
                Core.GameEvents.OnKillGiveScore?.Invoke(base.ScoreForDestory);
            }

            base.Kill();
        }
    }
}