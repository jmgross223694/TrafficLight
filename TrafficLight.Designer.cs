namespace TrafficLight
{
    partial class TrafficLight
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficLight));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peligroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precauciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modoAutomáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peligroToolStripMenuItem,
            this.precauciónToolStripMenuItem,
            this.modoNormalToolStripMenuItem,
            this.modoAutomáticoToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.accionesToolStripMenuItem.Text = "Modo de operación";
            // 
            // peligroToolStripMenuItem
            // 
            this.peligroToolStripMenuItem.Name = "peligroToolStripMenuItem";
            this.peligroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.peligroToolStripMenuItem.Text = "Modo peligro";
            this.peligroToolStripMenuItem.Click += new System.EventHandler(this.peligroToolStripMenuItem_Click);
            // 
            // precauciónToolStripMenuItem
            // 
            this.precauciónToolStripMenuItem.Name = "precauciónToolStripMenuItem";
            this.precauciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.precauciónToolStripMenuItem.Text = "Modo precaución";
            this.precauciónToolStripMenuItem.Click += new System.EventHandler(this.precaucionToolStripMenuItem_Click);
            // 
            // modoNormalToolStripMenuItem
            // 
            this.modoNormalToolStripMenuItem.Name = "modoNormalToolStripMenuItem";
            this.modoNormalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modoNormalToolStripMenuItem.Text = "Modo normal";
            this.modoNormalToolStripMenuItem.Click += new System.EventHandler(this.modoNormalToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // modoAutomáticoToolStripMenuItem
            // 
            this.modoAutomáticoToolStripMenuItem.Name = "modoAutomáticoToolStripMenuItem";
            this.modoAutomáticoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modoAutomáticoToolStripMenuItem.Text = "Modo automático";
            this.modoAutomáticoToolStripMenuItem.Click += new System.EventHandler(this.modoAutomáticoToolStripMenuItem_Click);
            // 
            // TrafficLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TrafficLight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrafficLight";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peligroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precauciónToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modoNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoAutomáticoToolStripMenuItem;
    }
}

