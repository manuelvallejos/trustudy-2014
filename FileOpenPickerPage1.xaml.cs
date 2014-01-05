using trustudy_2014.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Contrato del selector para abrir archivos está documentada en http://go.microsoft.com/fwlink/?LinkId=234239

namespace trustudy_2014
{
    /// <summary>
    /// Esta página muestra los archivos que pertenecen a la aplicación para que el usuario pueda conceder acceso a los mismos
    /// a otra aplicación.
    /// </summary>
    public sealed partial class FileOpenPickerPage1 : Page
    {
        /// <summary>
        /// Los archivos se agregan a la IU de Windows o se quitan de esta para informar a Windows de la selección realizada.
        /// </summary>
        private Windows.Storage.Pickers.Provider.FileOpenPickerUI _fileOpenPickerUI;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// Este puede cambiarse a un modelo de vista fuertemente tipada.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public FileOpenPickerPage1()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Window_SizeChanged;
            InvalidateVisualState();
        }

        void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            this.InvalidateVisualState();
        }

        private void InvalidateVisualState()
        {
            var visualState = DetermineVisualState();
            VisualStateManager.GoToState(this, visualState, false);
        }

        private string DetermineVisualState()
        {
            return Window.Current.Bounds.Width >= 500 ? "HorizontalView" : "VerticalView";
        }

        /// <summary>
        /// Se invoca cuando otra aplicación desea abrir archivos de esta aplicación.
        /// </summary>
        /// <param name="e">Datos de activación usados para coordinar el proceso con Windows.</param>
        public void Activate(FileOpenPickerActivatedEventArgs e)
        {
            this._fileOpenPickerUI = e.FileOpenPickerUI;
            _fileOpenPickerUI.FileRemoved += this.FilePickerUI_FileRemoved;

            // TODO: Establecer this.DefaultViewModel["Files"] para mostrar una colección de elementos,
            //       cada uno de los cuales debe tener propiedades Image, Title y Description enlazables

            this.DefaultViewModel["CanGoUp"] = false;
            Window.Current.Content = this;
            Window.Current.Activate();
        }

        /// <summary>
        /// Se invoca cuando el usuario quita uno de los elementos de la cesta del selector
        /// </summary>
        /// <param name="sender">Instancia de FileOpenPickerUI usada para contener los archivos disponibles.</param>
        /// <param name="e">Datos de evento que describen el archivo quitado.</param>
        private void FilePickerUI_FileRemoved(Windows.Storage.Pickers.Provider.FileOpenPickerUI sender, Windows.Storage.Pickers.Provider.FileRemovedEventArgs e)
        {
            // TODO: Responder a la desactivación de un elemento en la IU del selector.
        }

        /// <summary>
        /// Se invoca cuando cambia la colección de archivos seleccionada.
        /// </summary>
        /// <param name="sender">Instancia de GridView usada para mostrar los archivos disponibles.</param>
        /// <param name="e">Datos de evento que describen cómo cambió la selección.</param>
        private void FileGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Actualizar IU de Windows con this._fileOpenPickerUI.AddFile y
            //       this._fileOpenPickerUI.RemoveFile
        }

        /// <summary>
        /// Se invoca al hacer clic en el botón "Subir", lo que indica que el usuario desea emerger
        /// un nivel en la jerarquía de archivos.
        /// </summary>
        /// <param name="sender">Instancia de Button usada para representar el comando "Subir".</param>
        /// <param name="e">Datos de evento que describen cómo se hizo clic en el botón.</param>
        private void GoUpButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Establecer this.DefaultViewModel["CanGoUp"] en true para habilitar el comando correspondiente,
            //       usar las actualizaciones de this.DefaultViewModel["Files"] para reflejar el recorrido de la jerarquía de archivos
        }
    }
}
