using Enshrouded_Server_Manager.Enums;
using Enshrouded_Server_Manager.Events;
using Enshrouded_Server_Manager.Models;
using Enshrouded_Server_Manager.Services;
using Enshrouded_Server_Manager.Views.Interfaces;
using System.ComponentModel;

namespace Enshrouded_Server_Manager.Presenters;
public class GameSettingsPresenter
{
    private readonly IGameSettingsView _gameSettingsView;
    private readonly IServerSettingsService _serverSettingsService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IMessageBoxService _messageBox;
    private readonly IEnshroudedServerService _server;
    private readonly IEventAggregator _eventAggregator;
    private readonly IFileLoggerService _logger;

    private ServerProfile _serverProfile;
    private ServerSettings _serverSettings;

    private readonly decimal _nanoSecondConversionFactor = 60000000000;

    public GameSettingsPresenter(IGameSettingsView gameSettingsView,
        IEventAggregator eventAggregator,
        IServerSettingsService serverSettingsService,
        IFileSystemService fileSystemManager,
        IEnshroudedServerService server,
        IFileLoggerService fileLogger)
    {
        _gameSettingsView = gameSettingsView;
        _eventAggregator = eventAggregator;
        _serverSettingsService = serverSettingsService;
        _fileSystemService = fileSystemManager;
        _server = server;
        _logger = fileLogger;

        _gameSettingsView.SetTombstoneMode(new BindingList<TombstoneMode>(Enum.GetValues<TombstoneMode>().ToList()));
        _gameSettingsView.SetWeatherFrequency(new BindingList<WeatherFrequency>(Enum.GetValues<WeatherFrequency>().ToList()));
        _gameSettingsView.SetRandomSpawnerAmount(new BindingList<RandomSpawnerAmount>(Enum.GetValues<RandomSpawnerAmount>().ToList()));
        _gameSettingsView.SetAggroPoolAmount(new BindingList<AggroPoolAmount>(Enum.GetValues<AggroPoolAmount>().ToList()));
        _gameSettingsView.SetTamingStartleRepercussion(new BindingList<TamingStartleRepercussion>(Enum.GetValues<TamingStartleRepercussion>().ToList()));
        _gameSettingsView.SetCurseModifier(new BindingList<CurseModifier>(Enum.GetValues<CurseModifier>().ToList()));




        _gameSettingsView.SaveChangesButtonClicked += (sender, e) => SaveServerSettings();

        _eventAggregator.Subscribe<ProfileSelectedMessage>(p => OnServerProfileSelected(p.SelectedProfile));
        _eventAggregator.Subscribe<ServerSettingsSavedSuccessMessage>(m =>
        {
            _serverSettings = m.ServerSettings;
        });
    }

    public void SetGameSettings(ServerSettings serverSettings)
    {
        GameSettings gameSettings = serverSettings.GameSettings;

        if (gameSettings is null)
        {
            gameSettings = new GameSettings();
        }
        else
        {
            // when loading from file, need to transform nanoseconds into minutes
            _gameSettingsView.FromHungerToStarving = gameSettings.FromHungerToStarving / _nanoSecondConversionFactor;
            _gameSettingsView.DayTimeDuration = gameSettings.DayTimeDuration / _nanoSecondConversionFactor;
            _gameSettingsView.NightTimeDuration = gameSettings.NightTimeDuration / _nanoSecondConversionFactor;
        }

        _gameSettingsView.PlayerHealthFactor = gameSettings.PlayerHealthFactor;
        _gameSettingsView.PlayerManaFactor = gameSettings.PlayerManaFactor;
        _gameSettingsView.PlayerStaminaFactor = gameSettings.PlayerStaminaFactor;
        _gameSettingsView.PlayerBodyHeatFactor = gameSettings.PlayerBodyHeatFactor;
        _gameSettingsView.EnableDurability = gameSettings.EnableDurability;
        _gameSettingsView.EnableStarvingDebuff = gameSettings.EnableStarvingDebuff;
        _gameSettingsView.FoodBuffDurationFactor = gameSettings.FoodBuffDurationFactor;
        //_gameSettingsView.FromHungerToStarving = gameSettings.FromHungerToStarving;
        _gameSettingsView.ShroudTimeFactor = gameSettings.ShroudTimeFactor;
        _gameSettingsView.TombstoneMode = gameSettings.TombstoneMode;
        _gameSettingsView.EnableGliderTurbulences = gameSettings.EnableGliderTurbulences;
        _gameSettingsView.WeatherFrequency = gameSettings.WeatherFrequency;
        _gameSettingsView.MiningDamageFactor = gameSettings.MiningDamageFactor;
        _gameSettingsView.PlantGrowthSpeedFactor = gameSettings.PlantGrowthSpeedFactor;
        _gameSettingsView.ResourceDropStackAmountFactor = gameSettings.ResourceDropStackAmountFactor;
        _gameSettingsView.FactoryProductionSpeedFactor = gameSettings.FactoryProductionSpeedFactor;
        _gameSettingsView.PerkUpgradeRecyclingFactor = gameSettings.PerkUpgradeRecyclingFactor;
        _gameSettingsView.PerkCostFactor = gameSettings.PerkCostFactor;
        _gameSettingsView.ExperienceCombatFactor = gameSettings.ExperienceCombatFactor;
        _gameSettingsView.ExperienceMiningFactor = gameSettings.ExperienceMiningFactor;
        _gameSettingsView.ExperienceExplorationQuestsFactor = gameSettings.ExperienceExplorationQuestsFactor;
        _gameSettingsView.RandomSpawnerAmount = gameSettings.RandomSpawnerAmount;
        _gameSettingsView.AggroPoolAmount = gameSettings.AggroPoolAmount;
        _gameSettingsView.EnemyDamageFactor = gameSettings.EnemyDamageFactor;
        _gameSettingsView.EnemyHealthFactor = gameSettings.EnemyHealthFactor;
        _gameSettingsView.EnemyStaminaFactor = gameSettings.EnemyStaminaFactor;
        _gameSettingsView.EnemyPerceptionRangeFactor = gameSettings.EnemyPerceptionRangeFactor;
        _gameSettingsView.BossDamageFactor = gameSettings.BossDamageFactor;
        _gameSettingsView.BossHealthFactor = gameSettings.BossHealthFactor;
        _gameSettingsView.ThreatBonus = gameSettings.ThreatBonus;
        _gameSettingsView.PacifyAllEnemies = gameSettings.PacifyAllEnemies;
        _gameSettingsView.TamingStartleRepercussion = gameSettings.TamingStartleRepercussion;
        _gameSettingsView.CurseModifier = gameSettings.CurseModifier;
        //_gameSettingsView.DayTimeDuration = gameSettings.DayTimeDuration;
        //_gameSettingsView.NightTimeDuration = gameSettings.NightTimeDuration;
    }

