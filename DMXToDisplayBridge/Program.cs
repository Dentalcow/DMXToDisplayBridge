using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using ArtDotNet;
using DMXToDisplayBridge;
using System.Net.NetworkInformation;

namespace ArtDotNetClient
{
    class MainClass
    {
        static int universe = 0;
        static int subnet = 0;
        static int startAddress = 1;

        static int[] dmxData = new int[512];
        static int dim, red, green, blue;

        public static void Main(string[] args)
        {
            using (var settingsForm = new SettingsDialogForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    subnet = settingsForm.Subnet;
                    universe = settingsForm.Universe;
                    startAddress = settingsForm.StartingAddress;
                    Screen selectedMonitor = settingsForm.SelectedMonitor;

                    var controller = new ArtNetController();
                    string selectedInterfaceName = settingsForm.SelectedNetworkInterfaceName;
                    IPAddress ipAddress = GetIPAddressFromInterfaceName(selectedInterfaceName);

                    // Check if an IP address was found before setting it
                    if (ipAddress != null)
                    {
                        controller.Address = ipAddress;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No active network interface found. Exiting...");
                        return; // Exit the application or handle the error appropriately
                    }

                    Application.EnableVisualStyles();
                    Form displayForm = new Form();
                    displayForm.StartPosition = FormStartPosition.Manual;
                    displayForm.WindowState = FormWindowState.Normal;
                    displayForm.Bounds = selectedMonitor.Bounds;
                    displayForm.Text = "Color Display";
                    displayForm.FormBorderStyle = FormBorderStyle.None;
                    displayForm.WindowState = FormWindowState.Maximized;
                    displayForm.TopMost = true;

                    controller.DmxPacketReceived += (s, p) =>
                    {
                        if (p.SubUni != (universe * 16 + subnet))
                            return;

                        Array.Copy(p.Data, dmxData, p.Length);

                        int channelIndex = startAddress - 1;

                        for (int i = 0; i < 4 && channelIndex < p.Length; i++, channelIndex++)
                        {
                            switch (i)
                            {
                                case 0:
                                    dim = dmxData[channelIndex];
                                    break;
                                case 1:
                                    red = dmxData[channelIndex];
                                    break;
                                case 2:
                                    green = dmxData[channelIndex];
                                    break;
                                case 3:
                                    blue = dmxData[channelIndex];
                                    break;
                            }
                        }

                        float dimmer = dim / 255f;
                        red = (int)(red * dimmer);
                        green = (int)(green * dimmer);
                        blue = (int)(blue * dimmer);
                        displayForm.BackColor = Color.FromArgb(red, green, blue);
                    };

                    controller.Start();
                    Application.Run(displayForm);
                    controller.Stop();
                }
            }
        }
        private static IPAddress GetIPAddressFromInterfaceName(string interfaceName)
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(ni => ni.Name == interfaceName);

            if (networkInterface != null)
            {
                var address = networkInterface.GetIPProperties()
                    .UnicastAddresses
                    .FirstOrDefault(ua => ua.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.Address;

                return address;
            }

            return null;
        }

        private static IPAddress GetActiveNetworkInterfaceIPAddress()
        {
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up &&
                    netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return addr.Address;
                        }
                    }
                }
            }
            return null;
        }
    }
}
