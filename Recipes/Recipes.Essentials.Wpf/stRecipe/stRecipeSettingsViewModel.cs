using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Vortex.Connector;
using Vortex.Presentation.Wpf;

namespace HansPlc
{
    /// <summary>
    /// ViewModel for <see cref="stRecipeSettingsView"/>.
    /// </summary>
    public class stRecipeSettingsViewModel : RenderableViewModel
    {
        private const string DisplayModePresentationType = "ShadowDisplay";

        private const string EditModePresentationType = "ShadowControl";

        private const string RecipieFileSuffix = "rcp";

        object dataPresentation;

        string fileName;

        string selectedRecipeName;

        /// <summary>
        /// Creates new instance of <see cref="stRecipeSettingsViewModel"/>
        /// </summary>
        public stRecipeSettingsViewModel()
        {
            if (!Directory.Exists(RecipesDirectory))
            {
                Directory.CreateDirectory(RecipesDirectory);
            }

            Recipe = new stRecipe();
            this.SaveCommand = new RelayCommand(a => this.Save(), p => this.LockRecipeSelection);
            this.EditCommand = new RelayCommand(a => this.Edit(), p => !this.LockRecipeSelection);
            this.CreateNewCommand = new RelayCommand(a => this.CreateNew(), p => !this.LockRecipeSelection);
            this.SendToPlcCommand = new RelayCommand(a => this.SendToPlc(), p => !this.LockRecipeSelection);
            this.DeleteRecordCommand = new RelayCommand(a => this.DeleteRecord(), p => !this.LockRecipeSelection);
            this.StopEditingCommand = new RelayCommand(a => this.StopEditing(), p => this.LockRecipeSelection);
            this.OpenLogFileCommand = new RelayCommand(a => this.OpenLogFile(), p => !this.LockRecipeSelection);
        }

        /// <summary>
        /// Creates new recipe.
        /// </summary>
        private void CreateNew()
        {
            // Creates and empty plain object that is used to clear shadow value of 'Recipe' object.
            var emptyPlain = this.Recipe.CreatePlainerType();            
            emptyPlain.CopyPlainToShadow(this.Recipe);
           
            EditDataMode();
        }

        private void DisplayDataMode()
        {
            this.DataPresentation = LazyRenderer.Get.CreatePresentation(DisplayModePresentationType, this.Recipe);
            this.LockRecipeSelection = false;
        }

        private void Edit()
        {
            EditDataMode();
        }

        private void EditDataMode()
        {
            // Creates presentation of the Recipe object - editable form.
            this.DataPresentation = LazyRenderer.Get.CreatePresentation(EditModePresentationType, this.Recipe);
            this.SetUpLogging();
            this.LockRecipeSelection = true;
        }

        private void SetUpLogging()
        {
            foreach (var valueTag in ((stRecipe)this.Recipe).RetrieveValueTags())
            {
                valueTag.ShadowValueChange = CaptureValueChange;
            }
        }

        private void CaptureValueChange(IValueTag valueTag, dynamic original, dynamic newvalue)
        {
            using (var swr = new System.IO.StreamWriter(LogFile, true))
            {
                swr.WriteLine($"\"{this.Recipe._recipeName.Value}\", \"{valueTag.HumanReadable}\", \"{valueTag.Symbol}\", \"{original}\", \"{newvalue}\"");
            }
        }

        private void OpenLogFile()
        {
            Process.Start("notepad.exe", this.LogFile);
        }


        private string LogFile
        {
            get
            {
                return Path.Combine(this.RecipesDirectory, "changes.log");
            }
        }

        private string GetRecipeFileFullPath(string recipeFileName)
        { return Path.Combine(this.RecipesDirectory, recipeFileName); }

