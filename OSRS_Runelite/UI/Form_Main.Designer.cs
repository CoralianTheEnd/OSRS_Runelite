namespace OSRS_Runelite.UI
{
    partial class Form_Main
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
            toolStrip1 = new ToolStrip();
            toolStripLabel_FindWindow = new ToolStripLabel();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripComboBox1 = new ToolStripComboBox();
            stopScriptLabel = new ToolStripLabel();
            startScriptLabel = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel_FindWindow, toolStripTextBox1, toolStripTextBox2, toolStripComboBox1, stopScriptLabel, startScriptLabel, toolStripLabel2, toolStripLabel3, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(853, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel_FindWindow
            // 
            toolStripLabel_FindWindow.Image = Properties.Resources.Target_icon;
            toolStripLabel_FindWindow.Name = "toolStripLabel_FindWindow";
            toolStripLabel_FindWindow.RightToLeft = RightToLeft.Yes;
            toolStripLabel_FindWindow.Size = new Size(93, 22);
            toolStripLabel_FindWindow.Text = "Find Window";
            toolStripLabel_FindWindow.Click += toolStripLabel_FindWindow_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 25);
            toolStripTextBox1.Text = "hatch68778@outlook.com";
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(100, 25);
            toolStripTextBox2.Text = "osrspurepassword189";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            // 
            // stopScriptLabel
            // 
            stopScriptLabel.Alignment = ToolStripItemAlignment.Right;
            stopScriptLabel.Name = "stopScriptLabel";
            stopScriptLabel.Size = new Size(64, 22);
            stopScriptLabel.Text = "Stop Script";
            stopScriptLabel.Click += stopScriptLabel_Click;
            // 
            // startScriptLabel
            // 
            startScriptLabel.Alignment = ToolStripItemAlignment.Right;
            startScriptLabel.Name = "startScriptLabel";
            startScriptLabel.Size = new Size(64, 22);
            startScriptLabel.Text = "Start Script";
            startScriptLabel.Click += startScriptLabel_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(86, 22);
            toolStripLabel2.Text = "toolStripLabel2";
            toolStripLabel2.Click += toolStripLabel2_Click;
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(86, 22);
            toolStripLabel3.Text = "toolStripLabel3";
            toolStripLabel3.Click += toolStripLabel3_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 311);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(853, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(86, 15);
            toolStripLabel1.Text = "toolStripLabel1";
            toolStripLabel1.Click += toolStripLabel1_Click;
            // 
            // Form_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 333);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form_Main";
            Text = "Main";
            Load += Form_Main_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel_FindWindow;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripTextBox toolStripTextBox2;
        private StatusStrip statusStrip1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripLabel startScriptLabel;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel stopScriptLabel;
        private ToolStripLabel toolStripLabel1;
    }
}