using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//using Com.Plattysoft.Leonids;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(nameof(EngGameAppV2) + "." + nameof(EngGameAppV2.Effects))]
[assembly: ExportEffect(typeof(EngGameAppV2.Droid.Effects.ParticleEffect), nameof(EngGameAppV2.Droid.Effects.ParticleEffect))]
namespace EngGameAppV2.Droid.Effects
{
    public class ParticleEffect : PlatformEffect
    {
        private EngGameAppV2.Effects.ParticleEffect particleEffect;

        protected override void OnAttached()
        {
            var effect = Element.Effects.OfType<EngGameAppV2.Effects.ParticleEffect>().FirstOrDefault();

            if (effect != null)
            {
                particleEffect = effect;
                effect.Emit += OnEffectEmit;
            }
        }

        protected override void OnDetached()
        {
            if (particleEffect != null)
            {
                particleEffect.Emit -= OnEffectEmit;
            }
        }

        private void OnEffectEmit(object sender, EventArgs e)
        {
            var control = Control ?? Container;

            var effect = (EngGameAppV2.Effects.ParticleEffect)Element.Effects.FirstOrDefault(p => p is EngGameAppV2.Effects.ParticleEffect);

            var lifeTime = (long)(effect?.LifeTime * 1000 ?? (long)1500);
            var numberOfItems = effect?.NumberOfParticles ?? 4000;
            var scale = effect?.Scale ?? 1.0f;
            var speed = effect?.Speed ?? 0.1f;
            var image = effect?.Image ?? "ic_launcher";

            var location = new int[2];
            control.GetLocationOnScreen(location);

            var drawableImage = ContextCompat.GetDrawable(Xamarin.Essentials.Platform.CurrentActivity, Xamarin.Essentials.Platform.CurrentActivity.Resources.GetIdentifier(image, "drawable", Xamarin.Essentials.Platform.CurrentActivity.PackageName));
            //var particleSystem = new ParticleSystem(Xamarin.Essentials.Platform.CurrentActivity, numberOfItems, drawableImage, lifeTime);
            //particleSystem
            //  .SetSpeedRange(0f, speed)
            //  .SetScaleRange(0, scale)
            //  .Emit(location[0] + control.Width / 2, location[1] + control.Height / 2, numberOfItems);

            //Task.Run(async () =>
            //{
            //    await Task.Delay(200);
            //    particleSystem?.StopEmitting();
            //});
        }


    }
}