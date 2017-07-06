using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
