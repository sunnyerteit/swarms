﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for _gripperPage1.xaml
    /// </summary>
    public partial class _gripperPage1 : Page
    {
        Model3DGroup RA = new Model3DGroup();
        Model3D link1 = null;
        Model3D link2 = null;
        ModelVisual3D RoboticArm = new ModelVisual3D();

        //private const string MODEL_PATH1 = "C:\Users\sunnyi\Documents\Visual Studio 2017\Projects\Mai\Swarms\temp1\swarmsWpfTest\swarmsWpfTest\models\_base.STL";
        //private const string MODEL_PATH2 = "C:\Users\sunnyi\Documents\Visual Studio 2017\Projects\Mai\Swarms\temp1\swarmsWpfTest\swarmsWpfTest\models\_arm1.STL";
        private const string MODEL_PATH1 = "_base.STL";
        private const string MODEL_PATH2 = "_arm1.STL";
        private const string MODEL_PATH3 = "_arm2.STL";
        private const string MODEL_PATH4 = "_claw.STL";

        RotateTransform3D R = new RotateTransform3D();
        TranslateTransform3D T = new TranslateTransform3D();


        public _gripperPage1()
        {
            InitializeComponent();
            ModelVisual3D device3D = new ModelVisual3D();
            RoboticArm.Content = Initialize_Environment(MODEL_PATH1, MODEL_PATH2);
            // Add to view port
            viewPort3d.Children.Add(RoboticArm);
            viewPort3d.Camera.LookDirection = new Vector3D(0, 0, 47.218);
            viewPort3d.Camera.UpDirection = new Vector3D(0, 1, 0);
            viewPort3d.Camera.NearPlaneDistance = -1400;
        }

        private Model3DGroup Initialize_Environment(string model1, string model2)
        {
            try
            {
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);
                ModelImporter import = new ModelImporter();
                link1 = import.Load(model1);
                link2 = import.Load(model2);

                Transform3DGroup F1 = new Transform3DGroup();
                Transform3DGroup F2 = new Transform3DGroup();

                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0), new Point3D(0, 0, 0));
                F1.Children.Add(R);

                T = new TranslateTransform3D(0, 100, 0);
                R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0), new Point3D(0, 0, 0));
                F2.Children.Add(F1);
                F2.Children.Add(T);
                F2.Children.Add(R);

                link1.Transform = F1;
                link2.Transform = F2;


                RA.Children.Add(link1);
                RA.Children.Add(link2);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Error: " + e.StackTrace);

            }
            return RA;
        }
    }
}
