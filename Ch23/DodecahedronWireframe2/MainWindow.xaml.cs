using System;
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

using System.Windows.Media.Media3D;

namespace DodecahedronWireframe2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // The camera.
        private PerspectiveCamera TheCamera = null;

        // The camera controller.
        private SphericalCameraController CameraController = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Define WPF objects.
            ModelVisual3D visual3d = new ModelVisual3D();
            Model3DGroup modelGroup = new Model3DGroup();
            visual3d.Content = modelGroup;
            mainViewport.Children.Add(visual3d);

            // Define the camera, lights, and model.
            DefineCamera(mainViewport);
            DefineLights(modelGroup);
            DefineModel(modelGroup);
        }

        // Define the camera.
        private void DefineCamera(Viewport3D viewport)
        {
            TheCamera = new PerspectiveCamera();
            TheCamera.FieldOfView = 60;
            CameraController = new SphericalCameraController
                (TheCamera, viewport, this, mainGrid, mainGrid);
        }

        // Define the lights.
        private void DefineLights(Model3DGroup group)
        {
            Color dark = Color.FromArgb(255, 96, 96, 96);

            group.Children.Add(new AmbientLight(dark));

            group.Children.Add(new DirectionalLight(dark, new Vector3D(0, -1, 0)));
            group.Children.Add(new DirectionalLight(dark, new Vector3D(1, -3, -2)));
            group.Children.Add(new DirectionalLight(dark, new Vector3D(-1, 3, 2)));
        }

        // Define the model.
        private void DefineModel(Model3DGroup group)
        {
            // Make a dodecahedron.
            MeshGeometry3D mesh1 = new MeshGeometry3D();
            mesh1.AddDodecahedron();
            group.Children.Add(mesh1.MakeModel(Brushes.LightGreen));

            // Make a wireframe for the dodecahedron.
            MeshGeometry3D mesh2 = new MeshGeometry3D();
            HashSet<Edge> edges = new HashSet<Edge>();
            double thickness = 0.05;
            mesh2.AddDodecahedron(edges, thickness);
            group.Children.Add(mesh2.MakeModel(Brushes.Green));
        }
    }
}
