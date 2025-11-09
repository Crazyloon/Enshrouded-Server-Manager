using Enshrouded_Server_Manager.Views.Interfaces;

namespace Enshrouded_Server_Manager;

partial class GameSettingsView : UserControl
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
        btnSaveSettings = new Button();
        lblServerMustBeStoppedMessage = new Label();
        lblPhf = new Label();
        nudPlayerHealthFactor = new NumericUpDown();
        nudPlayerManaFactor = new NumericUpDown();
        lblPmf = new Label();
        nudPlayerStaminaFactor = new NumericUpDown();
        lblPsf = new Label();
        nudPlayerBodyHeatFactor = new NumericUpDown();
        lblPbhf = new Label();
        nudFoodBuffDurationFactor = new NumericUpDown();
        lblFoodBuff = new Label();
        nudFromHungerToStarving = new NumericUpDown();
        label1 = new Label();
        nudShroudTimeFactor = new NumericUpDown();
        lblShroudTimeFactor = new Label();
        nudMiningDamageFactor = new NumericUpDown();
        lblMiningFactor = new Label();
        nudPlantGrowthSpeedFactor = new NumericUpDown();
        lblPlantGrowthFactor = new Label();
        nudResourceDropStackAmountFactor = new NumericUpDown();
        lblResourceDropFactor = new Label();
        nudFactoryProductionSpeedFactor = new NumericUpDown();
        lblFactoryFactor = new Label();
        nudPerkUpgradeRecyclingFactor = new NumericUpDown();
        lblPerkRecycleFactor = new Label();
        nudPerkCostFactor = new NumericUpDown();
        lblWeaponUpgrade = new Label();
        nudExperienceCombatFactor = new NumericUpDown();
        lblCombatExp = new Label();
        nudExperienceMiningFactor = new NumericUpDown();
        lblMiningExp = new Label();
        nudExperienceExplorationQuestsFactor = new NumericUpDown();
        lblQuestExp = new Label();
        nudEnemyDamageFactor = new NumericUpDown();
        lblEnemyDmg = new Label();
        nudEnemyHealthFactor = new NumericUpDown();
        lblEnemyHealth = new Label();
        nudEnemyStaminaFactor = new NumericUpDown();
        lblEnemyStamina = new Label();
        nudEnemyPerceptionRangeFactor = new NumericUpDown();
        lblEnemyPerception = new Label();
        nudThreatBonus = new NumericUpDown();
        lblEnemyAttackRate = new Label();
        nudBossDamageFactor = new NumericUpDown();
        lblBossDmg = new Label();
        nudBossHealthFactor = new NumericUpDown();
        lblBossHealth = new Label();
        nudDayTimeDuration = new NumericUpDown();
        lblDayDuration = new Label();
        nudNightTimeDuration = new NumericUpDown();
        lblNightDuration = new Label();
        cbxTombstoneMode = new ComboBox();
        lblTombstone = new Label();
        chkEnableDurability = new CheckBox();
        chkEnableStarvingDebuff = new CheckBox();
        lblWeatherFreq = new Label();
        cbxWeatherFrequency = new ComboBox();
        lblEnemyAmount = new Label();
        cbxRandomSpawnerAmount = new ComboBox();
        lblEnemyAggro = new Label();
        cbxAggroPoolAmount = new ComboBox();
        lblTamingFailure = new Label();
        cbxTamingStartleRepercussion = new ComboBox();
        chkEnableGliderTurbulences = new CheckBox();
        chkPacifyAllEnemies = new CheckBox();
        lblInMinutes = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        cbxCurseModifier = new ComboBox();
        lblTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)nudPlayerHealthFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerManaFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerStaminaFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerBodyHeatFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFoodBuffDurationFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFromHungerToStarving).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudShroudTimeFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudMiningDamageFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPlantGrowthSpeedFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudResourceDropStackAmountFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFactoryProductionSpeedFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPerkUpgradeRecyclingFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPerkCostFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceCombatFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceMiningFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceExplorationQuestsFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyDamageFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyHealthFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyStaminaFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyPerceptionRangeFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThreatBonus).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBossDamageFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBossHealthFactor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudDayTimeDuration).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudNightTimeDuration).BeginInit();
        SuspendLayout();
        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Cursor = Cursors.Hand;
        btnSaveSettings.FlatAppearance.BorderColor = Color.FromArgb(115, 115, 137);
        btnSaveSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 42, 73);
        btnSaveSettings.FlatStyle = FlatStyle.Flat;
        btnSaveSettings.ForeColor = Color.FromArgb(0, 255, 185);
        btnSaveSettings.Location = new Point(410, 342);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new Size(128, 30);
        btnSaveSettings.TabIndex = 98;
        btnSaveSettings.Text = "Save Settings";
        btnSaveSettings.UseCompatibleTextRendering = true;
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.EnabledChanged += btnSaveSettings_EnabledChanged;
        // 
        // lblServerMustBeStoppedMessage
        // 
        lblServerMustBeStoppedMessage.AutoSize = true;
        lblServerMustBeStoppedMessage.ForeColor = SystemColors.Info;
        lblServerMustBeStoppedMessage.Location = new Point(258, 385);
        lblServerMustBeStoppedMessage.Name = "lblServerMustBeStoppedMessage";
        lblServerMustBeStoppedMessage.Size = new Size(229, 15);
        lblServerMustBeStoppedMessage.TabIndex = 60;
        lblServerMustBeStoppedMessage.Text = "Server must be stopped to update settings\r\n";
        lblServerMustBeStoppedMessage.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblPhf
        // 
        lblPhf.AutoSize = true;
        lblPhf.Location = new Point(74, 39);
        lblPhf.Name = "lblPhf";
        lblPhf.Size = new Size(77, 15);
        lblPhf.TabIndex = 61;
        lblPhf.Text = "Player Health";
        // 
        // nudPlayerHealthFactor
        // 
        nudPlayerHealthFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPlayerHealthFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPlayerHealthFactor.DecimalPlaces = 2;
        nudPlayerHealthFactor.ForeColor = SystemColors.Window;
        nudPlayerHealthFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerHealthFactor.Location = new Point(157, 37);
        nudPlayerHealthFactor.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
        nudPlayerHealthFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerHealthFactor.Name = "nudPlayerHealthFactor";
        nudPlayerHealthFactor.Size = new Size(62, 23);
        nudPlayerHealthFactor.TabIndex = 64;
        nudPlayerHealthFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // nudPlayerManaFactor
        // 
        nudPlayerManaFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPlayerManaFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPlayerManaFactor.DecimalPlaces = 2;
        nudPlayerManaFactor.ForeColor = SystemColors.Window;
        nudPlayerManaFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerManaFactor.Location = new Point(157, 66);
        nudPlayerManaFactor.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
        nudPlayerManaFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerManaFactor.Name = "nudPlayerManaFactor";
        nudPlayerManaFactor.Size = new Size(62, 23);
        nudPlayerManaFactor.TabIndex = 65;
        nudPlayerManaFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblPmf
        // 
        lblPmf.AutoSize = true;
        lblPmf.Location = new Point(79, 68);
        lblPmf.Name = "lblPmf";
        lblPmf.Size = new Size(72, 15);
        lblPmf.TabIndex = 65;
        lblPmf.Text = "Player Mana";
        // 
        // nudPlayerStaminaFactor
        // 
        nudPlayerStaminaFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPlayerStaminaFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPlayerStaminaFactor.DecimalPlaces = 2;
        nudPlayerStaminaFactor.ForeColor = SystemColors.Window;
        nudPlayerStaminaFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerStaminaFactor.Location = new Point(157, 95);
        nudPlayerStaminaFactor.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
        nudPlayerStaminaFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPlayerStaminaFactor.Name = "nudPlayerStaminaFactor";
        nudPlayerStaminaFactor.Size = new Size(62, 23);
        nudPlayerStaminaFactor.TabIndex = 66;
        nudPlayerStaminaFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblPsf
        // 
        lblPsf.AutoSize = true;
        lblPsf.Location = new Point(66, 97);
        lblPsf.Name = "lblPsf";
        lblPsf.Size = new Size(85, 15);
        lblPsf.TabIndex = 67;
        lblPsf.Text = "Player Stamina";
        // 
        // nudPlayerBodyHeatFactor
        // 
        nudPlayerBodyHeatFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPlayerBodyHeatFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPlayerBodyHeatFactor.DecimalPlaces = 2;
        nudPlayerBodyHeatFactor.ForeColor = SystemColors.Window;
        nudPlayerBodyHeatFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudPlayerBodyHeatFactor.Location = new Point(157, 124);
        nudPlayerBodyHeatFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudPlayerBodyHeatFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudPlayerBodyHeatFactor.Name = "nudPlayerBodyHeatFactor";
        nudPlayerBodyHeatFactor.Size = new Size(62, 23);
        nudPlayerBodyHeatFactor.TabIndex = 67;
        nudPlayerBodyHeatFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblPbhf
        // 
        lblPbhf.AutoSize = true;
        lblPbhf.Location = new Point(54, 126);
        lblPbhf.Name = "lblPbhf";
        lblPbhf.Size = new Size(97, 15);
        lblPbhf.TabIndex = 69;
        lblPbhf.Text = "Player Body Heat";
        // 
        // nudFoodBuffDurationFactor
        // 
        nudFoodBuffDurationFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudFoodBuffDurationFactor.BorderStyle = BorderStyle.FixedSingle;
        nudFoodBuffDurationFactor.DecimalPlaces = 2;
        nudFoodBuffDurationFactor.ForeColor = SystemColors.Window;
        nudFoodBuffDurationFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudFoodBuffDurationFactor.Location = new Point(157, 153);
        nudFoodBuffDurationFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudFoodBuffDurationFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudFoodBuffDurationFactor.Name = "nudFoodBuffDurationFactor";
        nudFoodBuffDurationFactor.Size = new Size(62, 23);
        nudFoodBuffDurationFactor.TabIndex = 68;
        nudFoodBuffDurationFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblFoodBuff
        // 
        lblFoodBuff.AutoSize = true;
        lblFoodBuff.Location = new Point(43, 155);
        lblFoodBuff.Name = "lblFoodBuff";
        lblFoodBuff.Size = new Size(108, 15);
        lblFoodBuff.TabIndex = 71;
        lblFoodBuff.Text = "Food Buff Duration";
        // 
        // nudFromHungerToStarving
        // 
        nudFromHungerToStarving.BackColor = Color.FromArgb(6, 6, 48);
        nudFromHungerToStarving.BorderStyle = BorderStyle.FixedSingle;
        nudFromHungerToStarving.DecimalPlaces = 1;
        nudFromHungerToStarving.ForeColor = SystemColors.Window;
        nudFromHungerToStarving.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudFromHungerToStarving.Location = new Point(553, 273);
        nudFromHungerToStarving.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
        nudFromHungerToStarving.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        nudFromHungerToStarving.Name = "nudFromHungerToStarving";
        nudFromHungerToStarving.Size = new Size(62, 23);
        nudFromHungerToStarving.TabIndex = 93;
        nudFromHungerToStarving.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(430, 275);
        label1.Name = "label1";
        label1.Size = new Size(117, 15);
        label1.TabIndex = 73;
        label1.Text = "Hunger to Starvation";
        // 
        // nudShroudTimeFactor
        // 
        nudShroudTimeFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudShroudTimeFactor.BorderStyle = BorderStyle.FixedSingle;
        nudShroudTimeFactor.DecimalPlaces = 2;
        nudShroudTimeFactor.ForeColor = SystemColors.Window;
        nudShroudTimeFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudShroudTimeFactor.Location = new Point(157, 182);
        nudShroudTimeFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudShroudTimeFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudShroudTimeFactor.Name = "nudShroudTimeFactor";
        nudShroudTimeFactor.Size = new Size(62, 23);
        nudShroudTimeFactor.TabIndex = 69;
        nudShroudTimeFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblShroudTimeFactor
        // 
        lblShroudTimeFactor.AutoSize = true;
        lblShroudTimeFactor.Location = new Point(77, 184);
        lblShroudTimeFactor.Name = "lblShroudTimeFactor";
        lblShroudTimeFactor.Size = new Size(75, 15);
        lblShroudTimeFactor.TabIndex = 75;
        lblShroudTimeFactor.Text = "Shroud Time";
        // 
        // nudMiningDamageFactor
        // 
        nudMiningDamageFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudMiningDamageFactor.BorderStyle = BorderStyle.FixedSingle;
        nudMiningDamageFactor.DecimalPlaces = 2;
        nudMiningDamageFactor.ForeColor = SystemColors.Window;
        nudMiningDamageFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudMiningDamageFactor.Location = new Point(157, 211);
        nudMiningDamageFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudMiningDamageFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudMiningDamageFactor.Name = "nudMiningDamageFactor";
        nudMiningDamageFactor.Size = new Size(62, 23);
        nudMiningDamageFactor.TabIndex = 70;
        nudMiningDamageFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblMiningFactor
        // 
        lblMiningFactor.AutoSize = true;
        lblMiningFactor.Location = new Point(59, 213);
        lblMiningFactor.Name = "lblMiningFactor";
        lblMiningFactor.Size = new Size(92, 15);
        lblMiningFactor.TabIndex = 77;
        lblMiningFactor.Text = "Mining Damage";
        // 
        // nudPlantGrowthSpeedFactor
        // 
        nudPlantGrowthSpeedFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPlantGrowthSpeedFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPlantGrowthSpeedFactor.DecimalPlaces = 2;
        nudPlantGrowthSpeedFactor.ForeColor = SystemColors.Window;
        nudPlantGrowthSpeedFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudPlantGrowthSpeedFactor.Location = new Point(157, 240);
        nudPlantGrowthSpeedFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudPlantGrowthSpeedFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudPlantGrowthSpeedFactor.Name = "nudPlantGrowthSpeedFactor";
        nudPlantGrowthSpeedFactor.Size = new Size(62, 23);
        nudPlantGrowthSpeedFactor.TabIndex = 71;
        nudPlantGrowthSpeedFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblPlantGrowthFactor
        // 
        lblPlantGrowthFactor.AutoSize = true;
        lblPlantGrowthFactor.Location = new Point(75, 242);
        lblPlantGrowthFactor.Name = "lblPlantGrowthFactor";
        lblPlantGrowthFactor.Size = new Size(76, 15);
        lblPlantGrowthFactor.TabIndex = 79;
        lblPlantGrowthFactor.Text = "Plant Growth";
        // 
        // nudResourceDropStackAmountFactor
        // 
        nudResourceDropStackAmountFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudResourceDropStackAmountFactor.BorderStyle = BorderStyle.FixedSingle;
        nudResourceDropStackAmountFactor.DecimalPlaces = 2;
        nudResourceDropStackAmountFactor.ForeColor = SystemColors.Window;
        nudResourceDropStackAmountFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudResourceDropStackAmountFactor.Location = new Point(157, 269);
        nudResourceDropStackAmountFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudResourceDropStackAmountFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudResourceDropStackAmountFactor.Name = "nudResourceDropStackAmountFactor";
        nudResourceDropStackAmountFactor.Size = new Size(62, 23);
        nudResourceDropStackAmountFactor.TabIndex = 72;
        nudResourceDropStackAmountFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblResourceDropFactor
        // 
        lblResourceDropFactor.AutoSize = true;
        lblResourceDropFactor.Location = new Point(69, 271);
        lblResourceDropFactor.Name = "lblResourceDropFactor";
        lblResourceDropFactor.Size = new Size(82, 15);
        lblResourceDropFactor.TabIndex = 81;
        lblResourceDropFactor.Text = "Resource Gain";
        // 
        // nudFactoryProductionSpeedFactor
        // 
        nudFactoryProductionSpeedFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudFactoryProductionSpeedFactor.BorderStyle = BorderStyle.FixedSingle;
        nudFactoryProductionSpeedFactor.DecimalPlaces = 2;
        nudFactoryProductionSpeedFactor.ForeColor = SystemColors.Window;
        nudFactoryProductionSpeedFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudFactoryProductionSpeedFactor.Location = new Point(157, 298);
        nudFactoryProductionSpeedFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudFactoryProductionSpeedFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudFactoryProductionSpeedFactor.Name = "nudFactoryProductionSpeedFactor";
        nudFactoryProductionSpeedFactor.Size = new Size(62, 23);
        nudFactoryProductionSpeedFactor.TabIndex = 73;
        nudFactoryProductionSpeedFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblFactoryFactor
        // 
        lblFactoryFactor.AutoSize = true;
        lblFactoryFactor.Location = new Point(9, 300);
        lblFactoryFactor.Name = "lblFactoryFactor";
        lblFactoryFactor.Size = new Size(142, 15);
        lblFactoryFactor.TabIndex = 83;
        lblFactoryFactor.Text = "Workstation Effectiveness";
        // 
        // nudPerkUpgradeRecyclingFactor
        // 
        nudPerkUpgradeRecyclingFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPerkUpgradeRecyclingFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPerkUpgradeRecyclingFactor.DecimalPlaces = 2;
        nudPerkUpgradeRecyclingFactor.ForeColor = SystemColors.Window;
        nudPerkUpgradeRecyclingFactor.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
        nudPerkUpgradeRecyclingFactor.Location = new Point(157, 327);
        nudPerkUpgradeRecyclingFactor.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPerkUpgradeRecyclingFactor.Name = "nudPerkUpgradeRecyclingFactor";
        nudPerkUpgradeRecyclingFactor.Size = new Size(62, 23);
        nudPerkUpgradeRecyclingFactor.TabIndex = 74;
        // 
        // lblPerkRecycleFactor
        // 
        lblPerkRecycleFactor.AutoSize = true;
        lblPerkRecycleFactor.Location = new Point(39, 329);
        lblPerkRecycleFactor.Name = "lblPerkRecycleFactor";
        lblPerkRecycleFactor.Size = new Size(112, 15);
        lblPerkRecycleFactor.TabIndex = 85;
        lblPerkRecycleFactor.Text = "Salvage Yield Factor";
        // 
        // nudPerkCostFactor
        // 
        nudPerkCostFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudPerkCostFactor.BorderStyle = BorderStyle.FixedSingle;
        nudPerkCostFactor.DecimalPlaces = 2;
        nudPerkCostFactor.ForeColor = SystemColors.Window;
        nudPerkCostFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPerkCostFactor.Location = new Point(157, 356);
        nudPerkCostFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudPerkCostFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudPerkCostFactor.Name = "nudPerkCostFactor";
        nudPerkCostFactor.Size = new Size(62, 23);
        nudPerkCostFactor.TabIndex = 75;
        nudPerkCostFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblWeaponUpgrade
        // 
        lblWeaponUpgrade.AutoSize = true;
        lblWeaponUpgrade.Location = new Point(20, 358);
        lblWeaponUpgrade.Name = "lblWeaponUpgrade";
        lblWeaponUpgrade.Size = new Size(131, 15);
        lblWeaponUpgrade.TabIndex = 87;
        lblWeaponUpgrade.Text = "Weapon Upgrade Costs";
        // 
        // nudExperienceCombatFactor
        // 
        nudExperienceCombatFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudExperienceCombatFactor.BorderStyle = BorderStyle.FixedSingle;
        nudExperienceCombatFactor.DecimalPlaces = 2;
        nudExperienceCombatFactor.ForeColor = SystemColors.Window;
        nudExperienceCombatFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudExperienceCombatFactor.Location = new Point(350, 37);
        nudExperienceCombatFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudExperienceCombatFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudExperienceCombatFactor.Name = "nudExperienceCombatFactor";
        nudExperienceCombatFactor.Size = new Size(62, 23);
        nudExperienceCombatFactor.TabIndex = 76;
        nudExperienceCombatFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblCombatExp
        // 
        lblCombatExp.AutoSize = true;
        lblCombatExp.Location = new Point(272, 39);
        lblCombatExp.Name = "lblCombatExp";
        lblCombatExp.Size = new Size(71, 15);
        lblCombatExp.TabIndex = 89;
        lblCombatExp.Text = "Combat Exp";
        // 
        // nudExperienceMiningFactor
        // 
        nudExperienceMiningFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudExperienceMiningFactor.BorderStyle = BorderStyle.FixedSingle;
        nudExperienceMiningFactor.DecimalPlaces = 2;
        nudExperienceMiningFactor.ForeColor = SystemColors.Window;
        nudExperienceMiningFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudExperienceMiningFactor.Location = new Point(350, 66);
        nudExperienceMiningFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudExperienceMiningFactor.Name = "nudExperienceMiningFactor";
        nudExperienceMiningFactor.Size = new Size(62, 23);
        nudExperienceMiningFactor.TabIndex = 77;
        // 
        // lblMiningExp
        // 
        lblMiningExp.AutoSize = true;
        lblMiningExp.Location = new Point(277, 68);
        lblMiningExp.Name = "lblMiningExp";
        lblMiningExp.Size = new Size(66, 15);
        lblMiningExp.TabIndex = 91;
        lblMiningExp.Text = "Mining Exp";
        // 
        // nudExperienceExplorationQuestsFactor
        // 
        nudExperienceExplorationQuestsFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudExperienceExplorationQuestsFactor.BorderStyle = BorderStyle.FixedSingle;
        nudExperienceExplorationQuestsFactor.DecimalPlaces = 2;
        nudExperienceExplorationQuestsFactor.ForeColor = SystemColors.Window;
        nudExperienceExplorationQuestsFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudExperienceExplorationQuestsFactor.Location = new Point(350, 95);
        nudExperienceExplorationQuestsFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudExperienceExplorationQuestsFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudExperienceExplorationQuestsFactor.Name = "nudExperienceExplorationQuestsFactor";
        nudExperienceExplorationQuestsFactor.Size = new Size(62, 23);
        nudExperienceExplorationQuestsFactor.TabIndex = 78;
        nudExperienceExplorationQuestsFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblQuestExp
        // 
        lblQuestExp.AutoSize = true;
        lblQuestExp.Location = new Point(284, 97);
        lblQuestExp.Name = "lblQuestExp";
        lblQuestExp.Size = new Size(59, 15);
        lblQuestExp.TabIndex = 93;
        lblQuestExp.Text = "Quest Exp";
        // 
        // nudEnemyDamageFactor
        // 
        nudEnemyDamageFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudEnemyDamageFactor.BorderStyle = BorderStyle.FixedSingle;
        nudEnemyDamageFactor.DecimalPlaces = 2;
        nudEnemyDamageFactor.ForeColor = SystemColors.Window;
        nudEnemyDamageFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudEnemyDamageFactor.Location = new Point(350, 182);
        nudEnemyDamageFactor.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        nudEnemyDamageFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudEnemyDamageFactor.Name = "nudEnemyDamageFactor";
        nudEnemyDamageFactor.Size = new Size(62, 23);
        nudEnemyDamageFactor.TabIndex = 81;
        nudEnemyDamageFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblEnemyDmg
        // 
        lblEnemyDmg.AutoSize = true;
        lblEnemyDmg.Location = new Point(254, 184);
        lblEnemyDmg.Name = "lblEnemyDmg";
        lblEnemyDmg.Size = new Size(90, 15);
        lblEnemyDmg.TabIndex = 95;
        lblEnemyDmg.Text = "Enemy Damage";
        // 
        // nudEnemyHealthFactor
        // 
        nudEnemyHealthFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudEnemyHealthFactor.BorderStyle = BorderStyle.FixedSingle;
        nudEnemyHealthFactor.DecimalPlaces = 2;
        nudEnemyHealthFactor.ForeColor = SystemColors.Window;
        nudEnemyHealthFactor.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudEnemyHealthFactor.Location = new Point(350, 211);
        nudEnemyHealthFactor.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        nudEnemyHealthFactor.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudEnemyHealthFactor.Name = "nudEnemyHealthFactor";
        nudEnemyHealthFactor.Size = new Size(62, 23);
        nudEnemyHealthFactor.TabIndex = 82;
        nudEnemyHealthFactor.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblEnemyHealth
        // 
        lblEnemyHealth.AutoSize = true;
        lblEnemyHealth.Location = new Point(263, 213);
        lblEnemyHealth.Name = "lblEnemyHealth";
        lblEnemyHealth.Size = new Size(81, 15);
        lblEnemyHealth.TabIndex = 97;
        lblEnemyHealth.Text = "Enemy Health";
        // 
        // nudEnemyStaminaFactor
        // 
        nudEnemyStaminaFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudEnemyStaminaFactor.BorderStyle = BorderStyle.FixedSingle;
        nudEnemyStaminaFactor.DecimalPlaces = 2;
        nudEnemyStaminaFactor.ForeColor = SystemColors.Window;
        nudEnemyStaminaFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudEnemyStaminaFactor.Location = new Point(350, 240);
        nudEnemyStaminaFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudEnemyStaminaFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudEnemyStaminaFactor.Name = "nudEnemyStaminaFactor";
        nudEnemyStaminaFactor.Size = new Size(62, 23);
        nudEnemyStaminaFactor.TabIndex = 83;
        nudEnemyStaminaFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblEnemyStamina
        // 
        lblEnemyStamina.AutoSize = true;
        lblEnemyStamina.Location = new Point(255, 242);
        lblEnemyStamina.Name = "lblEnemyStamina";
        lblEnemyStamina.Size = new Size(89, 15);
        lblEnemyStamina.TabIndex = 99;
        lblEnemyStamina.Text = "Enemy Stamina";
        // 
        // nudEnemyPerceptionRangeFactor
        // 
        nudEnemyPerceptionRangeFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudEnemyPerceptionRangeFactor.BorderStyle = BorderStyle.FixedSingle;
        nudEnemyPerceptionRangeFactor.DecimalPlaces = 2;
        nudEnemyPerceptionRangeFactor.ForeColor = SystemColors.Window;
        nudEnemyPerceptionRangeFactor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        nudEnemyPerceptionRangeFactor.Location = new Point(350, 269);
        nudEnemyPerceptionRangeFactor.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
        nudEnemyPerceptionRangeFactor.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
        nudEnemyPerceptionRangeFactor.Name = "nudEnemyPerceptionRangeFactor";
        nudEnemyPerceptionRangeFactor.Size = new Size(62, 23);
        nudEnemyPerceptionRangeFactor.TabIndex = 84;
        nudEnemyPerceptionRangeFactor.Value = new decimal(new int[] { 5, 0, 0, 65536 });
        // 
        // lblEnemyPerception
        // 
        lblEnemyPerception.AutoSize = true;
        lblEnemyPerception.Location = new Point(241, 271);
        lblEnemyPerception.Name = "lblEnemyPerception";
        lblEnemyPerception.Size = new Size(103, 15);
        lblEnemyPerception.TabIndex = 101;
        lblEnemyPerception.Text = "Enemy Perception";
        // 
        // nudThreatBonus
        // 
        nudThreatBonus.BackColor = Color.FromArgb(6, 6, 48);
        nudThreatBonus.BorderStyle = BorderStyle.FixedSingle;
        nudThreatBonus.DecimalPlaces = 2;
        nudThreatBonus.ForeColor = SystemColors.Window;
        nudThreatBonus.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        nudThreatBonus.Location = new Point(350, 298);
        nudThreatBonus.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
        nudThreatBonus.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
        nudThreatBonus.Name = "nudThreatBonus";
        nudThreatBonus.Size = new Size(62, 23);
        nudThreatBonus.TabIndex = 85;
        nudThreatBonus.Value = new decimal(new int[] { 25, 0, 0, 131072 });
        // 
        // lblEnemyAttackRate
        // 
        lblEnemyAttackRate.AutoSize = true;
        lblEnemyAttackRate.Location = new Point(238, 300);
        lblEnemyAttackRate.Name = "lblEnemyAttackRate";
        lblEnemyAttackRate.Size = new Size(106, 15);
        lblEnemyAttackRate.TabIndex = 103;
        lblEnemyAttackRate.Text = "Enemy Attack Rate";
        // 
        // nudBossDamageFactor
        // 
        nudBossDamageFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudBossDamageFactor.BorderStyle = BorderStyle.FixedSingle;
        nudBossDamageFactor.DecimalPlaces = 2;
        nudBossDamageFactor.ForeColor = SystemColors.Window;
        nudBossDamageFactor.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
        nudBossDamageFactor.Location = new Point(350, 124);
        nudBossDamageFactor.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        nudBossDamageFactor.Minimum = new decimal(new int[] { 2, 0, 0, 65536 });
        nudBossDamageFactor.Name = "nudBossDamageFactor";
        nudBossDamageFactor.Size = new Size(62, 23);
        nudBossDamageFactor.TabIndex = 79;
        nudBossDamageFactor.Value = new decimal(new int[] { 2, 0, 0, 65536 });
        // 
        // lblBossDmg
        // 
        lblBossDmg.AutoSize = true;
        lblBossDmg.Location = new Point(266, 126);
        lblBossDmg.Name = "lblBossDmg";
        lblBossDmg.Size = new Size(78, 15);
        lblBossDmg.TabIndex = 105;
        lblBossDmg.Text = "Boss Damage";
        // 
        // nudBossHealthFactor
        // 
        nudBossHealthFactor.BackColor = Color.FromArgb(6, 6, 48);
        nudBossHealthFactor.BorderStyle = BorderStyle.FixedSingle;
        nudBossHealthFactor.DecimalPlaces = 2;
        nudBossHealthFactor.ForeColor = SystemColors.Window;
        nudBossHealthFactor.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
        nudBossHealthFactor.Location = new Point(350, 153);
        nudBossHealthFactor.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        nudBossHealthFactor.Minimum = new decimal(new int[] { 2, 0, 0, 65536 });
        nudBossHealthFactor.Name = "nudBossHealthFactor";
        nudBossHealthFactor.Size = new Size(62, 23);
        nudBossHealthFactor.TabIndex = 80;
        nudBossHealthFactor.Value = new decimal(new int[] { 2, 0, 0, 65536 });
        // 
        // lblBossHealth
        // 
        lblBossHealth.AutoSize = true;
        lblBossHealth.Location = new Point(275, 155);
        lblBossHealth.Name = "lblBossHealth";
        lblBossHealth.Size = new Size(69, 15);
        lblBossHealth.TabIndex = 107;
        lblBossHealth.Text = "Boss Health";
        // 
        // nudDayTimeDuration
        // 
        nudDayTimeDuration.BackColor = Color.FromArgb(6, 6, 48);
        nudDayTimeDuration.BorderStyle = BorderStyle.FixedSingle;
        nudDayTimeDuration.DecimalPlaces = 2;
        nudDayTimeDuration.ForeColor = SystemColors.Window;
        nudDayTimeDuration.Location = new Point(553, 215);
        nudDayTimeDuration.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
        nudDayTimeDuration.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
        nudDayTimeDuration.Name = "nudDayTimeDuration";
        nudDayTimeDuration.Size = new Size(62, 23);
        nudDayTimeDuration.TabIndex = 91;
        nudDayTimeDuration.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblDayDuration
        // 
        lblDayDuration.AutoSize = true;
        lblDayDuration.Location = new Point(471, 217);
        lblDayDuration.Name = "lblDayDuration";
        lblDayDuration.Size = new Size(76, 15);
        lblDayDuration.TabIndex = 109;
        lblDayDuration.Text = "Day Duration";
        // 
        // nudNightTimeDuration
        // 
        nudNightTimeDuration.BackColor = Color.FromArgb(6, 6, 48);
        nudNightTimeDuration.BorderStyle = BorderStyle.FixedSingle;
        nudNightTimeDuration.DecimalPlaces = 2;
        nudNightTimeDuration.ForeColor = SystemColors.Window;
        nudNightTimeDuration.Location = new Point(553, 244);
        nudNightTimeDuration.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
        nudNightTimeDuration.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
        nudNightTimeDuration.Name = "nudNightTimeDuration";
        nudNightTimeDuration.Size = new Size(62, 23);
        nudNightTimeDuration.TabIndex = 92;
        nudNightTimeDuration.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblNightDuration
        // 
        lblNightDuration.AutoSize = true;
        lblNightDuration.Location = new Point(461, 246);
        lblNightDuration.Name = "lblNightDuration";
        lblNightDuration.Size = new Size(86, 15);
        lblNightDuration.TabIndex = 111;
        lblNightDuration.Text = "Night Duration";
        // 
        // cbxTombstoneMode
        // 
        cbxTombstoneMode.Anchor = AnchorStyles.Top;
        cbxTombstoneMode.BackColor = Color.FromArgb(6, 6, 48);
        cbxTombstoneMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxTombstoneMode.FlatStyle = FlatStyle.Flat;
        cbxTombstoneMode.ForeColor = SystemColors.Window;
        cbxTombstoneMode.FormattingEnabled = true;
        cbxTombstoneMode.Location = new Point(553, 37);
        cbxTombstoneMode.Name = "cbxTombstoneMode";
        cbxTombstoneMode.Size = new Size(175, 23);
        cbxTombstoneMode.TabIndex = 86;
        // 
        // lblTombstone
        // 
        lblTombstone.AutoSize = true;
        lblTombstone.Location = new Point(447, 41);
        lblTombstone.Name = "lblTombstone";
        lblTombstone.Size = new Size(101, 15);
        lblTombstone.TabIndex = 114;
        lblTombstone.Text = "Tombstone Mode";
        // 
        // chkEnableDurability
        // 
        chkEnableDurability.AutoSize = true;
        chkEnableDurability.Location = new Point(553, 308);
        chkEnableDurability.Name = "chkEnableDurability";
        chkEnableDurability.Size = new Size(115, 19);
        chkEnableDurability.TabIndex = 94;
        chkEnableDurability.Text = "Enable Durability";
        chkEnableDurability.UseVisualStyleBackColor = true;
        // 
        // chkEnableStarvingDebuff
        // 
        chkEnableStarvingDebuff.AutoSize = true;
        chkEnableStarvingDebuff.Location = new Point(553, 333);
        chkEnableStarvingDebuff.Name = "chkEnableStarvingDebuff";
        chkEnableStarvingDebuff.Size = new Size(117, 19);
        chkEnableStarvingDebuff.TabIndex = 95;
        chkEnableStarvingDebuff.Text = "Enable Starvation";
        chkEnableStarvingDebuff.UseVisualStyleBackColor = true;
        // 
        // lblWeatherFreq
        // 
        lblWeatherFreq.AutoSize = true;
        lblWeatherFreq.Location = new Point(438, 71);
        lblWeatherFreq.Name = "lblWeatherFreq";
        lblWeatherFreq.Size = new Size(109, 15);
        lblWeatherFreq.TabIndex = 118;
        lblWeatherFreq.Text = "Weather Frequency";
        // 
        // cbxWeatherFrequency
        // 
        cbxWeatherFrequency.Anchor = AnchorStyles.Top;
        cbxWeatherFrequency.BackColor = Color.FromArgb(6, 6, 48);
        cbxWeatherFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxWeatherFrequency.FlatStyle = FlatStyle.Flat;
        cbxWeatherFrequency.ForeColor = SystemColors.Window;
        cbxWeatherFrequency.FormattingEnabled = true;
        cbxWeatherFrequency.Location = new Point(553, 67);
        cbxWeatherFrequency.Name = "cbxWeatherFrequency";
        cbxWeatherFrequency.Size = new Size(175, 23);
        cbxWeatherFrequency.TabIndex = 87;
        // 
        // lblEnemyAmount
        // 
        lblEnemyAmount.AutoSize = true;
        lblEnemyAmount.Location = new Point(457, 101);
        lblEnemyAmount.Name = "lblEnemyAmount";
        lblEnemyAmount.Size = new Size(90, 15);
        lblEnemyAmount.TabIndex = 120;
        lblEnemyAmount.Text = "Enemy Amount";
        // 
        // cbxRandomSpawnerAmount
        // 
        cbxRandomSpawnerAmount.Anchor = AnchorStyles.Top;
        cbxRandomSpawnerAmount.BackColor = Color.FromArgb(6, 6, 48);
        cbxRandomSpawnerAmount.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxRandomSpawnerAmount.FlatStyle = FlatStyle.Flat;
        cbxRandomSpawnerAmount.ForeColor = SystemColors.Window;
        cbxRandomSpawnerAmount.FormattingEnabled = true;
        cbxRandomSpawnerAmount.Location = new Point(553, 97);
        cbxRandomSpawnerAmount.Name = "cbxRandomSpawnerAmount";
        cbxRandomSpawnerAmount.Size = new Size(175, 23);
        cbxRandomSpawnerAmount.TabIndex = 88;
        // 
        // lblEnemyAggro
        // 
        lblEnemyAggro.AutoSize = true;
        lblEnemyAggro.Location = new Point(468, 131);
        lblEnemyAggro.Name = "lblEnemyAggro";
        lblEnemyAggro.Size = new Size(79, 15);
        lblEnemyAggro.TabIndex = 122;
        lblEnemyAggro.Text = "Enemy Aggro";
        // 
        // cbxAggroPoolAmount
        // 
        cbxAggroPoolAmount.Anchor = AnchorStyles.Top;
        cbxAggroPoolAmount.BackColor = Color.FromArgb(6, 6, 48);
        cbxAggroPoolAmount.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxAggroPoolAmount.FlatStyle = FlatStyle.Flat;
        cbxAggroPoolAmount.ForeColor = SystemColors.Window;
        cbxAggroPoolAmount.FormattingEnabled = true;
        cbxAggroPoolAmount.Location = new Point(553, 127);
        cbxAggroPoolAmount.Name = "cbxAggroPoolAmount";
        cbxAggroPoolAmount.Size = new Size(175, 23);
        cbxAggroPoolAmount.TabIndex = 89;
        // 
        // lblTamingFailure
        // 
        lblTamingFailure.AutoSize = true;
        lblTamingFailure.Location = new Point(463, 161);
        lblTamingFailure.Name = "lblTamingFailure";
        lblTamingFailure.Size = new Size(85, 15);
        lblTamingFailure.TabIndex = 124;
        lblTamingFailure.Text = "Taming Failure";
        // 
        // cbxTamingStartleRepercussion
        // 
        cbxTamingStartleRepercussion.Anchor = AnchorStyles.Top;
        cbxTamingStartleRepercussion.BackColor = Color.FromArgb(6, 6, 48);
        cbxTamingStartleRepercussion.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxTamingStartleRepercussion.FlatStyle = FlatStyle.Flat;
        cbxTamingStartleRepercussion.ForeColor = SystemColors.Window;
        cbxTamingStartleRepercussion.FormattingEnabled = true;
        cbxTamingStartleRepercussion.Location = new Point(553, 157);
        cbxTamingStartleRepercussion.Name = "cbxTamingStartleRepercussion";
        cbxTamingStartleRepercussion.Size = new Size(175, 23);
        cbxTamingStartleRepercussion.TabIndex = 90;
        // 
        // chkEnableGliderTurbulences
        // 
        chkEnableGliderTurbulences.AutoSize = true;
        chkEnableGliderTurbulences.Location = new Point(553, 358);
        chkEnableGliderTurbulences.Name = "chkEnableGliderTurbulences";
        chkEnableGliderTurbulences.Size = new Size(158, 19);
        chkEnableGliderTurbulences.TabIndex = 96;
        chkEnableGliderTurbulences.Text = "Enable Glider Turbulence";
        chkEnableGliderTurbulences.UseVisualStyleBackColor = true;
        // 
        // chkPacifyAllEnemies
        // 
        chkPacifyAllEnemies.AutoSize = true;
        chkPacifyAllEnemies.Location = new Point(553, 383);
        chkPacifyAllEnemies.Name = "chkPacifyAllEnemies";
        chkPacifyAllEnemies.Size = new Size(102, 19);
        chkPacifyAllEnemies.TabIndex = 97;
        chkPacifyAllEnemies.Text = "Pacify Enemys";
        chkPacifyAllEnemies.UseVisualStyleBackColor = true;
        // 
        // lblInMinutes
        // 
        lblInMinutes.AutoSize = true;
        lblInMinutes.Location = new Point(621, 246);
        lblInMinutes.Name = "lblInMinutes";
        lblInMinutes.Size = new Size(50, 15);
        lblInMinutes.TabIndex = 127;
        lblInMinutes.Text = "Minutes";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(621, 217);
        label2.Name = "label2";
        label2.Size = new Size(50, 15);
        label2.TabIndex = 128;
        label2.Text = "Minutes";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(621, 275);
        label3.Name = "label3";
        label3.Size = new Size(50, 15);
        label3.TabIndex = 129;
        label3.Text = "Minutes";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(462, 190);
        label4.Name = "label4";
        label4.Size = new Size(85, 15);
        label4.TabIndex = 131;
        label4.Text = "Curse Modifier";
        // 
        // cbxCurseModifier
        // 
        cbxCurseModifier.Anchor = AnchorStyles.Top;
        cbxCurseModifier.BackColor = Color.FromArgb(6, 6, 48);
        cbxCurseModifier.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxCurseModifier.FlatStyle = FlatStyle.Flat;
        cbxCurseModifier.ForeColor = SystemColors.Window;
        cbxCurseModifier.FormattingEnabled = true;
        cbxCurseModifier.Location = new Point(553, 186);
        cbxCurseModifier.Name = "cbxCurseModifier";
        cbxCurseModifier.Size = new Size(175, 23);
        cbxCurseModifier.TabIndex = 130;
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        lblTitle.ForeColor = SystemColors.Info;
        lblTitle.Location = new Point(124, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(497, 20);
        lblTitle.TabIndex = 132;
        lblTitle.Text = "Game settings preset must be set to custom for these values to take effect";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // GameSettingsView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 18);
        Controls.Add(btnSaveSettings);
        Controls.Add(lblTitle);
        Controls.Add(label4);
        Controls.Add(cbxCurseModifier);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(lblInMinutes);
        Controls.Add(chkPacifyAllEnemies);
        Controls.Add(chkEnableGliderTurbulences);
        Controls.Add(lblTamingFailure);
        Controls.Add(cbxTamingStartleRepercussion);
        Controls.Add(lblEnemyAggro);
        Controls.Add(cbxAggroPoolAmount);
        Controls.Add(lblEnemyAmount);
        Controls.Add(cbxRandomSpawnerAmount);
        Controls.Add(lblWeatherFreq);
        Controls.Add(cbxWeatherFrequency);
        Controls.Add(chkEnableStarvingDebuff);
        Controls.Add(chkEnableDurability);
        Controls.Add(lblTombstone);
        Controls.Add(cbxTombstoneMode);
        Controls.Add(nudNightTimeDuration);
        Controls.Add(lblNightDuration);
        Controls.Add(nudDayTimeDuration);
        Controls.Add(lblDayDuration);
        Controls.Add(nudBossHealthFactor);
        Controls.Add(lblBossHealth);
        Controls.Add(nudBossDamageFactor);
        Controls.Add(lblBossDmg);
        Controls.Add(nudThreatBonus);
        Controls.Add(lblEnemyAttackRate);
        Controls.Add(nudEnemyPerceptionRangeFactor);
        Controls.Add(lblEnemyPerception);
        Controls.Add(nudEnemyStaminaFactor);
        Controls.Add(lblEnemyStamina);
        Controls.Add(nudEnemyHealthFactor);
        Controls.Add(lblEnemyHealth);
        Controls.Add(nudEnemyDamageFactor);
        Controls.Add(lblEnemyDmg);
        Controls.Add(nudExperienceExplorationQuestsFactor);
        Controls.Add(lblQuestExp);
        Controls.Add(nudExperienceMiningFactor);
        Controls.Add(lblMiningExp);
        Controls.Add(nudExperienceCombatFactor);
        Controls.Add(lblCombatExp);
        Controls.Add(nudPerkCostFactor);
        Controls.Add(lblWeaponUpgrade);
        Controls.Add(nudPerkUpgradeRecyclingFactor);
        Controls.Add(lblPerkRecycleFactor);
        Controls.Add(nudFactoryProductionSpeedFactor);
        Controls.Add(lblFactoryFactor);
        Controls.Add(nudResourceDropStackAmountFactor);
        Controls.Add(lblResourceDropFactor);
        Controls.Add(nudPlantGrowthSpeedFactor);
        Controls.Add(lblPlantGrowthFactor);
        Controls.Add(nudMiningDamageFactor);
        Controls.Add(lblMiningFactor);
        Controls.Add(nudShroudTimeFactor);
        Controls.Add(lblShroudTimeFactor);
        Controls.Add(nudFromHungerToStarving);
        Controls.Add(label1);
        Controls.Add(nudFoodBuffDurationFactor);
        Controls.Add(lblFoodBuff);
        Controls.Add(nudPlayerBodyHeatFactor);
        Controls.Add(lblPbhf);
        Controls.Add(nudPlayerStaminaFactor);
        Controls.Add(lblPsf);
        Controls.Add(nudPlayerManaFactor);
        Controls.Add(lblPmf);
        Controls.Add(nudPlayerHealthFactor);
        Controls.Add(lblPhf);
        Controls.Add(lblServerMustBeStoppedMessage);
        ForeColor = SystemColors.ButtonHighlight;
        Name = "GameSettingsView";
        Size = new Size(744, 411);
        ((System.ComponentModel.ISupportInitialize)nudPlayerHealthFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerManaFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerStaminaFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPlayerBodyHeatFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFoodBuffDurationFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFromHungerToStarving).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudShroudTimeFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudMiningDamageFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPlantGrowthSpeedFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudResourceDropStackAmountFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFactoryProductionSpeedFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPerkUpgradeRecyclingFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPerkCostFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceCombatFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceMiningFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudExperienceExplorationQuestsFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyDamageFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyHealthFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyStaminaFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudEnemyPerceptionRangeFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThreatBonus).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBossDamageFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBossHealthFactor).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudDayTimeDuration).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudNightTimeDuration).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnSaveSettings;
    private Label lblServerMustBeStoppedMessage;
    private Label lblPhf;
    private NumericUpDown nudPlayerHealthFactor;
    private NumericUpDown nudPlayerManaFactor;
    private Label lblPmf;
    private NumericUpDown nudPlayerStaminaFactor;
    private Label lblPsf;
    private NumericUpDown nudPlayerBodyHeatFactor;
    private Label lblPbhf;
    private NumericUpDown nudFoodBuffDurationFactor;
    private Label lblFoodBuff;
    private NumericUpDown nudFromHungerToStarving;
    private Label label1;
    private NumericUpDown nudShroudTimeFactor;
    private Label lblShroudTimeFactor;
    private NumericUpDown nudMiningDamageFactor;
    private Label lblMiningFactor;
    private NumericUpDown nudPlantGrowthSpeedFactor;
    private Label lblPlantGrowthFactor;
    private NumericUpDown nudResourceDropStackAmountFactor;
    private Label lblResourceDropFactor;
    private NumericUpDown nudFactoryProductionSpeedFactor;
    private Label lblFactoryFactor;
    private NumericUpDown nudPerkUpgradeRecyclingFactor;
    private Label lblPerkRecycleFactor;
    private NumericUpDown nudPerkCostFactor;
    private Label lblWeaponUpgrade;
    private NumericUpDown nudExperienceCombatFactor;
    private Label lblCombatExp;
    private NumericUpDown nudExperienceMiningFactor;
    private Label lblMiningExp;
    private NumericUpDown nudExperienceExplorationQuestsFactor;
    private Label lblQuestExp;
    private NumericUpDown nudEnemyDamageFactor;
    private Label lblEnemyDmg;
    private NumericUpDown nudEnemyHealthFactor;
    private Label lblEnemyHealth;
    private NumericUpDown nudEnemyStaminaFactor;
    private Label lblEnemyStamina;
    private NumericUpDown nudEnemyPerceptionRangeFactor;
    private Label lblEnemyPerception;
    private NumericUpDown nudThreatBonus;
    private Label lblEnemyAttackRate;
    private NumericUpDown nudBossDamageFactor;
    private Label lblBossDmg;
    private NumericUpDown nudBossHealthFactor;
    private Label lblBossHealth;
    private NumericUpDown nudDayTimeDuration;
    private Label lblDayDuration;
    private NumericUpDown nudNightTimeDuration;
    private Label lblNightDuration;
    private ComboBox cbxTombstoneMode;
    private Label lblTombstone;
    private CheckBox chkEnableDurability;
    private CheckBox chkEnableStarvingDebuff;
    private Label lblWeatherFreq;
    private ComboBox cbxWeatherFrequency;
    private Label lblEnemyAmount;
    private ComboBox cbxRandomSpawnerAmount;
    private Label lblEnemyAggro;
    private ComboBox cbxAggroPoolAmount;
    private Label lblTamingFailure;
    private ComboBox cbxTamingStartleRepercussion;
    private CheckBox chkEnableGliderTurbulences;
    private CheckBox chkPacifyAllEnemies;
    private Label lblInMinutes;
    private Label label2;
    private Label label3;
    private Button button1;
    private Label label4;
    private ComboBox cbxCurseModifier;
    private Label lblTitle;
}
