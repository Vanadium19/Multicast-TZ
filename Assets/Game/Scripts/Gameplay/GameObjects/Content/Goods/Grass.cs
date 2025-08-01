using UnityEngine;

namespace Gameplay.Content.Goods
{
    public class Grass : IGrass
    {
        //Temporary solution
        private readonly GameObject _gameObject;

        public Grass(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        //Temporary solution
        public int Cost => 5;

        public void Collect()
        {
            //Temporary solution
            Object.Destroy(_gameObject);
        }
    }
}