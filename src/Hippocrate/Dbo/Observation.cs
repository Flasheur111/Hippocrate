using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hippocrate.Dbo
{
    using System.Runtime.Serialization;

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Observation", Namespace = "http://schemas.datacontract.org/2004/07/Dbo")]
    public partial class Observation : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int BloodPressureField;

        private string CommentField;

        private System.DateTime DateField;

        private byte[][] PicturesField;

        private string[] PrescriptionField;

        private int WeightField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BloodPressure
        {
            get
            {
                return this.BloodPressureField;
            }
            set
            {
                this.BloodPressureField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comment
        {
            get
            {
                return this.CommentField;
            }
            set
            {
                this.CommentField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.DateField;
            }
            set
            {
                this.DateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[][] Pictures
        {
            get
            {
                return this.PicturesField;
            }
            set
            {
                this.PicturesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Prescription
        {
            get
            {
                return this.PrescriptionField;
            }
            set
            {
                this.PrescriptionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Weight
        {
            get
            {
                return this.WeightField;
            }
            set
            {
                this.WeightField = value;
            }
        }
    }
}
