namespace OSRS_Runelite.UI
{
    partial class Form_AccountManager
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
            AccountListview = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            SuspendLayout();
            // 
            // AccountListview
            // 
            AccountListview.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            AccountListview.FullRowSelect = true;
            AccountListview.GridLines = true;
            AccountListview.Location = new Point(66, 112);
            AccountListview.Name = "AccountListview";
            AccountListview.Size = new Size(372, 97);
            AccountListview.TabIndex = 0;
            AccountListview.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Username";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Password";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "";
            // 
            // FormAccountManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AccountListview);
            Name = "FormAccountManager";
            Text = "FormAccountManager";
            ResumeLayout(false);
        }

        #endregion

        private ListView AccountListview;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}