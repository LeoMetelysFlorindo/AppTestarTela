using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.DeviceInfo;

namespace AppTestarTela
{
    [Activity(Label = "Testar Resolução", MainLauncher = true, Icon = "@drawable/icon")]

     public class MainActivity : Activity
    {

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            //Algoritimo a desenvolver: 09/04/2017 14:48h
            //detectar o tamanho da tela em uso

            var platform = CrossDeviceInfo.Current.Platform;
            var versao = CrossDeviceInfo.Current.Version;
            var modelo = CrossDeviceInfo.Current.Model;      
                   
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);


            //remove título desta Activity
            //Window.RequestFeature(WindowFeatures.NoTitle);

            //setar apropriadamente qual layout apresentar na tela
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.TestarResolucao);
            var txtTamanho = FindViewById<TextView>(Resource.Id.txtWidth);
            var txtLargura = FindViewById<TextView>(Resource.Id.txtHeigth);
            var TxtPlataforma = FindViewById<TextView>(Resource.Id.txtPlataforma);
            var TxtVersao = FindViewById<TextView>(Resource.Id.txtVersao);
            var TxtModel = FindViewById<TextView>(Resource.Id.txtModelo);

            txtTamanho.SetTextColor(Android.Graphics.Color.Yellow);
            txtLargura.SetTextColor(Android.Graphics.Color.Yellow);
            txtTamanho.Text = "Width do Celular: " + widthInDp.ToString();
            txtLargura.Text = "Height do Celular: " + heightInDp.ToString();
            TxtPlataforma.Text = "Plataforma do Celular: " + platform.ToString();
            TxtVersao.Text = "Versão do Celular: " + versao.ToString();
            TxtModel.Text = "Modelo do Celular: " + modelo.ToString();
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

    }
}

