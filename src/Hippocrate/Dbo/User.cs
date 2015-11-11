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
    [System.Runtime.Serialization.DataContractAttribute(Name = "User", Namespace = "http://schemas.datacontract.org/2004/07/Dbo")]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private bool ConnectedField;

        private string FirstnameField;

        private string LoginField;

        private string NameField;

        private byte[] PictureField;

        private string PwdField;

        private string RoleField;

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
        public bool Connected
        {
            get
            {
                return this.ConnectedField;
            }
            set
            {
                this.ConnectedField = value;
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
        public string Login
        {
            get
            {
                return this.LoginField;
            }
            set
            {
                this.LoginField = value;
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
        public byte[] Picture
        {
            get
            {
                return this.PictureField;
            }
            set
            {
                this.PictureField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pwd
        {
            get
            {
                return this.PwdField;
            }
            set
            {
                this.PwdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Role
        {
            get
            {
                return this.RoleField;
            }
            set
            {
                this.RoleField = value;
            }
        }
    }
}
