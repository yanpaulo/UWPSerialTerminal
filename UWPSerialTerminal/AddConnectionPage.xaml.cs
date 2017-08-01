using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSerialTerminal.ViewModels;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPSerialTerminal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class AddConnectionPage : Page
    {
        private AddConnectionViewModel _viewModel;

        public AddConnectionPage()
        {
            this.InitializeComponent();
            _viewModel = (AddConnectionViewModel)DataContext;
        }
        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string aqs = SerialDevice.GetDeviceSelector();
            var dis = await DeviceInformation.FindAllAsync(aqs);

            DataContext = _viewModel =
                new AddConnectionViewModel
                {
                    DeviceIds = dis.Select(d => d.Id).ToList(),
                    Connection = null
                };


        }
        
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

    }
}
