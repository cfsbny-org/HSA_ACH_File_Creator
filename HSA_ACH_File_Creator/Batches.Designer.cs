namespace Cfs.Custom.Software
{
    partial class Batches
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batches));
            this.aCHFileBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.aCHFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createAchFile_toolstripButton = new System.Windows.Forms.ToolStripButton();
            this.closeBatch_toolstripButton = new System.Windows.Forms.ToolStripButton();
            this.aCHFileDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveAchFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printBatchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.previewBatchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingNavigator)).BeginInit();
            this.aCHFileBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // aCHFileBindingNavigator
            // 
            this.aCHFileBindingNavigator.AddNewItem = null;
            this.aCHFileBindingNavigator.BindingSource = this.aCHFileBindingSource;
            this.aCHFileBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.aCHFileBindingNavigator.DeleteItem = null;
            this.aCHFileBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.createAchFile_toolstripButton,
            this.printBatchToolStripButton,
            this.previewBatchToolStripButton,
            this.closeBatch_toolstripButton});
            this.aCHFileBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.aCHFileBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.aCHFileBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.aCHFileBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.aCHFileBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.aCHFileBindingNavigator.Name = "aCHFileBindingNavigator";
            this.aCHFileBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.aCHFileBindingNavigator.Size = new System.Drawing.Size(660, 25);
            this.aCHFileBindingNavigator.TabIndex = 0;
            this.aCHFileBindingNavigator.Text = "bindingNavigator1";
            // 
            // aCHFileBindingSource
            // 
            this.aCHFileBindingSource.DataSource = typeof(Cfs.Custom.Software.Data.ACHFile);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // createAchFile_toolstripButton
            // 
            this.createAchFile_toolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createAchFile_toolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("createAchFile_toolstripButton.Image")));
            this.createAchFile_toolstripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.createAchFile_toolstripButton.Name = "createAchFile_toolstripButton";
            this.createAchFile_toolstripButton.Size = new System.Drawing.Size(23, 22);
            this.createAchFile_toolstripButton.Text = "Create ACH File from Batch";
            this.createAchFile_toolstripButton.Click += new System.EventHandler(this.createAchFile_toolstripButton_Click);
            // 
            // closeBatch_toolstripButton
            // 
            this.closeBatch_toolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeBatch_toolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("closeBatch_toolstripButton.Image")));
            this.closeBatch_toolstripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.closeBatch_toolstripButton.Name = "closeBatch_toolstripButton";
            this.closeBatch_toolstripButton.Size = new System.Drawing.Size(23, 22);
            this.closeBatch_toolstripButton.Text = "Close batch.";
            // 
            // aCHFileDataGridView
            // 
            this.aCHFileDataGridView.AllowUserToAddRows = false;
            this.aCHFileDataGridView.AllowUserToDeleteRows = false;
            this.aCHFileDataGridView.AutoGenerateColumns = false;
            this.aCHFileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aCHFileDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.aCHFileDataGridView.DataSource = this.aCHFileBindingSource;
            this.aCHFileDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aCHFileDataGridView.Location = new System.Drawing.Point(0, 25);
            this.aCHFileDataGridView.MultiSelect = false;
            this.aCHFileDataGridView.Name = "aCHFileDataGridView";
            this.aCHFileDataGridView.ReadOnly = true;
            this.aCHFileDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aCHFileDataGridView.Size = new System.Drawing.Size(660, 338);
            this.aCHFileDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "achBatchId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Batch ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "achBatchCreated";
            this.dataGridViewTextBoxColumn2.HeaderText = "Batch Created";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "achBatchCreatedBy";
            this.dataGridViewTextBoxColumn3.HeaderText = "Created By";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "achCheckDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Check Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "achCompany";
            this.dataGridViewTextBoxColumn5.HeaderText = "Company";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "achTotalAmount";
            this.dataGridViewTextBoxColumn6.HeaderText = "achTotalAmount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "achFileStatus";
            this.dataGridViewTextBoxColumn7.HeaderText = "achFileStatus";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // saveAchFileDialog
            // 
            this.saveAchFileDialog.DefaultExt = "ach";
            this.saveAchFileDialog.Filter = "ACH Files (*.ach)|*.ach|All Files (*.*)|*.*";
            // 
            // printBatchToolStripButton
            // 
            this.printBatchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printBatchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printBatchToolStripButton.Image")));
            this.printBatchToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printBatchToolStripButton.Name = "printBatchToolStripButton";
            this.printBatchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printBatchToolStripButton.Text = "Print Batch";
            this.printBatchToolStripButton.Click += new System.EventHandler(this.printBatchToolStripButton_Click);
            // 
            // previewBatchToolStripButton
            // 
            this.previewBatchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previewBatchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("previewBatchToolStripButton.Image")));
            this.previewBatchToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.previewBatchToolStripButton.Name = "previewBatchToolStripButton";
            this.previewBatchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.previewBatchToolStripButton.Text = "Preview Batch";
            this.previewBatchToolStripButton.Click += new System.EventHandler(this.previewBatchToolStripButton_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // Batches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 363);
            this.Controls.Add(this.aCHFileDataGridView);
            this.Controls.Add(this.aCHFileBindingNavigator);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Batches";
            this.Text = "Open Batches";
            this.Load += new System.EventHandler(this.Batches_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingNavigator)).EndInit();
            this.aCHFileBindingNavigator.ResumeLayout(false);
            this.aCHFileBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource aCHFileBindingSource;
        private System.Windows.Forms.BindingNavigator aCHFileBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView aCHFileDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripButton createAchFile_toolstripButton;
        private System.Windows.Forms.ToolStripButton closeBatch_toolstripButton;
        private System.Windows.Forms.SaveFileDialog saveAchFileDialog;
        private System.Windows.Forms.ToolStripButton printBatchToolStripButton;
        private System.Windows.Forms.ToolStripButton previewBatchToolStripButton;
        private System.Windows.Forms.PrintDialog printDialog;

    }
}