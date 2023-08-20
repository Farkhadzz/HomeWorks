using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhiteBoard.View
{
    public partial class BoardView : UserControl
    {
        private readonly DrawingAttributes PenAttributes = new()
        {
            Color = Colors.Black,
            Height = 2,
            Width = 2
        };

        private readonly DrawingAttributes HighlighterAttributes = new()
        {
            Color = Colors.Yellow,
            Height = 10,
            Width = 2,
            IgnorePressure = true,
            IsHighlighter = true,
            StylusTip = StylusTip.Rectangle
        };
        public BoardView()
        {
            InitializeComponent();
            Canvas.DefaultDrawingAttributes = PenAttributes;
        }

        #region Editing Mode

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Select);
        }

        private void PenBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Pen);
        }

        private void HighlighterBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Highlighter);
        }

        private void EraserBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Eraser);
        }

        private void SetEditingMode(EditingMode mode)
        {
            SelectBtn.IsChecked = false;
            PenBtn.IsChecked = false;
            EraserBtn.IsChecked = false;

            switch (mode)
            {
                case EditingMode.Select:
                    SelectBtn.IsChecked = true;
                    Canvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case EditingMode.Pen:
                    PenBtn.IsChecked = true;
                    Canvas.EditingMode = InkCanvasEditingMode.Ink;
                    Canvas.DefaultDrawingAttributes = PenAttributes;
                    break;

                case EditingMode.Eraser:
                    EraserBtn.IsChecked = true;
                    if (PartialStrokeRadio.IsChecked == true)
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    else
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

                default:
                    break;
            }
        }

        #endregion
        #region Pen

        private void PenColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded)
                PenAttributes.Color = PenColorPicker.SelectedColor ?? Colors.Black;
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                PenAttributes.Width = ThicknessSlider.Value;
                PenAttributes.Height = ThicknessSlider.Value;
            }
        }

        #endregion
        #region Highlighter

        private void YellowRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Yellow;
        }

        private void CyanRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Cyan;
        }

        private void MagentaRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Magenta;
        }

        #endregion
        #region Eraser Type

        private void PartialStrokeRadio_Click(object sender, RoutedEventArgs e)
        {
            if (EraserBtn.IsChecked == true)
                Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void FullStrokeRadio_Click(object sender, RoutedEventArgs e)
        {
            if (EraserBtn.IsChecked == true)
                Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        #endregion

        private void SaveCanvasToFile(string filePath)
        {
            try
            {
                StrokeCollection strokes = Canvas.Strokes;

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    strokes.Save(fs);
                }

                MessageBox.Show("File saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message);
            }
        }
    }

    public enum EditingMode
    {
        Select, Pen, Highlighter, Eraser
    }
    }