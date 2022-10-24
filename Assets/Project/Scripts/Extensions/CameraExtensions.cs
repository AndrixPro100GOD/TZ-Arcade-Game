using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        public static Bounds OrthographicBounds(this Camera camera)
        {
            float cameraHeight = camera.orthographicSize * 2;
            float screenAspect = Screen.width / (float)Screen.height;

            Bounds bounds = new(
                camera.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
}