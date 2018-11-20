using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Android.Graphics;
using RoadRangerMobileApp.Views;
using static Android.Views.View;

namespace RoadRangerMobileApp.Droid
{
    [Activity]
    public class CameraActivity : Activity, TextureView.ISurfaceTextureListener, Android.Hardware.Camera.IAutoFocusCallback
    {
        Android.Hardware.Camera _camera;
        TextureView _textureView;

        protected override void OnCreate(Bundle bundle)     //Sukurus activity vykdomas kodas
        {
            base.OnCreate(bundle);
            _textureView = new TextureView(this);
            _textureView.SurfaceTextureListener = this;

            SetContentView(_textureView);
        }

        public void OnSurfaceTextureAvailable(
            Android.Graphics.SurfaceTexture surface,
            int width, int height)
        {
            _camera = Android.Hardware.Camera.Open();
            var previewSize = _camera.GetParameters().PreviewSize;
            _textureView.LayoutParameters =
                new FrameLayout.LayoutParams(previewSize.Width,
                    previewSize.Height, GravityFlags.Center);
            _camera.SetDisplayOrientation(90);

            try
            {
                _camera.SetPreviewTexture(surface);
                _camera.StartPreview();
                _camera.AutoFocus(this);
            }
            catch (Java.IO.IOException ex)
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Something went wrong!");
                alertDialog.SetMessage("Couldn't turn on the camera.");
                alertDialog.SetNeutralButton("OK", delegate {
                    alertDialog.Dispose();
                     });
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                _camera.AutoFocus(this);
            }
            return true;
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            //Nebutina implementuoti
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            //Nebutina implementuoti
        }

        public void OnAutoFocus(bool success, Android.Hardware.Camera camera)
        {
            //Nebutina implementuoti
        }
    }
}