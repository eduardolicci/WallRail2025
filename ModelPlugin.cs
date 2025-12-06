using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Tekla.Structures.Datatype;

namespace WallRail2025

{
    public class PluginData
    {
        #region Fields
        [StructuresField("BottomHeight")]
        public double BottomHeight;

        [StructuresField("SlopedHeight")]
        public double SlopedHeight;

        [StructuresField("TopHeight")]
        public double TopHeight;

        [StructuresField("BottomExtension")]
        public double BottomExtension;

        [StructuresField("TopExtension")]
        public double TopExtension;

        [StructuresField("BottomReturnLength")]
        public double BottomReturnLength;

        [StructuresField("TopReturnLength")]
        public double TopReturnLength;

        [StructuresField("RailOffset")]
        public double RailOffset;

        [StructuresField("RailGeometryType")]
        public string RailGeometryType;

        [StructuresField("SelectedProfileBox")]
        public string SelectedProfileBox;

        [StructuresField("SelectedMaterialBox")]
        public string SelectedMaterialBox;

        [StructuresField("NameBox")]
        public string NameBox;

        [StructuresField("ClassBox")]
        public string ClassBox;

        [StructuresField("FinishBox")]
        public string FinishBox;





        #endregion
    }

    [Plugin("WallRail2025")]
    [PluginUserInterface("WallRail2025.MainForm")]
    public class WallRail2025 : PluginBase
    {
        #region Fields
        private Model _Model;
        private PluginData _Data;
        //
        // Define variables for the field values.
        //
        /* Some examples:
        private string _RebarName = string.Empty;
        private string _RebarSize = string.Empty;
        private string _RebarGrade = string.Empty;
        private ArrayList _RebarBendingRadius = new ArrayList();
        private int _RebarClass = new int();
        private double _RebarSpacing;
        */
        
        private double bottomHeight;
        private double slopedHeight;
        private double topHeight;
        private double bottomExtension;
        private double topExtension;
        private double bottomReturnLength;
        private double topReturnLength;
        private double railOffset;
        private string railGeometryType;
        private string selectedProfileBox;
        private string selectedMaterialBox;
        private string nameBox;
        private string classBox;
        private string finishBox;
        #endregion

        #region Properties
        private Model Model
        {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }
        #endregion

        #region Constructor
        public WallRail2025(PluginData data)
        {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides
        public override List<InputDefinition> DefineInput()
        {
            //
            // This is an example for selecting two points; change this to suit your needs.
            //
            List<InputDefinition> PointList = new List<InputDefinition>();
            Picker Picker = new Picker();
            ArrayList PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);

            PointList.Add(new InputDefinition(PickedPoints));

            return PointList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetValuesFromDialog();

                //
                // This is an example for selecting two points; change this to suit your needs.
                //
                ArrayList Points = (ArrayList)Input[0].GetInput();
                Point StartPoint = Points[0] as Point;
                Point EndPoint = Points[1] as Point;

                CreateSlopedRail(StartPoint, EndPoint);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }

            return true;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog()
        {
            if (IsDefaultValue(_Data.BottomHeight))
            {
                _Data.BottomHeight = (36 * 25.4);
                bottomHeight = _Data.BottomHeight;
                MessageBox.Show(bottomHeight.ToString());

            }
            else
            {
                bottomHeight = _Data.BottomHeight;
            }

            if (IsDefaultValue(_Data.SlopedHeight))
            {
                _Data.SlopedHeight = (36 * 25.4);
                slopedHeight = _Data.SlopedHeight;
            }
            else
            {
                slopedHeight = _Data.SlopedHeight;
            }

            if (IsDefaultValue(_Data.SelectedProfileBox))
            {
                _Data.SelectedProfileBox = "PIPE1-1/2STD";
                selectedProfileBox = _Data.SelectedProfileBox;
            }
            else
            {
                selectedProfileBox = _Data.SelectedProfileBox;
            }

            if (IsDefaultValue(_Data.SelectedMaterialBox))
            {
                _Data.SelectedMaterialBox = "A500-GR.B";
                selectedMaterialBox = _Data.SelectedMaterialBox;
            }
            else
            {
                selectedMaterialBox = _Data.SelectedMaterialBox;
            }

            if (IsDefaultValue(_Data.RailGeometryType))
            {
                _Data.RailGeometryType = "1";
                railGeometryType = _Data.RailGeometryType;
            }

            else
            {
                railGeometryType = _Data.RailGeometryType;
            }

        }

        // Write your private methods here.

        private void CreateSlopedRail(Point StartPoint, Point EndPoint)
        {
            Model model = new Model();

            if (!model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla Structures is not connected.");
                return;
            }

            Point SlopedRail_Start = new Point(StartPoint);
            Point SlopedRail_End = new Point(EndPoint);
            SlopedRail_Start.Translate(0, 0, slopedHeight);
            SlopedRail_End.Translate(0, 0, slopedHeight);

            Beam rail = new Beam(SlopedRail_Start, SlopedRail_End);
            rail.Profile.ProfileString = selectedProfileBox;
            rail.Material.MaterialString = selectedMaterialBox;
            rail.Class = classBox;

            bool isInserted = rail.Insert();

            if (isInserted){
                Model.CommitChanges();

            }

            else
            {
                MessageBox.Show("Rail not inserted.");
            }
        }

        #endregion
    }
}
