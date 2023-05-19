using System;
using System.IO;
using Activities.CustomLib.Files.Properties;
using BR.Core;
using BR.Core.Attributes;
using Path = BR.Core.Attributes.Path;

namespace Activities.CustomLib.Files.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("DOF_ScreenName", typeof(Resources))]
    [LocalizableDescription("DOF_Description", typeof(Resources))]
    [LocalizableRepresentation("DOF_Representation", typeof(Resources))]
    [Image(typeof(DeleteOldFiles), "Activities.CustomLib.Files.Images.files_deleting_icon.png")]
    public class DeleteOldFiles : Activity
    {
        private const string DAYS_VALIDATION_ERROR = "Количество дней должно быть положительным числом!",
                             EXTENSION_VALIDATION_ERROR = "Расширение файла не должно начинаться с точки!";

        #region [PROPERTIES]

        [LocalizableScreenName("DOF_Folder_ScreenName", typeof(Resources))]
        [LocalizableDescription("DOF_Folder_Description", typeof(Resources))]
        [IsRequired]
        [IsFilePathChooser]
        public string Folder { get; set; }

        [LocalizableScreenName("DOF_Days_ScreenName", typeof(Resources))]
        [LocalizableDescription("DOF_Days_Description", typeof(Resources))]
        [IsRequired]
        public int Days { get; set; }

        [LocalizableScreenName("DOF_Extension_ScreenName", typeof(Resources))]
        [LocalizableDescription("DOF_Extension_Description", typeof(Resources))]
        public string Extension { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            var filesArr = GetFilesInFolder(Folder, Extension);
            DeleteFilesOlderThan(filesArr, Days);
        }
        #endregion

        #region [ADVANCED]
        /// <summary>
        /// Метод для определения списка файлов указанного расширения, которые хранятся в указанной папке.
        /// </summary>
        /// <param name="folderPath">Путь до целевой папки.</param>
        /// <param name="extension">Расширение файлов, которые требуется получить.</param>
        /// <returns>Перечень путей до файлов.</returns>
        static string[] GetFilesInFolder(string folderPath, string extension)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new ArgumentException($"Папка '{folderPath}' не существует.", nameof(folderPath));
            }

            try
            {
                if (string.IsNullOrEmpty(extension))
                {
                    return Directory.GetFiles(folderPath);
                }
                else
                {
                    if (extension.Trim().StartsWith("."))
                    {
                        throw new ArgumentException(EXTENSION_VALIDATION_ERROR);
                    }

                    string searchPattern = $"*.{extension.Trim()}";
                    return Directory.GetFiles(folderPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch
            {
                throw new ArgumentException($"Файлы в папке '{folderPath}' не найдены.", nameof(folderPath));
            }
        }

        /// <summary>
        /// Метод для удаления файлов, если срок их хранения истек.
        /// </summary>
        /// <param name="files">Перечень файлов для проверки.</param>
        /// <param name="days">Срок хранения файлов в днях.</param>
        /// <returns></returns>
        static void DeleteFilesOlderThan(string[] files, int days)
        {
            if (days < 0)
            {
                throw new ArgumentException(DAYS_VALIDATION_ERROR);
            }

            DateTime thresholdDate = DateTime.Now.AddDays(-days);

            foreach (string file in files)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.LastWriteTime < thresholdDate)
                    {
                        fileInfo.Delete();
                        Console.WriteLine($"Удален: {file}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка удаления файла {file}: {ex.Message}");
                }
            }
        }
        #endregion
    }
}

