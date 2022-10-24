using Gameplay.Weapon.Bullet;

using System.Collections;

using UnityEngine;

namespace Gameplay.Weapon
{
    public class LaserGun : MonoBehaviour, IGun
    {
        [SerializeField]
        private LaserBullet laserBulletPrefab;

        [SerializeField]
        [Range(0.1f, 1f)]
        [Tooltip("Delay before firing in seconds (default)")]
        private float shootDelay = 0.3f;

        [SerializeField]
        private Transform gunOwnerTransform;//cringe but let's keep it)

        private bool _toggle = false;

        public void SetGunOwner(Transform gunUser)
        {
            gunOwnerTransform = gunUser;
        }

        public void ShootingToggle(bool toggle)
        {
            if (_toggle != toggle)
            {
                _toggle = toggle;
            }

            StopAllCoroutines();

            if (!toggle)
            {
                //TODO: Make sound of overheated gun SFX
                return;
            }

            _ = StartCoroutine(ShootingCoroutin());
        }

        private IEnumerator ShootingCoroutin()
        {
            WaitForSeconds delay = new(shootDelay);

            while (_toggle)
            {
                Shoot(gunOwnerTransform.position);
                yield return delay;
            }
        }

        private void Shoot(Vector3 fromPosition)
        {
            LaserBullet bullet = Instantiate(laserBulletPrefab, fromPosition, Quaternion.identity);
            bullet.Fly(Vector3.up);
        }
    }
}