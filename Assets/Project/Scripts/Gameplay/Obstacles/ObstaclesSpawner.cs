using Core.GameBorders;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Gameplay.Obstacles
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstaclesSpawner : MonoBehaviour, ISpawner
    {
        [SerializeReference]
        private BorderGeneratorByCameraSize CameraBorderSize;

        [SerializeField]
        private List<BaseObstacle> obstacles = new();

        [SerializeField, HideInInspector]
        private BoxCollider2D _boxCollider;

        #region MonoBeh

#if DEBUG

        private void OnDrawGizmos()
        {
            if (_boxCollider is null)
            {
                Reset();
            }

            Gizmos.color = Color.green;
            Bounds bounds = _boxCollider.bounds;
            Gizmos.DrawCube(bounds.center, bounds.size);
        }

#endif

        private void Reset()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            CreaateSpawnZone();
        }

        #endregion MonoBeh

        void ISpawner.StartSpawn()
        {
            _ = StartCoroutine(SpawnObstacles());
        }

        void ISpawner.StopSpawn()
        {
            StopAllCoroutines();
        }

        private void CreaateSpawnZone()
        {
            Bounds cameraBounds = CameraBorderSize.GetCameraBounds;

            transform.position = CameraBorderSize.transform.position;

            _boxCollider.offset = new Vector3(0, cameraBounds.max.y + 1, 0);

            Vector3 size = cameraBounds.size;
            size.x *= 0.8f;
            size.y = 1;

            _boxCollider.size = size;
        }

        private void Spawn(SizeOfObstacle size)
        {
            BaseObstacle[] allObsWithSize = obstacles.Where(obs => obs.GetSize.Equals(size)).ToArray();

            int index = UnityEngine.Random.Range(0, allObsWithSize.Count());

            //Init(allObsWithSize[index]);
        }

        private void Spawn(BaseObstacle obstacle)
        {
            Bounds bounds = _boxCollider.bounds;
            float xPosition = Random.Range(bounds.min.x, bounds.max.x);

            BaseObstacle obj = Instantiate(obstacle, new Vector3(xPosition, bounds.center.y, 0), Quaternion.identity);
            obj.Init();
        }

        private IEnumerator SpawnObstacles()
        {
            WaitForSeconds delay = new(0.5f);

            while (enabled)
            {
                yield return null;

                int randomIndex = Random.Range(0, obstacles.Count());
                Spawn(obstacles[randomIndex]);

                yield return delay;
            }
        }
    }
}