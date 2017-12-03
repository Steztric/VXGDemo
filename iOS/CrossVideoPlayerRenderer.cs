using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using VideoPlayer;
using VideoPlayer.iOS;
using MediaPlayerSDK;

[assembly: ExportRenderer(typeof(CrossVideoPlayer), typeof(CrossVideoPlayerRenderer))]
namespace VideoPlayer.iOS
{


    public class CrossVideoPlayerRenderer : ViewRenderer<CrossVideoPlayer, UIView>
    {
        public partial class Callback : MediaPlayerSDK.MediaPlayerCallback
        {
            public CrossVideoPlayerRenderer _delegate;

            public override int Status(MediaPlayerSDK.MediaPlayer player, int arg)
            {
                return 0;
            }

            public override int OnReceiveData(MediaPlayerSDK.MediaPlayer player, IntPtr buffer, int size, nint pts)
            {
                return 0;
            }
            public override int OnReceiveSubtitleString(MediaPlayerSDK.MediaPlayer player, string data, ulong duration)
            {
                return 0;
            }
            public override int OnVideoSourceFrameAvailable(MediaPlayerSDK.MediaPlayer player, IntPtr buffer, int size, nint pts, nint dts, int stream_index, int format)
            {
                //BeginInvokeOnMainThread( () => {  _delegate.DebugLbl.Text  =  String.Format("pts {0}",  pts); });
                return 0;
            }
            public override int OnAudioSourceFrameAvailable(MediaPlayerSDK.MediaPlayer player, IntPtr buffer, int size, nint pts, nint dts, int stream_index, int format)
            {
                return 0;
            }


        }
        MediaPlayerSDK.MediaPlayer _mediaPlayer;

        protected override void OnElementChanged(ElementChangedEventArgs<CrossVideoPlayer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                CGRect bounds = new CGRect();

                if (e.NewElement != null)
                    bounds = new CGRect(10, 10, 250, 250);

                _mediaPlayer = new MediaPlayerSDK.MediaPlayer(bounds);

                _mediaPlayer?.Open(new MediaPlayerConfig
                {
                    ConnectionUrl = "rtsp://192.168.1.1:8554/ep",
                    ConnectionNetworkProtocol = 1,
                    ConnectionBufferingTime = 500,
                    ConnectionDetectionTime = 1000,
                    DecodingType = 0,
                    RendererType = 1,
                    SynchroEnable = 0,
                    SynchroNeedDropVideoFrames = 0,
                    EnableColorVideo = 1,
                    DataReceiveTimeout = 30000,
                    NumberOfCPUCores = 0,
                    DecoderLatency = 1,
                    EnableAudio = 0,
                    AspectRatioMode = 1,
                    RecordPath = "",
                    RecordFlags = 0,
                    RecordSplitTime = 0,
                    RecordSplitSize = 0
                }, new Callback { _delegate = this });

                SetNativeControl(_mediaPlayer?.ContentView);
            }
        }
    }
}
