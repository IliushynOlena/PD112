namespace _09_TreeViewListView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dirTree = new System.Windows.Forms.TreeView();
            this.fileList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // dirTree
            // 
            this.dirTree.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dirTree.Location = new System.Drawing.Point(12, 12);
            this.dirTree.Name = "dirTree";
            this.dirTree.Size = new System.Drawing.Size(893, 913);
            this.dirTree.TabIndex = 0;
            this.dirTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.dirTree_AfterCollapse);
            this.dirTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.dirTree_AfterExpand);
            this.dirTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dirTree_AfterSelect);
            // 
            // fileList
            // 
            this.fileList.HideSelection = false;
            this.fileList.Location = new System.Drawing.Point(929, 16);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(932, 909);
            this.fileList.TabIndex = 1;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Tile;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1873, 937);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.dirTree);
            this.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView dirTree;
        private System.Windows.Forms.ListView fileList;
    }
}
