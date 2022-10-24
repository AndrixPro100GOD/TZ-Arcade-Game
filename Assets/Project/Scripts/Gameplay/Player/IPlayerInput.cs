using System;

using UnityEngine;

namespace Gameplay.Player
{
    public interface IPlayerInputLisener
    {
        Action<Vector2> PlayerMove { get; set; }
        Action<Vector2> PlayerMoveEnd { get; set; }
        Action<bool> PlayerShoot { get; set; }
    }
}