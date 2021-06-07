using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Catel;
using Catel.Services;
using CP77.CR2W;
using DynamicData;
using ReactiveUI;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Model.Arguments;
using WolvenKit.Common.Services;
using WolvenKit.Common.Wcc;
using WolvenKit.Functionality.Commands;
using WolvenKit.Functionality.Controllers;
using WolvenKit.Functionality.Services;
using WolvenKit.Models;
using WolvenKit.Functionality.Helpers;
using WolvenKit.RED4.CR2W.Archive;
using ObservableObject = Catel.Data.ObservableObject;

namespace WolvenKit.ViewModels.Editor
{
    public class ImportExportViewModel : ToolViewModel
    {

        /// <summary>
        /// Identifies the <see ref="ContentId"/> of this tool window.
        /// </summary>
        public const string ToolContentId = "ImportExport_Tool";

        /// <summary>
        /// Identifies the caption string used for this tool window.
        /// </summary>
        public const string ToolTitle = "Import Export Tool";

        /// <summary>
        /// Private Importable Items
        /// </summary>
        private readonly ReadOnlyObservableCollection<ImportableItemViewModel> _importableItems;

        /// <summary>
        /// Public Importable Items
        /// </summary>
        public ReadOnlyObservableCollection<ImportableItemViewModel> ImportableItems => _importableItems;

        /// <summary>
        /// Private Exportable Items
        /// </summary>
        private readonly ReadOnlyObservableCollection<ExportableItemViewModel> _exportableItems;

        /// <summary>
        /// Public Exportable items.
        /// </summary>
        public ReadOnlyObservableCollection<ExportableItemViewModel> ExportableItems => _exportableItems;



        public ExportableItemViewModel SelectedExport { get; set; }

        public ImportableItemViewModel SelectedImport { get; set; }

        public ImportExportItemViewModel SelectedObject => IsImportsSelected
            ? SelectedImport
            : SelectedExport;


        public string CurrentSelectedInGridName { get; set; }

        private readonly ILoggerService _loggerService;
        private readonly IMessageService _messageService;
        private readonly IProjectManager _projectManager;
        private readonly IWatcherService _watcherService;
        private readonly IGameControllerFactory _gameController;

        /// <summary>
        /// Private Readonly ModTools
        /// </summary>
        private readonly ModTools _modTools;

        /// <summary>
        /// Import Export ViewModel Constructor
        /// </summary>
        /// <param name="projectManager"></param>
        /// <param name="loggerService"></param>
        /// <param name="messageService"></param>
        /// <param name="watcherService"></param>
        /// <param name="gameController"></param>
        /// <param name="modTools"></param>
        public ImportExportViewModel(
           IProjectManager projectManager,
           ILoggerService loggerService,
           IMessageService messageService,
           IWatcherService watcherService,
           IGameControllerFactory gameController,
           ModTools modTools
           ) : base(ToolTitle)
        {
            Argument.IsNotNull(() => projectManager);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => loggerService);
            Argument.IsNotNull(() => watcherService);
            Argument.IsNotNull(() => modTools);
            Argument.IsNotNull(() => gameController);


            _projectManager = projectManager;
            _loggerService = loggerService;
            _messageService = messageService;
            _watcherService = watcherService;
            _modTools = modTools;
            _gameController = gameController;

            SetupToolDefaults();


            ProcessAllCommand = new RelayCommand(ExecuteProcessAll, CanProcessAll);
            ProcessSelectedCommand = new RelayCommand(ExecuteProcessSelected, CanProcessSelected);

            _watcherService.Files
                .Connect()
                .Filter(_ => _.IsImportable)
                .Transform(_ => new ImportableItemViewModel(_))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _importableItems)
                .Subscribe();

