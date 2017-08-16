using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.UI.Core;

namespace UWPSerialTerminal.ViewModels
{
    public class DeviceConnection : INotifyPropertyChanged
    {
        private string _content;
        private SerialDevice _device;

        public string Id { get; set; }

        public int BaudRate { get; set; }

        public string Content
        {
            get { return _content; }
            set { _content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content")); }
        }
        
        public SerialDevice Device
        {
            get { return _device; }
            set { 
                if (_device != null)
                {
                    _device.PinChanged -= Device_PinChanged;
                    value.PinChanged += Device_PinChanged;
                }
                _device = value;
                DataReaderObject = new DataReader(_device.InputStream);
                DataWriterObject = new DataWriter(_device.OutputStream);

            }
        }

        public DataReader DataReaderObject { get; private set; }

        public DataWriter DataWriterObject { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Device_PinChanged(SerialDevice sender, PinChangedEventArgs args)
        {
            if (args.PinChange == SerialPinChange.DataSetReady)
            {
                var size = await DataReaderObject.LoadAsync(int.MaxValue);
                if (size > 0)
                {
                    var str = DataReaderObject.ReadString(size);

                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Content += $"Device: {str}\r\n";
                    });
                } 
            }
        }

    }
}
