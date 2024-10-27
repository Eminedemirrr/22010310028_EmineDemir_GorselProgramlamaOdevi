using Android.App;
using Android.Content.Res;
using Android.Runtime;
using AndroidX.AppCompat.Widget;

namespace hesapmakinesigp
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        }
        if(View is Entry){
            handler.PlatformView.BackgroundTintList= ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            handler.PlatformView.ShowSoftInputOnFocus=false;
            }

});
}
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
