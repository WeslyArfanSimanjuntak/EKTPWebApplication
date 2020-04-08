using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EKTPWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEKTPService" in both code and config file together.
    [ServiceContract]
    public interface IEKTPService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        Content CekNIK(string nik);
        [OperationContract]
        string StringCekNIK(string nik);
    }
    [DataContract]
    public class Content
    {
        [DataMember]
        public long NO_KK { get; set; }
        [DataMember]
        public long NIK { get; set; }
        [DataMember]
        public string NAMA_LGKP { get; set; }
        [DataMember]
        public string KAB_NAME { get; set; }
        [DataMember]
        public object NO_RW { get; set; }
        [DataMember]
        public string KEC_NAME { get; set; }
        [DataMember]
        public string JENIS_PKRJN { get; set; }
        [DataMember]
        public int NO_RT { get; set; }
        [DataMember]
        public int NO_KEL { get; set; }
        [DataMember]
        public string ALAMAT { get; set; }
        [DataMember]
        public int NO_KEC { get; set; }
        [DataMember]
        public string TMPT_LHR { get; set; }
        [DataMember]
        public string STATUS_KAWIN { get; set; }
        [DataMember]
        public int NO_PROP { get; set; }
        [DataMember]
        public string NAMA_LGKP_IBU { get; set; }
        [DataMember]
        public string PROP_NAME { get; set; }
        [DataMember]
        public int NO_KAB { get; set; }
        [DataMember]
        public string KEL_NAME { get; set; }
        [DataMember]
        public string JENIS_KLMIN { get; set; }
        [DataMember]
        public string TGL_LHR { get; set; }
    }

    public class RootObject
    {
        public List<Content> content { get; set; }
        public bool lastPage { get; set; }
        public int numberOfElements { get; set; }
        public object sort { get; set; }
        public int totalElements { get; set; }
        public bool firstPage { get; set; }
        public int number { get; set; }
        public int size { get; set; }
    }
}
