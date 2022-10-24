using Extensions;

using UnityEngine;

namespace Core.GameBorders
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CompositeCollider2D))]
    public class BorderGeneratorByCameraSize : MonoBehaviour
    {
        [SerializeField]
        private Camera cameraComp;

        private Rigidbody2D _rigidbody2D;

        private readonly BoxCollider2D[] _boxCollider2Ds = new BoxCollider2D[4];

        public Bounds GetCameraBounds => cameraComp.OrthographicBounds();

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            CreateBorders();
        }

        private void CreateBorders()
        {
            Bounds cameraBounds = GetCameraBounds;
            float THICKness = .5f;

            for (int borderSide = 0; borderSide < 4; borderSide++)
            {
                BoxCollider2D colider = gameObject.AddComponent<BoxCollider2D>();
                colider.usedByComposite = true;
                _boxCollider2Ds[borderSide] = colider;

                switch (borderSide)
                {
                    case 0://Left Side
                        colider.size = new Vector2(THICKness, cameraBounds.size.y);
                        colider.offset = new Vector2(cameraBounds.min.x, 0);
                        break;

                    case 1: // Right Side
                        colider.size = new Vector2(THICKness, cameraBounds.size.y);
                        colider.offset = new Vector2(cameraBounds.max.x, 0);
                        break;

                    case 2: // Top Side
                        colider.size = new Vector2(cameraBounds.size.x, THICKness);
                        colider.offset = new Vector2(0, cameraBounds.max.y);
                        break;

                    case 3: // Иottom side
                        colider.size = new Vector2(cameraBounds.size.x, THICKness);
                        colider.offset = new Vector2(0, cameraBounds.min.y);
                        break;
                }
            }
        }
    }
}