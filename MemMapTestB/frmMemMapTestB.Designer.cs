namespace MemMapTestB
{
    partial class frmMemMapTestB
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
            this.btnReceive = new System.Windows.Forms.Button();
            this.pbSprite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblData.Location = new System.Drawing.Point(12, 38);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(109, 57);
            this.lblData.TabIndex = 1;
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(12, 12);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 3;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // pbSprite
            // 
            this.pbSprite.Location = new System.Drawing.Point(12, 98);
            this.pbSprite.Name = "pbSprite";
            this.pbSprite.Size = new System.Drawing.Size(100, 100);
            this.pbSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSprite.TabIndex = 4;
            this.pbSprite.TabStop = false;
            this.pbSprite.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragDrop);
            this.pbSprite.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbSprite_DragEnter);
            this.pbSprite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSprite_MouseDown);
            // 
            // frmMemMapTestB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pbSprite);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.lblData);
            this.Name = "frmMemMapTestB";
            this.Text = "frmMemMapTestB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemMapTestB_FormClosing);
            this.Load += new System.EventHandler(this.frmMemMapTestA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.PictureBox pbSprite;
    }
}

