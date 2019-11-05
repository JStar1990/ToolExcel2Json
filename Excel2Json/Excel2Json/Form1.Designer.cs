namespace Excel2Json
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.list_configs = new System.Windows.Forms.CheckedListBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_on = new System.Windows.Forms.Button();
            this.button_off = new System.Windows.Forms.Button();
            this.main_config = new System.Windows.Forms.Label();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.out_config_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.out_script_url = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suffix_ts = new System.Windows.Forms.CheckBox();
            this.suffix_cs = new System.Windows.Forms.CheckBox();
            this.is_unity = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // list_configs
            // 
            this.list_configs.FormattingEnabled = true;
            this.list_configs.Location = new System.Drawing.Point(12, 37);
            this.list_configs.Name = "list_configs";
            this.list_configs.Size = new System.Drawing.Size(294, 404);
            this.list_configs.TabIndex = 0;
            this.list_configs.ThreeDCheckBoxes = true;
            this.list_configs.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(350, 418);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "开始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.onClickStart);
            // 
            // button_on
            // 
            this.button_on.Location = new System.Drawing.Point(312, 360);
            this.button_on.Name = "button_on";
            this.button_on.Size = new System.Drawing.Size(66, 23);
            this.button_on.TabIndex = 2;
            this.button_on.Text = "全选";
            this.button_on.UseVisualStyleBackColor = true;
            this.button_on.Click += new System.EventHandler(this.onClickOn);
            // 
            // button_off
            // 
            this.button_off.Location = new System.Drawing.Point(394, 360);
            this.button_off.Name = "button_off";
            this.button_off.Size = new System.Drawing.Size(66, 23);
            this.button_off.TabIndex = 3;
            this.button_off.TabStop = false;
            this.button_off.Text = "反选";
            this.button_off.UseVisualStyleBackColor = true;
            this.button_off.Click += new System.EventHandler(this.onClickOff);
            // 
            // main_config
            // 
            this.main_config.AutoSize = true;
            this.main_config.Location = new System.Drawing.Point(12, 9);
            this.main_config.Name = "main_config";
            this.main_config.Size = new System.Drawing.Size(41, 12);
            this.main_config.TabIndex = 4;
            this.main_config.Text = "label1";
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(312, 389);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(148, 23);
            this.progress_bar.TabIndex = 5;
            // 
            // out_config_url
            // 
            this.out_config_url.Location = new System.Drawing.Point(312, 52);
            this.out_config_url.Name = "out_config_url";
            this.out_config_url.Size = new System.Drawing.Size(148, 21);
            this.out_config_url.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "配置文件输出目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "脚本文件输出目录";
            // 
            // out_script_url
            // 
            this.out_script_url.Location = new System.Drawing.Point(312, 127);
            this.out_script_url.Name = "out_script_url";
            this.out_script_url.Size = new System.Drawing.Size(148, 21);
            this.out_script_url.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "脚本文件输出格式";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // suffix_ts
            // 
            this.suffix_ts.AutoSize = true;
            this.suffix_ts.Location = new System.Drawing.Point(314, 179);
            this.suffix_ts.Name = "suffix_ts";
            this.suffix_ts.Size = new System.Drawing.Size(114, 16);
            this.suffix_ts.TabIndex = 12;
            this.suffix_ts.Text = ".ts(TypeScript)";
            this.suffix_ts.UseVisualStyleBackColor = true;
            // 
            // suffix_cs
            // 
            this.suffix_cs.AutoSize = true;
            this.suffix_cs.Location = new System.Drawing.Point(314, 201);
            this.suffix_cs.Name = "suffix_cs";
            this.suffix_cs.Size = new System.Drawing.Size(114, 16);
            this.suffix_cs.TabIndex = 13;
            this.suffix_cs.Text = ".cs(C# Unity3D)";
            this.suffix_cs.UseVisualStyleBackColor = true;
            // 
            // is_unity
            // 
            this.is_unity.AutoSize = true;
            this.is_unity.Location = new System.Drawing.Point(314, 79);
            this.is_unity.Name = "is_unity";
            this.is_unity.Size = new System.Drawing.Size(66, 16);
            this.is_unity.TabIndex = 14;
            this.is_unity.Text = "Unity3D";
            this.is_unity.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 450);
            this.Controls.Add(this.is_unity);
            this.Controls.Add(this.suffix_cs);
            this.Controls.Add(this.suffix_ts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.out_script_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.out_config_url);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.main_config);
            this.Controls.Add(this.button_off);
            this.Controls.Add(this.button_on);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.list_configs);
            this.Name = "Form1";
            this.Text = "Excel2Json";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox list_configs;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_on;
        private System.Windows.Forms.Button button_off;
        private System.Windows.Forms.Label main_config;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.TextBox out_config_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox out_script_url;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox suffix_ts;
        private System.Windows.Forms.CheckBox suffix_cs;
        private System.Windows.Forms.CheckBox is_unity;
    }
}