            _watcherService.Files
                .Connect()
                .Filter(_ => _.IsExportable)
                .Transform(_ => new ExportableItemViewModel(_))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _exportableItems)
                .Subscribe();

        }


        /// <summary>
        /// Is Import Selected, if false Export is default.
        /// </summary>
        public bool IsImportsSelected { get; set; }

        /// <summary>
        /// Process all in Import / Export Grid Command.
        /// </summary>
        public ICommand ProcessAllCommand { get; private set; }

        /// <summary>
        /// Can Process all Bool
        /// </summary>
        /// <returns>bool</returns>
        private bool CanProcessAll() => true;

        /// <summary>
        /// Execute Process all in Import / Export Grid Command.
        /// </summary>
        private void ExecuteProcessAll()
        {
            if (IsImportsSelected)
            {
                foreach (var item in ImportableItems)
                {
                    ImportSingle(item);
                }
            }
            else
            {
                foreach (var item in ExportableItems)
                {
                    ExportSingle(item);
                }

            }
        }

        private void ImportSingle(ImportableItemViewModel item)
        {
            var fi = new FileInfo(item.FullName);
            if (fi.Exists)
            {
                _modTools.Import(fi, item.Properties as ImportArgs);
            }
        }

        private void ExportSingle(ExportableItemViewModel item)
        {
            var fi = new FileInfo(item.FullName);
            if (fi.Exists)
            {
                if (item.Properties is MeshExportArgs meshExportArgs)
                {
                    var cp77controller = _gameController.GetController() as Cp77Controller;
                    var archivemanager =
                        cp77controller.GetArchiveManagersManagers(false).First() as ArchiveManager;
                    meshExportArgs.Archives = archivemanager.Archives.Values.Cast<Archive>().ToList();
                }

                var settings = new GlobalExportArgs().Register(item.Properties as ExportArgs);
                _modTools.Export(fi, settings);
            }
        }

        /// <summary>
        /// Process selected in Import / Export Grid Command
        /// </summary>
        public ICommand ProcessSelectedCommand { get; private set; }

        /// <summary>
        /// Can Process Selected Bool.
        /// </summary>
        /// <returns>bool</returns>
        private bool CanProcessSelected() => true;

        /// <summary>
        /// Execute Process selected in Import / Export Grid Command
        /// </summary>
        private void ExecuteProcessSelected()
        {
            if (IsImportsSelected)
            {
                foreach (var item in ImportableItems.Where(_ => _.IsChecked))
                {
                    ImportSingle(item);
                }
            }
            else
            {
                foreach (var item in ExportableItems.Where(_ => _.IsChecked))
                {
                    ExportSingle(item);
                }

            }
        }


        /// <summary>
        /// Close Async
        /// </summary>
        /// <returns></returns>
        protected override Task CloseAsync() =>
            // TODO: Unsubscribe from events
            base.CloseAsync();

        /// <summary>
        /// Initialize Async
        /// </summary>
        /// <returns></returns>
        protected override async Task InitializeAsync() =>
            // TODO: Write initialization code here and subscribe to events
            await base.InitializeAsync();

        /// <summary>
        /// Setup Tool defaults for tool window.
        /// </summary>
        private void SetupToolDefaults() => ContentId = ToolContentId;



        // Define a unique contentid for this toolwindow
        //BitmapImage bi = new BitmapImage();
        // Define an icon for this toolwindow
        //bi.BeginInit();
        //bi.UriSource = new Uri("pack://application:,,/Resources/Media/Images/property-blue.png");
        //bi.EndInit();
        //IconSource = bi;

    }



    /// <summary>
    /// ImportExportItem ViewModel
    /// </summary>
    public abstract class ImportExportItemViewModel : ObservableObject
    {
        protected FileModel BaseFile { get; set; }

        public ImportExportArgs Properties
        {
            get => _properties;
            set
            {
                if (_properties != value)
                {
                    var oldValue = _properties;
                    _properties = value;
                    RaisePropertyChanged(() => Properties, oldValue, value);
                    RaisePropertyChanged(() => ExportTaskIdentifier);
                }
            }
        }

        private ImportExportArgs _properties;

        public string ExportTaskIdentifier => Properties.ToString();

        public string Extension => BaseFile.GetExtension();
        public string FullName => BaseFile.FullName;
        public string Name => BaseFile.Name;


        public bool IsChecked { get; set; }



        public EExportState ExportState => BaseFile.IsImportable ? EExportState.Importable : EExportState.Exportable;
    }


    public class ImportableItemViewModel : ImportExportItemViewModel
    {
        public ImportableItemViewModel(FileModel model)
        {
            BaseFile = model;
            Properties = DecideImportOptions(model);
        }

        private ImportArgs DecideImportOptions(FileModel model)
        {

            _ = Enum.TryParse(model.GetExtension(), out ERawFileFormat Extension);

            switch (Extension)
            {
                case ERawFileFormat.tga:
                case ERawFileFormat.dds:
                    return new XbmImportArgs();
                case ERawFileFormat.fbx:
                    return new CommonImportArgs();

                case ERawFileFormat.glb:
                case ERawFileFormat.gltf:
                    return new MeshImportArgs();


                default:
                    return new CommonImportArgs();
            }
        }
    }
    public class ExportableItemViewModel : ImportExportItemViewModel
    {
        public ExportableItemViewModel(FileModel model)
        {
            BaseFile = model;
            Properties = DecideExportOptions(model);
        }

        private ExportArgs DecideExportOptions(FileModel model)
        {

            _ = Enum.TryParse(model.GetExtension(), out ECookedFileFormat Extension);

            switch (Extension)
            {
                case ECookedFileFormat.mesh:
                    return new MeshExportArgs();
                case ECookedFileFormat.xbm:
                    return new XbmExportArgs();
                case ECookedFileFormat.wem:
                    return new WemExportArgs();
                case ECookedFileFormat.csv:
                case ECookedFileFormat.json:
                case ECookedFileFormat.mlmask:
                case ECookedFileFormat.cubemap:
                case ECookedFileFormat.envprobe:
                case ECookedFileFormat.texarray:
                    return new CommonExportArgs();
                case ECookedFileFormat.morphtarget:
                    return new MorphTargetExportArgs();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }



}
