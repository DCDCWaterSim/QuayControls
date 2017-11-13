using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuayControls
{
    public partial class PropertyView : UserControl
    {
        string fLabel = "";
        int FIntValue = int.MinValue;
        double FDoubleValue = double.MinValue;
        bool FEditMode = false;
        bool FAutoSize = false; 
        string FStringValue = "";

        int LeftOffset = 5;
        int TopOffset = 5;


        //---------------------------------------------------------
        public PropertyView()
        {
            InitializeComponent();
            PropertyLabel.Text = fLabel;
            PropertyTextbox.Text = "";
            FEditMode = false;
            FAutoSize = true;
        }
        //---------------------------------------------------------
        public PropertyView(string TheLabel, string TheValue)
        {
            InitializeComponent();
            fLabel = TheLabel;
            PropertyLabel.Text = TheLabel;
            PropertyTextbox.Text = TheValue;
            FEditMode = false;
            FAutoSize = true;
        }
        //---------------------------------------------------------
        public PropertyView(string TheLabel, string TheValue, bool isEditable, bool isAutoSize)
        {
            InitializeComponent();
            fLabel = TheLabel;
            PropertyLabel.Text = TheLabel;
            FStringValue = TheValue;
            FEditMode = isAutoSize;
            FAutoSize = isAutoSize;
            ResetControl();
        }
        //---------------------------------------------------------
        internal void ResetControl()
        {
            string UseLabel = "";
            System.Drawing.Size ValueSize = System.Windows.Forms.TextRenderer.MeasureText(FStringValue, PropertyTextbox.Font);
            System.Drawing.Size LabSize = System.Windows.Forms.TextRenderer.MeasureText(fLabel, PropertyLabel.Font);
            if (AutoSize)
            {
                int VWidth = ValueSize.Width;
                int LWidth = LabSize.Width;
                PropertyLabel.Left = LeftOffset;
                PropertyLabel.Top = TopOffset;
                PropertyLabel.Width = LWidth;
                PropertyTextbox.Left = LeftOffset + LWidth;
                PropertyTextbox.Top = TopOffset;
                PropertyTextbox.Width = VWidth;

                
                UseLabel = fLabel ;

            }
            else
            {
                UseLabel = fLabel;
                int XLabel = LeftOffset;
                int YLabel = TopOffset;
                int XValue = Width / 2;
                int YValue = TopOffset;
                int WidthValue = (Width / 2)-LeftOffset;
                int WidthLabel = (Width / 2) - LeftOffset;
                
                PropertyLabel.Left = XLabel;
                PropertyLabel.Top = YLabel;
                PropertyLabel.Width = WidthLabel;
                PropertyTextbox.Left = XValue;
                PropertyTextbox.Top = YValue;
                PropertyTextbox.Width = WidthValue;

            }
            PropertyLabel.Text = UseLabel;
            PropertyTextbox.Text = FStringValue;
            PropertyTextbox.Enabled = FEditMode;
        }
        //---------------------------------------------------------
        public string AsString
        {
            get { return FStringValue; }
            set { 
                    FStringValue = value;
                    double tempd = double.NaN;
                    if (!double.TryParse(value, out FDoubleValue))
                    {
                        FDoubleValue = double.NaN;
                    }
                    if (!int.TryParse(value, out FIntValue))
                    {
                        FIntValue = 0;
                    }
                    ResetControl();
                }
        }
        //---------------------------------------------------------
        public int AsInt
        {
            get { return FIntValue; }
            set { 
                    FIntValue = value;
                    FDoubleValue = value;
                    FStringValue = value.ToString();
                    ResetControl();
            }
        }
        //---------------------------------------------------------
        public double AsDouble
        {
            get { return FDoubleValue; }
            set { 
                   FDoubleValue = value;
                   if ((value <= int.MaxValue) && (value >= int.MinValue))
                   {
                       FIntValue = Convert.ToInt32(Math.Truncate(value));
                   }
                   else
                       FIntValue = 0;
                   ResetControl();
                }
        }
        //---------------------------------------------------------
        public bool EditMode
        {
            get { return FEditMode; }
            set { 
                    FEditMode = value;
                    ResetControl();
                }
        }
        //---------------------------------------------------------
        public string Label
        {
            get { return fLabel; }
            set
            {
                fLabel = value;
                ResetControl();
            }
        }

        private void PropertyView_Resize(object sender, EventArgs e)
        {
            ResetControl();

        }
        //---------------------------------------------------------
        

    }
}
