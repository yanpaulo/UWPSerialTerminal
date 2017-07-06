using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSerialTerminal.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<DeviceConnection> DeviceConnections { get; private set; } = new ObservableCollection<DeviceConnection>();

        public DeviceConnection SelectedDeviceConnection { get; set; }

    }
}
