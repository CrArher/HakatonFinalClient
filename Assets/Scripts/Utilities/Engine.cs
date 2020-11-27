using System.Collections.Generic;

namespace Utilities
{
    public class Engine : ISystem
    {
        private readonly List<ISystem> _systems = new List<ISystem>();

        public void Update()
        {
            foreach (var system in _systems)
            {
                system.Update();
            }
        }

        public void Add(ISystem system)
        {
            _systems.Add(system);
        }

        public void Remove(ISystem system)
        {
            _systems.Remove(system);
        }

        public void Clear()
        {
            _systems.Clear();
        }
    }
}