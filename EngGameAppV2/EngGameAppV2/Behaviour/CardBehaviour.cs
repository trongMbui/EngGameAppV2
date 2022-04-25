using EngGameAppV2.Effects;
using EngGameAppV2.Models;
using EngGameAppV2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EngGameAppV2.Behavior
{
    public class CardBehaviour : Behavior<Frame>
    {
        private Frame frame;
        private CardViewModel card;

        protected override void OnAttachedTo(Frame bindable)
        {
            base.OnAttachedTo(bindable);

            frame = bindable;
            frame.BindingContextChanged += OnBindingContextChanged;
        }

        protected void OnBindingContextChanged(object sender, EventArgs e)
        {
            if (frame.BindingContext is CardViewModel speakerViewModel)
            {
                card = speakerViewModel;
                card.PropertyChanged += OnCardPropertyChanged;
            }
        }

        protected override void OnDetachingFrom(Frame bindable)
        {
            base.OnDetachingFrom(bindable);

            frame.BindingContextChanged -= OnBindingContextChanged;

            if (card is not null)
            {
                card.PropertyChanged -= OnCardPropertyChanged;
            }
        }

        private async void OnCardPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CardViewModel.IsSelected))
            {
                await frame.RotateXTo(90, 100, Easing.BounceIn);
                frame.Content.IsVisible = card.IsSelected;
                await frame.RotateXTo(0, 100, Easing.BounceIn);
            }
            else if (e.PropertyName == nameof(CardViewModel.IsGuessed))
            {
                var animation = new Animation
                {
                    { 0.0, 0.2, new Animation(v => frame.Scale = v, 1, 0.9) },
                    { 0.2, 0.75, new Animation(v => frame.Scale = v, 0.9, 1.2) },
                    { 0.75, 1.0, new Animation(v => frame.Scale = v, 1.2, 0) }
                };

                animation.Commit(
                    frame,
                    "SuccessfulMatch",
                    length: 500,
                    easing: Easing.SpringIn,
                    finished: (v, f) =>
                    {
                        //frame.Parent.Effects.OfType<ParticleEffect>().First().RaiseEmit();

                        frame.IsVisible = false;
                    });
            }
        }
    }
}
