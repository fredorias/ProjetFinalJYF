
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.WCF
{
    [DataContract]
    public class QueryContract
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime? DataExpiryDate { get; set; }
        [DataMember]
        public DateTime? DataTimeStamp { get; set; }
        [DataMember]
        public List<PageContract> ListePages { get; set; }

    }

    [DataContract]
    public class PageContract
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public virtual QueryContract Query { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public List<SelectorContract> ListeSelectors { get; set; }

    }
    [DataContract]
    public class SelectorContract
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public virtual PageContract Page { get; set; }
        [DataMember]
        public string Value { get; set; }

    }
    [DataContract]
    public class ResultsHeaderContract
    {
        public ResultsHeaderContract()
        {

        }
        public ResultsHeaderContract(SelectorContract SC)
        {
            Id = Guid.NewGuid();
            QueryExecutionDate = DateTime.Now;
            Selector = SC;
        }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public virtual SelectorContract Selector { get; set; }
        [DataMember]
        public DateTime QueryExecutionDate { get; set; }
    }
    [DataContract]
    public class ResultsDetailContract
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public virtual ResultsHeaderContract ResultsHeader { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string CLEF { get; set; }
    }
}
