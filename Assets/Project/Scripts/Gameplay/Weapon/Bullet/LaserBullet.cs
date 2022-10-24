using System.Collections;

using UnityEngine;

namespace Gameplay.Weapon.Bullet
{
    [RequireComponent(typeof(Collision2D))]
    public class LaserBullet : MonoBehaviour
    {
        private void Start()
        {
            Destroy(this.gameObject, 10f);// TODO: PoolObject
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void Fly(Vector3 dir)
        {
            _ = StartCoroutine(BulletFly(dir));
        }

        private IEnumerator BulletFly(Vector3 dir)
        {
            WaitForFixedUpdate fixedUpdate = new();

            while (enabled)
            {
                transform.position += dir * 0.3f;
                yield return fixedUpdate;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}