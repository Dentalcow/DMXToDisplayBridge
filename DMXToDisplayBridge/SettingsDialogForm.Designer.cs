namespace DMXToDisplayBridge
{
    partial class SettingsDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            universeNumericUpDown = new NumericUpDown();
            startAddressNumericUpDown = new NumericUpDown();
            monitorComboBox = new ComboBox();
            okButton = new Button();
            subnetNumericUpDown = new NumericUpDown();
            subnetLabel = new Label();
            universeLabel = new Label();
            startingAddressLabel = new Label();
            monitorLabel = new Label();
            networkAdapterLabel = new Label();
            networkInterfaceComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)universeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startAddressNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subnetNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // universeNumericUpDown
            // 
            universeNumericUpDown.Location = new Point(14, 95);
            universeNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            universeNumericUpDown.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            universeNumericUpDown.Name = "universeNumericUpDown";
            universeNumericUpDown.Size = new Size(344, 27);
            universeNumericUpDown.TabIndex = 1;
            // 
            // startAddressNumericUpDown
            // 
            startAddressNumericUpDown.Location = new Point(14, 153);
            startAddressNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            startAddressNumericUpDown.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
            startAddressNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            startAddressNumericUpDown.Name = "startAddressNumericUpDown";
            startAddressNumericUpDown.Size = new Size(344, 27);
            startAddressNumericUpDown.TabIndex = 2;
            startAddressNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // monitorComboBox
            // 
            monitorComboBox.FormattingEnabled = true;
            monitorComboBox.Location = new Point(14, 212);
            monitorComboBox.Margin = new Padding(3, 4, 3, 4);
            monitorComboBox.Name = "monitorComboBox";
            monitorComboBox.Size = new Size(343, 28);
            monitorComboBox.TabIndex = 3;
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 334);
            okButton.Margin = new Padding(3, 4, 3, 4);
            okButton.Name = "okButton";
            okButton.Size = new Size(344, 31);
            okButton.TabIndex = 4;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            // 
            // subnetNumericUpDown
            // 
            subnetNumericUpDown.Location = new Point(14, 36);
            subnetNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            subnetNumericUpDown.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            subnetNumericUpDown.Name = "subnetNumericUpDown";
            subnetNumericUpDown.Size = new Size(344, 27);
            subnetNumericUpDown.TabIndex = 5;
            subnetNumericUpDown.ValueChanged += subnetNumericUpDown_ValueChanged;
            // 
            // subnetLabel
            // 
            subnetLabel.AutoSize = true;
            subnetLabel.Location = new Point(14, 12);
            subnetLabel.Name = "subnetLabel";
            subnetLabel.Size = new Size(55, 20);
            subnetLabel.TabIndex = 6;
            subnetLabel.Text = "Subnet";
            // 
            // universeLabel
            // 
            universeLabel.AutoSize = true;
            universeLabel.Location = new Point(14, 71);
            universeLabel.Name = "universeLabel";
            universeLabel.Size = new Size(65, 20);
            universeLabel.TabIndex = 7;
            universeLabel.Text = "Universe";
            // 
            // startingAddressLabel
            // 
            startingAddressLabel.AutoSize = true;
            startingAddressLabel.Location = new Point(14, 129);
            startingAddressLabel.Name = "startingAddressLabel";
            startingAddressLabel.Size = new Size(118, 20);
            startingAddressLabel.TabIndex = 8;
            startingAddressLabel.Text = "Starting Address";
            // 
            // monitorLabel
            // 
            monitorLabel.AutoSize = true;
            monitorLabel.Location = new Point(14, 188);
            monitorLabel.Name = "monitorLabel";
            monitorLabel.Size = new Size(62, 20);
            monitorLabel.TabIndex = 9;
            monitorLabel.Text = "Monitor";
            // 
            // networkAdapterLabel
            // 
            networkAdapterLabel.AutoSize = true;
            networkAdapterLabel.Location = new Point(14, 244);
            networkAdapterLabel.Name = "networkAdapterLabel";
            networkAdapterLabel.Size = new Size(123, 20);
            networkAdapterLabel.TabIndex = 11;
            networkAdapterLabel.Text = "Network Adapter";
            // 
            // networkInterfaceComboBox
            // 
            networkInterfaceComboBox.FormattingEnabled = true;
            networkInterfaceComboBox.Location = new Point(14, 268);
            networkInterfaceComboBox.Margin = new Padding(3, 4, 3, 4);
            networkInterfaceComboBox.Name = "networkInterfaceComboBox";
            networkInterfaceComboBox.Size = new Size(343, 28);
            networkInterfaceComboBox.TabIndex = 10;
            // 
            // SettingsDialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 378);
            Controls.Add(networkAdapterLabel);
            Controls.Add(networkInterfaceComboBox);
            Controls.Add(monitorLabel);
            Controls.Add(startingAddressLabel);
            Controls.Add(universeLabel);
            Controls.Add(subnetLabel);
            Controls.Add(subnetNumericUpDown);
            Controls.Add(okButton);
            Controls.Add(monitorComboBox);
            Controls.Add(startAddressNumericUpDown);
            Controls.Add(universeNumericUpDown);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingsDialogForm";
            Text = "SettingsDialogForm";
            ((System.ComponentModel.ISupportInitialize)universeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startAddressNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)subnetNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown universeNumericUpDown;
        private NumericUpDown startAddressNumericUpDown;
        private ComboBox monitorComboBox;
        private Button okButton;
        private NumericUpDown subnetNumericUpDown;
        private Label subnetLabel;
        private Label universeLabel;
        private Label startingAddressLabel;
        private Label monitorLabel;
        private Label networkAdapterLabel;
        private ComboBox networkInterfaceComboBox;
    }
}