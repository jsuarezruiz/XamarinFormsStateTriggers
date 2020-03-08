using System;
using Xamarin.Forms;

namespace XamarinFormsStateTriggers.Sample.Views
{
    public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
		}

        void OnEnergySaverStatusStateTriggerClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnergySaverStatusStateTriggerView());
        }

        void OnNetworkConnectionStateTriggerClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NetworkConnectionStateTriggerView());
        }
    }
}