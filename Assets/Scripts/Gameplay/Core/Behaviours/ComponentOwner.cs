using Gameplay.Core.Components;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Core.Behaviours
{
    public class ComponentOwner : MonoBehaviour, IComponentOwner
    {
        private const Int32 NotFoundIndex = -1;

        [SerializeField]
        private List<ComponentBase> _components;

        public bool Has<TComponent>() where TComponent : ComponentBase
        {
            var index = Find<TComponent>();
            return index != NotFoundIndex;
        }

        public TComponent Get<TComponent>() where TComponent : ComponentBase
        {
            var index = Find<TComponent>();
            if (index == NotFoundIndex)
            {
                return null;
            }
            var component = _components[index] as TComponent;
            return component;
        }

        public bool Add<TComponent>(TComponent component) where TComponent : ComponentBase
        {
            var index = Find<TComponent>();
            if (index != NotFoundIndex)
            {
                return false;
            }
            _components.Add(component);
            return true;
        }

        public bool Remove<TComponent>() where TComponent : ComponentBase
        {
            var index = Find<TComponent>();
            if (index == NotFoundIndex)
            {
                return false;
            }
            _components.RemoveAt(index);
            return true;
        }

        private int Find<TComponent>() where TComponent : ComponentBase
        {
            return _components.FindIndex(component => component is TComponent);
        }
    }
}