using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Work121App.Adapter;

namespace Work121App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        GridView gridView;
      //  public static GridAdapter grid_adapter;
        //InternetConnection con;
        public static ImageAdapter image_adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            gridView = FindViewById<GridView>(Resource.Id.gridview);
            image_adapter = new ImageAdapter(this);

           // grid_adapter = new GridAdapter(this, Utilities.imageList);
            gridView.Adapter = image_adapter;
           // gridView.NestedScrollingEnabled = false;
           // gridView.ScrollbarFadingEnabled = true;
        }
    }
}