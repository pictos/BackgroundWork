using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Work;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BackgroundWork.Droid
{
    public class LocalWorker : Worker
    {
        public LocalWorker(Context context, WorkerParameters workerParams) 
            : base(context, workerParams)
        {
        }

        public override Result DoWork()
        {
            Location local = null;
            var request = new GeolocationRequest(GeolocationAccuracy.Default);
            local = Geolocation.GetLocationAsync(request).GetAwaiter().GetResult();

            Log.Info("Teste", $"Trabalho funcionando - {DateTime.Now}");

            Log.Info( "Local", $"Latitude:{local?.Latitude}, Longitude:{local?.Longitude}");

            return new Result.Retry();
        }
    }
}