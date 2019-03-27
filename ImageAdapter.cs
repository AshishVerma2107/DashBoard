using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Work121App.Model;
using Android.Preferences;
using Newtonsoft.Json;
using System.Dynamic;
using System.Json;
using System.Threading.Tasks;
using System;

namespace Work121App.Adapter
{
    public class ImageAdapter : BaseAdapter
    {
        Context context;
        ImageView imageView;

        List<ImageListModel> result;
        ServiceHelper restService;
        Geolocation geo;
        ISharedPreferences prefs;

        public ImageAdapter(Context c)
        {
            context = c;
        }
        public override int Count
        {
            get
            {
                return thumbIds.Length;
            }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        // create a new ImageView for each item referenced by the Adapter   
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            if (convertView == null)
            { // if it's not recycled, initialize some attributes   
                imageView = new ImageView(context);

                imageView.LayoutParameters = new GridView.LayoutParams(200, 200);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
               // imageView.SetPadding(20, 20, 20, 20);
            }
            else
            {
                imageView = (ImageView)convertView;
            }


             imageView.SetImageResource(thumbIds[position]);

            int resourceId = context.Resources.GetIdentifier("date5", "drawable", this.context.PackageName);

            int date6 = context.Resources.GetIdentifier("date6", "drawable", this.context.PackageName);

            int time5 = context.Resources.GetIdentifier("time5", "drawable", this.context.PackageName);


            if (thumbIds[position] == resourceId)
            {
                imageView.Click += delegate
                {
                    PlayStore();

                };

            }

            if (thumbIds[position] == date6)
            {
                imageView.Click += delegate
                {
                    PlayStoreAppNotInstalled();

                };

            }

            if (thumbIds[position] == time5)
            {
                imageView.Click += delegate
                {
                    PlayStoreWhatsApp();

                };

            }





            return imageView;
        }
        // references to our images   
        int[] thumbIds = {
        Resource.Drawable.date5,
        Resource.Drawable.date6,
        Resource.Drawable.time5,
        Resource.Drawable.date5,
        Resource.Drawable.date5,
        Resource.Drawable.date6,
        Resource.Drawable.time5,
        Resource.Drawable.date5,


    };

        public void PlayStore()
        {
           // string appPackageName = Application.Context.PackageName;


            string your_apppackagename = "com.facebook.katana";
            PackageManager packageManager = context.PackageManager;
            ApplicationInfo applicationInfo = null;
            try
            {
                applicationInfo = packageManager.GetApplicationInfo(your_apppackagename, 0);

                // applicationInfo = packageManager.GetApplicationInfo(your_apppackagenamenotinstalled, 0);
            }
            catch (PackageManager.NameNotFoundException e)
            {
                e.PrintStackTrace();
            }
            if (applicationInfo == null)
            {

                Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + your_apppackagename)));

