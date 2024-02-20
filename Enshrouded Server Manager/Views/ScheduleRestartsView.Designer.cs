namespace Enshrouded_Server_Manager.Views;

partial class ScheduleRestartsView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        radOneTime = new RadioButton();
        radHourly = new RadioButton();
        radDaily = new RadioButton();
        radWeekly = new RadioButton();
        radMonthly = new RadioButton();
        lblStartDateTime = new Label();
        dtpStartDate = new DateTimePicker();
        lblRecur = new Label();
        nudRecur = new NumericUpDown();
        lblRecurUnit = new Label();
        chkSunday = new CheckBox();
        chkMonday = new CheckBox();
        chkTuesday = new CheckBox();
        chkWednesday = new CheckBox();
        chkSaturday = new CheckBox();
        chkFriday = new CheckBox();
        chkThursday = new CheckBox();
        btnClearAll = new Button();
        btnApplySettings = new Button();
        dtpStartTime = new DateTimePicker();
        lblServerMustBeStoppedMessage = new Label();
        chkEnableScheduledRestarts = new CheckBox();
        lblTimeLeft = new Label();
        chkStartWithServer = new CheckBox();
        lblOr = new Label();
        ((System.ComponentModel.ISupportInitialize)nudRecur).BeginInit();
        SuspendLayout();
        // 
        // radOneTime
        // 
        radOneTime.AutoSize = true;
        radOneTime.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
        radOneTime.Location = new Point(32, 45);
        radOneTime.Name = "radOneTime";
        radOneTime.Size = new Size(71, 17);
        radOneTime.TabIndex = 0;
        radOneTime.TabStop = true;
        radOneTime.Text = "One Time";
        radOneTime.UseVisualStyleBackColor = true;
        // 
        // radHourly
        // 
        radHourly.AutoSize = true;
        radHourly.Location = new Point(32, 70);
        radHourly.Name = "radHourly";
        radHourly.Size = new Size(61, 19);
        radHourly.TabIndex = 1;
        radHourly.TabStop = true;
        radHourly.Text = "Hourly";
        radHourly.UseVisualStyleBackColor = true;
        // 
        // radDaily
        // 
        radDaily.AutoSize = true;
        radDaily.Location = new Point(32, 95);
        radDaily.Name = "radDaily";
        radDaily.Size = new Size(51, 19);
        radDaily.TabIndex = 2;
        radDaily.TabStop = true;
        radDaily.Text = "Daily";
        radDaily.UseVisualStyleBackColor = true;
        // 
        // radWeekly
        // 
        radWeekly.AutoSize = true;
        radWeekly.Location = new Point(32, 120);
        radWeekly.Name = "radWeekly";
        radWeekly.Size = new Size(63, 19);
        radWeekly.TabIndex = 3;
        radWeekly.TabStop = true;
        radWeekly.Text = "Weekly";
        radWeekly.UseVisualStyleBackColor = true;
        // 
        // radMonthly
        // 
        radMonthly.AutoSize = true;
        radMonthly.Location = new Point(32, 145);
        radMonthly.Name = "radMonthly";
        radMonthly.Size = new Size(70, 19);
        radMonthly.TabIndex = 4;
        radMonthly.TabStop = true;
        radMonthly.Text = "Monthly";
        radMonthly.UseVisualStyleBackColor = true;
        // 
        // lblStartDateTime
        // 
        lblStartDateTime.AutoSize = true;
        lblStartDateTime.Location = new Point(205, 24);
        lblStartDateTime.Name = "lblStartDateTime";
        lblStartDateTime.Size = new Size(127, 15);
        lblStartDateTime.TabIndex = 43;
        lblStartDateTime.Text = "Start at Specified Time:";
        // 
        // dtpStartDate
        // 
        dtpStartDate.CalendarFont = new Font("Malgun Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
        dtpStartDate.CalendarForeColor = SystemColors.ControlLight;
        dtpStartDate.CalendarMonthBackground = Color.FromArgb(0, 0, 18);
        dtpStartDate.CalendarTitleBackColor = Color.FromArgb(0, 255, 185);
        dtpStartDate.CalendarTitleForeColor = SystemColors.ButtonHighlight;
        dtpStartDate.CustomFormat = "";
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(205, 42);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 5;
        // 
        // lblRecur
        // 
        lblRecur.AutoSize = true;
        lblRecur.Location = new Point(205, 145);
        lblRecur.Name = "lblRecur";
        lblRecur.Size = new Size(71, 15);
        lblRecur.TabIndex = 46;
        lblRecur.Text = "Recur every:";
        // 
        // nudRecur
        // 
        nudRecur.BackColor = Color.FromArgb(6, 6, 48);
        nudRecur.ForeColor = SystemColors.Window;
        nudRecur.Location = new Point(285, 143);
        nudRecur.Name = "nudRecur";
        nudRecur.Size = new Size(39, 23);
        nudRecur.TabIndex = 7;
        // 
        // lblRecurUnit
        // 
        lblRecurUnit.AutoSize = true;
        lblRecurUnit.Location = new Point(334, 145);
        lblRecurUnit.Name = "lblRecurUnit";
        lblRecurUnit.Size = new Size(39, 15);
        lblRecurUnit.TabIndex = 48;
        lblRecurUnit.Text = "Hours";
        // 
        // chkSunday
        // 
        chkSunday.AutoSize = true;
        chkSunday.Location = new Point(55, 193);
        chkSunday.Name = "chkSunday";
        chkSunday.Size = new Size(65, 19);
        chkSunday.TabIndex = 8;
        chkSunday.Text = "Sunday";
        chkSunday.UseVisualStyleBackColor = true;
        // 
        // chkMonday
        // 
        chkMonday.AutoSize = true;
        chkMonday.Location = new Point(144, 193);
        chkMonday.Name = "chkMonday";
        chkMonday.Size = new Size(70, 19);
        chkMonday.TabIndex = 9;
        chkMonday.Text = "Monday";
        chkMonday.UseVisualStyleBackColor = true;
        // 
        // chkTuesday
        // 
        chkTuesday.AutoSize = true;
        chkTuesday.Location = new Point(233, 193);
        chkTuesday.Name = "chkTuesday";
        chkTuesday.Size = new Size(69, 19);
        chkTuesday.TabIndex = 10;
        chkTuesday.Text = "Tuesday";
        chkTuesday.UseVisualStyleBackColor = true;
        // 
        // chkWednesday
        // 
        chkWednesday.AutoSize = true;
        chkWednesday.Location = new Point(322, 193);
        chkWednesday.Name = "chkWednesday";
        chkWednesday.Size = new Size(87, 19);
        chkWednesday.TabIndex = 11;
        chkWednesday.Text = "Wednesday";
        chkWednesday.UseVisualStyleBackColor = true;
        // 
        // chkSaturday
        // 
        chkSaturday.AutoSize = true;
        chkSaturday.Location = new Point(233, 228);
        chkSaturday.Name = "chkSaturday";
        chkSaturday.Size = new Size(72, 19);
        chkSaturday.TabIndex = 14;
        chkSaturday.Text = "Saturday";
        chkSaturday.UseVisualStyleBackColor = true;
        // 
        // chkFriday
        // 
        chkFriday.AutoSize = true;
        chkFriday.Location = new Point(144, 228);
        chkFriday.Name = "chkFriday";
        chkFriday.Size = new Size(58, 19);
        chkFriday.TabIndex = 13;
        chkFriday.Text = "Friday";
        chkFriday.UseVisualStyleBackColor = true;
        // 
        // chkThursday
        // 
        chkThursday.AutoSize = true;
        chkThursday.Location = new Point(55, 228);
        chkThursday.Name = "chkThursday";
        chkThursday.Size = new Size(74, 19);
        chkThursday.TabIndex = 12;
        chkThursday.Text = "Thursday";
        chkThursday.UseVisualStyleBackColor = true;
        // 
        // btnClearAll
        // 
        btnClearAll.BackgroundImageLayout = ImageLayout.None;
        btnClearAll.Cursor = Cursors.Hand;
        btnClearAll.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnClearAll.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnClearAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnClearAll.FlatStyle = FlatStyle.Flat;
        btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        btnClearAll.ForeColor = SystemColors.ControlLightLight;
        btnClearAll.Location = new Point(68, 315);
        btnClearAll.Margin = new Padding(0);
        btnClearAll.Name = "btnClearAll";
        btnClearAll.Padding = new Padding(0, 2, 0, 0);
        btnClearAll.Size = new Size(128, 30);
        btnClearAll.TabIndex = 16;
        btnClearAll.Text = "Clear All";
        btnClearAll.UseCompatibleTextRendering = true;
        btnClearAll.UseVisualStyleBackColor = true;
        // 
        // btnApplySettings
        // 
        btnApplySettings.Cursor = Cursors.Hand;
        btnApplySettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnApplySettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnApplySettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnApplySettings.FlatStyle = FlatStyle.Flat;
        btnApplySettings.ForeColor = Color.FromArgb(0, 255, 185);
        btnApplySettings.Location = new Point(263, 315);
        btnApplySettings.Name = "btnApplySettings";
        btnApplySettings.Size = new Size(128, 30);
        btnApplySettings.TabIndex = 15;
        btnApplySettings.Text = "Save Settings";
        btnApplySettings.UseCompatibleTextRendering = true;
        btnApplySettings.UseVisualStyleBackColor = true;
        btnApplySettings.EnabledChanged += btnApplySettings_EnabledChanged;
        // 
        // dtpStartTime
        // 
        dtpStartTime.CalendarFont = new Font("Malgun Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
        dtpStartTime.CalendarForeColor = SystemColors.ButtonHighlight;
        dtpStartTime.CalendarMonthBackground = Color.FromArgb(0, 0, 18);
        dtpStartTime.CalendarTitleBackColor = Color.FromArgb(0, 255, 185);
        dtpStartTime.CalendarTitleForeColor = SystemColors.ButtonHighlight;
        dtpStartTime.CustomFormat = "";
        dtpStartTime.Format = DateTimePickerFormat.Time;
        dtpStartTime.Location = new Point(325, 42);
        dtpStartTime.Name = "dtpStartTime";
        dtpStartTime.ShowUpDown = true;
        dtpStartTime.Size = new Size(100, 23);
        dtpStartTime.TabIndex = 6;
        // 
        // lblServerMustBeStoppedMessage
        // 
        lblServerMustBeStoppedMessage.AutoSize = true;
        lblServerMustBeStoppedMessage.ForeColor = SystemColors.Info;
        lblServerMustBeStoppedMessage.Location = new Point(91, 355);
        lblServerMustBeStoppedMessage.Name = "lblServerMustBeStoppedMessage";
        lblServerMustBeStoppedMessage.Size = new Size(7, 30);
        lblServerMustBeStoppedMessage.TabIndex = 59;
        lblServerMustBeStoppedMessage.Text = "\r\n\r\n";
        lblServerMustBeStoppedMessage.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // chkEnableScheduledRestarts
        // 
        chkEnableScheduledRestarts.AutoSize = true;
        chkEnableScheduledRestarts.Location = new Point(148, 265);
        chkEnableScheduledRestarts.Name = "chkEnableScheduledRestarts";
        chkEnableScheduledRestarts.Size = new Size(163, 19);
        chkEnableScheduledRestarts.TabIndex = 60;
        chkEnableScheduledRestarts.Text = "Enable Scheduled Restarts";
        chkEnableScheduledRestarts.UseVisualStyleBackColor = true;
        // 
        // lblTimeLeft
        // 
        lblTimeLeft.AutoSize = true;
        lblTimeLeft.ForeColor = Color.FromArgb(0, 204, 204);
        lblTimeLeft.Location = new Point(32, 15);
        lblTimeLeft.Name = "lblTimeLeft";
        lblTimeLeft.Size = new Size(104, 15);
        lblTimeLeft.TabIndex = 61;
        lblTimeLeft.Text = "Next Restart: 00:00";
        lblTimeLeft.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // chkStartWithServer
        // 
        chkStartWithServer.AutoSize = true;
        chkStartWithServer.Location = new Point(205, 96);
        chkStartWithServer.Name = "chkStartWithServer";
        chkStartWithServer.Size = new Size(183, 19);
        chkStartWithServer.TabIndex = 62;
        chkStartWithServer.Text = " Start Schedule on Server Start";
        chkStartWithServer.UseVisualStyleBackColor = true;
        // 
        // lblOr
        // 
        lblOr.AutoSize = true;
        lblOr.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblOr.ForeColor = SystemColors.Info;
        lblOr.Location = new Point(299, 74);
        lblOr.Name = "lblOr";
        lblOr.Size = new Size(23, 17);
        lblOr.TabIndex = 63;
        lblOr.Text = "Or";
        // 
        // ScheduleRestartsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(chkStartWithServer);
        Controls.Add(lblTimeLeft);
        Controls.Add(chkEnableScheduledRestarts);
        Controls.Add(lblServerMustBeStoppedMessage);
        Controls.Add(btnApplySettings);
        Controls.Add(btnClearAll);
        Controls.Add(chkSaturday);
        Controls.Add(chkFriday);
        Controls.Add(chkThursday);
        Controls.Add(chkWednesday);
        Controls.Add(chkTuesday);
        Controls.Add(chkMonday);
        Controls.Add(chkSunday);
        Controls.Add(lblRecurUnit);
        Controls.Add(nudRecur);
        Controls.Add(lblRecur);
        Controls.Add(dtpStartTime);
        Controls.Add(dtpStartDate);
        Controls.Add(lblOr);
        Controls.Add(lblStartDateTime);
        Controls.Add(radMonthly);
        Controls.Add(radWeekly);
        Controls.Add(radDaily);
        Controls.Add(radHourly);
        Controls.Add(radOneTime);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "ScheduleRestartsView";
        Size = new Size(459, 384);
        ((System.ComponentModel.ISupportInitialize)nudRecur).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RadioButton radOneTime;
    private RadioButton radHourly;
    private RadioButton radDaily;
    private RadioButton radWeekly;
    private RadioButton radMonthly;
    private Label lblStartDateTime;
    private DateTimePicker dtpStartDate;
    private Label lblRecur;
    private NumericUpDown nudRecur;
    private Label lblRecurUnit;
    private CheckBox chkSunday;
    private CheckBox chkMonday;
    private CheckBox chkTuesday;
    private CheckBox chkWednesday;
    private CheckBox chkSaturday;
    private CheckBox chkFriday;
    private CheckBox chkThursday;
    private Button btnClearAll;
    private Button btnApplySettings;
    private DateTimePicker dtpStartTime;
    private Label lblServerMustBeStoppedMessage;
    private CheckBox chkEnableScheduledRestarts;
    private Label lblTimeLeft;
    private CheckBox chkStartWithServer;
    private Label lblOr;
}
