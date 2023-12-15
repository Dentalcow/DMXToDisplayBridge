using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms; // Correct namespace for Form and Application
using ArtDotNet;

namespace ArtDotNetClient
{
    class MainClass
    {
        static int universe = 0;
        static int subnet = 0;
        static int startAddress = 1;

        static int[] dmxData = new int[512];
        static int red, green, blue, white;

        public static void Main(string[] args)
        {
            Console.WriteLine("ArtDotNet Client");
            var controller = new ArtNetController();
            controller.Address = IPAddress.Loopback;

            // Initialize GUI
            Application.EnableVisualStyles();
            Form displayForm = new Form();
            displayForm.Text = "Color Display";
            displayForm.Size = new Size(800, 600); // Set the size of the window

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
                            red = dmxData[channelIndex];
                            break;
                        case 1:
                            green = dmxData[channelIndex];
                            break;
                        case 2:
                            blue = dmxData[channelIndex];
                            break;
                        case 3:
                            white = dmxData[channelIndex];
                            break;
                    }
                }

                // Set the background color of the form
                displayForm.BackColor = Color.FromArgb(red, green, blue);
            };

            controller.Start();

            // Run the application
            Application.Run(displayForm);

            controller.Stop();
        }
    }
}
