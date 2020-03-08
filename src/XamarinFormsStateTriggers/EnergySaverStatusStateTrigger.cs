using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinFormsStateTriggers
{
    public class EnergySaverStatusStateTrigger : StateTriggerBase
    {
        public EnergySaverStatusStateTrigger()
        {
            UpdateState();

            // TODO: Subscribe and unsubscribe this event using OnAttached and OnDetach.
            Battery.BatteryInfoChanged += OnBatteryInfoChanged;
        }

        public bool IsEnergySaverStatus
        {
            get => (bool)GetValue(IsEnergySaverStatusProperty);
            set => SetValue(IsEnergySaverStatusProperty, value);
        }

        public static readonly BindableProperty IsEnergySaverStatusProperty =
        BindableProperty.Create(nameof(IsEnergySaverStatus), typeof(bool), typeof(EnergySaverStatusStateTrigger), false,
            propertyChanged: OnIsEnergySaverStatusChanged);

        static void OnIsEnergySaverStatusChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((EnergySaverStatusStateTrigger)bindable).UpdateState();
        }

        void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            UpdateState();
        }

        void UpdateState()
        {
            var energySaverStatus = Battery.EnergySaverStatus;

            if (IsEnergySaverStatus)
                SetActive(energySaverStatus == EnergySaverStatus.On);
            else
                SetActive(energySaverStatus == EnergySaverStatus.Off);
        }
    }
}