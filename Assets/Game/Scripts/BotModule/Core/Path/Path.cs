using UnityEngine;

namespace BotModule
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private PathPoint[] _points;

        public PathPoint GetFirstPoint()
        {
            return _points.Length == 0 ? null : _points[0];
        }

        public PathPoint GetNextPoint(PathPoint currentPoint)
        {
            if (_points.Length == 0)
                return null;

            var currentIndex = System.Array.IndexOf(_points, currentPoint);
            var lastIndex = _points.Length - 1;

            if (currentIndex < 0 || currentIndex >= lastIndex)
                return _points[0];

            return _points[++currentIndex];
        }
    }
}