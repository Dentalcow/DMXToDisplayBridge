using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMXToDisplayBridge
{
    public partial class SettingsDialogForm : Form
    {
        public int Subnet => (int)subnetNumericUpDown.Value;
        public int Universe => (int)universeNumericUpDown.Value;
        public int StartingAddress => (int)startAddressNumericUpDown.Value;
        public Screen SelectedMonitor => Screen.AllScreens[monitorComboBox.SelectedIndex];
        public SettingsDialogForm()
        {
            InitializeComponent();

            PopulateNetworkInterfaces();


            // Monitor ComboBox setup
            foreach (var screen in Screen.AllScreens)
            {
                monitorComboBox.Items.Add(screen.DeviceName);
            }

            // OK Button setup
            okButton.Text = "OK";
            okButton.Click += OkButton_Click;

            // Add controls to the form
            this.Controls.Add(subnetNumericUpDown);
            this.Controls.Add(universeNumericUpDown);
            this.Controls.Add(startAddressNumericUpDown);
            this.Controls.Add(monitorComboBox);
            this.Controls.Add(okButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void subnetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PopulateNetworkInterfaces()
        {
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up &&
                    netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    networkInterfaceComboBox.Items.Add(netInterface.Name);
                }
            }

            if (networkInterfaceComboBox.Items.Count > 0)
                networkInterfaceComboBox.SelectedIndex = 0;
        }

        public string SelectedNetworkInterfaceName => networkInterfaceComboBox.SelectedItem?.ToString();
    }
}

