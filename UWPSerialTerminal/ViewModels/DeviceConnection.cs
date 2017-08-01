using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;

namespace UWPSerialTerminal.ViewModels
{
    public class DeviceConnection : INotifyPropertyChanged
    {
        private string _content;

        public string Id { get; set; }

        public int BaudRate { get; set; }

        public string Content
        {
            get { return _content; }
            set { _content = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content")); }
        }

        public SerialDevice Device { get; set; }

        public DataReader DataReaderObject { get; set; }

        public DataWriter DataWriterObject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
