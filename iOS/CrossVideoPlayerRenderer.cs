using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using VideoPlayer;
using VideoPlayer.iOS;

[assembly: ExportRenderer(typeof(CrossVideoPlayer), typeof(CrossVideoPlayerRenderer))]
namespace VideoPlayer.iOS
{
    public class CrossVideoPlayerRenderer : ViewRenderer<CrossVideoPlayer, UIView>
    {
        MediaPlayerSDK.MediaPlayer _mediaPlayer;

        protected override void OnElementChanged(ElementChangedEventArgs<CrossVideoPlayer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                CGRect bounds = new CGRect();

                if (e.NewElement != null)
                    bounds = new CGRect(e.NewElement.X, e.NewElement.Y, e.NewElement.Width, e.NewElement.Height);

                _mediaPlayer = new MediaPlayerSDK.MediaPlayer(bounds);
                SetNativeControl(_mediaPlayer?.ContentView);
            }
        }
    }
}
