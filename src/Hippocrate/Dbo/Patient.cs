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
    [System.Runtime.Serialization.DataContractAttribute(Name = "Patient", Namespace = "http://schemas.datacontract.org/2004/07/Dbo")]
    public partial class Patient : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private System.DateTime BirthdayField;

        private string FirstnameField;

        private int IdField;

        private string NameField;

        private Dbo.Observation[] ObservationsField;

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
        public System.DateTime Birthday
        {
            get
            {
                return this.BirthdayField;
            }
            set
            {
                this.BirthdayField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Firstname
        {
            get
            {
                return this.FirstnameField;
            }
            set
            {
                this.FirstnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Dbo.Observation[] Observations
        {
            get
            {
                return this.ObservationsField;
            }
            set
            {
                this.ObservationsField = value;
            }
        }
    }
}
