using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.UI;
using Enshrouded_Server_Manager.Views.Interfaces;
using System.ComponentModel;

namespace Enshrouded_Server_Manager;
public partial class GameSettingsView : UserControl, IGameSettingsView
{
    public GameSettingsView()
    {
        InitializeComponent();
        cbxWeatherFrequency.SelectedIndexChanged += (sender, args) => cbxWeatherFrequencyChanged?.Invoke(this, EventArgs.Empty);
        cbxRandomSpawnerAmount.SelectedIndexChanged += (sender, args) => cbxRandomSpawnerAmountChanged?.Invoke(this, EventArgs.Empty);
        cbxAggroPoolAmount.SelectedIndexChanged += (sender, args) => cbxAggroPoolAmountChanged?.Invoke(this, EventArgs.Empty);
        cbxTamingStartleRepercussion.SelectedIndexChanged += (sender, args) => cbxTamingStartleRepercussionChanged?.Invoke(this, EventArgs.Empty);
    }

    public decimal PlayerHealthFactor
    {
        get => (decimal)nudPlayerHealthFactor.Value;
        set => nudPlayerHealthFactor.Value = value;
    }
    public decimal PlayerManaFactor
    {
        get => (decimal)nudPlayerManaFactor.Value;
        set => nudPlayerManaFactor.Value = value;
    }
    public decimal PlayerStaminaFactor
    {
        get => (decimal)nudPlayerStaminaFactor.Value;
        set => nudPlayerStaminaFactor.Value = value;
    }
    public decimal PlayerBodyHeatFactor
    {
        get => (decimal)nudPlayerBodyHeatFactor.Value;
        set => nudPlayerBodyHeatFactor.Value = value;
    }
    public bool EnableDurability
    {
        get => chkEnableDurability.Checked;
        set => chkEnableDurability.Checked = value;
    }
    public bool EnableStarvingDebuff
    {
        get => chkEnableStarvingDebuff.Checked;
        set => chkEnableStarvingDebuff.Checked = value;
    }
    public decimal FoodBuffDurationFactor
    {
        get => (decimal)nudFoodBuffDurationFactor.Value;
        set => nudFoodBuffDurationFactor.Value = value;
    }
    public decimal FromHungerToStarving
    {
        get => (decimal)nudFromHungerToStarving.Value;
        set => nudFromHungerToStarving.Value = (decimal)value;
    }
    public decimal ShroudTimeFactor
    {
        get => (decimal)nudShroudTimeFactor.Value;
        set => nudShroudTimeFactor.Value = value;
    }
    public string TombstoneMode
    {
        get => ((TombstoneMode)cbxTombstoneMode.SelectedItem).ToString();
        set => cbxTombstoneMode.SelectedItem = Enum.Parse(typeof(TombstoneMode), value);
    }
    public bool EnableGliderTurbulences
    {
        get => chkEnableGliderTurbulences.Checked;
        set => chkEnableGliderTurbulences.Checked = value;
    }
    public string WeatherFrequency
    {
        get => ((WeatherFrequency)cbxWeatherFrequency.SelectedItem).ToString();
        set => cbxWeatherFrequency.SelectedItem = Enum.Parse(typeof(WeatherFrequency), value);
    }
    public decimal MiningDamageFactor
    {
        get => (decimal)nudMiningDamageFactor.Value;
        set => nudMiningDamageFactor.Value = value;
    }
    public decimal PlantGrowthSpeedFactor
    {
        get => (decimal)nudPlantGrowthSpeedFactor.Value;
        set => nudPlantGrowthSpeedFactor.Value = value;
    }
    public decimal ResourceDropStackAmountFactor
    {
        get => (decimal)nudResourceDropStackAmountFactor.Value;
        set => nudResourceDropStackAmountFactor.Value = value;
    }
    public decimal FactoryProductionSpeedFactor
    {
        get => (decimal)nudFactoryProductionSpeedFactor.Value;
        set => nudFactoryProductionSpeedFactor.Value = value;
    }
    public decimal PerkUpgradeRecyclingFactor
    {
        get => (decimal)nudPerkUpgradeRecyclingFactor.Value;
        set => nudPerkUpgradeRecyclingFactor.Value = (decimal)value;
    }
    public decimal PerkCostFactor
    {
        get => (decimal)nudPerkCostFactor.Value;
        set => nudPerkCostFactor.Value = value;
    }
    public decimal ExperienceCombatFactor
    {
        get => (decimal)nudExperienceCombatFactor.Value;
        set => nudExperienceCombatFactor.Value = value;
    }
    public decimal ExperienceMiningFactor
    {
        get => (decimal)nudExperienceMiningFactor.Value;
        set => nudExperienceMiningFactor.Value = value;
    }
    public decimal ExperienceExplorationQuestsFactor
    {
        get => (decimal)nudExperienceExplorationQuestsFactor.Value;
        set => nudExperienceExplorationQuestsFactor.Value = value;
    }
    public string RandomSpawnerAmount
    {
        get => ((RandomSpawnerAmount)cbxRandomSpawnerAmount.SelectedItem).ToString();
        set => cbxRandomSpawnerAmount.SelectedItem = Enum.Parse(typeof(RandomSpawnerAmount), value);
    }
    public string AggroPoolAmount
    {
        get => ((AggroPoolAmount)cbxAggroPoolAmount.SelectedItem).ToString();
        set => cbxAggroPoolAmount.SelectedItem = Enum.Parse(typeof(AggroPoolAmount), value);
    }
    public decimal EnemyDamageFactor
    {
        get => (decimal)nudEnemyDamageFactor.Value;
        set => nudEnemyDamageFactor.Value = value;
    }
    public decimal EnemyHealthFactor
    {
        get => (decimal)nudEnemyHealthFactor.Value;
        set => nudEnemyHealthFactor.Value = value;
    }
    public decimal EnemyStaminaFactor
    {
        get => (decimal)nudEnemyStaminaFactor.Value;
        set => nudEnemyStaminaFactor.Value = value;
    }
    public decimal EnemyPerceptionRangeFactor
    {
        get => (decimal)nudEnemyPerceptionRangeFactor.Value;
        set => nudEnemyPerceptionRangeFactor.Value = value;
    }
    public decimal BossDamageFactor
    {
        get => (decimal)nudBossDamageFactor.Value;
        set => nudBossDamageFactor.Value = value;
    }
    public decimal BossHealthFactor
    {
        get => (decimal)nudBossHealthFactor.Value;
        set => nudBossHealthFactor.Value = value;
    }
    public decimal ThreatBonus
    {
        get => (decimal)nudThreatBonus.Value;
        set => nudThreatBonus.Value = value;
    }
    public bool PacifyAllEnemies
    {
        get => chkPacifyAllEnemies.Checked;
        set => chkPacifyAllEnemies.Checked = value;
    }
    public string TamingStartleRepercussion
    {
        get => ((TamingStartleRepercussion)cbxTamingStartleRepercussion.SelectedItem).ToString();
        set => cbxTamingStartleRepercussion.SelectedItem = Enum.Parse(typeof(TamingStartleRepercussion), value);
    }
    public decimal DayTimeDuration
    {
        get => (decimal)nudDayTimeDuration.Value;
        set => nudDayTimeDuration.Value = (decimal)value;
    }
    public decimal NightTimeDuration
    {
        get => (decimal)nudNightTimeDuration.Value;
        set => nudNightTimeDuration.Value = (decimal)value;
    }

