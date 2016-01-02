using System;
using System.Windows.Forms;

namespace ParallelSPSS
{
    partial class Form1
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
            this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearRegresionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reoGridDataView = new unvell.ReoGrid.ReoGridControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reoGridVarView = new unvell.ReoGrid.ReoGridControl();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardDeviationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varianceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reoGridControl1
            // 
            this.reoGridControl1.BackColor = System.Drawing.Color.White;
            this.reoGridControl1.ColumnHeaderContextMenuStrip = null;
            this.reoGridControl1.LeadHeaderContextMenuStrip = null;
            this.reoGridControl1.Location = new System.Drawing.Point(0, 0);
            this.reoGridControl1.Name = "reoGridControl1";
            this.reoGridControl1.RowHeaderContextMenuStrip = null;
            this.reoGridControl1.Script = null;
            this.reoGridControl1.SheetTabContextMenuStrip = null;
            this.reoGridControl1.SheetTabControlNewButtonVisible = true;
            this.reoGridControl1.SheetTabControlWidth = 400;
            this.reoGridControl1.SheetTabNewButtonVisible = true;
            this.reoGridControl1.Size = new System.Drawing.Size(0, 0);
            this.reoGridControl1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.analyzeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.saveAsMenu,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.exitMenu});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "New";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.newMenuClicked);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem3.Text = "Open";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.openMenuClicked);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem4.Text = "Save";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.saveMenuClicked);
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            this.saveAsMenu.Size = new System.Drawing.Size(164, 22);
            this.saveAsMenu.Text = "Save As";
            this.saveAsMenu.Click += new System.EventHandler(this.saveAsClicked);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.cSVToolStripMenuItem});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "Import";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem1,
            this.cSVToolStripMenuItem1});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "Export";
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(164, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenuClicked);
            // 
            // analyzeToolStripMenuItem
            // 
            this.analyzeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.modesToolStripMenuItem,
            this.standardDeviationToolStripMenuItem,
            this.varianceToolStripMenuItem,
            this.rangeToolStripMenuItem,
            this.linearRegresionToolStripMenuItem});
            this.analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            this.analyzeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // meanToolStripMenuItem
            // 
            this.meanToolStripMenuItem.Name = "meanToolStripMenuItem";
            this.meanToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.meanToolStripMenuItem.Text = "Mean";
            this.meanToolStripMenuItem.Click += new System.EventHandler(this.meanClick);
            // 
            // rangeToolStripMenuItem
            // 
            this.rangeToolStripMenuItem.Name = "rangeToolStripMenuItem";
            this.rangeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.rangeToolStripMenuItem.Text = "Range";
            this.rangeToolStripMenuItem.Click += new System.EventHandler(this.rangeClicked);
            // 
            // linearRegresionToolStripMenuItem
            // 
            this.linearRegresionToolStripMenuItem.Name = "linearRegresionToolStripMenuItem";
            this.linearRegresionToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.linearRegresionToolStripMenuItem.Text = "Linear Regresion";
            this.linearRegresionToolStripMenuItem.Click += new System.EventHandler(this.regresionClicked);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 465);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.reoGridDataView);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data View";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(789, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1 : ";
            // 
            // reoGridDataView
            // 
            this.reoGridDataView.BackColor = System.Drawing.Color.White;
            this.reoGridDataView.ColumnHeaderContextMenuStrip = null;
            this.reoGridDataView.LeadHeaderContextMenuStrip = null;
            this.reoGridDataView.Location = new System.Drawing.Point(-3, 24);
            this.reoGridDataView.Name = "reoGridDataView";
            this.reoGridDataView.RowHeaderContextMenuStrip = null;
            this.reoGridDataView.Script = null;
            this.reoGridDataView.SheetTabContextMenuStrip = null;
            this.reoGridDataView.SheetTabControlNewButtonVisible = true;
            this.reoGridDataView.SheetTabControlWidth = 60;
            this.reoGridDataView.SheetTabNewButtonVisible = true;
            this.reoGridDataView.Size = new System.Drawing.Size(875, 413);
            this.reoGridDataView.TabIndex = 0;
            this.reoGridDataView.Text = "Data View";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reoGridVarView);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Variable View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reoGridVarView
            // 
            this.reoGridVarView.BackColor = System.Drawing.Color.White;
            this.reoGridVarView.ColumnHeaderContextMenuStrip = null;
            this.reoGridVarView.LeadHeaderContextMenuStrip = null;
            this.reoGridVarView.Location = new System.Drawing.Point(-3, -3);
            this.reoGridVarView.Name = "reoGridVarView";
            this.reoGridVarView.RowHeaderContextMenuStrip = null;
            this.reoGridVarView.Script = null;
            this.reoGridVarView.SheetTabContextMenuStrip = null;
            this.reoGridVarView.SheetTabControlNewButtonVisible = true;
            this.reoGridVarView.SheetTabControlWidth = 60;
            this.reoGridVarView.SheetTabNewButtonVisible = true;
            this.reoGridVarView.Size = new System.Drawing.Size(875, 440);
            this.reoGridVarView.TabIndex = 0;
            this.reoGridVarView.Text = "reoGridVariableView";
            // 
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.modesToolStripMenuItem.Text = "Modes";
            this.modesToolStripMenuItem.Click += new System.EventHandler(this.modesClicked);
            // 
            // standardDeviationToolStripMenuItem
            // 
            this.standardDeviationToolStripMenuItem.Name = "standardDeviationToolStripMenuItem";
            this.standardDeviationToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.standardDeviationToolStripMenuItem.Text = "Standard Deviation";
            this.standardDeviationToolStripMenuItem.Click += new System.EventHandler(this.standardDeviationClicked);
            // 
            // varianceToolStripMenuItem
            // 
            this.varianceToolStripMenuItem.Name = "varianceToolStripMenuItem";
            this.varianceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.varianceToolStripMenuItem.Text = "Variance";
            this.varianceToolStripMenuItem.Click += new System.EventHandler(this.varianceClicked);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.importExcelMenuClicked);
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            this.cSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVMenuClicked);
            // 
            // excelToolStripMenuItem1
            // 
            this.excelToolStripMenuItem1.Name = "excelToolStripMenuItem1";
            this.excelToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.excelToolStripMenuItem1.Text = "Excel";
            this.excelToolStripMenuItem1.Click += new System.EventHandler(this.exportAsExcelMenuClicked);
            // 
            // cSVToolStripMenuItem1
            // 
            this.cSVToolStripMenuItem1.Name = "cSVToolStripMenuItem1";
            this.cSVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.cSVToolStripMenuItem1.Text = "CSV";
            this.cSVToolStripMenuItem1.Click += new System.EventHandler(this.exportAsCSVMenuClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 493);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.reoGridControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SPSS";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private unvell.ReoGrid.ReoGridControl reoGridControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem analyzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private unvell.ReoGrid.ReoGridControl reoGridDataView;
        private unvell.ReoGrid.ReoGridControl reoGridVarView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private ToolStripMenuItem rangeToolStripMenuItem;
        private ToolStripMenuItem linearRegresionToolStripMenuItem;
        private ToolStripMenuItem medianToolStripMenuItem;
        private ToolStripMenuItem modesToolStripMenuItem;
        private ToolStripMenuItem standardDeviationToolStripMenuItem;
        private ToolStripMenuItem varianceToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
        private ToolStripMenuItem cSVToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem1;
        private ToolStripMenuItem cSVToolStripMenuItem1;
    }
}