                //  Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + your_apppackagenamenotinstalled)));
            }
            else
            {

                Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(your_apppackagename);

                //Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(your_apppackagenamenotinstalled);
                Application.Context.StartActivity(LaunchIntent);
            }

        }

        public void PlayStoreWhatsApp()
        {
            // string appPackageName = Application.Context.PackageName;


            string whatsapp = "com.whatsapp";
            PackageManager packageManager = context.PackageManager;
            ApplicationInfo applicationInfo = null;
            try
            {
                applicationInfo = packageManager.GetApplicationInfo(whatsapp, 0);

                // applicationInfo = packageManager.GetApplicationInfo(your_apppackagenamenotinstalled, 0);
            }
            catch (PackageManager.NameNotFoundException e)
            {
                e.PrintStackTrace();
            }
            if (applicationInfo == null)
            {

                Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + whatsapp)));

                //  Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + your_apppackagenamenotinstalled)));
            }
            else
            {

                Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(whatsapp);

                //Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(your_apppackagenamenotinstalled);
                Application.Context.StartActivity(LaunchIntent);
            }

        }

        public void PlayStoreAppNotInstalled()
        {
            string your_apppackagenamenotinstalled = "com.india.foodpanda.android";
            PackageManager packageManager = context.PackageManager;
            ApplicationInfo applicationInfo = null;
            try
            {
                applicationInfo = packageManager.GetApplicationInfo(your_apppackagenamenotinstalled, 0);

                // applicationInfo = packageManager.GetApplicationInfo(your_apppackagenamenotinstalled, 0);
            }
            catch (PackageManager.NameNotFoundException e)
            {
                e.PrintStackTrace();
            }
            if (applicationInfo == null)
            {

                Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + your_apppackagenamenotinstalled)));

                //  Application.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + your_apppackagenamenotinstalled)));
            }
            else
            {

                Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(your_apppackagenamenotinstalled);

                //Intent LaunchIntent = packageManager.GetLaunchIntentForPackage(your_apppackagenamenotinstalled);
                Application.Context.StartActivity(LaunchIntent);
            }
        }

        public byte[] GetStreamFromFile(string filePath)
        {
            try
            {
                Android.Net.Uri uri = Android.Net.Uri.FromFile(new Java.IO.File(filePath));
                byte[] byteArray = System.IO.File.ReadAllBytes(uri.Path);
                return byteArray;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }


        private async Task AppFromServer(string work121app)
        {
            string Activityintent = "", Appiconurl = "", Appurl = "";

            prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            string licenceid = prefs.GetString("LicenceId", "");
            string liceId = prefs.GetString("LicenceId", "");
            string desigId = prefs.GetString("DesignationId", "");
            //com.work121.ComTaxService service = new com.work121.ComTaxService();
            //com.work121.GSTINData[] result = null;
            dynamic value = new ExpandoObject();

            value.searchkey = work121app;
            string json = JsonConvert.SerializeObject(value);
            try
            {

                JsonValue item = await restService.GetServiceMethod(context, "GetGSTINData", json).ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<List<ImageListModel>>(item);
                //Activity.RunOnUiThread(() =>
                //{
                //    if (result != null)
                //    {
                //        for (int i = 0; i < result.Count; i++)
                //        {
                //            Activityintent = result[i].activityintent;
                //            Appiconurl = result[i].appiconurl;
                //            Appurl = result[i].appurl;

                //        }
                //    }
                //});
            }
            catch (Exception e)
            {

            }
        }




            // PackageManager pm = context.PackageManager;
            // Boolean isInstalled = isPackageInstalled("com.facebook.katana", pm);

            //try
            //{
            //    //  var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + appPackageName));

            //    // var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=com.india.foodpanda.android"));

            //    var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id="+ isInstalled));

            //    intent.AddFlags(ActivityFlags.NewTask);

            //    isPackageInstalled(appPackageName, pm);

            //    Application.Context.StartActivity(intent);


            //}
            //catch (ActivityNotFoundException)
            //{
            //     var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id="));



            //    intent.AddFlags(ActivityFlags.NewTask);

            //    Application.Context.StartActivity(intent);
            //}

            //try
            //{
            //    string facebook = "com.facebook.katana";

            //    Boolean isAppInstalled = AppInstalledOrNot("com.facebook.katana");

            //    if(isAppInstalled)
            //    {
            //        Intent LaunchIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + facebook));

            //        Application.Context.StartActivity(LaunchIntent);

            //       // Log.Debug("Ashish","Application is already installed.");
            //    }
            //    else
            //    {
            //        // Do whatever we want to do if application not installed
            //        // For example, Redirect to play store

            //       // Log.Debug("Ashish","Application is not currently installed.");
            //    }
            //}

            //catch
            //{
            //    var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id="));



            //    intent.AddFlags(ActivityFlags.NewTask);

            //    Application.Context.StartActivity(intent);
            //}


            // string your_apppackagenamenotinstalled = "com.india.foodpanda.android";


            //private bool AppInstalledOrNot(string uri)
            //{
            //    PackageManager pm =  context.PackageManager;
            //    try
            //    {
            //        pm.GetPackageInfo(uri, PackageInfoFlags.Activities);
            //        return true;
            //    }
            //    catch (PackageManager.NameNotFoundException e)
            //    {
            //    }

            //    return false;
            //}

            //private Boolean isPackageInstalled(string packageName, PackageManager packageManager)
            //{

            //    Boolean found = true;

            //    try
            //    {

            //        packageManager.GetPackageInfo(packageName, 0);
            //    }
            //    catch (PackageManager.NameNotFoundException e)
            //    {

            //        found = false;
            //    }

            //    return found;
            //}


        }

}