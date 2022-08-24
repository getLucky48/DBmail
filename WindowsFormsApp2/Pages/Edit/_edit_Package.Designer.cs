
namespace WindowsFormsApp2.Pages.Edit
{
    partial class _edit_Package
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
            this.tBoxSender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxStartPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxRecipient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxFinishPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxPay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBoxStartPointIdx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBoxFinishPointIdx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboTypePackage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInventoryDelete = new System.Windows.Forms.Button();
            this.btnInventoryEdit = new System.Windows.Forms.Button();
            this.btnInventoryCreate = new System.Windows.Forms.Button();
            this.cBoxInventory = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridInventory = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxSender
            // 
            this.tBoxSender.Location = new System.Drawing.Point(6, 51);
            this.tBoxSender.Name = "tBoxSender";
            this.tBoxSender.Size = new System.Drawing.Size(251, 20);
            this.tBoxSender.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отправитель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Адрес отправления";
            // 
            // tBoxStartPoint
            // 
            this.tBoxStartPoint.Location = new System.Drawing.Point(6, 92);
            this.tBoxStartPoint.Name = "tBoxStartPoint";
            this.tBoxStartPoint.Size = new System.Drawing.Size(165, 20);
            this.tBoxStartPoint.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Получатель";
            // 
            // tBoxRecipient
            // 
            this.tBoxRecipient.Location = new System.Drawing.Point(6, 139);
            this.tBoxRecipient.Name = "tBoxRecipient";
            this.tBoxRecipient.Size = new System.Drawing.Size(251, 20);
            this.tBoxRecipient.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Адрес получения";
            // 
            // tBoxFinishPoint
            // 
            this.tBoxFinishPoint.Location = new System.Drawing.Point(6, 183);
            this.tBoxFinishPoint.Name = "tBoxFinishPoint";
            this.tBoxFinishPoint.Size = new System.Drawing.Size(165, 20);
            this.tBoxFinishPoint.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вес";
            // 
            // tBoxWeight
            // 
            this.tBoxWeight.Location = new System.Drawing.Point(6, 225);
            this.tBoxWeight.Name = "tBoxWeight";
            this.tBoxWeight.Size = new System.Drawing.Size(251, 20);
            this.tBoxWeight.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сумма описи (при наличии)";
            // 
            // tBoxPay
            // 
            this.tBoxPay.Location = new System.Drawing.Point(6, 272);
            this.tBoxPay.Name = "tBoxPay";
            this.tBoxPay.Size = new System.Drawing.Size(251, 20);
            this.tBoxPay.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Индекс";
            // 
            // tBoxStartPointIdx
            // 
            this.tBoxStartPointIdx.Location = new System.Drawing.Point(183, 92);
            this.tBoxStartPointIdx.Name = "tBoxStartPointIdx";
            this.tBoxStartPointIdx.Size = new System.Drawing.Size(74, 20);
            this.tBoxStartPointIdx.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Индекс";
            // 
            // tBoxFinishPointIdx
            // 
            this.tBoxFinishPointIdx.Location = new System.Drawing.Point(180, 183);
            this.tBoxFinishPointIdx.Name = "tBoxFinishPointIdx";
            this.tBoxFinishPointIdx.Size = new System.Drawing.Size(77, 20);
            this.tBoxFinishPointIdx.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboTypePackage
            // 
            this.comboTypePackage.FormattingEnabled = true;
            this.comboTypePackage.Location = new System.Drawing.Point(6, 317);
            this.comboTypePackage.Name = "comboTypePackage";
            this.comboTypePackage.Size = new System.Drawing.Size(121, 21);
            this.comboTypePackage.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Тип посылки";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxSender);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboTypePackage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tBoxStartPoint);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tBoxRecipient);
            this.groupBox1.Controls.Add(this.tBoxFinishPointIdx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tBoxFinishPoint);
            this.groupBox1.Controls.Add(this.tBoxStartPointIdx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tBoxWeight);
            this.groupBox1.Controls.Add(this.tBoxPay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 352);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры посылки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Лист №";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInventoryDelete);
            this.groupBox2.Controls.Add(this.btnInventoryEdit);
            this.groupBox2.Controls.Add(this.btnInventoryCreate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cBoxInventory);
            this.groupBox2.Location = new System.Drawing.Point(12, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 114);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Опись";
            // 
            // btnInventoryDelete
            // 
            this.btnInventoryDelete.Location = new System.Drawing.Point(189, 78);
            this.btnInventoryDelete.Name = "btnInventoryDelete";
            this.btnInventoryDelete.Size = new System.Drawing.Size(68, 23);
            this.btnInventoryDelete.TabIndex = 23;
            this.btnInventoryDelete.Text = "Удалить";
            this.btnInventoryDelete.UseVisualStyleBackColor = true;
            this.btnInventoryDelete.Click += new System.EventHandler(this.btnInventoryDelete_Click);
            // 
            // btnInventoryEdit
            // 
            this.btnInventoryEdit.Location = new System.Drawing.Point(85, 78);
            this.btnInventoryEdit.Name = "btnInventoryEdit";
            this.btnInventoryEdit.Size = new System.Drawing.Size(98, 23);
            this.btnInventoryEdit.TabIndex = 22;
            this.btnInventoryEdit.Text = "Редактировать";
            this.btnInventoryEdit.UseVisualStyleBackColor = true;
            this.btnInventoryEdit.Click += new System.EventHandler(this.btnInventoryEdit_Click);
            // 
            // btnInventoryCreate
            // 
            this.btnInventoryCreate.Location = new System.Drawing.Point(6, 78);
            this.btnInventoryCreate.Name = "btnInventoryCreate";
            this.btnInventoryCreate.Size = new System.Drawing.Size(73, 23);
            this.btnInventoryCreate.TabIndex = 21;
            this.btnInventoryCreate.Text = "Добавить";
            this.btnInventoryCreate.UseVisualStyleBackColor = true;
            this.btnInventoryCreate.Click += new System.EventHandler(this.btnInventoryCreate_Click);
            // 
            // cBoxInventory
            // 
            this.cBoxInventory.FormattingEnabled = true;
            this.cBoxInventory.Location = new System.Drawing.Point(6, 42);
            this.cBoxInventory.Name = "cBoxInventory";
            this.cBoxInventory.Size = new System.Drawing.Size(251, 21);
            this.cBoxInventory.TabIndex = 0;
            this.cBoxInventory.SelectedIndexChanged += new System.EventHandler(this.cBoxInventory_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridInventory);
            this.groupBox3.Location = new System.Drawing.Point(299, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(547, 433);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Содержимое описи";
            // 
            // gridInventory
            // 
            this.gridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventory.Location = new System.Drawing.Point(8, 38);
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.Size = new System.Drawing.Size(528, 389);
            this.gridInventory.TabIndex = 0;
            // 
            // _edit_Package
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "_edit_Package";
            this.Text = "Редактирование";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxSender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxStartPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxRecipient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxFinishPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBoxWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxPay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBoxStartPointIdx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBoxFinishPointIdx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboTypePackage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxInventory;
        private System.Windows.Forms.Button btnInventoryCreate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInventoryDelete;
        private System.Windows.Forms.Button btnInventoryEdit;
        private System.Windows.Forms.DataGridView gridInventory;
    }
}