    public event EventHandler SaveChangesButtonClicked
    {
        add => btnSaveSettings.Click += value;
        remove => btnSaveSettings.Click -= value;
    }

    public event EventHandler cbxTombstoneModeChanged;
    public event EventHandler cbxWeatherFrequencyChanged;
    public event EventHandler cbxRandomSpawnerAmountChanged;
    public event EventHandler cbxAggroPoolAmountChanged;
    public event EventHandler cbxTamingStartleRepercussionChanged;

    public void AnimateSaveButton()
    {
        Interactions.AnimateSaveChangesButton(btnSaveSettings, btnSaveSettings.Text, Constants.ButtonText.SAVED_SUCCESS);
    }

    private void btnSaveSettings_EnabledChanged(object sender, EventArgs e)
    {
        var button = ((Button)sender);
        Interactions.HandleEnabledChanged_PrimaryButton(button);
    }

    public void SetTombstoneMode(BindingList<TombstoneMode> tombstoneMode)
    {
        cbxTombstoneMode.DataSource = tombstoneMode;
    }
    public void SetWeatherFrequency(BindingList<WeatherFrequency> weatherFrequency)
    {
        cbxWeatherFrequency.DataSource = weatherFrequency;
    }
    public void SetRandomSpawnerAmount(BindingList<RandomSpawnerAmount> randomSpawnerAmount)
    {
        cbxRandomSpawnerAmount.DataSource = randomSpawnerAmount;
    }
    public void SetAggroPoolAmount(BindingList<AggroPoolAmount> aggroPoolAmount)
    {
        cbxAggroPoolAmount.DataSource = aggroPoolAmount;
    }
    public void SetTamingStartleRepercussion(BindingList<TamingStartleRepercussion> tamingStartleRepercussion)
    {
        cbxTamingStartleRepercussion.DataSource = tamingStartleRepercussion;
    }

    public void SetWeatherFrequencies(BindingList<WeatherFrequency> weatherFrequencies)
    {
        throw new NotImplementedException();
    }
}
