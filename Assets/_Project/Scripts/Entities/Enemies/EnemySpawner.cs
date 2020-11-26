using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class EnemySpawner : TickBehaviour
	{
        [Header("Spawning Variables")]
        [Space]

        [SerializeField] private List<EnemyController> _enemyTypes = null;
        [SerializeField] private List<Transform> _enemySpawnPositions = null;

        [Space]

        [SerializeField] [Range(0, 20)] private float _enemyLimit = 10;
        [SerializeField] [Range(0, 5)] private float _spawnDelay = 2;

        private readonly List<IResource> _entities = new List<IResource>();

        private float _lastActionTime;

        public override void Tick()
        {
            base.Tick();

            for (var i = _entities.Count - 1; i >= 0; i--)
            {
                if (_entities[i].IsValid)
                    continue;

                UpdateLastActionTime();
                DespawnEnemy(i);
            }

            if (_entities.Count < _enemyLimit && _lastActionTime + _spawnDelay < Time.time)
            {
                UpdateLastActionTime();

                var enemyIndex = Random.Range(0, _enemyTypes.Count);
                var positionIndex = Random.Range(0, _enemySpawnPositions.Count);

                SpawnEnemy(enemyIndex, positionIndex);
            }
        }

        public override void Disable()
        {
            for (var i = 0; i < _entities.Count; i++)
                GameManager.Instance.PoolManager.Despawn(_entities[i]);
            _entities.Clear();

            base.Disable();
        }

        private void SpawnEnemy(int enemyIndex, int positionIndex)
        {
            var entity =
                GameManager.Instance.PoolManager.Spawn(
                    _enemyTypes[enemyIndex],
                    GameManager.Instance.PoolManager.Root,
                    _enemySpawnPositions[positionIndex].position,
                    _enemySpawnPositions[positionIndex].rotation);

            _entities.Add(entity);
        }

        private void DespawnEnemy(int i)
        {
            GameManager.Instance.PoolManager.Despawn(_entities[i]);
            _entities.Remove(_entities[i]);
        }

        private void UpdateLastActionTime()
        {
            _lastActionTime = Time.time;
        }
    }
}
