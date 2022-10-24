using System.Collections;

using UnityEngine;

namespace Gameplay.Obstacles
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class BaseObstacle : MonoBehaviour
    {
        [SerializeField]
        protected int ScoreForDestory = 10;

        [SerializeField]
        private SizeOfObstacle sizeOfObstacle;

        public SizeOfObstacle GetSize => sizeOfObstacle;

        public void Init()
        {
            _ = StartCoroutine(StartFalling());
            Destroy(this.gameObject, 20f);
        }

        private IEnumerator StartFalling()
        {
            WaitForFixedUpdate Fixed = new();
            float speedOfSpin = Random.Range(0.5f, 2f);
            float speedOfFall = Random.Range(0.01f, 0.1f);
            Vector3 rotateVector = Random.Range(0, 2) == 0 ? Vector3.forward : Vector3.back;

            while (enabled)
            {
                yield return Fixed;

                transform.Rotate(rotateVector * speedOfSpin);

                Vector3 moveDownSpeed = Vector3.up * speedOfFall;
                transform.position -= moveDownSpeed;
            }
        }

        public void Kill()
        {
            StopAllCoroutines();
            Destroy(this.gameObject);// TODO: Сдлеать poolObject
        }
    }
}