    public void OnServerProfileSelected(ServerProfile serverProfile)
    {
        _serverProfile = serverProfile;
        if (serverProfile is not null)
        {
            _serverSettings = _serverSettingsService.LoadServerSettings(serverProfile.Name);
            SetGameSettings(_serverSettings);
        }
    }

    private void SaveServerSettings()
    {
        // when saving to file, need to transform minutes into nano seconds
        var hungerToStarving = _gameSettingsView.FromHungerToStarving * _nanoSecondConversionFactor;
        var dayTimeDuration = _gameSettingsView.DayTimeDuration * _nanoSecondConversionFactor;
        var nightTimeDuration = _gameSettingsView.NightTimeDuration * _nanoSecondConversionFactor;

        _serverSettings.GameSettings = new GameSettings()
        {
            PlayerHealthFactor = _gameSettingsView.PlayerHealthFactor,
            PlayerManaFactor = _gameSettingsView.PlayerManaFactor,
            PlayerStaminaFactor = _gameSettingsView.PlayerStaminaFactor,
            PlayerBodyHeatFactor = _gameSettingsView.PlayerBodyHeatFactor,
            EnableDurability = _gameSettingsView.EnableDurability,
            EnableStarvingDebuff = _gameSettingsView.EnableStarvingDebuff,
            FoodBuffDurationFactor = _gameSettingsView.FoodBuffDurationFactor,
            FromHungerToStarving = hungerToStarving,
            ShroudTimeFactor = _gameSettingsView.ShroudTimeFactor,
            TombstoneMode = _gameSettingsView.TombstoneMode,
            EnableGliderTurbulences = _gameSettingsView.EnableGliderTurbulences,
            WeatherFrequency = _gameSettingsView.WeatherFrequency,
            MiningDamageFactor = _gameSettingsView.MiningDamageFactor,
            PlantGrowthSpeedFactor = _gameSettingsView.PlantGrowthSpeedFactor,
            ResourceDropStackAmountFactor = _gameSettingsView.ResourceDropStackAmountFactor,
            FactoryProductionSpeedFactor = _gameSettingsView.FactoryProductionSpeedFactor,
            PerkUpgradeRecyclingFactor = _gameSettingsView.PerkUpgradeRecyclingFactor,
            PerkCostFactor = _gameSettingsView.PerkCostFactor,
            ExperienceCombatFactor = _gameSettingsView.ExperienceCombatFactor,
            ExperienceMiningFactor = _gameSettingsView.ExperienceMiningFactor,
            ExperienceExplorationQuestsFactor = _gameSettingsView.ExperienceExplorationQuestsFactor,
            RandomSpawnerAmount = _gameSettingsView.RandomSpawnerAmount,
            AggroPoolAmount = _gameSettingsView.AggroPoolAmount,
            EnemyDamageFactor = _gameSettingsView.EnemyDamageFactor,
            EnemyHealthFactor = _gameSettingsView.EnemyHealthFactor,
            EnemyStaminaFactor = _gameSettingsView.EnemyStaminaFactor,
            EnemyPerceptionRangeFactor = _gameSettingsView.EnemyPerceptionRangeFactor,
            BossDamageFactor = _gameSettingsView.BossDamageFactor,
            BossHealthFactor = _gameSettingsView.BossHealthFactor,
            ThreatBonus = _gameSettingsView.ThreatBonus,
            PacifyAllEnemies = _gameSettingsView.PacifyAllEnemies,
            TamingStartleRepercussion = _gameSettingsView.TamingStartleRepercussion,
            CurseModifier = _gameSettingsView.CurseModifier,
            DayTimeDuration = dayTimeDuration,
            NightTimeDuration = nightTimeDuration,
        };

        if (_serverSettingsService.SaveServerSettings(_serverSettings, _serverProfile))
        {
            _gameSettingsView.AnimateSaveButton();
            _eventAggregator.Publish(new ServerSettingsSavedSuccessMessage(_serverSettings));
        }
    }
}
