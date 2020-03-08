using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinFormsStateTriggers
{
    public class NetworkConnectionStateTrigger : StateTriggerBase
    {
        public NetworkConnectionStateTrigger()
        {
            UpdateState();

            // TODO: Subscribe and unsubscribe this event using OnAttached and OnDetach.
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        public bool IsConnected
        {
            get => (bool)GetValue(IsConnectedProperty);
            set => SetValue(IsConnectedProperty, value);
        }

        public static readonly BindableProperty IsConnectedProperty =
        BindableProperty.Create(nameof(IsConnected), typeof(bool), typeof(NetworkConnectionStateTrigger), false,
            propertyChanged: OnIsConnectedChanged);

        static void OnIsConnectedChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((NetworkConnectionStateTrigger)bindable).UpdateState();
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            UpdateState();
        }

        void UpdateState()
        {
            var current = Connectivity.NetworkAccess;

            if (IsConnected)
                SetActive(current == NetworkAccess.Internet);
            else
                SetActive(current != NetworkAccess.Internet);
        }
    }
}