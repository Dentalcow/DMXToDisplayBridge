using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms; // Correct namespace for Form and Application
using ArtDotNet;
using DMXToDisplayBridge;

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
                // Show the settings dialog form modally
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve settings from the dialog form
                    int subnet = settingsForm.Subnet;
                    int universe = settingsForm.Universe;
                    int startAddress = settingsForm.StartingAddress;
                    Screen selectedMonitor = settingsForm.SelectedMonitor;

                    // Proceed with the rest of your application logic
                    var controller = new ArtNetController();
                    controller.Address = IPAddress.Loopback;
                    // ... configure your controller and main application form

                    // Example: Position the form on the selected monitor
                    Form mainForm = new Form();
                    mainForm.StartPosition = FormStartPosition.Manual;
                    mainForm.Bounds = selectedMonitor.Bounds;
                    // ... other form configurations

                    // Initialize GUI
                    Application.EnableVisualStyles();
                    Form displayForm = new Form();
                    displayForm.Text = "Color Display";
                    displayForm.FormBorderStyle = FormBorderStyle.None; // No borders
                    displayForm.WindowState = FormWindowState.Maximized; // Maximize the window
                    displayForm.TopMost = true; // Ensure the form is topmost

                    controller.DmxPacketReceived += (s, p) =>
                    {
                        if (p.SubUni != (universe * 16 + subnet))
                            return;

                        // Copy DMX data to the local array
                        Array.Copy(p.Data, dmxData, p.Length);

                        int channelIndex = startAddress - 1; // Calculate the index for the starting address

                        for (int i = 0; i < 4 && channelIndex < p.Length; i++, channelIndex++)
                        {
                            // Assign values to red, green, blue, and white variables based on channel index
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
                                    blue = dmxData[channelIndex]; // white channel used as dimmer
                                    break;
                            }
                        }

                        // Calculate dimming factor (0 to 1)
                        float dimmer = dim / 255f;

                        // Apply dimming to RGB channels
                        red = (int)(red * dimmer);
                        green = (int)(green * dimmer);
                        blue = (int)(blue * dimmer);

                        // Set the background color of the form with dimmed RGB values
                        displayForm.BackColor = Color.FromArgb(red, green, blue);
                    };

                    controller.Start();

                    // Run the application
                    Application.Run(displayForm);

                    controller.Stop();
                }
            }
        }
    }
}
