using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Tekla.CustomUtilities;


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

        [StructuresField("DirectionBox")]
        public string DirectionBox;

        [StructuresField("TypeBox")]
        public string TypeBox;

        [StructuresField("BracketSpacingBox")]
        public double BracketSpacingBox;

        [StructuresField("StartOffsetBox")]
        public double StartOffsetBox;

        [StructuresField("EndOffsetBox")]
        public double EndOffsetBox;

        [StructuresField("TopBracketDistance")]
        public double TopBracketDistance;

        [StructuresField("BottomBracketDist")]
        public double BottomBracketDistance;

        [StructuresField("SpacingConditionBox")]
        public string SpacingConditionBox;

        [StructuresField("AlignmentBox")]
        public string AlignmentBox;

        [StructuresField("PartPrefixBox")]
        public string PartPrefixBox;

        [StructuresField("PartStartNumberBox")]
        public int PartStartNumberingBox;

        [StructuresField("AssemblyPrefixBox")]
        public string AssemblyPrefixBox;

        [StructuresField("AssemblyStartNumberBox")]
        public int AssemblyStartNumberingBox;

        [StructuresField("FirstRiserHeight")]
        public double FirstRiserHeight;
        #endregion
    }

    [Plugin("WallRail2025")]
    [PluginUserInterface("WallRail2025.MainForm")]
    public class WallRail2025 : PluginBase
    {
        #region Fields
        private Model _Model;
        private PluginData _Data;
        
        private double bottomHeight;
        private double slopedHeight;
        private double topHeight;
        private double bottomExtension;
        private double topExtension;
        private double bottomReturnLength;
        private double topReturnLength;
        private double railOffset;
        private double firstRiserHeight;
        private string selectedProfileBox;
        private string selectedMaterialBox;
        private string nameBox;
        private string classBox;
        private string finishBox;
        private string directionBox;
        private string typeBox;
        private double bracketSpacingBox;
        private double startOffsetBox;
        private double endOffsetBox;
        private double topBracketDistance;
        private double bracketDistanceBottom;
        private string spacingConditionBox;
        private string alignmentBox;
        private string partPrefixBox;
        private int partStartNumberBox;
        private string assemblyPrefixBox;
        private int assemblyStartNumberBox;
        public static string bracketShape = "WAGNER 1251R";
        public static double atDepth = InchToMM(-1.5690);

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

                ArrayList Points = (ArrayList)Input[0].GetInput();
                Point StartPoint = Points[0] as Point;
                Point EndPoint = Points[1] as Point;

                CreateRail(StartPoint, EndPoint);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }

            return true;
        }
        #endregion

        #region Private methods
        private void GetValuesFromDialog()
        {
            //WallRail Parameters
            bottomHeight = _Data.BottomHeight;
            slopedHeight = _Data.SlopedHeight;
            topHeight = _Data.TopHeight;
            bottomExtension = _Data.BottomExtension;
            topExtension = _Data.TopExtension;
            bottomReturnLength = _Data.BottomReturnLength;
            topReturnLength = _Data.TopReturnLength;
            railOffset = _Data.RailOffset;
            firstRiserHeight = _Data.FirstRiserHeight;
            selectedProfileBox = _Data.SelectedProfileBox;
            selectedMaterialBox = _Data.SelectedMaterialBox;
            nameBox = _Data.NameBox;
            classBox = _Data.ClassBox;
            finishBox = _Data.FinishBox;
            directionBox = _Data.DirectionBox;
            typeBox = _Data.TypeBox;
            partPrefixBox = _Data.PartPrefixBox;
            

            //Bracket Parameters
            bracketSpacingBox = _Data.BracketSpacingBox;
            startOffsetBox = _Data.StartOffsetBox;
            endOffsetBox = _Data.EndOffsetBox;
            topBracketDistance = _Data.TopBracketDistance;
            bracketDistanceBottom = _Data.BottomBracketDistance;
            spacingConditionBox = _Data.SpacingConditionBox;
            alignmentBox = _Data.AlignmentBox;
           
            //Wallrail Parameters
            if (IsDefaultValue(bottomHeight))
            {
                bottomHeight = InchToMM(36);
                
            }
            else
            {
                bottomHeight = InchToMM(bottomHeight);
            }

            // First Riser Height — subtract from bottomHeight to get the effective rail height above the floor
            if (IsDefaultValue(firstRiserHeight))
            {
                firstRiserHeight = InchToMM(7);
            }
            else
            {
                firstRiserHeight = InchToMM(firstRiserHeight);
            }

            if (firstRiserHeight >= bottomHeight)
            {
                MessageBox.Show(
                    $"Warning: First Riser Height ({firstRiserHeight / 25.4:F2}\") is equal to or greater than Bottom Height ({bottomHeight / 25.4:F2}\"). " +
                    "The effective bottom height would be zero or negative. Please check your values.",
                    "Invalid First Riser Height",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                bottomHeight -= firstRiserHeight;
            }

            if (IsDefaultValue(slopedHeight))
            {
                slopedHeight = InchToMM(36);
            }
            else
            {
                slopedHeight = InchToMM(slopedHeight);
            }

            if (IsDefaultValue(topHeight))
            {
                topHeight = InchToMM(36);
            }
            else
            {
                topHeight = InchToMM(topHeight);
            }

            if (IsDefaultValue(bottomExtension))
            {
                bottomExtension = InchToMM(12);
            }
            else
            {
                bottomExtension = InchToMM(bottomExtension);
            }

            if (IsDefaultValue(topExtension))
            {
                topExtension = InchToMM(12);
            }
            else
            {
                topExtension = InchToMM(topExtension);
            }

            if (IsDefaultValue(bottomReturnLength))
            {
                bottomReturnLength = InchToMM(3);
            }
            else
            {
                bottomReturnLength = InchToMM(bottomReturnLength);
            }

            if (IsDefaultValue(topReturnLength))
            {
                topReturnLength = InchToMM(3);
            }
            else
            {
                topReturnLength = InchToMM(topReturnLength);
            }

            if (IsDefaultValue(railOffset))
            {
                railOffset = InchToMM(3.25);
            }
            else
            {
                railOffset = InchToMM(railOffset);
            }

            if (IsDefaultValue(selectedProfileBox))
            {
                selectedProfileBox = "PIPE1-1/2STD";
            }
            

            if (IsDefaultValue(selectedMaterialBox))
            {
                selectedMaterialBox = "A500-GR.B";
            }

            if (IsDefaultValue(nameBox))
            {
                nameBox = "WALLRAIL";
            }

            if (IsDefaultValue(classBox))
            {
                classBox = "6";
            }
            if (IsDefaultValue(finishBox))
            {
                finishBox = "";
            }

            if (IsDefaultValue(directionBox))
            {
                directionBox = "left";
            }

            if (IsDefaultValue(typeBox))
            {
                typeBox = "leveled";
            }

            if (IsDefaultValue(partPrefixBox))
            {
                partPrefixBox = "";
            }
            if (IsDefaultValue(partStartNumberBox))
            {
                partStartNumberBox = 1;
            }

            if (IsDefaultValue(assemblyPrefixBox))
            {
                assemblyPrefixBox = "1WR";
            }
            
            if (IsDefaultValue(assemblyStartNumberBox))
            {
                assemblyStartNumberBox = 1;
            }


            //bracket Parameters
            if (IsDefaultValue(bracketSpacingBox))
            {
                bracketSpacingBox = InchToMM(60);
            }
            else
            {
                bracketSpacingBox = InchToMM(bracketSpacingBox);
            }

            if (IsDefaultValue(startOffsetBox))
            {
                startOffsetBox = InchToMM(6);
            }
            else
            {
                startOffsetBox= InchToMM(startOffsetBox);
            }

            if (IsDefaultValue(endOffsetBox))
            {
                endOffsetBox = InchToMM(6);
            }
            else
            {
                endOffsetBox = InchToMM(endOffsetBox);
            }

            if (IsDefaultValue(topBracketDistance))
            {
                topBracketDistance = InchToMM(6);
            }
            else
            {
                topBracketDistance = InchToMM(topBracketDistance);
            }

            if (IsDefaultValue(bracketDistanceBottom))
            {
                bracketDistanceBottom = InchToMM(6);
            }
            else
            {
                bracketDistanceBottom = InchToMM(bracketDistanceBottom);
            }

            if (IsDefaultValue(spacingConditionBox))
            {
                spacingConditionBox = "max";
            }
            if (IsDefaultValue(alignmentBox))
            {
                alignmentBox = "middle";
            }
        }


        private void CreateRail(Point StartPoint, Point EndPoint)
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

            List<Point> polybeamPoints = new List<Point>();

            //rail direction
            Vector railDirectionVector = new Vector(SlopedRail_Start + SlopedRail_End);
            railDirectionVector.Normalize();


            
            //getting sloped rail start point
            Point slopedRailStartExtended;
            double bottomTargetZ = StartPoint.Z + bottomHeight;

            if (!FindIntersectionWithHorizontalPlane(SlopedRail_Start, SlopedRail_End, bottomTargetZ, out slopedRailStartExtended))
            {
                MessageBox.Show("Error: Intersection Point not found for slopedRailStartExtended point");
            }

            Console.WriteLine(typeBox.ToString());
            if (typeBox == "leveled") //if leveled we get the extension point
            {
                //getting horizontal direction vector
                Vector bottomExtensionDirectionVector = new Vector(railDirectionVector.X, railDirectionVector.Y, 0);
                bottomExtensionDirectionVector.Normalize();
                //getting bottom extension point
                Point bottomExtensionPoint = MoveWithDirectionVector(StartPoint, bottomExtensionDirectionVector, bottomExtension, true);
                bottomExtensionPoint.Z += bottomHeight;
                //getting return point
                Point returnPoint = GetReturnPoint(bottomExtensionPoint, railDirectionVector, bottomReturnLength);
                //adding points to polybeam
                polybeamPoints.Add(returnPoint);
                polybeamPoints.Add(bottomExtensionPoint);
            }

            else // else rail is straight and we only need to get the return point
            {
                //getting bottom return point
                Point returnPoint = GetReturnPoint(slopedRailStartExtended, railDirectionVector, bottomReturnLength);
                //adding points to polybeam
                polybeamPoints.Add(returnPoint);
            }

            polybeamPoints.Add(slopedRailStartExtended);


            // Adjust SlopedRail_End if topHeight is not equal to sloped rail height
            if (topHeight != slopedHeight)
            {
                double topTargetZ = EndPoint.Z + topHeight;
                Point adjustedEnd;
                if (FindIntersectionWithHorizontalPlane(SlopedRail_Start, SlopedRail_End, topTargetZ, out adjustedEnd))
                {
                    SlopedRail_End = adjustedEnd;
                }
            }
            polybeamPoints.Add(SlopedRail_End);

            //getting direction vector for top extension
            Vector topExtensionDirectionVector = new Vector(railDirectionVector.X, railDirectionVector.Y, 0);
            topExtensionDirectionVector.Normalize();

            // Calculate extension point using Tekla API Point.Translate
            Vector topExtensionMove = topExtensionDirectionVector * topExtension;
            Point topExtensionPoint = new Point(EndPoint);
            topExtensionPoint.Translate(topExtensionMove.X, topExtensionMove.Y, topHeight);

            // Calculate return point perpendicular to rail direction
            Vector upVector = new Vector(0, 0, 1);
            Vector sideVector = topExtensionDirectionVector.Cross(upVector);
            if (directionBox == "left")
            {
                sideVector = sideVector * -1.0;
            }
            sideVector.Normalize();
            Vector finalMove = sideVector * topReturnLength;
            Point topReturnPoint = topExtensionPoint + finalMove;

            polybeamPoints.Add(topExtensionPoint);
            polybeamPoints.Add(topReturnPoint);



            PolyBeam rail = new PolyBeam();
            int currentPoint = 0;
            foreach (Point point in polybeamPoints)
            {
                if (currentPoint == 1 || currentPoint == polybeamPoints.Count-2)
                {
                    rail.AddContourPoint(new ContourPoint(point, new Chamfer(InchToMM(1.5), InchToMM(1.5), Chamfer.ChamferTypeEnum.CHAMFER_ROUNDING)));
                    
                }
                else
                {
                    rail.AddContourPoint(new ContourPoint(point, new Chamfer(InchToMM(3), InchToMM(3), Chamfer.ChamferTypeEnum.CHAMFER_ROUNDING)));
                }
                    
                currentPoint++;
            }

            rail.Profile.ProfileString = selectedProfileBox;
            rail.Material.MaterialString = selectedMaterialBox;
            rail.Name = nameBox;
            rail.Class = classBox;
            rail.Finish = finishBox;
            rail.Position.Depth = Position.DepthEnum.MIDDLE;
            rail.Position.Plane = Position.PlaneEnum.MIDDLE;
            rail.PartNumber.Prefix = partPrefixBox;
            rail.PartNumber.StartNumber = partStartNumberBox;
            rail.AssemblyNumber.Prefix = assemblyPrefixBox;
            rail.AssemblyNumber.StartNumber = assemblyStartNumberBox;

            bool isInserted = rail.Insert();
            Vector directionVector = VectorOperations.DirectionVector(polybeamPoints[0], polybeamPoints[1]);
            TranslationOperations.Move(rail, directionVector, railOffset);
            rail.Select();
            ArrayList updatedPolybeamPoints = rail.Contour.ContourPoints;

            InsertBrackets(updatedPolybeamPoints);

            if (isInserted)
            {
                Model.CommitChanges();

            }

            else
            {
                MessageBox.Show("Rail not inserted.");
            }
        }
        private Point GetReturnPoint(Point startPoint, Vector railDirection, double returnLength)
        {
            // 1. FLATTEN THE DIRECTION
            // We want the return to be horizontal, so we ignore the rail's slope.
            Vector flatDir = new Vector(railDirection.X, railDirection.Y, 0.0);
            

            // 2. DEFINE "UP"
            Vector upVector = new Vector(0, 0, 1);

            // 3. CALCULATE THE SIDE VECTOR (Cross Product)
            // rail x up = Right Side (usually, depending on coordinate system)
            Vector sideVector = flatDir.Cross(upVector);

            // 4. HANDLE LEFT VS RIGHT
            // The cross product gives us one side. To get the other, we flip it (-1).
            // You might need to swap these depending on exactly how you define "Left"
            if (directionBox == "left")
            {
                
                sideVector = sideVector * -1.0;
            }

            // 5. SCALE BY LENGTH
            sideVector.Normalize(); // Good practice to re-normalize after cross product
            Vector finalMove = sideVector * returnLength;

            // 6. CALCULATE POINT
            Point returnPoint = startPoint + finalMove;

            return returnPoint;
        }
        private Point StraightBottomExtensionPoint(Point SlopedRail_Start, Point SlopedRail_End, double bottomExtension)
        {
            // 1. Get the Direction Vector (Down the slope)
            // Assuming SlopedRail_Start is the bottom tip where we are extending from
            Vector direction = new Vector(SlopedRail_Start - SlopedRail_End);
            direction.Normalize(); // Make length 1.0

            // 2. Find the Horizontal Component (The "Run" of the unit vector)
            // This effectively gives us the Cosine of the slope angle
            // Sqrt(X*X + Y*Y) ignores Z (Height)
            double horizontalFactor = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            // Safety: If rail is perfectly vertical, we can't extend horizontally
            if (horizontalFactor < 0.001) return SlopedRail_Start;

            // 3. Calculate the Required 3D Length (Hypotenuse)
            // Formula: Hypotenuse = Horizontal_Target / Cos(angle)
            double real3DLength = bottomExtension / horizontalFactor;

            // 4. Create the scaled 3D vector
            Vector extensionVector = direction * real3DLength;

            // 5. Calculate the new point
            Point bottomExtensionPoint = SlopedRail_Start + extensionVector;

            return bottomExtensionPoint;
        }
        public void GetLeveledRailPoints(Point slopedRailTop, Point slopedRailBottom, Point bottomNosing, double bottomExtensionHeight, double bottomExtension, out Point bottomExtensionPoint, out Point bottomSlopedStartPoint)
        {
            double targetZ = bottomNosing.Z + bottomExtensionHeight;
            FindIntersectionWithHorizontalPlane(slopedRailTop, slopedRailBottom, targetZ, out bottomSlopedStartPoint);

            Vector directionVector = new Vector(slopedRailBottom + slopedRailTop);
            directionVector.Normalize();
            bottomExtensionPoint = MoveWithDirectionVector(bottomSlopedStartPoint, directionVector, bottomExtension, false);
        }
        public static double InchToMM (double inch)
        {
            return inch * 25.4;
        }

        /// <summary>
        /// Finds the intersection point of a line (defined by two points) with a horizontal plane at a given height
        /// Uses Tekla API Intersection.LineToPlane method
        /// </summary>
        /// <param name="point1">First point defining the line</param>
        /// <param name="point2">Second point defining the line</param>
        /// <param name="planeHeight">Z coordinate of the horizontal plane</param>
        /// <param name="intersectionPoint">The intersection point if found, null otherwise</param>
        /// <returns>True if intersection found, false otherwise</returns>
        private bool FindIntersectionWithHorizontalPlane(Point point1, Point point2, double planeHeight, out Point intersectionPoint)
        {
            Line line = new Line(point1, point2);
            GeometricPlane horizontalPlane = new GeometricPlane(
                new Point(0, 0, planeHeight),
                new Vector(0, 0, 1)
            );

            intersectionPoint = Intersection.LineToPlane(line, horizontalPlane);
            return intersectionPoint != null;
        }
        private void InsertBrackets(ArrayList polybeamPoints)
        {
            
            //if count is 6 rail is leveled
            if (polybeamPoints.Count == 6)
            {
                insertLeveledRailBrackets(polybeamPoints);
            }

            //if count is 5 rail is straight
            else if (polybeamPoints.Count == 5)
            {
                insertStraightRailBrackets(polybeamPoints);
            }

            else
            {
                MessageBox.Show("Unable to create brackets, polybeam count is neither 5 or 6");
            }
        }
        private void insertLeveledRailBrackets(ArrayList polybeamPoints)
        {
            // Point index map (0-based → 1-based label):
            // [0] = pt1 - bottom return tip
            // [1] = pt2 - bottom bend (return ↔ leveled junction)
            // [2] = pt3 - bottom slope start (leveled ↔ slope junction)
            // [3] = pt4 - top slope end (slope ↔ top leveled junction)
            // [4] = pt5 - top bend (top leveled ↔ return junction)
            // [5] = pt6 - top return tip
            Point bottomExtensionPoint = polybeamPoints[1] as Point; // pt2
            Point bottomStartPoint     = polybeamPoints[2] as Point; // pt3
            Point topEndPoint          = polybeamPoints[3] as Point; // pt4
            Point topExtensionPoint    = polybeamPoints[4] as Point; // pt5

            // --- Bottom bracket on the LEVELED section ---
            // Distance measured from pt2 in the direction pt2 → pt3
            Vector bottomLeveledDir = new Vector(bottomStartPoint - bottomExtensionPoint);
            bottomLeveledDir.Normalize();

            Point bottomBracketStartPoint = new Point(bottomExtensionPoint + (bottomLeveledDir * bracketDistanceBottom));
            Point bottomBracketEndPoint   = new Point(bottomBracketStartPoint + (bottomLeveledDir * InchToMM(3)));
            insertOneBracket(bottomBracketStartPoint, bottomBracketEndPoint);

            // --- Top bracket on the LEVELED section ---
            // Distance measured from pt5 in the direction pt5 → pt4
            Vector topLeveledDir = new Vector(topEndPoint - topExtensionPoint);
            topLeveledDir.Normalize();

            Point topBracketStartPoint = new Point(topExtensionPoint + (topLeveledDir * topBracketDistance));
            Point topBracketEndPoint   = new Point(topBracketStartPoint + (topLeveledDir * InchToMM(-3)));
            insertOneBracket(topBracketStartPoint, topBracketEndPoint);

            // --- Sloped section brackets ---
            Vector slopedBracketDirectionVector = new Vector(topEndPoint - bottomStartPoint);
            slopedBracketDirectionVector.Normalize();

            if (directionBox == "right")
            {
                Point slopedBracketStartPoint = MoveWithDirectionVector(bottomStartPoint, slopedBracketDirectionVector, startOffsetBox, false);
                Point slopedBracketEndPoint   = MoveWithDirectionVector(topEndPoint, slopedBracketDirectionVector, endOffsetBox, true);
                CopyBracketsAlongLine(slopedBracketStartPoint, slopedBracketEndPoint, spacingConditionBox, bracketSpacingBox, slopedBracketDirectionVector, alignmentBox, directionBox);
            }
            else
            {
                Point slopedBracketStartPoint = MoveWithDirectionVector(bottomStartPoint, slopedBracketDirectionVector, startOffsetBox, true);
                Point slopedBracketEndPoint   = MoveWithDirectionVector(topEndPoint, slopedBracketDirectionVector, endOffsetBox, false);
                CopyBracketsAlongLine(slopedBracketStartPoint, slopedBracketEndPoint, spacingConditionBox, bracketSpacingBox, slopedBracketDirectionVector, alignmentBox, directionBox);
            }
        }
        private void insertStraightRailBrackets(ArrayList polybeamPoints)
        {

        }
        private void insertOneBracket(Point startPoint, Point endPoint)
        {
            Brep bracket = new Brep();
            bracket.StartPoint = startPoint;
            bracket.EndPoint = endPoint;



            //bracket.StartPointOffset.Dz = InchToMM(-3.9574);
            //bracket.EndPointOffset.Dz = InchToMM( -3.9574);
            //bracket.Position.RotationOffset = 90;

            //bracket.StartPointOffset.Dy = InchToMM(1.44);
            //bracket.EndPointOffset.Dy = InchToMM(1.44);
            bracket.Position.DepthOffset = atDepth;

            bracket.Profile.ProfileString = bracketShape;
            bracket.Name = bracketShape;
            bracket.Material.MaterialString = "BUY-OUT";
            bracket.Class = "12";
            bracket.AssemblyNumber.Prefix = "";
            bracket.PartNumber.Prefix = "";

            bool isInserted = bracket.Insert();
            if (!isInserted)
            {
                MessageBox.Show("Bracket not inserted");
            }

        }
        private void DebugOutput(List<string> text)
        {
            string debugFilePath = @"C:\Users\WindowsPC\Desktop\WallRail_BracketDebug.txt";

            try
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\WindowsPC\Desktop");

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(debugFilePath, true)) // true = append
                {
                    writer.WriteLine("=================================================");
                    writer.WriteLine($"DEBUG LOG - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine("=================================================\n");

                    writer.WriteLine("\n");
                    for (int i = 0; i < text.Count; i++)
                    {
                        string p = text[i];
                        writer.WriteLine(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Debug error: {ex.Message}", "Error");
            }
        }
        public static void CopyBracketsAlongLine(Point bracketStartPoint, Point bracketEndPoint, string spacingCondition, double spacing, Vector directionVector, string alignmentCondition, string directionBox)
        {
            double workingLength = Tekla.Structures.Geometry3d.Distance.PointToPoint(bracketStartPoint, bracketEndPoint);

            // Calculate actual spacing and number of brackets
            double actualSpacing;
            int numberOfBrackets;

            if (spacingCondition == "max")
            {
                actualSpacing = calculateSpacing(workingLength, spacing);
                numberOfBrackets = (int)Math.Ceiling(workingLength / spacing);
            }
            else // "exact"
            {
                actualSpacing = spacing;
                numberOfBrackets = (int)Math.Floor(workingLength / spacing);
            }

            // Calculate starting offset based on alignment
            double startOffset = 0;

            if (alignmentCondition == "middle")
            {
                // Center the brackets - calculate leftover space and split it
                double totalBracketSpan = actualSpacing * (numberOfBrackets - 1);
                startOffset = (workingLength - totalBracketSpan) / 2.0;
            }
            else if (alignmentCondition == "end")
            {
                // Start from the end, work backwards
                double totalBracketSpan = actualSpacing * (numberOfBrackets - 1);
                startOffset = workingLength - totalBracketSpan;
            }
            // else alignmentCondition == "start", startOffset = 0 (default)

            // Normalize direction vector to ensure consistent scaling
            Vector normalizedDirection = new Vector(directionVector);
            normalizedDirection.Normalize();

            // Create brackets
            for (int i = 0; i < numberOfBrackets; i++)
            {
                // Calculate distance along the line for this bracket
                double distanceAlongLine = startOffset + (i * actualSpacing);

                // Create the bracket start point by moving from bracketStartPoint
                Point newBracketStart = MoveWithDirectionVector(bracketStartPoint, normalizedDirection, distanceAlongLine, false);

                // Create the bracket end point 3 inches away from start point along the same direction
                Point newBracketEnd = new Point();
                if (directionBox == "right")
                {
                    newBracketEnd = MoveWithDirectionVector(newBracketStart, normalizedDirection, InchToMM(3), false);
                }

                else
                {
                    newBracketEnd = MoveWithDirectionVector(newBracketStart, normalizedDirection, InchToMM(3), true);
                }

                // Create the bracket
                Brep copiedBracket = new Brep();
                copiedBracket.StartPoint = newBracketStart;
                copiedBracket.EndPoint = newBracketEnd;

                // Apply offsets
                //copiedBracket.StartPointOffset.Dz = -3.9574 * 25.4;
                //copiedBracket.EndPointOffset.Dz = -3.9574 * 25.4;
                //copiedBracket.StartPointOffset.Dy = 1.44 * 25.4;
                //copiedBracket.EndPointOffset.Dy = 1.44 * 25.4;
                //copiedBracket.Position.RotationOffset = 90;
                copiedBracket.Position.DepthOffset = atDepth;

                // Set properties
                copiedBracket.Profile.ProfileString = bracketShape;
                copiedBracket.Name = "WAGNER-RB 13251R";
                copiedBracket.Material.MaterialString = "BUY-OUT";
                copiedBracket.Class = "12";
                copiedBracket.AssemblyNumber.Prefix = "";
                copiedBracket.PartNumber.Prefix = "";


                // Insert bracket
                bool inserted = copiedBracket.Insert();
                if (!inserted)
                {
                    MessageBox.Show($"Error: Bracket {i + 1} not inserted at distance {distanceAlongLine:F2} mm");
                }
            }

            
        }
        public static double calculateSpacing(double length, double spacingBox)
        {
            double numberOfBrackets = Math.Ceiling(length / spacingBox);
            double spacing = length / numberOfBrackets;
            return spacing;
        }
        public static Point MoveWithDirectionVector(Point originPoint, Vector directionVector, double distance, bool invertDirection)
        {
            if (invertDirection) 
            {
                distance = -distance;
            }

            Point newPoint = new Point(originPoint + (directionVector * distance));
            return newPoint;
        }
        #endregion
    }
}
