using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CP77.CR2W;
using WolvenKit.Common;
using WolvenKit.RED4.CR2W.Archive;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Model.Arguments;
using WolvenKit.Common.Services;

namespace CP77Tools.Tasks
{
    public partial class ConsoleFunctions
    {
        #region Methods

        public void UncookTask(string[] path, string outpath, string rawOutDir,
            EUncookExtension uext, bool flip, ulong hash, string pattern, string regex, bool unbundle,
            ECookedFileFormat forcebuffers)
        {
            if (path == null || path.Length < 1)
            {
                _loggerService.Warning("Please fill in an input path.");
                return;
            }

            Parallel.ForEach(path, file =>
            {
                UncookTaskInner(file, outpath, rawOutDir, uext, flip, hash, pattern, regex, unbundle, forcebuffers);
            });
        }

        private void UncookTaskInner(string path, string outpath, string rawOutDir,
            EUncookExtension uext, bool flip, ulong hash, string pattern, string regex, bool unbundle,
            ECookedFileFormat forcebuffers)
        {
            #region checks

            if (string.IsNullOrEmpty(path))
            {
                _loggerService.Warning("Please fill in an input path.");
                return;
            }

            var inputFileInfo = new FileInfo(path);
            var inputDirInfo = new DirectoryInfo(path);

            if (!inputFileInfo.Exists && !inputDirInfo.Exists)
            {
                _loggerService.Warning("Input path does not exist.");
                return;
            }

            if (inputFileInfo.Exists && inputFileInfo.Extension != ".archive")
            {
                _loggerService.Warning("Input file is not an .archive.");
                return;
            }
            else if (inputDirInfo.Exists && inputDirInfo.GetFiles().All(_ => _.Extension != ".archive"))
            {
                _loggerService.Warning("No .archive file to process in the input directory");
                return;
            }

            var isDirectory = !inputFileInfo.Exists;
            var basedir = inputFileInfo.Exists ? new FileInfo(path).Directory : inputDirInfo;

            var exportArgs = new GlobalExportArgs().Register(
                new XbmExportArgs()
                {
                    UncookExtension = uext,
                    Flip = flip
                }
            );

            #endregion checks

            List<FileInfo> archiveFileInfos;
            if (isDirectory)
            {
                var archiveManager = new ArchiveManager(_hashService);
                archiveManager.LoadFromFolder(basedir.FullName);
                // TODO: use the manager here?
                archiveFileInfos = archiveManager.Archives.Select(_ => new FileInfo(_.Value.ArchiveAbsolutePath)).ToList();
            }
            else
            {
                archiveFileInfos = new List<FileInfo> { inputFileInfo };
            }

            foreach (var processedarchive in archiveFileInfos)
            {
                // get outdirectory
                DirectoryInfo outDir;
                if (string.IsNullOrEmpty(outpath))
                {
                    outDir = new DirectoryInfo(Path.Combine(
                        basedir.FullName,
                        processedarchive.Name.Replace(".archive", "")));
                }
                else
                {
                    outDir = new DirectoryInfo(outpath);
                    if (!outDir.Exists)
                    {
                        outDir = new DirectoryInfo(outpath);
                    }
                }

                DirectoryInfo rawOutDirInfo = null;
                if (string.IsNullOrEmpty(rawOutDir))
                {
                    rawOutDirInfo = outDir;
                }
                else
                {
                    rawOutDirInfo = new DirectoryInfo(rawOutDir);
                    if (!rawOutDirInfo.Exists)
                    {
                        rawOutDirInfo = new DirectoryInfo(rawOutDir);
                    }
                }

                // read archive
                var ar = Red4ParserServiceExtensions.ReadArchive(processedarchive.FullName, _hashService);

                // run
                if (hash != 0)
                {
                    _modTools.UncookSingle(ar, hash, outDir, exportArgs, rawOutDirInfo, forcebuffers);
                    _loggerService.Success($" {ar.ArchiveAbsolutePath}: Uncooked one file: {hash}");
                }
                else
                {
                    _modTools.UncookAll(ar, outDir, exportArgs, unbundle, pattern, regex, rawOutDirInfo, forcebuffers);
                }
            }

            return;
        }

        #endregion Methods
    }
}