        private void OpenFile(string recipeName)
        {
            try
            {
                if (recipeName == null)
                    return;

                using (var streamReader = new System.IO.StreamReader(GetRecipeFileFullPath(GetRecipeFileName(recipeName))))
                {
                    var plain = Recipe.CreatePlainerType();
                    plain.CopyShadowToPlain(this.Recipe);

                    var serializer = new System.Xml.Serialization.XmlSerializer(plain.GetType());
                    plain = serializer.Deserialize(streamReader) as PlainstRecipe;

                    plain.CopyPlainToShadow(this.Recipe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                "There was an error opening the recipe",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private string GetRecipeFileName(string recipeName)
        {
            return $"{recipeName}.{RecipieFileSuffix}";
        }

        private void Save()
        {
            DisplayDataMode();
            this.SaveToFile();
            this.SelectedRecipeName = this.Recipe._recipeName.Value;
            this.OnPropertyChanged(nameof(RecipesList));
        }

        private void SaveToFile()
        {
            try
            {
                using (var streamWriter = new System.IO.StreamWriter(GetRecipeFileFullPath(GetRecipeFileName(Recipe._recipeName.Value))))
                {
                    var plain = Recipe.CreatePlainerType();
                    plain.CopyShadowToPlain(this.Recipe);

                    var serializer = new System.Xml.Serialization.XmlSerializer(plain.GetType());
                    serializer.Serialize(streamWriter, plain);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                "There was an error saving the recipe",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        public void UpdateRecipesList() { this.OnPropertyChanged(nameof(RecipesList)); }
        private void SendToPlc()
        {
            this.Recipe.FlushShadowToOnline();
        }
        private void DeleteRecord()
        {
            try
            {
                if (MessageBox.Show($"Sure to delete {this.SelectedRecipeName}?", "Deleting recipe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Delete(this.GetRecipeFileFullPath(this.SelectedRecipeName));
                    this.OnPropertyChanged(nameof(RecipesList));
                    this.SelectedRecipeName = this.RecipesList.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                   "There was an error delting the recipe",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
            }
        }
        private void StopEditing()
        {
            this.DataPresentation = LazyRenderer.Get.CreatePresentation(DisplayModePresentationType, this.Recipe);
            this.LockRecipeSelection = false;
            this.OpenFile(this.SelectedRecipeName);
        }

        public RelayCommand CreateNewCommand { get; }

        public object DataPresentation
        {
            get { return dataPresentation; }
            set
            {
                if (dataPresentation == value)
                {
                    return;
                }

                SetProperty(ref dataPresentation, value);
            }
        }

        public RelayCommand EditCommand { get; }

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName == value)
                {
                    return;
                }

                SetProperty(ref fileName, value);
            }
        }

        public override object Model { get => Recipe; set { Recipe = value as stRecipe; this.SelectedRecipeName = this.RecipesList.FirstOrDefault(); } }

        public IShadowstRecipe Recipe { get; private set; }

        public string RecipesDirectory { get; set; } = Path.Combine(Environment.CurrentDirectory, "Recipes");

        public IEnumerable<string> RecipesList
        {
            get
            {
                return Directory.EnumerateFiles(this.RecipesDirectory).Where(p => p.EndsWith($".{RecipieFileSuffix}")).Select(p => new FileInfo(p)).Select(f => f.Name.Substring(0, f.Name.Length - (RecipieFileSuffix.Length + 1)));
            }
        }

        public RelayCommand SaveCommand { get; }

        public RelayCommand SendToPlcCommand { get; }

        public RelayCommand DeleteRecordCommand { get; }

        public RelayCommand StopEditingCommand { get; }

        public RelayCommand OpenLogFileCommand { get; }

        public string SelectedRecipeName
        {
            get { return selectedRecipeName; }
            set
            {
                if (selectedRecipeName == value)
                {
                    return;
                }

                SetProperty(ref selectedRecipeName, value);

                this.OpenFile(selectedRecipeName);
                this.DataPresentation = LazyRenderer.Get.CreatePresentation(DisplayModePresentationType, this.Recipe);
            }
        }

        bool lockRecipeSelection;
        public bool LockRecipeSelection
        {
            get
            {
                return lockRecipeSelection;
            }
            set
            {
                if (lockRecipeSelection == value)
                {
                    return;
                }

                SetProperty(ref lockRecipeSelection, value);
            }
        }
    }       
}
