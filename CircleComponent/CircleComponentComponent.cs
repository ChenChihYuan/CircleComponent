using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace CircleComponent
{
    public class CircleComponentComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CircleComponentComponent()
          : base("CircleComponent", "CirPack",
              "This component will generate a lot of circles!",
              "Curve", "AutoGeneration")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddSurfaceParameter("rectangle","rect","The target rectangle", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Circles", "cirs", "The generated circles", GH_ParamAccess.item);
            pManager.AddTextParameter("Reverse", "R", "Reversed string", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare a variable for the input String
            
            

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetData(0, ref srf)) { return; }

            // If the retrieved data is Nothing, we need to abort.
            // We're also going to abort on a zero-length String.
            
            if (!srf.IsValid) { return; }
            

            // Convert the String to a character array.
            

            //
            int count = 0;
            int total = 10;
            int attempts = 0;
            List<Circle> circles = new List<Circle>();
            
            while(count < total)
            {
                Circle newC = new Circle();
                
                if(newC.IsValid)
                {
                    circles.Add(newC);
                    count++;
                }
                attempts++;
                if (attempts > 1000)
                {
                    noLoop();
                    break;
                }
            }

            // Reverse the array of character.
            System.Array.Reverse(chars);

            // Use the DA object to assign a new String to the first output parameter.
            DA.SetData(0, new string(chars));
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("75d07d5f-f961-4d40-9e3d-0114155e3cc5"); }
        }
    }

    public class Circle
    {
        double x;
        double y;
        double r;

        Circle(double x_, double y_)
        {
            x = x_;
            y = y_;

        }

    }
}
