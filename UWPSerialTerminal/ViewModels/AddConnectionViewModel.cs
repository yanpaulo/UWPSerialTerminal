using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSerialTerminal.ViewModels
{
    public class AddConnectionViewModel
    {
        public IList<string> DeviceIds { get; set; } = 
            new[] { "21063604-7224-4d57-8698-8e3d95d1718c" };

        public IList<int> BaudRates { get; set; } =
            new[] { 9600, 115200 };

        public DeviceConnection Connection { get; set; } =
            new DeviceConnection { Id = "21063604-7224-4d57-8698-8e3d95d1718c", BaudRate = 9600 };
    }
}
