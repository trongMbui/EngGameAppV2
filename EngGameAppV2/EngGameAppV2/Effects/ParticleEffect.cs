using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EngGameAppV2.Effects
{
    public class ParticleEffect : RoutingEffect
    {
        public int NumberOfParticles { get; set; } = 100;
        public float LifeTime { get; set; } = 1.5f;
        public float Speed { get; set; } = 0.1f;
        public float Scale { get; set; } = 1.0f;
        public string Image { get; set; }

        public ParticleEffect() : base($"{nameof(EngGameAppV2)}.{nameof(Effects)}.{nameof(ParticleEffect)}")
        {

        }

        public event EventHandler<EventArgs> Emit;

        public void RaiseEmit() => Emit?.Invoke(this, EventArgs.Empty);
    }
}
