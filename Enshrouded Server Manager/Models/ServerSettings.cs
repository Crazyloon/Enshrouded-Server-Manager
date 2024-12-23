using System.Text.Json.Serialization;

namespace Enshrouded_Server_Manager.Models;

public record ServerSettings
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("saveDirectory")]
    public string SaveDirectory { get; set; }

    [JsonPropertyName("logDirectory")]
    public string LogDirectory { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    [JsonPropertyName("gamePort")]
    public int GamePort { get; set; }

    [JsonPropertyName("queryPort")]
    public int QueryPort { get; set; }

    [JsonPropertyName("slotCount")]
    public int SlotCount { get; set; }

    [JsonPropertyName("gameSettingsPreset")]
    public string GameSettingsPreset { get; set; } = "Default";

    [JsonPropertyName("gameSettings")]
    public GameSettings GameSettings { get; set; }

    [JsonPropertyName("userGroups")]
    public List<UserGroup> UserGroups { get; set; }
}

public record GameSettings
{

    [JsonPropertyName("playerHealthFactor")]
    public decimal PlayerHealthFactor { get; set; } = 1;

    [JsonPropertyName("playerManaFactor")]
    public decimal PlayerManaFactor { get; set; } = 1;

    [JsonPropertyName("playerStaminaFactor")]
    public decimal PlayerStaminaFactor { get; set; } = 1;

    [JsonPropertyName("playerBodyHeatFactor")]
    public decimal PlayerBodyHeatFactor { get; set; } = 1;

    [JsonPropertyName("enableDurability")]
    public bool EnableDurability { get; set; } = true;

    [JsonPropertyName("enableStarvingDebuff")]
    public bool EnableStarvingDebuff { get; set; } = false;

    [JsonPropertyName("foodBuffDurationFactor")]
    public decimal FoodBuffDurationFactor { get; set; } = 1;

    [JsonPropertyName("fromHungerToStarving")]
    public decimal FromHungerToStarving { get; set; } = 10;

    [JsonPropertyName("shroudTimeFactor")]
    public decimal ShroudTimeFactor { get; set; } = 1;

    [JsonPropertyName("tombstoneMode")]
    public string TombstoneMode { get; set; } = "AddBackpackMaterials";

    [JsonPropertyName("enableGliderTurbulences")]
    public bool EnableGliderTurbulences { get; set; } = true;

    [JsonPropertyName("weatherFrequency")]
    public string WeatherFrequency { get; set; } = "Normal";

    [JsonPropertyName("miningDamageFactor")]
    public decimal MiningDamageFactor { get; set; } = 1;

    [JsonPropertyName("plantGrowthSpeedFactor")]
    public decimal PlantGrowthSpeedFactor { get; set; } = 1;

    [JsonPropertyName("resourceDropStackAmountFactor")]
    public decimal ResourceDropStackAmountFactor { get; set; } = 1;

    [JsonPropertyName("factoryProductionSpeedFactor")]
    public decimal FactoryProductionSpeedFactor { get; set; } = 1;

    [JsonPropertyName("perkUpgradeRecyclingFactor")]
    public decimal PerkUpgradeRecyclingFactor { get; set; } = 0.5m;

    [JsonPropertyName("perkCostFactor")]
    public decimal PerkCostFactor { get; set; } = 1;

    [JsonPropertyName("experienceCombatFactor")]
    public decimal ExperienceCombatFactor { get; set; } = 1;

    [JsonPropertyName("experienceMiningFactor")]
    public decimal ExperienceMiningFactor { get; set; } = 1;

    [JsonPropertyName("experienceExplorationQuestsFactor")]
    public decimal ExperienceExplorationQuestsFactor { get; set; } = 1;

    [JsonPropertyName("randomSpawnerAmount")]
    public string RandomSpawnerAmount { get; set; } = "Normal";

    [JsonPropertyName("aggroPoolAmount")]
    public string AggroPoolAmount { get; set; } = "Normal";

    [JsonPropertyName("enemyDamageFactor")]
    public decimal EnemyDamageFactor { get; set; } = 1;

    [JsonPropertyName("enemyHealthFactor")]
    public decimal EnemyHealthFactor { get; set; } = 1;

    [JsonPropertyName("enemyStaminaFactor")]
    public decimal EnemyStaminaFactor { get; set; } = 1;

    [JsonPropertyName("enemyPerceptionRangeFactor")]
    public decimal EnemyPerceptionRangeFactor { get; set; } = 1;

    [JsonPropertyName("bossDamageFactor")]
    public decimal BossDamageFactor { get; set; } = 1;

    [JsonPropertyName("bossHealthFactor")]
    public decimal BossHealthFactor { get; set; } = 1;

    [JsonPropertyName("threatBonus")]
    public decimal ThreatBonus { get; set; } = 1;

    [JsonPropertyName("pacifyAllEnemies")]
    public bool PacifyAllEnemies { get; set; } = false;

    [JsonPropertyName("tamingStartleRepercussion")]
    public string TamingStartleRepercussion { get; set; } = "LoseSomeProgress";

    [JsonPropertyName("dayTimeDuration")]
    public decimal DayTimeDuration { get; set; } = 30;

    [JsonPropertyName("nightTimeDuration")]
    public decimal NightTimeDuration { get; set; } = 12;
}



public record UserGroup
{

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("canKickBan")]
    public bool CanKickBan { get; set; }

    [JsonPropertyName("canAccessInventories")]
    public bool CanAccessInventories { get; set; }

    [JsonPropertyName("canEditBase")]
    public bool CanEditBase { get; set; }

    [JsonPropertyName("canExtendBase")]
    public bool CanExtendBase { get; set; }

    [JsonPropertyName("reservedSlots")]
    public int ReservedSlots { get; set; } = 0;
}

