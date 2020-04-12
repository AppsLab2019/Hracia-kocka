using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Dice.Models
{
    class DetectShake
    {
        SensorSpeed sensorSpeed = SensorSpeed.Fastest;
        public ViewModels.MainViewModel model;
     
        public DetectShake()
        {
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetedted;
        }
        void Accelerometer_ShakeDetedted(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                model.RandomNumber = new int();
            });
        }
        public void ToggleAccelerometer()
        {
            try
               {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(sensorSpeed);
               }
            catch (FeatureNotSupportedException fnsEx)
            {
            // Feature not supported on device
            }
            catch (Exception ex)
            {
            // Other error has occurred.
            }
        }

    }
}
