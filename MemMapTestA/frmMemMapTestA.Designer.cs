namespace MemMapTestA
{
    partial class frmMemMapTestA
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
            this.lblData = new System.Windows.Forms.Label();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            this.pbSprite2 = new System.Windows.Forms.PictureBox();
            this.lblData2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblData.Location = new System.Drawing.Point(12, 38);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(109, 57);
            this.lblData.TabIndex = 2;
            // 
            // pbSprite
            // 
            this.pbSprite.Location = new System.Drawing.Point(12, 98);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(100, 100);
            this.pbSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSprite.TabIndex = 5;
            this.pbSprite.TabStop = false;
            this.pbSprite.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragDrop);
            this.pbSprite.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragEnter);
            this.pbSprite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSprite_MouseDown);
            // 
            // pbSprite2
            // 
            this.pbSprite2.Location = new System.Drawing.Point(127, 98);
            this.pbSprite2.Name = "pbSprite2";
            this.pbSprite2.Size = new System.Drawing.Size(100, 100);
            this.pbSprite2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSprite2.TabIndex = 6;
            this.pbSprite2.TabStop = false;
            this.pbSprite2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragDrop);
            this.pbSprite2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragEnter);
            this.pbSprite2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSprite_MouseDown);
            // 
            // lblData2
            // 
            this.lblData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblData2.Location = new System.Drawing.Point(127, 38);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(109, 57);
            this.lblData2.TabIndex = 7;
            // 
            // frmMemMapTestA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblData2);
            this.Controls.Add(this.pbSprite2);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.lblData);
            this.Name = "frmMemMapTestA";
            this.Text = "frmMemMapTestA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemMapTestA_FormClosing);
            this.Load += new System.EventHandler(this.frmMemMapTestB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.PictureBox pbSprite;
        private System.Windows.Forms.PictureBox pbSprite2;
        private System.Windows.Forms.Label lblData2;
    }
}

