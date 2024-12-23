using Enshrouded_Server_Manager.Enums;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Views.Interfaces;

public interface IGameSettingsView
{
    decimal PlayerHealthFactor { get; set; }
    decimal PlayerManaFactor { get; set; }
    decimal PlayerStaminaFactor { get; set; }
    decimal PlayerBodyHeatFactor { get; set; }
    bool EnableDurability { get; set; }
    bool EnableStarvingDebuff { get; set; }
    decimal FoodBuffDurationFactor { get; set; }
    decimal FromHungerToStarving { get; set; }
    decimal ShroudTimeFactor { get; set; }
    string TombstoneMode { get; set; }
    bool EnableGliderTurbulences { get; set; }
    string WeatherFrequency { get; set; }
    decimal MiningDamageFactor { get; set; }
    decimal PlantGrowthSpeedFactor { get; set; }
    decimal ResourceDropStackAmountFactor { get; set; }
    decimal FactoryProductionSpeedFactor { get; set; }
    decimal PerkUpgradeRecyclingFactor { get; set; }
    decimal PerkCostFactor { get; set; }
    decimal ExperienceCombatFactor { get; set; }
    decimal ExperienceMiningFactor { get; set; }
    decimal ExperienceExplorationQuestsFactor { get; set; }
    string RandomSpawnerAmount { get; set; }
    string AggroPoolAmount { get; set; }
    decimal EnemyDamageFactor { get; set; }
    decimal EnemyHealthFactor { get; set; }
    decimal EnemyStaminaFactor { get; set; }
    decimal EnemyPerceptionRangeFactor { get; set; }
    decimal BossDamageFactor { get; set; }
    decimal BossHealthFactor { get; set; }
    decimal ThreatBonus { get; set; }
    bool PacifyAllEnemies { get; set; }
    string TamingStartleRepercussion { get; set; }
    decimal DayTimeDuration { get; set; }
    decimal NightTimeDuration { get; set; }

    event EventHandler SaveChangesButtonClicked;
    event EventHandler cbxWeatherFrequencyChanged;
    event EventHandler cbxTombstoneModeChanged;
    event EventHandler cbxRandomSpawnerAmountChanged;
    event EventHandler cbxAggroPoolAmountChanged;
    event EventHandler cbxTamingStartleRepercussionChanged;

    void SetWeatherFrequency(BindingList<WeatherFrequency> weatherFrequencies);
    void SetTombstoneMode(BindingList<TombstoneMode> tombstoneModes);
    void SetRandomSpawnerAmount(BindingList<RandomSpawnerAmount> randomSpawnerAmounts);
    void SetAggroPoolAmount(BindingList<AggroPoolAmount> aggroPool);
    void SetTamingStartleRepercussion(BindingList<TamingStartleRepercussion> tamingStartleRepercussion);

    void AnimateSaveButton();
}