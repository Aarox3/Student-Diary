﻿
namespace StudentsDiary
{
    partial class AddEditStudent
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
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbSurname = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbMath = new System.Windows.Forms.Label();
            this.tbMath = new System.Windows.Forms.TextBox();
            this.lbTech = new System.Windows.Forms.Label();
            this.tbtech = new System.Windows.Forms.TextBox();
            this.lbPhysic = new System.Windows.Forms.Label();
            this.tbPhysic = new System.Windows.Forms.TextBox();
            this.lbPolish = new System.Windows.Forms.Label();
            this.tbPolish = new System.Windows.Forms.TextBox();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.tbLanguage = new System.Windows.Forms.TextBox();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(140, 12);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(322, 20);
            this.tbId.TabIndex = 0;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(19, 19);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(53, 13);
            this.lbId.TabIndex = 1;
            this.lbId.Text = "Id ucznia:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(19, 45);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 13);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Imię:";
            this.lbName.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(140, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(322, 20);
            this.tbName.TabIndex = 2;
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(19, 71);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(56, 13);
            this.lbSurname.TabIndex = 5;
            this.lbSurname.Text = "Nazwisko:";
            this.lbSurname.Click += new System.EventHandler(this.lbSurname_Click);
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(140, 64);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(322, 20);
            this.tbSurname.TabIndex = 4;
            // 
            // lbMath
            // 
            this.lbMath.AutoSize = true;
            this.lbMath.Location = new System.Drawing.Point(19, 94);
            this.lbMath.Name = "lbMath";
            this.lbMath.Size = new System.Drawing.Size(68, 13);
            this.lbMath.TabIndex = 7;
            this.lbMath.Text = "Matematyka:";
            // 
            // tbMath
            // 
            this.tbMath.Location = new System.Drawing.Point(140, 91);
            this.tbMath.Name = "tbMath";
            this.tbMath.Size = new System.Drawing.Size(322, 20);
            this.tbMath.TabIndex = 6;
            // 
            // lbTech
            // 
            this.lbTech.AutoSize = true;
            this.lbTech.Location = new System.Drawing.Point(18, 120);
            this.lbTech.Name = "lbTech";
            this.lbTech.Size = new System.Drawing.Size(69, 13);
            this.lbTech.TabIndex = 9;
            this.lbTech.Text = "Technologia:";
            // 
            // tbtech
            // 
            this.tbtech.Location = new System.Drawing.Point(140, 117);
            this.tbtech.Name = "tbtech";
            this.tbtech.Size = new System.Drawing.Size(322, 20);
            this.tbtech.TabIndex = 8;
            // 
            // lbPhysic
            // 
            this.lbPhysic.AutoSize = true;
            this.lbPhysic.Location = new System.Drawing.Point(21, 146);
            this.lbPhysic.Name = "lbPhysic";
            this.lbPhysic.Size = new System.Drawing.Size(40, 13);
            this.lbPhysic.TabIndex = 11;
            this.lbPhysic.Text = "Fizyka:";
            this.lbPhysic.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbPhysic
            // 
            this.tbPhysic.Location = new System.Drawing.Point(140, 143);
            this.tbPhysic.Name = "tbPhysic";
            this.tbPhysic.Size = new System.Drawing.Size(322, 20);
            this.tbPhysic.TabIndex = 10;
            // 
            // lbPolish
            // 
            this.lbPolish.AutoSize = true;
            this.lbPolish.Location = new System.Drawing.Point(19, 169);
            this.lbPolish.Name = "lbPolish";
            this.lbPolish.Size = new System.Drawing.Size(64, 13);
            this.lbPolish.TabIndex = 13;
            this.lbPolish.Text = "Język polski";
            // 
            // tbPolish
            // 
            this.tbPolish.Location = new System.Drawing.Point(140, 169);
            this.tbPolish.Name = "tbPolish";
            this.tbPolish.Size = new System.Drawing.Size(322, 20);
            this.tbPolish.TabIndex = 12;
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Location = new System.Drawing.Point(21, 195);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(63, 13);
            this.lbLanguage.TabIndex = 15;
            this.lbLanguage.Text = "Język obcy:";
            // 
            // tbLanguage
            // 
            this.tbLanguage.Location = new System.Drawing.Point(140, 195);
            this.tbLanguage.Name = "tbLanguage";
            this.tbLanguage.Size = new System.Drawing.Size(322, 20);
            this.tbLanguage.TabIndex = 14;
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(140, 231);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(322, 198);
            this.rtbComments.TabIndex = 16;
            this.rtbComments.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Uwagi:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(387, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 505);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbComments);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.tbLanguage);
            this.Controls.Add(this.lbPolish);
            this.Controls.Add(this.tbPolish);
            this.Controls.Add(this.lbPhysic);
            this.Controls.Add(this.tbPhysic);
            this.Controls.Add(this.lbTech);
            this.Controls.Add(this.tbtech);
            this.Controls.Add(this.lbMath);
            this.Controls.Add(this.tbMath);
            this.Controls.Add(this.lbSurname);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.tbId);
            this.Name = "lbComments";
            this.Text = "AddEditStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbMath;
        private System.Windows.Forms.TextBox tbMath;
        private System.Windows.Forms.Label lbTech;
        private System.Windows.Forms.TextBox tbtech;
        private System.Windows.Forms.Label lbPhysic;
        private System.Windows.Forms.TextBox tbPhysic;
        private System.Windows.Forms.Label lbPolish;
        private System.Windows.Forms.TextBox tbPolish;
        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.TextBox tbLanguage;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}