using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace CircleComponent
{
    public class CircleComponentInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {  
                return "CircleComponent";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("b08678c4-ca23-4096-8046-e9839ba4b8e8");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
