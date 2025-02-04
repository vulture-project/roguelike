﻿using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class AccelerationSystem : IEcsRunSystem
    {
        private EcsFilter<AccelerationComponent, VelocityComponent, InputComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var acceleration = ref _filter.Get1(i);
                ref var velocity = ref _filter.Get2(i);
                ref var input = ref _filter.Get3(i);

                var deltaVelocity = acceleration.Value * Time.deltaTime;

                if (!Mathf.Approximately(input.Value.x, 0.0f))
                {
                    var x = velocity.Value.x + input.Value.x * deltaVelocity.x;
                    x = Mathf.Clamp(x, -velocity.MaxValue.x, velocity.MaxValue.x);
                    velocity.Value += Vector3.right * (x - velocity.Value.x);
                }

                if (!Mathf.Approximately(input.Value.z, 0.0f))
                {
                    var z = velocity.Value.z + input.Value.z * deltaVelocity.z;
                    z = Mathf.Clamp(z, -velocity.MaxValue.z, velocity.MaxValue.z);
                    velocity.Value += Vector3.forward * (z - velocity.Value.z);
                }
                
                if (Mathf.Approximately(input.Value.x, 0.0f))
                {
                    input.Value.x = 0.0f;
                }

                if (Mathf.Approximately(input.Value.z, 0.0f))
                {
                    input.Value.z = 0.0f;
                }
            }
        }
    }
}